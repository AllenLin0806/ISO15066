using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testAll;

namespace AutomaticSystem
{
    public partial class frm_Query : BasicForm
    {
        SqlData _SqlData;
        frm_Report _frm_Report;
        public frm_Query()
        {
            InitializeComponent();
            _SqlData = new SqlData();
            _frm_Report = new frm_Report();
        }

        private void frm_Query_Load(object sender, EventArgs e)
        {
            Comboboxitems(cbArmModel_SN, "Data", 8, "ArmModel_SN");
        }

        private void initLV1()
        {
            string Sqlstr;
            LV1.Clear();
            LV1.Columns.Add("id", 0, HorizontalAlignment.Left);
            LV1.Columns.Add("Axis", 50, HorizontalAlignment.Center);
            LV1.Columns.Add("K1K2", 100, HorizontalAlignment.Center);
            LV1.Columns.Add("Force(Max)", 120, HorizontalAlignment.Left);
            LV1.Columns.Add("Force(Static)", 120, HorizontalAlignment.Left);
            LV1.Columns.Add("SensorID", 80, HorizontalAlignment.Left);
            LV1.Columns.Add("讀取時間", 180, HorizontalAlignment.Left);
            LV1.Columns.Add("最後更新時間", 180, HorizontalAlignment.Left);
            LV1.Columns.Add("手臂SN", 120, HorizontalAlignment.Center);

            Sqlstr = _SqlData.GetData("Data", 9);
            Sqlstr = Sqlstr.Replace("?1", cbArmModel_SN.Text);
            Sqlstr = Sqlstr.Replace("?2", dtpStart.Value.ToString("yyyy/MM/dd 00:00:00"));
            Sqlstr = Sqlstr.Replace("?3", dtpEnd.Value.ToString("yyyy/MM/dd 23:59:59"));
            DataTable DT = _frm_Report.ConnectQuery(Sqlstr);
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
                LV1.Items.Add(lvitem);
            }
        }

        #region Combobox 複寫
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

        private void Comboboxitems(ComboBox cb, string DataType, int Action, string DataName)
        {
            string Sqlstr;
            Sqlstr = _SqlData.GetData(DataType, Action);
            DataTable DT = _frm_Report.ConnectQuery(Sqlstr);
            cb.Items.Clear();
            foreach (DataRow DR in DT.Rows)
            {
                ComboboxItem vitem = new ComboboxItem();
                vitem.Text = DR[DataName].ToString();
                cb.Items.Add(vitem);

                if (cb.Items.Count == 0) { return; } else { cb.SelectedIndex = 0; }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date) 
            { MsgBox.Show("起訖時間設定有誤，請重新輸入！", "警告", enMessageButton.OK); dtpStart.Focus(); return; }
            
            initLV1();
            lbltotal.Text = "共 " + LV1.Items.Count + " 筆資料";
        }
    }
}
