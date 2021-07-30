using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJCP.IO.Ports;

namespace ArduinoDebugger
{
    public partial class MainForm : Form
    {
        private static SerialPortStream? ComPort { get; set; }
        private static Dictionary<string, TreeNode> Nodes { get; } = new Dictionary<string, TreeNode>();

        public MainForm()
        {
            InitializeComponent();
        }

        private static DateTime lastTick = DateTime.Now;

        private void MoveMouse(byte x, byte y, byte b = 255)
        {
            var buffer = new[] { x, y, b };
            MultiThreadCallback(lblAthenaCmd, t => t.Text = $@"Command: {buffer[0].ToString("X2")} {buffer[1].ToString("X2")} {buffer[2].ToString("X2")}");

            if (ComPort == null) return;
            if (ComPort.IsDisposed) return;
            if (!ComPort.IsOpen) return;

            if (lastTick.Subtract(DateTime.Now).TotalMilliseconds > 4) return;
            lastTick = DateTime.Now;

            ComPort.Write(buffer, 0, buffer.Length);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Enabled = false;

                if (ComPort != null && ComPort.IsOpen)
                {
                    ComPort.Close();
                    ComPort.Dispose();
                    ComPort = null;
                    UpdateStatus("disconnected");
                    btnConnect.Text = "Connect";
                }
                else
                {
                    if (comboPorts.SelectedItem == null) return;
                    var port = comboPorts.SelectedItem.ToString();
                    if (!string.IsNullOrEmpty(port))
                    {
                        ComPort = new SerialPortStream(port, 115200);

                        if (ComPort == null) throw new ApplicationException("Unable to instantiate COM Port");

                        ComPort.DataReceived += (sender, args) =>
                        {
                            if (sender == null || args == null) return;

                            MultiThreadCallback(Nodes["arduino"], t =>
                            {
                                try
                                {
                                    while (ComPort.BytesToRead > 0)
                                    {
                                        var signature = (char)ComPort.ReadChar();
                                        var bufferLen = (int)ComPort.ReadByte();

                                        var buffer = new byte[bufferLen];
                                        ComPort.Read(buffer, 0, buffer.Length);

                                        string signatureParsed = "Unknown";

                                        switch (signature)
                                        {
                                            case 'I':
                                                signatureParsed = "Internal";
                                                break;
                                            case 'E':
                                                signatureParsed = "External";
                                                break;
                                        }

                                        lblLastBufferCommand.Text = @$"Type: {signatureParsed} - Length: {bufferLen}{Environment.NewLine}Command: {buffer[0].ToString("X2")} {buffer[1].ToString("X2")} {buffer[2].ToString("X2")} {buffer[3].ToString("X2")}";
                                    }
                                }
                                catch { }
                            });
                        };

                        ComPort.Open();
                        UpdateStatus("connected");
                        btnConnect.Text = "Disconnect";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ComPort != null && ComPort.IsOpen)
                {
                    ComPort.Close();
                    ComPort.Dispose();
                    btnConnect.Text = "Connect";
                }

                MessageBox.Show(ex.Message, "[Connection] Critical Failure", MessageBoxButtons.OK);
            }
            finally
            {
                Enabled = true;
            }
        }

