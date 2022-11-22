using NModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
using System.Diagnostics;
using System.IO;
using Timer = System.Windows.Forms.Timer;
using testAll;

namespace AutomaticSystem
{
    public partial class frm_ControlSystem : BasicForm
    {
        ModbusClient plc1;
        public frm_ControlSystem()
        {
            InitializeComponent();
            plc1 = new ModbusClient();
        }

        private void frm_ControlSystem_Load(object sender, EventArgs e)
        {
            this.Size = new Size(gbSetting.Width + gbState.Width + 65, 676);
            timerall.Enabled = true;
            txtIP.Select();
            backgroundWorker1.WorkerReportsProgress = true;
        }
        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string[] vProjectname = new string[0];
                if (plc1.Connected == false)
                {
                    plc1.IPAddress = txtIP.Text;
                    plc1.Port = Convert.ToInt32("502");
                    plc1.Connect();

                    btnConnect.Text = "Disconnect";
                    lblconnectMsg.Text = "Connected";
                    lblconnectMsg.BackColor = Color.LimeGreen;
                    vProjectname = ConvertRegistersToString(plc1.ReadInputRegisters(7701, 30), 0, 30).Split('\0');
                    tlblProjects.Text = vProjectname[0];  //讀取當前專案名稱 
                    txtPointProject.Focus();
                }
                else
                {
                    plc1.Disconnect();
                    btnConnect.Text = "Connect";
                    lblconnectMsg.Text = "Disconnect"; 
                    lblconnectMsg.BackColor = Color.Red;
                    txtIP.Focus();
                    
                    if (btnContorl.Text == "<")
                    {
                        btnContorl.Text = ">";
                        this.Size = new Size(this.Width - plControl.Width, Height);
                    }
                }
                GetContorlPress();
            }
            catch (Exception ex)
            {
                lblconnectMsg.Text = "Disconnect";
                lblconnectMsg.BackColor = Color.Red;
                Clear();
                txtIP.Focus();
                MsgBox.Show("Not found！" + ex.Message);
            }
        }

        private void Clear()
        {
            tlblProjects.Text = "Current Project";
            lblHmi.Text = "None";
            lblRobotModel.Text = "None";
            lblControlBoxNumber.Text = "None";
            lblStatus.Text = "None";
            txtLight.Text = "";
            lblError.Text = "None";
            lblReset.Text = "None";
            txtPointProject.Text = "";
            plSe2.Enabled = false;
        }

        #region Byte[]轉換String
        public string ConvertRegistersToString(int[] registers, int offset, int stringLength)
        {
            byte[] result = new byte[stringLength];
            byte[] registerResult = new byte[2];

            for (int i = 0; i < stringLength / 2; i++)
            {
                registerResult = BitConverter.GetBytes(registers[offset + i]);
                result[i * 2] = registerResult[1];
                result[i * 2 + 1] = registerResult[0];
            }
            return System.Text.Encoding.Default.GetString(result);
        }

        public int[] ConvertStringToRegisters(string stringToConvert)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(stringToConvert);
            int[] returnarray = new int[stringToConvert.Length / 2 + stringToConvert.Length % 2];
            for (int i = 0; i < returnarray.Length; i++)
            {
                returnarray[i] = array[i * 2];
                if (i * 2 + 1 < array.Length)
                {
                    returnarray[i] = array[i * 2 + 1] | ((int)returnarray[i] << 8);
                }
                else if (i * 2 + 1 == array.Length)
                {
                    returnarray[i] = 0 | ((int)returnarray[i] << 8);
                }
            }
            return returnarray;
        }
        #endregion

        #region Control Robot
        private void btnPlay_Click(object sender, EventArgs e)
        {
            plc1.WriteSingleCoil(7104, true);   //Robot Stick-> Play
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            plc1.WriteSingleCoil(7105, true);   //Robot Stick-> Stop
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            plc1.WriteSingleCoil(7108, true);   //Robot Stick-> Pause
        }
        private void btnAddition_Click(object sender, EventArgs e)
        {
            plc1.WriteSingleCoil(7106, true);   //Robot Stick-> +
        }
        private void btnSubtraction_Click(object sender, EventArgs e)
        {
            plc1.WriteSingleCoil(7107, true);   //Robot Stick-> -
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtDo.Text.Length == 0) { MsgBox.Show("請輸入【0 ~ 15】ControlBox DO Address！"); txtDo.Focus(); return; }
            plc1.WriteSingleCoil(Convert.ToInt32(txtDo.Text), true);
            lblReset.Text = "Enable";
            lblReset.Update();
            Thread.Sleep(2000);
            plc1.WriteSingleCoil(Convert.ToInt32(txtDo.Text), false);
            lblReset.Text = "Done";
            lblReset.Update();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            string[] vPoint = new string[3];
            vPoint = txtPointProject.Text.Split(',');
            if (txtDo.Text.Length == 0) { MsgBox.Show("請輸入【0 ~ 15】ControlBox DO Address！"); txtDo.Focus(); return; }
            panel6.Visible = true;
            panel6.Location = new Point(2,-4);
            panel6.BringToFront();
            this.Size = new Size(panel6.Width + 50, this.Height - 160);
            btnContorl.Enabled = false;
        }
        
        private void btnChanges_Click(object sender, EventArgs e)
        {
            ////panel2.Visible = false;
            //try
            //{
            //    if (plc1.ReadDiscreteInputs(7201, 1)[0].ToString() == "True") { btnReset.PerformClick(); Thread.Sleep(1000); }
            //    int vAxis = 0, first = 0;
            //    string[] vPoint = new string[3];
            //    panel2.Visible = false;
            //    lblDisplay.Visible = true;
            //    this.Size = new Size(gbSetting.Width + gbState.Width + plControl.Width + 60, 676);
            //    btnRefresh_Click(null, null);

            //    string[] vProjects = new string[0];
            //    vPoint = txtPointProject.Text.Split(',');
            //    if (txtChange.Text.Length != 0) { vProjects = txtChange.Text.Replace("\r\n", "").Split(','); frm_Report.K1K2 = vProjects;} 
            //    else { MsgBox.Show("請輸入專案名稱，並以逗號區分，不得為空白！"); txtChange.Focus(); return; }
            //    for (int a = 0; a <= vPoint.Length - 1; a++)
            //    {
            //        if ((vPoint[a].ToUpper().Contains("X") && vProjects.Count(s => s.ToUpperInvariant().Contains("X")) < 1)
            //            || (vPoint[a].ToUpper().Contains("Y") && vProjects.Count(s => s.ToUpperInvariant().Contains("Y")) < 1)
            //            || (vPoint[a].ToUpper().Contains("Z") && vProjects.Count(s => s.ToUpperInvariant().Contains("Z")) < 1))
            //        { continue; }

            //        plc1.WriteMultipleRegisters(7701, ConvertStringToRegisters(vPoint[a]));
            //        Thread.Sleep(500);
            //        tlblProjects.Text = vPoint[a];
            //        Application.DoEvents();
            //        lblDisplay.Text = "回打擊位置";
            //        btnPlay.PerformClick();
            //        MsgBox.Show("請先調整位置，並按確認繼續執行！", "警告", enMessageButton.OK, enMessageType.Warning,5);

            //        if (a == 0) { first = 0; vAxis = vProjects.Count(s => s.ToUpperInvariant().Contains("X")); }
            //        else if (a == 1) { first = vAxis; vAxis = vProjects.Count(s => s.ToUpperInvariant().Contains("Y")); }
            //        else { first = vAxis + vProjects.Count(s => s.ToUpperInvariant().Contains("X")); vAxis = vProjects.Count(s => s.ToUpperInvariant().Contains("Z")); }

            //        for (int j = first; j <= first + vAxis - 1; j++)
            //        {
            //            plc1.WriteMultipleRegisters(7701, ConvertStringToRegisters(vProjects[j]));
            //            Thread.Sleep(500);
            //            tlblProjects.Text = vProjects[j];
            //            Application.DoEvents();
            //            for (int k = 1; k <= 3; k++)
            //            {
            //                lblDisplay.Text = "執行中 " + k + "/3";
            //                lblDisplay.Update();
            //                btnPlay.PerformClick();

            //                if (vProjects[j].Contains("60") || vProjects[j].Contains("75")) { Thread.Sleep(20000); }
            //                else { Thread.Sleep(15000); }

            //                if (k < 3)
            //                {
            //                    if (plc1.ReadDiscreteInputs(7201, 1)[0].ToString() == "True")
            //                    {
            //                        btnReset.PerformClick();
            //                        Thread.Sleep(1000);
            //                    }
            //                }
            //            }

            //            if (j < first + vAxis - 1)
            //            {
            //                if (MsgBox.Show("請更換Sensor！", "警告", enMessageButton.OKCancel, enMessageType.Warning) == DialogResult.OK)
            //                {
            //                    btnReset.PerformClick();
            //                    Thread.Sleep(1000);
            //                    plc1.WriteMultipleRegisters(7701, ConvertStringToRegisters(vPoint[a]));
            //                    lblDisplay.Text = "回打擊位置";
            //                    btnPlay.PerformClick();
            //                    MsgBox.Show("調整位置後，按確認繼續執行...", "警告", enMessageButton.OK, enMessageType.Warning);
            //                    Thread.Sleep(2000);
            //                }
            //                else { btnStop.PerformClick(); btnCancel.PerformClick(); lblDisplay.Visible = false; return; };
            //            }
            //        }
            //        if (a == 0 && vPoint[a] != "0" && txtChange.Text.Contains("Y")) { MsgBox.Show("X-Axis已測試完畢，請將手臂附近清出空間，\n並按確認執行Y-Axis！", "警告", enMessageButton.OK, enMessageType.Warning); }
            //        else if (a == 1 && vPoint[a] != "0" && txtChange.Text.Contains("Z")) { MsgBox.Show("Y-Axis已測試完畢，請將手臂附近清出空間，\n並更改治具後按確認執行Z-Axis！", "警告", enMessageButton.OK, enMessageType.Warning); }
            //        btnReset.PerformClick();
            //    }

            //    lblDisplay.Text = "執行完成";
            //    btnContorl.Enabled = true;
            //    checkboxD();
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.Show(ex.Message);
            //}
            ////plProgressBar.Location = new Point(panel3.Left + 100, panel3.Top + 250);
            plProgressBar.Location = new Point(panel2.Width / 6, (panel2.Height / 2) - 60);
            backgroundWorker1.RunWorkerAsync(); //啟動執行DoWork
        }
        #endregion

        #region backgroundWorker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            btnContorl_Click(null, null);
            //this.Size = new Size(gbSetting.Width + gbState.Width + plControl.Width + 60, 676);
            
            try
            {
                if (plc1.ReadDiscreteInputs(7201, 1)[0].ToString() == "True") { btnReset.PerformClick(); Thread.Sleep(1000); }
                int vAxis = 0, first = 0;
                string[] vPoint = new string[3];
                panel6.Visible = false;
                lblDisplay.Visible = true;
                this.Size = new Size(gbSetting.Width + gbState.Width + 65, 676);
                btnRefresh_Click(null, null);

                string[] vProjects = new string[0];
                vPoint = txtPointProject.Text.Split(',');
                if (txtChange.Text.Length != 0) { vProjects = txtChange.Text.Replace("\r\n", "").Split(','); frm_Report.K1K2 = vProjects; }
                else { MsgBox.Show("請輸入專案名稱，並以逗號區分，不得為空白！"); txtChange.Focus(); return; }
                for (int a = 0; a <= vPoint.Length - 1; a++)
                {
                    if ((vPoint[a].ToUpper().Contains("X") && vProjects.Count(s => s.ToUpperInvariant().Contains("X")) < 1)
                        || (vPoint[a].ToUpper().Contains("Y") && vProjects.Count(s => s.ToUpperInvariant().Contains("Y")) < 1)
                        || (vPoint[a].ToUpper().Contains("Z") && vProjects.Count(s => s.ToUpperInvariant().Contains("Z")) < 1))
                    { continue; }

                    plc1.WriteMultipleRegisters(7701, ConvertStringToRegisters(vPoint[a]));
                    Thread.Sleep(500);
                    tlblProjects.Text = vPoint[a];
                    Application.DoEvents();
                    lblDisplay.Text = "回打擊位置";
                    btnPlay.PerformClick();
                    MsgBox.Show("請先調整位置，並按確認繼續執行！", "警告", enMessageButton.OK, enMessageType.Warning, 5);

                    if (a == 0) { first = 0; vAxis = vProjects.Count(s => s.ToUpperInvariant().Contains("X")); }
                    else if (a == 1) { first = vAxis; vAxis = vProjects.Count(s => s.ToUpperInvariant().Contains("Y")); }
                    else { first = vAxis + vProjects.Count(s => s.ToUpperInvariant().Contains("X")); vAxis = vProjects.Count(s => s.ToUpperInvariant().Contains("Z")); }

                    for (int j = first; j <= first + vAxis - 1; j++)
                    {
                        plc1.WriteMultipleRegisters(7701, ConvertStringToRegisters(vProjects[j]));
                        Thread.Sleep(500);
                        tlblProjects.Text = vProjects[j];
                        Application.DoEvents();
                        for (int k = 1; k <= 3; k++)
                        {
                            lblDisplay.Text = "執行中 " + k + "/3";
                            lblDisplay.Update();
                            btnPlay.PerformClick();

                            if (vProjects[j].Contains("60") || vProjects[j].Contains("75")) { Thread.Sleep(20000); }
                            else { Thread.Sleep(20000); }

                            if (k < 3)
                            {
                                if (plc1.ReadDiscreteInputs(7201, 1)[0].ToString() == "True")
                                {
                                    btnReset.PerformClick();
                                    Thread.Sleep(1000);
                                }
                            }
                        }

                        if (j < first + vAxis - 1)
                        {
                            if (MsgBox.Show("請更換Sensor！", "警告", enMessageButton.OKCancel, enMessageType.Warning) == DialogResult.OK)
                            {
                                btnReset.PerformClick();
                                Thread.Sleep(1000);
                                plc1.WriteMultipleRegisters(7701, ConvertStringToRegisters(vPoint[a]));
                                lblDisplay.Text = "回打擊位置";
                                btnPlay.PerformClick();
                                MsgBox.Show("調整位置後，按確認繼續執行...", "警告", enMessageButton.OK, enMessageType.Warning);
                                Thread.Sleep(2000);
                            }
                            else { btnStop.PerformClick(); btnCancel.PerformClick(); lblDisplay.Visible = false; return; };
                        }
                    }
                    if (a == 0 && vPoint[a] != "0" && txtChange.Text.Contains("Y")) { MsgBox.Show("X-Axis已測試完畢，請將手臂附近清出空間，\n並按確認執行Y-Axis！", "警告", enMessageButton.OK, enMessageType.Warning); backgroundWorker1.ReportProgress(a + 1 * 33); }
                    else if (a == 1 && vPoint[a] != "0" && txtChange.Text.Contains("Z")) { MsgBox.Show("Y-Axis已測試完畢，請將手臂附近清出空間，\n並更改治具後按確認執行Z-Axis！", "警告", enMessageButton.OK, enMessageType.Warning); backgroundWorker1.ReportProgress(a + 1 * 33); }
                    btnReset.PerformClick();
                }
                backgroundWorker1.ReportProgress(100);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblbgker.Text = "已完成：" + progressBar1.Value + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblDisplay.Text = String.Empty;
            btnDone.Visible = true;
            btnDone.Location = new Point(progressBar1.Right - 77, progressBar1.Height + 55);
            btnContorl.Enabled = true;
            checkboxD();
        }
        #endregion

        #region Robot Status All
        private void Status()
        {
            if (plc1.Connected == true)
            {
                //ProjectStatus
                bool vRun, vEdit, vPause;
                vEdit = plc1.ReadDiscreteInputs(7203, 1)[0];
                vPause = plc1.ReadDiscreteInputs(7204, 1)[0];
                vRun = plc1.ReadDiscreteInputs(7202, 1)[0];

                if (vPause == true) { lblStatus.Text = "Pause"; }
                else if (vEdit == true) { lblStatus.Text = "Editing"; }
                else if (vRun == true) { lblStatus.Text = "Running"; }
                else { lblStatus.Text = "STOP"; }

                //RobotLight
                string type = plc1.ReadInputRegisters(7332, 1)[0].ToString();
                switch (type)
                {
                    case "0":
                        txtLight.Text = "Light off, when robot power off.";
                        break;
                    case "1":
                        txtLight.Text = "Solid Red, fatal error.";
                        break;
                    case "2":
                        txtLight.Text = "Flashing Red, Robot is initializing.";
                        break;
                    case "3":
                        txtLight.Text = "Solid Green, standby in Manual Mode.";
                        break;
                    case "4":
                        txtLight.Text = "Flashing Green, in Manual Mode.";
                        break;
                    case "5":
                        txtLight.Text = "Alternating Green&Red, Manual Mode error.";
                        break;
                    case "6":
                        txtLight.Text = "Alternating Yellow&Green, in Manual Mode & Recovery mode.";
                        break;
                    case "7":
                        txtLight.Text = "Alternating Purple&Green, in Manual Mode (Human Machine Safety Settings trigger).";
                        break;
                    case "8":
                        txtLight.Text = "Alternating Blue&Green, in Manual Mode & Maintenance mode.";
                        break;
                    case "9":
                        txtLight.Text = "Solid White, standby in Auto Mode.";
                        break;
                    case "10":
                        txtLight.Text = "Flashing White, in Auto Mode.";
                        break;
                    case "11":
                        txtLight.Text = "Alternating White&Red, Auto Mode error.";
                        break;
                    case "12":
                        txtLight.Text = "Alternating Yellow&White, in Auto Mode & Recovery mode.";
                        break;
                    case "13":
                        txtLight.Text = "Alternating Purple&White, in Auto Mode (Human Machine Safety Settings trigger).";
                        break;
                    case "14":
                        txtLight.Text = "Alternating Blue&White, in Auto Mode & Maintenance mode.";
                        break;
                }

                //HMI version
                lblHmi.Text = ConvertRegistersToString(plc1.ReadInputRegisters(7308, 10), 0, 10);
                frm_Report.HmiVersion = lblHmi.Text;

                //ControlBox Serial Number
                lblControlBoxNumber.Text = ConvertRegistersToString(plc1.ReadInputRegisters(7561, 10), 0, 10);

                //RobotModel
                lblRobotModel.Text = ConvertRegistersToString(plc1.ReadInputRegisters(7571, 10), 0, 10);

                //Error
                lblError.Text = plc1.ReadDiscreteInputs(7201, 1)[0].ToString();
            }
        }
        #endregion

        #region Socket連線方式
        public Socket _socketCliect;
        public Socket newclient;
        public bool Connected;
        public Thread myThread;
        //public delegate void MyInvoke(string str);
        //private static IModbusSerialMaster master;
        public void Connect()
        {
            
            string ipadd = txtIP.Text.Trim();                      //將伺服器IP地址存放在字串 ipadd中
            int port = 502;//Convert.ToInt32(textBox2.Text.Trim());   //將埠號強制為32位整型，存放在port中

            //建立一個連接 
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipadd), port);
            newclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            //將IP遠端伺服器地址相連
            try
            {
                newclient.Connect(ie);
                btnConnect.Enabled = false;    //使連線按鈕變無法點選
                Connected = true;
                lblconnectMsg.Text = "連線成功！";


            }
            catch (SocketException e)
            {
                MsgBox.Show("連線伺服器失敗  " + e.Message);
                return;
            }

            //ThreadStart ReceiveMsg = null;
            //ThreadStart myThreaddelegate = new ThreadStart(ReceiveMsg);
            //myThread = new Thread(myThreaddelegate);
            //myThread.Start();
            //tmSend.Enabled = true;  //增加定時傳送需要將此功能開啟
        }
        #endregion

        private void PointProjects()
        {
            //顯示Collision point
            txtRead();
            string[] sX, sY, sZ;
            sX = myList[0].Replace("X-Axis|", "").Split(',');
            sY = myList[1].Replace("Y-Axis|", "").Split(',');
            sZ = myList[2].Replace("Z-Axis|", "").Split(',');

            if (sX.Length == 9 && sY.Length == 9 && sZ.Length == 9) { txtPointProject.Text = sX[8] + "," + sY[8] + "," + sZ[8]; }
            else { txtPointProject.Text = "No Projects"; }
        }

        private void btnContorl_Click(object sender, EventArgs e)
        {
            int width = this.Size.Width;
            int Height = this.Size.Height;

            if (btnContorl.Text == ">")
            {
                btnContorl.Text = "<"; 
                this.Size = new Size(width + plControl.Width + 10, Height);
            }
            else
            {
                btnContorl.Text = ">";
                this.Size = new Size(width - plControl.Width - 10, Height);
            }
            GetContorlPress();
            txtDo.Focus();
        }
        
        private void GetContorlPress()
        {
            if (plc1.Connected)
            {
                btnPlay.Enabled = true;
                btnStop.Enabled = true;
                btnPause.Enabled = true;
                btnSubtraction.Enabled = true;
                btnAddition.Enabled = true;
                btnReset.Enabled = true;
                btnStart.Enabled = true;
                txtDo.Enabled = true;
                txtIP.Enabled = false;
                plSe2.Enabled = true;
                btnContorl.Enabled = true;
                lblControl.BackColor = Color.LimeGreen;
                Status();
                PointProjects();
            }
            else
            {
                btnPlay.Enabled = false;
                btnStop.Enabled = false;
                btnPause.Enabled = false;
                btnSubtraction.Enabled = false;
                btnAddition.Enabled = false;
                btnReset.Enabled = false;
                btnStart.Enabled = false;
                txtDo.Enabled = false;
                txtIP.Enabled = true;
                btnContorl.Enabled = false;
                lblControl.BackColor = Color.Red;
                Clear();
            }
        }

        private void timerall_Tick(object sender, EventArgs e)
        {
            timerall.Interval = 100;
            if (plc1.Connected) { Status(); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            txtChange.Text = "";
            this.Size = new Size(gbSetting.Width + gbState.Width + plControl.Width + 60, 676);
            btnContorl.Enabled = true;
            checkboxD();
        }

        #region TextBox Focus顏色
        private void TextBoxE_Enter(object sender, EventArgs e)
        {
            TextBox Tb = (TextBox)sender;
            switch (Tb.Name)
            {
                case "txtIP":
                    txtIP.BackColor = Color.PaleGreen;
                    break;
                case "txtPointProject":
                    txtPointProject.BackColor = Color.PaleGreen;
                    break;
                case "txtDo":
                    txtDo.BackColor = Color.PaleGreen;
                    break;
            }
        }

        private void TextBoxL_Leave(object sender, EventArgs e)
        {
            TextBox Tb = (TextBox)sender;
            switch (Tb.Name)
            {
                case "txtIP":
                    txtIP.BackColor = Color.White;
                    break;
                case "txtPointProject":
                    txtPointProject.BackColor = Color.White;
                    string[] vPoint = new string[0];
                    vPoint = txtPointProject.Text.Split(',');

                    break;
                case "txtDo":
                    txtDo.BackColor = Color.White;
                    break;
            }
        }
        #endregion

        #region Edit & Setting
        public static List<string> myList = new List<string>();
        public List<string> txtRead()
        {
            string path = Directory.GetCurrentDirectory();
            foreach (string fname in Directory.GetFiles(path))
            {
                if (Path.GetFileNameWithoutExtension(fname) == "Projects" && Path.GetExtension(fname) == ".txt")
                {
                    string line;
                    myList.Clear();  //做完一次就清除

                    // 一次讀取一行
                    StreamReader file = new StreamReader(fname);
                    while ((line = file.ReadLine()) != null)
                    {
                        myList.Add(line.Trim());
                    }
                    file.Close();
                }
            }
            return myList;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            plEditing.Visible = true;
            btnChanges.Enabled = false;
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            txtRead();
            txtX_Axis.Text = myList[0].Replace("X-Axis|","");
            txtY_Axis.Text = myList[1].Replace("Y-Axis|","");
            txtZ_Axis.Text = myList[2].Replace("Z-Axis|","");
            plEditing.Location = new Point(txtChange.Location.X + 194, txtChange.Location.Y + 30);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string Str = "";
            Str += "X-Axis|" + txtX_Axis.Text + "\r\n";
            Str += "Y-Axis|" + txtY_Axis.Text + "\r\n";
            Str += "Z-Axis|" + txtZ_Axis.Text + "\r\n";
            File.WriteAllText("Projects.txt",Str);
            plEditing.Visible = false;
            MsgBox.Show("更改完成！", "Done", enMessageButton.OK);
            checkboxD();
            PointProjects();

            btnChanges.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            plEditing.Visible = false;
            txtX_Axis.Text = "";
            txtY_Axis.Text = "";
            txtZ_Axis.Text = "";
            checkboxD();

            btnChanges.Enabled = true;
            btnCancel.Enabled = true;
            btnEdit.Enabled = true;
        }
        #endregion

        #region CheckBox
        private void cbox_CheckedChanged(object sender, EventArgs e)
        {
            txtRead();
            string[] StrX,StrY,StrZ;

            if (myList.Count == 3)
            {
                StrX = myList[0].Replace("X-Axis|", "").Split(',');
                StrY = myList[1].Replace("Y-Axis|", "").Split(',');
                StrZ = myList[2].Replace("Z-Axis|", "").Split(',');

                if (StrX.Length != 9) { MsgBox.Show("X-Axis 數量有誤，請重新確認！"); txtX_Axis.Focus(); return; }
                else if (StrY.Length != 9) { MsgBox.Show("Y-Axis 數量有誤，請重新確認！"); txtY_Axis.Focus(); return; }
                else if (StrZ.Length != 9) { MsgBox.Show("Z-Axis 數量有誤，請重新確認！"); txtZ_Axis.Focus(); return; }
            }
            else { MsgBox.Show("Projects文件有問題", "警告", enMessageButton.OK, enMessageType.Warning); plSetting.Focus(); return; }

            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                switch (cb.Name)
                {
                    case "cb10x":
                        txtChange.Text += StrX[0] + ",\r\n";
                        break;
                    case "cb25x":
                        txtChange.Text += StrX[1] + ",\r\n";
                        break;
                    case "cb30x":
                        txtChange.Text += StrX[2] + ",\r\n";
                        break;
                    case "cb35x":
                        txtChange.Text += StrX[3] + ",\r\n";
                        break;
                    case "cb40x":
                        txtChange.Text += StrX[4] + ",\r\n";
                        break;
                    case "cb50x":
                        txtChange.Text += StrX[5] + ",\r\n";
                        break;
                    case "cb60x":
                        txtChange.Text += StrX[6] + ",\r\n";
                        break;
                    case "cb75x":
                        txtChange.Text += StrX[7] + ",\r\n";
                        break;
                    case "cb10y":
                        txtChange.Text += StrY[0] + ",\r\n";
                        break;
                    case "cb25y":
                        txtChange.Text += StrY[1] + ",\r\n";
                        break;
                    case "cb30y":
                        txtChange.Text += StrY[2] + ",\r\n";
                        break;
                    case "cb35y":
                        txtChange.Text += StrY[3] + ",\r\n";
                        break;
                    case "cb40y":
                        txtChange.Text += StrY[4] + ",\r\n";
                        break;
                    case "cb50y":
                        txtChange.Text += StrY[5] + ",\r\n";
                        break;
                    case "cb60y":
                        txtChange.Text += StrY[6] + ",\r\n";
                        break;
                    case "cb75y":
                        txtChange.Text += StrY[7] + ",\r\n";
                        break;
                    case "cb10z":
                        txtChange.Text += StrZ[0] + ",\r\n";
                        break;
                    case "cb25z":
                        txtChange.Text += StrZ[1] + ",\r\n";
                        break;
                    case "cb30z":
                        txtChange.Text += StrZ[2] + ",\r\n";
                        break;
                    case "cb35z":
                        txtChange.Text += StrZ[3] + ",\r\n";
                        break;
                    case "cb40z":
                        txtChange.Text += StrZ[4] + ",\r\n";
                        break;
                    case "cb50z":
                        txtChange.Text += StrZ[5] + ",\r\n";
                        break;
                    case "cb60z":
                        txtChange.Text += StrZ[6] + ",\r\n";
                        break;
                    case "cb75z":
                        txtChange.Text += StrZ[7] + ",\r\n";
                        break;
                }
            }
            else
            {
                switch (cb.Name)
                {
                    case "cb10x":
                        txtChange.Text = txtChange.Text.Replace(StrX[0] + ",\r\n", "");
                        break;
                    case "cb25x":
                        txtChange.Text = txtChange.Text.Replace(StrX[1] + ",\r\n", "");
                        break;
                    case "cb30x":
                        txtChange.Text = txtChange.Text.Replace(StrX[2] + ",\r\n", "");
                        break;
                    case "cb35x":
                        txtChange.Text = txtChange.Text.Replace(StrX[3] + ",\r\n", "");
                        break;
                    case "cb40x":
                        txtChange.Text = txtChange.Text.Replace(StrX[4] + ",\r\n", "");
                        break;
                    case "cb50x":
                        txtChange.Text = txtChange.Text.Replace(StrX[5] + ",\r\n", "");
                        break;
                    case "cb60x":
                        txtChange.Text = txtChange.Text.Replace(StrX[6] + ",\r\n", "");
                        break;
                    case "cb75x":
                        txtChange.Text = txtChange.Text.Replace(StrX[7] + ",\r\n", "");
                        break;
                    case "cb10y":
                        txtChange.Text = txtChange.Text.Replace(StrY[0] + ",\r\n", "");
                        break;
                    case "cb25y":
                        txtChange.Text = txtChange.Text.Replace(StrY[1] + ",\r\n", "");
                        break;
                    case "cb30y":
                        txtChange.Text = txtChange.Text.Replace(StrY[2] + ",\r\n", "");
                        break;
                    case "cb35y":
                        txtChange.Text = txtChange.Text.Replace(StrY[3] + ",\r\n", "");
                        break;
                    case "cb40y":
                        txtChange.Text = txtChange.Text.Replace(StrY[4] + ",\r\n", "");
                        break;
                    case "cb50y":
                        txtChange.Text = txtChange.Text.Replace(StrY[5] + ",\r\n", "");
                        break;
                    case "cb60y":
                        txtChange.Text = txtChange.Text.Replace(StrY[6] + ",\r\n", "");
                        break;
                    case "cb75y":
                        txtChange.Text = txtChange.Text.Replace(StrY[7] + ",\r\n", "");
                        break;
                    case "cb10z":
                        txtChange.Text = txtChange.Text.Replace(StrZ[0] + ",\r\n", "");
                        break;
                    case "cb25z":
                        txtChange.Text = txtChange.Text.Replace(StrZ[1] + ",\r\n", "");
                        break;
                    case "cb30z":
                        txtChange.Text = txtChange.Text.Replace(StrZ[2] + ",\r\n", "");
                        break;
                    case "cb35z":
                        txtChange.Text = txtChange.Text.Replace(StrZ[3] + ",\r\n", "");
                        break;
                    case "cb40z":
                        txtChange.Text = txtChange.Text.Replace(StrZ[4] + ",\r\n", "");
                        break;
                    case "cb50z":
                        txtChange.Text = txtChange.Text.Replace(StrZ[5] + ",\r\n", "");
                        break;
                    case "cb60z":
                        txtChange.Text = txtChange.Text.Replace(StrZ[6] + ",\r\n", "");
                        break;
                    case "cb75z":
                        txtChange.Text = txtChange.Text.Replace(StrZ[7] + ",\r\n", "");
                        break;
                }
            }
        }
        #endregion

        private void btnSelectall_Click(object sender, EventArgs e)
        {
            foreach (Control con in plSetting.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
            {
                if (con is CheckBox) 
                {
                    CheckBox chk = con as CheckBox;
                    if (chk.Checked == false)
                    {
                        btnSelectall.Text = "Deselect";
                        chk.Checked = true;
                    }
                    else
                    {
                        btnSelectall.Text = "Select All";
                        chk.Checked = false;
                    }
                }
            }
        }

        //全部不選
        private void checkboxD()
        {
            foreach (Control con in plSetting.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
            {
                if (con is CheckBox)
                {
                    CheckBox chk = con as CheckBox;
                    btnSelectall.Text = "Select All";
                    chk.Checked = false;
                }
            }
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {
            string[] mList;
            mList = txtChange.Text.Split(',');
            lbltotalProjects.Text = "總數 : " + (mList.Length -1) + "筆";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string[] StrAll;
            StrAll = txtChange.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(StrAll);
            txtChange.Text = "";
            foreach (string S in StrAll) { txtChange.Text += S + "\r\n"; }
        }

        #region 截圖功能
        private void PrintScreen()
        {
            Bitmap myImage = new Bitmap(880, 711);
            Graphics g = Graphics.FromImage(myImage);
            Thread.Sleep(12000);
            g.CopyFromScreen(new Point(this.Location.X + 530, this.Location.Y + 190), new Point(0, 0), new Size(this.Width, this.Height));
            IntPtr dc1 = g.GetHdc();
            g.ReleaseHdc(dc1);
            myImage.Save(@"C:\Users\allen.lin\Desktop\TE90\screen1.jpg");
        }
        #endregion

        private void frm_ControlSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            plc1.Disconnect();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            plProgressBar.Visible = false;
            lblbgker.Text = "已完成0%";
        }
    }
}
