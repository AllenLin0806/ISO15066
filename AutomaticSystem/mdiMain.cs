using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using testAll;

namespace AutomaticSystem
{
    public partial class mdiMain : TitleForm
    {
        public mdiMain()
        {
            InitializeComponent();
        }

        private void mdiMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            foreach (Control ctl in this.Controls.OfType<MdiClient>())          //mdi顏色的修改
            {
                ctl.BackColor = Color.MidnightBlue;
            }

            System.Diagnostics.Process[] vHewCtrlProcess = System.Diagnostics.Process.GetProcessesByName("CoboSafe-Vision");
            if (vHewCtrlProcess.Length == 0)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + @"\CoboSafe-Vision.lnk");
            }

            this.Visible = true;
            if (_frm_Help == null) { _frm_Help = new frm_Help(); }
            _frm_Help.MdiParent = this;
            _frm_Help.Show();
            _frm_Help.Width = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tlblDatetime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            timer1.Interval = 100;
        }

        frm_ControlSystem _frm_Control;
        frm_Report _frm_Report;
        frm_Query _frm_Query;
        frm_Help _frm_Help;
        MsgExecution _MsgExecution;
        public void newMDIChild(string name)
        {
            switch (name)
            {
                case "ControlSystem":
                    //如果是空的，會建立一個新視窗
                    if (_frm_Control == null) { _frm_Control = new frm_ControlSystem(); }
                    //判斷如果form被處置後，建立新的from
                    if (_frm_Control.IsDisposed == true) { _frm_Control = new frm_ControlSystem(); }
                    // Set the Parent Form of the Child window.
                    _frm_Control.MdiParent = this;
                    //顯示位置
                    _frm_Control.StartPosition = FormStartPosition.CenterScreen;
                    // Display the new form.
                    _frm_Control.Show();
                    //點選到視窗會跳到最前面
                    _frm_Control.Activate();
                    break;
                case "Report":
                    if (_frm_Report == null) { _frm_Report = new frm_Report(); }
                    if (_frm_Report.IsDisposed == true) { _frm_Report = new frm_Report(); }
                    _frm_Report.MdiParent = this;
                    _frm_Report.StartPosition = FormStartPosition.CenterScreen;
                    _frm_Report.Show();
                    _frm_Report.Activate();
                    break;
                case "Query":
                    if (_frm_Query == null) { _frm_Query = new frm_Query(); }
                    if (_frm_Query.IsDisposed == true) { _frm_Query = new frm_Query(); }
                    _frm_Query.MdiParent = this;
                    _frm_Query.StartPosition = FormStartPosition.CenterScreen;
                    _frm_Query.Show();
                    _frm_Query.Activate();
                    break;
            }
        }

        private void tbtnControl_Click(object sender, EventArgs e)
        {
            newMDIChild("ControlSystem");
        }

        private void tbtnReport_Click(object sender, EventArgs e)
        {
            newMDIChild("Report");
        }

        private void tbtnQuery_Click(object sender, EventArgs e)
        {
            newMDIChild("Query");
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (_frm_Help.Visible == false) { return; }
            if (_frm_Help.Width == 0)
            {
                _frm_Help.Width = 500;
                _frm_Help.Left = this.Width - 577;

                _frm_Help.Top = 0;
                _frm_Help.Height = this.Height - 120;

                btnExpand.Text = ">";
            }
            else
            {
                _frm_Help.Width = 0;
                btnExpand.Text = "<";
            }
            _frm_Help.Dock = DockStyle.Right;
        }

    }
}
