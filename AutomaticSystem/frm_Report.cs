using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Spire.Xls;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using testAll;

namespace AutomaticSystem
{
    public partial class frm_Report : BasicForm
    {
        public static string[] K1K2 = new string[0];
        public static int NewId;
        public static string HmiVersion;
        
        SqlData _SqlData;
        public frm_Report()
        {
            InitializeComponent();
            _SqlData = new SqlData();
        }

        public enum Sheets : int
        {
            testResult = 0,
            ForcePhoto = 1
        }

        public enum panelAll : int
        {
            pMain = 1,
            gbUp = 2,
            pMainE = 3,
            gbUpE = 4
        }

        #region 一般SQL連線、All SQL
        string DBConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ISO15006_Ctrl.mdb;Persist Security Info=False";
        public DataTable ConnectQuery(string Sqlstr)
        {
            OleDbConnection Conn = new OleDbConnection(DBConnStr);
            OleDbDataAdapter DA = new OleDbDataAdapter(Sqlstr, Conn);
            DataTable DT = new DataTable();
            try
            {
                Conn.Open();
                DA.SelectCommand.CommandText = Sqlstr;
                DA.Fill(DT);
                Conn.Close();
            }
            catch (Exception ex) { MsgBox.Show(ex.Message); }

            return DT;
        }

        public void Connect(string Sqlstr)
        {
            OleDbConnection Conn = new OleDbConnection(DBConnStr);
            OleDbCommand oleCmd = new OleDbCommand("", Conn);
            Conn.Open();
            oleCmd.CommandText = Sqlstr;
            oleCmd.ExecuteNonQuery();
            Conn.Close();
        }

        private void Comboboxitems(ComboBox cb, string DataType, int Action, string DataName)
        {
            string Sqlstr;
            Sqlstr = _SqlData.GetData(DataType, Action);
            DataTable DT = ConnectQuery(Sqlstr);
            cb.Items.Clear();
            foreach (DataRow DR in DT.Rows)
            {
                ComboboxItem vitem = new ComboboxItem();
                vitem.Text = DR[DataName].ToString();
                vitem.Value = DR["id"].ToString();
                cb.Items.Add(vitem);

                if (cb.Items.Count == 0) { return; } else { cb.SelectedIndex = 0; }
            }
        }
        #endregion