        private void RefreshPortList()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(RefreshPortList));
            }
            else
            {
                comboPorts.Items.Clear();
                comboPorts.Items.AddRange(SerialPortStream.GetPortNames());
                if (comboPorts.Items.Count > 0)
                    comboPorts.SelectedIndex = 0;
            }
        }

        private void UpdateStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => UpdateStatus(status)));
            }
            else
            {
                lblStatus.Text = "Status: " + status;
            }
        }

        private void MultiThreadCallback<T>(T node, Action<T> callback)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => MultiThreadCallback(node, callback)));
                }
                else
                {
                    callback(node);
                }
            }
            catch { }
        }

        private bool IsKeyDown(int val) => (Native.GetKeyState(val) & 0x8000) != 0;

        private int IsRunning = 0;

        private void FormLoad(object sender, EventArgs e)
        {
            Interlocked.Exchange(ref IsRunning, 1);
            RefreshPortList();
            UpdateStatus("disconnected");

            Application.ApplicationExit += Application_ApplicationExit;

            Nodes["arduino"] = new TreeNode("Arduino");
            Nodes["mouse"] = new TreeNode("Mouse");

            try
            {
                if (Nodes != null && dataTreeView != null && dataTreeView.Nodes != null)
                    dataTreeView.Nodes.AddRange(Nodes.Values.ToArray());
            }
            catch { }

            Task.Run(() =>
            {
                while (IsRunning == 1)
                {
                    if (recoilEnabled.Checked)
                    {
                        MoveMouse(1, 1, 0);
                    }

                    Thread.Sleep(1);
                }
            });

            Task.Run(() =>
            {
                var LMB = new TreeNode("LMB: false");
                var RMB = new TreeNode("RMB: false");
                var XB1 = new TreeNode("XB1: false");
                var XB2 = new TreeNode("XB2: false");
                var SCRL = new TreeNode("SCRL: false");

                MultiThreadCallback(Nodes!["mouse"], t => t.Nodes.AddRange(new[] { LMB, RMB, XB1, XB2, SCRL }));

                var ActionValidate = new Action<int, string, TreeNode, Panel>((key, name, node, panel) => {
                    var state = IsKeyDown(key);
                    MultiThreadCallback(node, t => { t.Text = $"{name}: {(state ? "true" : "false")}"; });
                    MultiThreadCallback(panel, t => t.BackColor = state ? System.Drawing.Color.ForestGreen : System.Drawing.Color.IndianRed);
                });

                while (IsRunning == 1)
                {
                    ActionValidate(1, nameof(LMB), LMB, MLeftBtn);
                    ActionValidate(2, nameof(RMB), RMB, MRightBtn);
                    ActionValidate(5, nameof(XB1), XB1, MX1Btn);
                    ActionValidate(6, nameof(XB2), XB2, MX2Btn);
                    ActionValidate(6, nameof(SCRL), SCRL, MScrollBtn);

                    Thread.Sleep(50);
                }
            });

            Task.Run(() => {
                var server = new NamedPipeServerStream(@"ArduinoDebugger", PipeDirection.InOut, 1);
                var lastHeartbeat = DateTime.Now;

                while (IsRunning == 1)
                {
                    Thread.Sleep(1);
                    MultiThreadCallback(lblAthenaStatus, t => t.Text = "Pipe: disconnected");
                    server.WaitForConnection();
                    var stream = new StreamReader(server);
                    MultiThreadCallback(lblAthenaStatus, t => t.Text = "Pipe: connected");

                    while (server.IsConnected)
                    {
                        Thread.Sleep(1);
                        if (lastHeartbeat.Subtract(DateTime.Now).Seconds > 2) server.Disconnect();

                        if (stream.Peek() == 0xFF)
                        {
                            lastHeartbeat = DateTime.Now;
                            stream.Read();
                        }

                        if (stream.Peek() != -1)
                        {
                            var cBuffer = new char[3];
                            stream.Read(cBuffer, 0, cBuffer.Length);

                            byte[] buffer = new[] { (byte)cBuffer[0], (byte)cBuffer[1], (byte)cBuffer[2] };
                            MoveMouse(buffer[0], buffer[1]);
                            server.WaitForPipeDrain();
                        }
                    }

                    stream.Dispose();
                    stream = null;
                    server.Dispose();
                    server = new NamedPipeServerStream(@"ArduinoDebugger", PipeDirection.InOut, 1);
                }

                server.Dispose();
            });
        }

        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            Interlocked.Exchange(ref IsRunning, 0);
        }

        private void btnRefreshList_Click(object sender, EventArgs e) => RefreshPortList();

        private void btnClearList_Click(object sender, EventArgs e) => MultiThreadCallback(Nodes["arduino"], t => t.Nodes.Clear());

        private void btnExportList_Click(object sender, EventArgs e)
        {
            MultiThreadCallback(Nodes["arduino"], t =>
            {
                var sfd = new SaveFileDialog();
                sfd.Title = "Save List to File";
                sfd.Filter = "CSV File | *.csv";
                sfd.AddExtension = true;
                sfd.FileName = "export.csv";
                sfd.InitialDirectory = System.IO.Path.GetFullPath(".");

                using var fs = sfd.OpenFile();
                var sb = new StringBuilder();

                foreach (TreeNode node in t.Nodes)
                {
                    sb.AppendLine(node.Text);
                }

                fs.Write(Encoding.UTF8.GetBytes(sb.ToString()));
                fs.Close();
            });
        }
    }
}
