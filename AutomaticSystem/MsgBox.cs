using AutomaticSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomaticSystem
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }
        static MsgBox thisMsgBox;
        static DialogResult result = DialogResult.Cancel;
        private static int count = 0;
        private static System.Threading.Timer timer;

        public static DialogResult Show(string MsgBoxMessage, string MsgBoxHeader = "", enMessageButton MsgBtn = enMessageButton.OK, enMessageType MsgType = enMessageType.Default, int _Count = 0)
        {
            thisMsgBox = new MsgBox();
            thisMsgBox.lblMessage.Text = MsgBoxMessage;
            if (String.IsNullOrEmpty(MsgBoxHeader) == false)
            {
                thisMsgBox.lblHeader.Text = MsgBoxHeader;
            }
            switch (MsgType)
            {
                case enMessageType.Warning:
                    thisMsgBox.lblIcon.ImageIndex = 0;
                    break;
                case enMessageType.Error:
                    thisMsgBox.lblIcon.ImageIndex = 1;
                    break;
                case enMessageType.Info:
                    thisMsgBox.lblIcon.ImageIndex = 2;
                    break;
                default:
                    //將圖示隱藏 訊息欄位拉到與訊息欄同寬
                    thisMsgBox.lblIcon.Visible = false;
                    thisMsgBox.lblMessage.Left = 20;
                    thisMsgBox.lblMessage.Width = thisMsgBox.Width;
                    break;
            }
            switch (MsgBtn)
            {
                case enMessageButton.OKCancel:
                    thisMsgBox.btnOK.Visible = true;
                    thisMsgBox.btnCancel.Visible = true;
                    break;
                case enMessageButton.OK:
                    thisMsgBox.btnOK.Left = thisMsgBox.Width / 2 - 35;
                    thisMsgBox.btnOK.Visible = true;
                    thisMsgBox.btnCancel.Visible = false;

                    if (_Count > 0)
                    {
                        count = _Count;
                        timer = new System.Threading.Timer(TimerFunction, null, 0, 1000);
                        thisMsgBox.btnOK.Enabled = false;
                        thisMsgBox.btnclose.Enabled = false;
                    }
                    break;
                default:
                    thisMsgBox.btnOK.Visible = true;
                    thisMsgBox.btnCancel.Visible = true;
                    break;
            }

            thisMsgBox.ShowDialog();
            return result;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
        }

        private static void TimerFunction(object state)
        {
            //thisMsgBox.Invoke(new Action(() => { thisMsgBox.btnOK.Text = $"確定({count})"; }));   //委派任務

            if (count > 0)
            {
                thisMsgBox.btnOK.Text = $"確定({count})";
                count--;
            } 
            else 
            {
                timer.Dispose();
                thisMsgBox.btnOK.Text = "確定";
                thisMsgBox.Invoke(new Action(() => { thisMsgBox.btnOK.Enabled = true; }));
                thisMsgBox.Invoke(new Action(() => { thisMsgBox.btnclose.Enabled = true; }));
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            Button btnName = (Button)sender;
            switch (btnName.Name)
            {
                case "btnOK":
                    btnOK.ForeColor = Color.Blue;
                    break;
                case "btnCancel":
                    btnCancel.ForeColor = Color.Blue;
                    break;
                case "btnclose":
                    btnclose.BackColor = Color.Red;
                    break;
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btnName = (Button)sender;
            switch (btnName.Name)
            {
                case "btnOK":
                    btnOK.ForeColor = Color.White;
                    break;
                case "btnCancel":
                    btnCancel.ForeColor = Color.White;
                    break;
                case "btnclose":
                    btnclose.BackColor = Color.Black;
                    break;
            }
        }
    }
}