        #region Combobox
        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public ComboboxItem()
            {
            }
            public ComboboxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }
            public override string ToString()
            {
                return Text;
            }
        }
        #endregion


        private void frm_Report_Load(object sender, EventArgs e)
        {
            #region 泡沫排序法
            /*
            int temp = 0;
            int[] data = new int[] { 89, 34, 23, 78, 67, 100, 66, 29, 79, 55, 78, 88, 92, 96, 96, 23 };
            label1.Text = "";
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[i] > data[j])
                    {
                        temp = data[j];
                        data[j] = data[i];
                        data[i] = temp;
                    }
                }
                if (i == data.Length -1) 
                {
                    label1.Text += data[i];
                }
                else
                { label1.Text += data[i] + "、"; }
            }
            */
            #endregion

            this.Size = new Size(pMain.Width - gbUp.Width + 10, gbData.Height + 50);
            txtPath.Focus();
            lblHMI.Text = HmiVersion;
            Comboboxitems(cbHW, "HW_Version", 1, "hw_version");
            Comboboxitems(cbTester, "Tester", 1, "Name");

            ComboboxItem vitem = new ComboboxItem();
            ComboboxItem vitem2 = new ComboboxItem();
            vitem.Text = "HW版本";
            vitem.Value = "1";
            cbLV.Items.Add(vitem);
            vitem2.Text = "Tester";
            vitem2.Value = "2";
            cbLV.Items.Add(vitem2);

            gbData.MouseDoubleClick += new MouseEventHandler(gbChange_MouseDoubleClick); //點擊兩下切換模式
            gbManual.MouseDoubleClick += new MouseEventHandler(gbChange_MouseDoubleClick); //點擊兩下切換模式
        }

        private void gbChange_MouseDoubleClick(object sender, EventArgs e)
        {
            if (gbData.Text.Contains("正常")) { gbData.Text = "Data-手動模式"; gbManual.Visible = true; gbData.Visible = false; gbManual.Location = gbData.Location; }
            else { gbData.Text = "Data-正常模式"; gbData.Visible = true; gbManual.Visible = false; }

            
            
        }

        List<string> vRtx = new List<string>();
        public void txtRead(string Rtxpath)
        {
            foreach (string fname in System.IO.Directory.GetFiles(Rtxpath))
            {
                if (System.IO.Path.GetFileNameWithoutExtension(fname) == "Robot_Configuration" + DateTime.Now.ToString("yyyyMMdd") && System.IO.Path.GetExtension(fname) == ".txt")
                {
                    string line;
                    vRtx.Clear();  //做完一次就清除

                    // 一次讀取一行
                    System.IO.StreamReader file = new System.IO.StreamReader(fname);
                    while ((line = file.ReadLine()) != null)
                    {
                        //if (line.Contains("GroupName") || line.Contains("SoftwareVersion"))
                        //{
                        //    if (vRtx.Count < 4) { vRtx.Add(line.Trim()); }
                        //    else
                        //    {
                        //        if (vRtx[2] == line || vRtx[3] == line) { }
                        //        else { vRtx.Add(line.Trim()); }
                        //    }
                        //}
                        if (line.Contains("Power_Name") || line.Contains("Power_FW") || line.Contains("J0_Name") || line.Contains("J0_FW") ||
                            line.Contains("IO_Name") || line.Contains("IO_FW") || line.Contains("Patriot_L0_Name") || line.Contains("Patriot_L0_FW"))
                        {
                            vRtx.Add(line.Trim().Substring(0, line.LastIndexOf(',')));
                        }
                    }
                }
            }
        }

        List<string> vNumber = new List<string>();
        public void txtReadData(string Rtxpath)
        {
            string Sqlstr = "", vK1K2 = "";
            try
            {
                foreach (string fname in System.IO.Directory.GetFiles(Rtxpath))
                {
                    if (System.IO.Path.GetFileNameWithoutExtension(fname).Contains("VisionNumber") && System.IO.Path.GetExtension(fname) == ".log" &&
                        System.IO.Path.GetFileNameWithoutExtension(fname).Contains(DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        string line;
                        vNumber.Clear();  //做完一次就清除

                        // 一次讀取一行
                        System.IO.StreamReader file = new System.IO.StreamReader(fname);
                        while ((line = file.ReadLine()) != null)
                        {
                            vNumber.Add(line.Trim());
                        }
                    }
                }

                if (vNumber.Count == 0) { MsgBox.Show("沒有Sensor log值，請確認是否放入檔案！", "警告", enMessageButton.OK, enMessageType.Warning); return; }

                int N = 1;
                for (int j = 0; j <= K1K2.Length - 1; j++)
                {
                    if (j == 0) { if (!vNumber[0].Contains("ProjectStart")) { N = 0; } else { N = 1; } }
                    for (int i = 1; i <= 3; i++)
                    {
                        //if (vNumber[0].Contains("ProjectStart")) { continue; }
                        Sqlstr = _SqlData.GetData("Data", 1);
                        Sqlstr = Sqlstr.Replace("?1", K1K2[j].Substring(K1K2[j].IndexOf('_') - 1, 1));
                        if (K1K2[j].Contains("10")) { vK1K2 = "10SH10"; }
                        else if (K1K2[j].Contains("25")) { vK1K2 = "25SH70"; }
                        else if (K1K2[j].Contains("30")) { vK1K2 = "30SH30"; }
                        else if (K1K2[j].Contains("35")) { vK1K2 = "35SH30"; }
                        else if (K1K2[j].Contains("40")) { vK1K2 = "40SH70"; }
                        else if (K1K2[j].Contains("50")) { vK1K2 = "50SH30"; }
                        else if (K1K2[j].Contains("60")) { vK1K2 = "60SH30"; }
                        else if (K1K2[j].Contains("75")) { vK1K2 = "75SH70"; }
                        Sqlstr = Sqlstr.Replace("?2", vK1K2);
                        if (vNumber[N].Contains("FT")) { Sqlstr = Sqlstr.Replace("?3", vNumber[N].Substring(vNumber[N].IndexOf('=') + 1)); }
                        else { Sqlstr = Sqlstr.Replace("?3", ""); }
                        N += 1;
                        if (vNumber[N].Contains("FS")) { Sqlstr = Sqlstr.Replace("?4", vNumber[N].Substring(vNumber[N].IndexOf('=') + 1)); }
                        else { Sqlstr = Sqlstr.Replace("?4", ""); }
                        N += 1;
                        if (vNumber[N].Contains("ID")) { Sqlstr = Sqlstr.Replace("?5", vNumber[N].Substring(vNumber[N].IndexOf('=') + 1)); }
                        else { Sqlstr = Sqlstr.Replace("?5", ""); }
                        Sqlstr = Sqlstr.Replace("?6", vNumber[N].Substring(0, vNumber[N].IndexOf('=') - 3));
                        Sqlstr = Sqlstr.Replace("?7", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        Sqlstr = Sqlstr.Replace("?8", txtArmName.Text.Substring(txtArmName.Text.IndexOf('#') + 1));
                        Connect(Sqlstr);
                        if ((!vNumber[0].Contains("ProjectStart") && N == 2) || N == 3)
                        {
                            //抓取第一筆ID
                            Sqlstr = _SqlData.GetData("Data", 3);
                            DataTable DT = ConnectQuery(Sqlstr);
                            NewId = int.Parse(DT.Rows[0][0].ToString());
                        }

                        N += 1;
                    }
                    initLV2("Max");
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, "Error", enMessageButton.OK, enMessageType.Error);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblPlc.Text == "請選擇公版")
                { MsgBox.Show("未選取匯入公版，請重新選擇！", "WARNING", enMessageButton.OK, enMessageType.Warning); return; }
                if (lblPath.Text == "") 
                { MsgBox.Show("未選取檔案路徑，請重新選擇！", "WARNING", enMessageButton.OK, enMessageType.Warning); return; }
                if (txtFileName.Text == "")
                { MsgBox.Show("未輸入檔案名稱，請重新輸入！", "WARNING", enMessageButton.OK, enMessageType.Warning); return; }

                if (cbHW.Text == "3.2") { txtRead(txtPath.Text.Replace("\\Enable","")); }
                else { txtRead(txtPath.Text); }

                //創建Workbook
                Workbook workbook = new Workbook();
                workbook.LoadFromFile("HW"+ cbHW.Text + "\\" + lblPlc.Text + ".xlsx");

                //工作表
                Worksheet sheet = workbook.Worksheets[(int)Sheets.ForcePhoto];

                // 執行檔路徑下的資料夾
                string folderName = txtPath.Text;
                string FNN, FNA;
                string[] vname = { };
                List<string> myList = new List<string>();

                // 取得資料夾內所有檔案名稱(含副檔名)
                foreach (string fname in System.IO.Directory.GetFiles(folderName))
                {
                    FNN = System.IO.Path.GetFileNameWithoutExtension(fname);
                    FNA = System.IO.Path.GetExtension(fname);
                    if (FNN.ToUpper().Contains("X") || FNN.ToUpper().Contains("Y") || FNN.ToUpper().Contains("Z"))
                    {
                        if (FNA.ToLower() == ".jpg" || FNA.ToLower() == ".png")
                            myList.Add(FNN + FNA);
                    }
                }

                Worksheet sheet_M = workbook.Worksheets[(int)Sheets.testResult];
                sheet_M.Range[4, 66].Text = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("en-us")).Substring(0,3) + "," + DateTime.Now.ToString("dd,yy");
                int found;
                if (vRtx.Count == 8)
                {
                    for (int i = 0; i < vRtx.Count; i++)
                    {
                        found = vRtx[i].IndexOf(":") + 1;
                        switch (vRtx[i].Substring(found))
                        {
                            case "PowerManager/IOs":
                                found = vRtx[i + 1].IndexOf(":") + 1;
                                sheet_M.Range[27, 20].Text = vRtx[i + 1].Substring(found);
                                break;
                            case "AC Servo Driver": //Joint
                                found = vRtx[i + 1].IndexOf(":") + 1;
                                sheet_M.Range[31, 20].Text = vRtx[i + 1].Substring(found);
                                break;
                            case "Multi-IO Module":
                                found = vRtx[i + 1].IndexOf(":") + 1;
                                sheet_M.Range[33, 20].Text = vRtx[i + 1].Substring(found);
                                break;
                            case "Patriot L0":  //Safety
                                found = vRtx[i + 1].IndexOf(":") + 1;
                                sheet_M.Range[29, 20].Text = vRtx[i + 1].Substring(found);
                                break;
                        }
                        i++;
                    }
                }
                else { MsgBox.Show("數量有誤，請重新確認！", "警告", enMessageButton.OK, enMessageType.Warning); }
                sheet_M.Range[21, 20].Text = txtArmName.Text;
                sheet_M.Range[23, 20].Text = txtCbName.Text;
                sheet_M.Range[25, 20].Text = lblHMI.Text;
                sheet_M.Range[35, 20].Text = DateTime.Now.ToString("yyyy/MM/dd");
                sheet_M.Range[37, 20].Text = cbTester.Text;
                sheet_M.Range[96, 3].Text = txtArmName.Text.Substring(txtArmName.Text.IndexOf('#') + 1);
                sheet_M.Range[110, 9].Text = "#" + txtArmName.Text.Substring(txtArmName.Text.IndexOf('#') + 1);

                //K1K2 = new string[] { 
                //    "CollisionX_10", "CollisionX_25", "CollisionX_30", "CollisionX_35", "CollisionX_40", "CollisionX_50", "CollisionX_60", "CollisionX_75",
                //    "CollisionY_10", "CollisionY_25", "CollisionY_30", "CollisionY_35", "CollisionY_40", "CollisionY_50", "CollisionY_60", "CollisionY_75",
                //    "CollisionZ_10", "CollisionZ_25", "CollisionZ_30", "CollisionZ_35", "CollisionZ_40", "CollisionZ_50", "CollisionZ_60", "CollisionZ_75"
                //};
                if (K1K2 != null) 
                {
                    int FT1, FT2, FT3, FS1, FS2, FS3, vID = 2;
                    for (int i = 0; i <= K1K2.Length - 2; i++)
                    {
                        Sqlstr = _SqlData.GetData("Data", 4);
                        Sqlstr = Sqlstr.Replace("?1", NewId + "");
                        Sqlstr = Sqlstr.Replace("?2", NewId + vID + "");
                        DataTable DT0 = ConnectQuery(Sqlstr);
                        FT1 = int.Parse(DT0.Rows[0][0].ToString());
                        FT2 = int.Parse(DT0.Rows[1][0].ToString());
                        FT3 = int.Parse(DT0.Rows[2][0].ToString());
                        FS1 = int.Parse(DT0.Rows[0][1].ToString());
                        FS2 = int.Parse(DT0.Rows[1][1].ToString());
                        FS3 = int.Parse(DT0.Rows[2][1].ToString());
                        if (FT1 - FT2 <= 5 && FT1 - FT3 <= 5 && -(FT2 - FT3) * -1 <= 5)
                        {
                            Sqlstr = _SqlData.GetData("Data", 5);
                            Sqlstr = Sqlstr.Replace("?1", NewId + "");
                            Sqlstr = Sqlstr.Replace("?2", NewId + vID + "");
                        }
                        else if (FT1 - FT2 > 5 && FT1 - FT3 > 5 && -(FT2 - FT3) * -1 <= 5)
                        {
                            Sqlstr = _SqlData.GetData("Data", 6);
                            Sqlstr = Sqlstr.Replace("?1", NewId + "");
                            Sqlstr = Sqlstr.Replace("?2", NewId + vID + "");
                        }
                        else
                        {
                            Sqlstr = _SqlData.GetData("Data", 5);
                            Sqlstr = Sqlstr.Replace("?1", NewId + "");
                            Sqlstr = Sqlstr.Replace("?2", NewId + vID + ""); //原本有+1
                        }

                        DataTable DT = ConnectQuery(Sqlstr);
                        if (DT.Rows[0][0].ToString() == "X")
                        {
                            if (DT.Rows[0][1].ToString() == "10SH10")
                            {
                                sheet_M.Range[113, 20].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[113, 28].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "25SH70")
                            {
                                sheet_M.Range[114, 20].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[114, 28].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "30SH30")
                            {
                                sheet_M.Range[115, 20].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[115, 28].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "35SH30")
                            {
                                sheet_M.Range[116, 20].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[116, 28].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "40SH70")
                            {
                                sheet_M.Range[117, 20].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[117, 28].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "50SH30")
                            {
                                sheet_M.Range[118, 20].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[118, 28].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "60SH30")
                            {
                                sheet_M.Range[119, 20].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[119, 28].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "75SH70")
                            {
                                sheet_M.Range[120, 20].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[120, 28].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                        }
                        else if (DT.Rows[0][0].ToString() == "Y")
                        {
                            if (DT.Rows[0][1].ToString() == "10SH10")
                            {
                                sheet_M.Range[113, 36].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[113, 44].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "25SH70")
                            {
                                sheet_M.Range[114, 36].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[114, 44].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "30SH30")
                            {
                                sheet_M.Range[115, 36].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[115, 44].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "35SH30")
                            {
                                sheet_M.Range[116, 36].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[116, 44].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "40SH70")
                            {
                                sheet_M.Range[117, 36].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[117, 44].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "50SH30")
                            {
                                sheet_M.Range[118, 36].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[118, 44].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "60SH30")
                            {
                                sheet_M.Range[119, 36].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[119, 44].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "75SH70")
                            {
                                sheet_M.Range[120, 36].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[120, 44].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                        }
                        else if (DT.Rows[0][0].ToString() == "Z")
                        {
                            if (DT.Rows[0][1].ToString() == "10SH10")
                            {
                                sheet_M.Range[113, 52].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[113, 60].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "25SH70")
                            {
                                sheet_M.Range[114, 52].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[114, 60].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "30SH30")
                            {
                                sheet_M.Range[115, 52].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[115, 60].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "35SH30")
                            {
                                sheet_M.Range[116, 52].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[116, 60].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "40SH70")
                            {
                                sheet_M.Range[117, 52].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[117, 60].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "50SH30")
                            {
                                sheet_M.Range[118, 52].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[118, 60].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "60SH30")
                            {
                                sheet_M.Range[119, 52].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[119, 60].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                            else if (DT.Rows[0][1].ToString() == "75SH70")
                            {
                                sheet_M.Range[120, 52].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][2].ToString()));
                                sheet_M.Range[120, 60].Value = string.Format("{0:F2}", Convert.ToDouble(DT.Rows[0][3].ToString()));
                            }
                        }
                        NewId += 3;
                    }
                }
                
                if (K1K2.Where(val => val != String.Empty).ToArray().Length == myList.Count)
                {
                    //加入圖片
                    int[] Rows = new int[] { 2,16,30,44,58,72,86,100}; // j -> 列
                    int[] Column = new int[] { 6, 37, 68};             // n -> 欄
                    int vK1K2 = 0, vAxis;
                    string _Part;
                    for (int i = 0; i < myList.Count; i++)
                    {
                        //軸向
                        if (myList[i].ToUpper().Contains("X")) { vAxis = Column[(int)enAxis.X]; }
                        else if (myList[i].ToUpper().Contains("Y")) { vAxis = Column[(int)enAxis.Y]; }
                        else { vAxis = Column[(int)enAxis.Z]; }

                        //部位
                        _Part = Regex.Replace(myList[i], "[^0-9]", "");
                        if (_Part == "10") { vK1K2 = Rows[(int)enK1K2.Abdomen]; }
                        else if (_Part == "25") { vK1K2 = Rows[(int)enK1K2.Chest]; }
                        else if (_Part == "30") { vK1K2 = Rows[(int)enK1K2.UpperArm]; }
                        else if (_Part == "35") { vK1K2 = Rows[(int)enK1K2.Back]; }
                        else if (_Part == "40") { vK1K2 = Rows[(int)enK1K2.LowerLeg]; }
                        else if (_Part == "50") { vK1K2 = Rows[(int)enK1K2.Thigh]; }
                        else if (_Part == "60") { vK1K2 = Rows[(int)enK1K2.LowerLeg]; }
                        else if (_Part == "70") { vK1K2 = Rows[(int)enK1K2.Hands]; }
                        
                        //將圖片匯入Excel
                        ExcelPicture picture = sheet.Pictures.Add(vK1K2, vAxis, txtPath.Text + "\\" + myList[i]);

                        //通過LeftColumnOffset和TopRowOffset屬性值設置圖片在單元格中的橫向、縱向對齊
                        picture.LeftColumnOffset = 200;
                        picture.TopRowOffset = 50;

                        //指定圖片寬度和高度
                        picture.Width = 395;
                        picture.Height = 300;
                    }
                }
                else
                { MsgBox.Show("各軸圖片提供有多或缺，請重新確認！", "ERROR", enMessageButton.OK, enMessageType.Error); return; }

                //保存並打開文檔
                string vPath = "";
                if (cbHW.Text == "3.2") { vPath = txtPath.Text.Replace("\\Enable",""); } else { vPath = txtPath.Text; }
                workbook.SaveToFile(vPath + "\\" + txtFileName.Text + ".xlsx", ExcelVersion.Version2016);
                System.Diagnostics.Process.Start(vPath + "\\" + txtFileName.Text + ".xlsx");

                MsgBox.Show("Excel匯入已完成！");
                ClearDataE((int)panelAll.pMain);
                
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, "ERROR", enMessageButton.OK, enMessageType.Error);
            }
        }

        #region TestBox focus
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox Tb = (TextBox)sender;
            switch (Tb.TabIndex)
            {
                case 2:
                    txtPath.BackColor = Color.PaleGreen;
                    break;
                case 3:
                    txtArmName.BackColor = Color.PaleGreen;
                    break;
                case 4:
                    txtCbName.BackColor = Color.PaleGreen;
                    break;
                case 7:
                    txtFileName.BackColor = Color.PaleGreen;
                    break;
                case 65:
                    txtHW2.BackColor = Color.PaleGreen;
                    break;
                case 66:
                    
                    break;
                case 67:
                    txtTester2.BackColor = Color.PaleGreen;
                    break;
                case 92:
                    txtFT.BackColor = Color.PaleGreen;
                    break;
                case 94:
                    txtFS.BackColor = Color.PaleGreen;
                    break;
            }
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox Tb = (TextBox)sender;
            switch (Tb.TabIndex)
            {
                case 2:
                    txtPath.BackColor = Color.White;
                    break;
                case 3:
                    txtArmName.BackColor = Color.White;
                    break;
                case 4:
                    txtCbName.BackColor = Color.White;
                    break;
                case 7:
                    txtFileName.BackColor = Color.White;
                    break;
                case 65:
                    txtHW2.BackColor = Color.White;
                    break;
                case 66:
                    
                    break;
                case 67:
                    txtTester2.BackColor = Color.White;
                    break;
                case 92:
                    txtFT.BackColor = Color.White;
                    break;
                case 94:
                    txtFS.BackColor = Color.White;
                    break;
            }
        }
        #endregion

        #region 選擇公版及檔案(圖片)路徑
        private void btnFileplc_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = System.IO.Directory.GetCurrentDirectory() + "\\HW" + cbHW.Text;
            file.ShowDialog();
            if (file.FileName == "")
            {
                lblPlc.Text = "請選擇公版";
                lblPlc.BackColor = Color.Gray;
                btnClear.PerformClick();
            }
            else
            {
                lblPlc.Text = file.SafeFileName.Replace(".xlsx", "");
                lblPlc.BackColor = Color.Lime;
                txtArmName.Text = lblPlc.Text.Substring(lblPlc.Text.IndexOf('_') + 1) + "xxxx#";
                //txtFileName.Text = lblPlc.Text.Substring(0, Convert.ToInt32(lblPlc.Text.IndexOf('_'))) + "_";

                if (txtArmName.Text.Contains("TM5S_") || txtArmName.Text.Contains("TM7S_") || txtArmName.Text.Contains("700") || txtArmName.Text.Contains("900"))
                { txtCbName.Text = "Regular payload series standard control box_"; }
                else
                { txtCbName.Text = "Medium & heavy payload series standard control box_"; }
            }

            if (lblPlc.BackColor == Color.Gray) { MsgBox.Show("請先選擇公版！", "警告", enMessageButton.OK, enMessageType.Warning); return; }
            else { lblType.Text = lblPlc.Text.Substring(lblPlc.Text.IndexOf('_') + 1).Replace("_", ""); }
        }

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog path = new FolderBrowserDialog();
            fbD_path.SelectedPath = System.IO.Directory.GetCurrentDirectory();
            fbD_path.ShowDialog();
            txtPath.Text = fbD_path.SelectedPath;
            txtArmName.Focus();
        }
        #endregion

        #region LV設定
        private void initLV(string title)
        {
            string Sqlstr;
            LV1.Clear();
            if (cbLV.Text.Contains("HW"))
            {
                LV1.Columns.Add("id", 0, HorizontalAlignment.Left);
                LV1.Columns.Add("HW", 60, HorizontalAlignment.Center);
                LV1.Columns.Add("pid", 0, HorizontalAlignment.Left);

                Sqlstr = _SqlData.GetData("HW_Version", 1);
                DataTable DT = ConnectQuery(Sqlstr);
                foreach (DataRow DR in DT.Rows)
                {
                    ListViewItem lvitem = new ListViewItem();
                    lvitem.Text = DR["id"].ToString();
                    lvitem.SubItems.Add(DR["hw_version"].ToString());
                    lvitem.SubItems.Add(DR["pid"].ToString());
                    LV1.Items.Add(lvitem);
                }
            }
            else if (cbLV.Text.Contains("HMI"))
            {
                LV1.Columns.Add("id", 0, HorizontalAlignment.Left);
                LV1.Columns.Add("HMI Version", 100, HorizontalAlignment.Center);
                LV1.Columns.Add("pid", 0, HorizontalAlignment.Center);

                Sqlstr = _SqlData.GetData("HMI_Version", 1);
                DataTable DT = ConnectQuery(Sqlstr);
                foreach (DataRow DR in DT.Rows)
                {
                    ListViewItem lvitem = new ListViewItem();
                    lvitem.Text = DR["id"].ToString();
                    lvitem.SubItems.Add(DR["Version"].ToString());
                    lvitem.SubItems.Add(DR["pid"].ToString());
                    LV1.Items.Add(lvitem);
                }
            }
            else
            {
                LV1.Columns.Add("id", 0, HorizontalAlignment.Left);
                LV1.Columns.Add("測試人員", 100, HorizontalAlignment.Center);

                Sqlstr = _SqlData.GetData("Tester", 1);
                DataTable DT = ConnectQuery(Sqlstr);
                foreach (DataRow DR in DT.Rows)
                {
                    ListViewItem lvitem = new ListViewItem();
                    lvitem.Text = DR["id"].ToString();
                    lvitem.SubItems.Add(DR["Name"].ToString());
                    LV1.Items.Add(lvitem);
                }
            }
        }

        private void LV1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtHW2.Enabled == true || txtTester2.Enabled == true)
            {
                if (cbLV.Text.Contains("HW")) 
                { txtHW2.Text = LV1.FocusedItem.SubItems[1].Text; txtTester2.Text = ""; txtPID.Text = LV1.FocusedItem.SubItems[2].Text; }
                if (cbLV.Text.Contains("HMI")) 
                { txtHW2.Text = ""; txtTester2.Text = ""; txtPID.Text = LV1.FocusedItem.SubItems[2].Text; }
                if (cbLV.Text.Contains("Tester")) 
                { txtTester2.Text = LV1.FocusedItem.SubItems[1].Text; txtHW2.Text = ""; txtPID.Text = LV1.FocusedItem.SubItems[0].Text; }
            }
        }

        private void cbLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            initLV(cbLV.Text);
            if (btnmodify.Enabled == true && btnAdd.Enabled == false)
            {
                if (cbLV.Text.Contains("HW")) { txtHW2.Enabled = true; txtTester2.Enabled = false; txtHW2.Focus(); }
                else { txtHW2.Enabled = false; txtTester2.Enabled = true; txtTester2.Focus(); }
            }

            if (btnDelete.Enabled == true && btnAdd.Enabled == false && btnmodify.Enabled == false)
            {
                if (cbLV.Text.Contains("HW")) { txtHW2.Enabled = true; txtTester2.Enabled = false; txtHW2.Focus(); }
                else { txtHW2.Enabled = false; txtTester2.Enabled = true; txtTester2.Focus(); }
            }
            
        }

        private void initLV2(string title)
        {
            LV2.Clear();
            LV2.Columns.Add("id", 0, HorizontalAlignment.Left);
            LV2.Columns.Add("Axis", 50, HorizontalAlignment.Center);
            LV2.Columns.Add("K1K2", 100, HorizontalAlignment.Center);
            LV2.Columns.Add("Force(Max)", 120, HorizontalAlignment.Left);
            LV2.Columns.Add("Force(Static)", 120, HorizontalAlignment.Left);
            LV2.Columns.Add("SensorID", 80, HorizontalAlignment.Left);
            LV2.Columns.Add("讀取時間", 180, HorizontalAlignment.Left);
            LV2.Columns.Add("最後更新時間", 180, HorizontalAlignment.Left);
            LV2.Columns.Add("手臂SN", 120, HorizontalAlignment.Center);

            if (title == "Max")
            {
                Sqlstr = _SqlData.GetData("Data", 2);
                Sqlstr = Sqlstr.Replace("?1", NewId +"");
                DataTable DT = ConnectQuery(Sqlstr);
                foreach (DataRow DR in DT.Rows)
                {
                    ListViewItem lvitem = new ListViewItem();
                    lvitem.Text = DR["id"].ToString();
                    lvitem.SubItems.Add(DR["Axis"].ToString());
                    lvitem.SubItems.Add(DR["K1K2"].ToString());
                    lvitem.SubItems.Add(DR["FT"].ToString());
                    lvitem.SubItems.Add(DR["FS"].ToString());
                    lvitem.SubItems.Add(DR["pid"].ToString());
                    lvitem.SubItems.Add(DR["done_datetime"].ToString());
                    lvitem.SubItems.Add(DR["last_datetime"].ToString());
                    lvitem.SubItems.Add(DR["ArmModel_SN"].ToString());
                    LV2.Items.Add(lvitem);
                }
            }
            else if (title == "All")
            {
                Sqlstr = _SqlData.GetData("Data", 10);
                Sqlstr = Sqlstr.Replace("?1", txtFT.Text);
                Sqlstr = Sqlstr.Replace("?2", txtFS.Text);
                Sqlstr = Sqlstr.Replace("?3", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                Sqlstr = Sqlstr.Replace("?4", txtdataID.Text);
                Connect(Sqlstr);

                Sqlstr = _SqlData.GetData("Data", 7);
                Sqlstr = Sqlstr.Replace("?1", NewId +"");
                DataTable DT1 = ConnectQuery(Sqlstr);
                foreach (DataRow DR in DT1.Rows)
                {
                    ListViewItem lvitem = new ListViewItem();
                    lvitem.Text = DR["id"].ToString();
                    lvitem.SubItems.Add(DR["Axis"].ToString());
                    lvitem.SubItems.Add(DR["K1K2"].ToString());
                    lvitem.SubItems.Add(DR["FT"].ToString());
                    lvitem.SubItems.Add(DR["FS"].ToString());
                    lvitem.SubItems.Add(DR["pid"].ToString());
                    lvitem.SubItems.Add(DR["done_datetime"].ToString());
                    lvitem.SubItems.Add(DR["last_datetime"].ToString());
                    lvitem.SubItems.Add(DR["ArmModel_SN"].ToString());
                    LV2.Items.Add(lvitem);
                }
            }
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearDataE((int)panelAll.pMain);
        }
        private void btnClear2_Click(object sender, EventArgs e)
        {
            ClearDataE((int)panelAll.gbUp);
            EnableData(0);
            initLV(cbLV.Text);
            gbUp.Text = "新增資訊";
        }
        private void ClearDataE(int panel)
        {
            switch (panel)
            {
                case 1:
                    txtArmName.Text = "";
                    txtCbName.Text = "";
                    txtFileName.Text = "";
                    txtPath.Text = "";
                    lblPlc.Text = "請選擇公版";
                    lblPlc.BackColor = Color.Gray;
                    lblType.Text = "None";
                    LV2.Clear();
                    txtFS.Text = "";
                    txtFT.Text = "";
                    txtFT.Enabled = false;
                    txtFS.Enabled = false;
                    btnDatamodify.Enabled = false;
                    LV2.Enabled = false;

                    cbHW.SelectedIndex = 0;
                    cbTester.SelectedIndex = 0;
                    cbHW.Focus();
                    break;
                case 2:
                    txtHW2.Text = "";
                    txtTester2.Text = "";
                    LV1.Clear();
                    cbLV.SelectedIndex = 0;
                    txtHW2.Focus();
                    break;
                case 3:
                    gbData.Enabled = false;
                    btnClear.Enabled = false;
                    btnUp.Enabled = false;
                    btnStart.Enabled = false;
                    btnFileplc.Enabled = false;
                    btnFilePath.Enabled = false;

                    txtArmName.Enabled = false;
                    txtCbName.Enabled = false;
                    txtFileName.Enabled = false;
                    txtPath.Enabled = false;

                    cbHW.Enabled = false;
                    cbTester.Enabled = false;

                    txtHW2.Enabled = false;
                    txtTester2.Enabled = false;
                    btnOK.Enabled = false;
                    btnAdd.Enabled = true;
                    btnmodify.Enabled = true;
                    btnDelete.Enabled = true;
                    btnOK.Enabled = false;
                    cbLV.SelectedIndex = 0;
                    cbLV.Focus();
                    initLV(cbLV.Text);
                    break;
                case 4:
                    gbData.Enabled = true;
                    btnClear.Enabled = true;
                    btnUp.Enabled = true;
                    btnStart.Enabled = true;
                    btnFileplc.Enabled = true;
                    btnFilePath.Enabled = true;

                    txtArmName.Enabled = true;
                    txtCbName.Enabled = true;
                    txtFileName.Enabled = true;
                    txtPath.Enabled = true;

                    cbHW.Enabled = true;
                    cbTester.Enabled = true;
                    cbHW.SelectedIndex = 0;
                    cbHW.Focus();
                    break;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            this.Width = this.Width + gbUp.Width + 5;
            gbUp.Visible = true;

            ClearDataE((int)panelAll.pMainE);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Width = this.Width - gbUp.Width - 5;
            gbUp.Visible = false;

            ClearDataE((int)panelAll.gbUpE);
            ClearDataE((int)panelAll.pMain);
            ClearDataE((int)panelAll.gbUp);
            Comboboxitems(cbHW, "HW_Version", 1, "hw_version");
            Comboboxitems(cbTester, "Tester", 1, "Name");
        }

        #region 新增、修改、刪除資訊
        private void EnableData(int txtData)
        {
            switch (txtData)
            {
                case 1:
                    txtHW2.Enabled = true;
                    txtTester2.Enabled = true;
                    txtHW2.Focus();

                    btnmodify.Enabled = false;
                    btnDelete.Enabled = false;
                    btnOK.Enabled = true;
                    break;
                case 2:
                    txtHW2.Enabled = true;
                    cbLV.SelectedIndex = 0;
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    btnOK.Enabled = true;
                    break;
                case 3:
                    txtHW2.Enabled = true;
                    btnAdd.Enabled = false;
                    btnmodify.Enabled = false;
                    btnOK.Enabled = true;
                    cbLV.Focus();
                    break;
                default:
                    btnUp_Click(null, null);
                    break;
                
            }
        }

        string Sqlstr, Type;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableData(1);
            Type = "Add";
            gbUp.Text = "狀態- 新增 ";
        }

        private void btnmodify_Click(object sender, EventArgs e)
        {
            EnableData(2);
            Type = "modify";
            gbUp.Text = "狀態- 修改 ";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EnableData(3);
            Type = "Delete";
            gbUp.Text = "狀態- 刪除 ";
        }

        private void txtArmName_TextChanged(object sender, EventArgs e)
        {
            txtFileName.Text = "Collision test (ISO-15066)_" + txtArmName.Text.Replace("#", "_");

            if (txtArmName.Text.Contains("TM4S_") || txtArmName.Text.Contains("TM6S_"))
            { txtCbName.Text = "Regular payload series standard control box" + txtArmName.Text.Substring(txtArmName.Text.IndexOf('_')).Replace("CA", "CC"); }
            else if (txtArmName.Text.Contains("700") || txtArmName.Text.Contains("900"))
            { txtCbName.Text = "Regular payload series standard control box" + txtArmName.Text.Substring(txtArmName.Text.IndexOf('_')).Replace("BA", "BC"); }
            else
            {
                if (txtArmName.Text == "") 
                { }
                else
                {
                    if (cbHW.Text == "3.2")
                    { txtCbName.Text = "Medium & heavy payload series standard control box" + txtArmName.Text.Substring(txtArmName.Text.IndexOf('_')).Replace("BA", "BC"); }
                    else
                    { txtCbName.Text = "Medium & heavy payload series standard control box" + txtArmName.Text.Substring(txtArmName.Text.IndexOf('_')).Replace("CA", "CC"); }
                }
            }
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog path = new FolderBrowserDialog();
            fbD_path.SelectedPath = System.IO.Directory.GetCurrentDirectory();
            if (fbD_path.ShowDialog() == DialogResult.OK) 
            { 
                txtReadData(fbD_path.SelectedPath);
                txtFT.Enabled = true;
                txtFS.Enabled = true;
                btnDatamodify.Enabled = true;
                LV2.Enabled = true;
            }
            else { return; }
        }

        private enum enLV2Column : int
        { 
            id = 0,
            Axis = 1,
            K1K2 = 2,
            FT = 3,
            FS = 4,
            pid = 5,
            done_datetime = 6,
            last_datetime = 7,
            ArmModel_SN = 8
        }

        private void LV2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            txtdataID.Text = LV2.FocusedItem.SubItems[(int)enLV2Column.id].Text;
            txtFT.Text = LV2.FocusedItem.SubItems[(int)enLV2Column.FT].Text;
            txtFS.Text = LV2.FocusedItem.SubItems[(int)enLV2Column.FS].Text;
        }

        private void btnDatamodify_Click(object sender, EventArgs e)
        {
            initLV2("All");
        }

        private void cbx10_1_Leave(object sender, EventArgs e)
        {
            if (!cbx10_1.Text.Contains("/")) { MsgBox.Show("格式有誤!"); cbx10_1.Focus(); return; }
        }

        private void btnK1K2_Click(object sender, EventArgs e)
        {
            if (plK1K2.Visible == true)
            {
                plK1K2.Visible = false;
            }
            else
            {
                plK1K2.Visible = true;
                //if (K1K2.Where(val => val != String.Empty).ToArray().Length == 0) { txtK1K2.Text = "\r\n目前無資訊"; return; }
                K1K2 = new string[] {
                    "CollisionX_10", "CollisionX_25", "CollisionX_30", "CollisionX_35", "CollisionX_40", "CollisionX_50", "CollisionX_60", "CollisionX_75",
                    "CollisionY_10", "CollisionY_25", "CollisionY_30", "CollisionY_35", "CollisionY_40", "CollisionY_50", "CollisionY_60", "CollisionY_75",
                    "CollisionZ_10", "CollisionZ_25", "CollisionZ_30", "CollisionZ_35", "CollisionZ_40", "CollisionZ_50", "CollisionZ_60", "CollisionZ_75"
                };
                for (int i = 0; i < K1K2.Length; i++)
                {
                    txtK1K2.Text += K1K2[i] + "\r\n";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Type == "Add")
            {
                if (txtHW2.Text != "")
                {
                    int vPid = 0;
                    Sqlstr = _SqlData.GetData("HW_Version", 3);
                    DataTable DT = ConnectQuery(Sqlstr);
                    vPid = int.Parse(DT.Rows[0][0].ToString()) + 1;

                    Sqlstr = _SqlData.GetData("HW_Version", 2);
                    Sqlstr = Sqlstr.Replace("?1", txtHW2.Text);
                    Sqlstr = Sqlstr.Replace("?2", vPid + "");
                    Connect(Sqlstr);
                }
                if (txtTester2.Text != "")
                {
                    Sqlstr = _SqlData.GetData("Tester", 2);
                    Sqlstr = Sqlstr.Replace("?1", txtTester2.Text);
                    Connect(Sqlstr);
                }
            }
            else if (Type == "modify")
            {
                if (txtHW2.Text != "")
                {
                    Sqlstr = _SqlData.GetData("HW_Version", 4);
                    Sqlstr = Sqlstr.Replace("?1", txtHW2.Text);
                    Sqlstr = Sqlstr.Replace("?2", txtPID.Text);
                    Connect(Sqlstr);
                }
                if (txtTester2.Text != "")
                {
                    Sqlstr = _SqlData.GetData("Tester", 3);
                    Sqlstr = Sqlstr.Replace("?1", txtTester2.Text);
                    Sqlstr = Sqlstr.Replace("?2", txtPID.Text);
                    Connect(Sqlstr);
                }
            }
            else
            {
                if (txtHW2.Text != "")
                {
                    Sqlstr = _SqlData.GetData("HW_Version", 5);
                    Sqlstr = Sqlstr.Replace("?1", txtPID.Text);
                    Connect(Sqlstr);
                }
                if (txtTester2.Text != "")
                {
                    Sqlstr = _SqlData.GetData("Tester", 4);
                    Sqlstr = Sqlstr.Replace("?1", txtPID.Text);
                    Connect(Sqlstr);
                }
            }
            

            ClearDataE((int)panelAll.gbUp);
            initLV(cbLV.Text);
            gbUp.Text = "新增資訊";
        }
        #endregion
    }
}
