using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testAll
{
    public partial class TitleForm : Form
    {
        private bool moving = false;
        private Point oldMousePosition;

        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return base.FormBorderStyle;
            }
            set
            {
                if (value != FormBorderStyle.Sizable && value != FormBorderStyle.SizableToolWindow)
                {
                    titlepanel.Controls.Remove(button2);
                }
                base.FormBorderStyle = value;
            }
        }

        #region 隱藏父類的屬性，使其不可見
        [Browsable(false)]
        public new string Text
        {
            get
            {
                return titlelabel.Text;
            }
            set
            { }
        }

        [Browsable(false)]
        public new bool ControlBox
        {
            get
            {
                return false;
            }
            set
            {
                base.ControlBox = false;
            }
        }
        #endregion

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗體標題")]
        public string Title
        {
            get { return titlelabel.Text; }
            set { titlelabel.Text = value; }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗體標題字體樣式")]
        public Font TitleFont
        {
            get
            {
                return titlelabel.Font;
            }
            set
            {
                titlelabel.Font = value;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗體標題字體顏色")]
        public Color TitleColor
        {
            get
            {
                return titlelabel.ForeColor;
            }
            set
            {
                titlelabel.ForeColor = value;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗體標題欄背景色")]
        public Color TitleBarBackColor
        {
            get
            {
                return titlepanel.BackColor;
            }
            set
            {
                titlepanel.BackColor = value;
            }
        }

        public new bool MaximizeBox
        {
            get
            {
                return titlepanel.Contains(button2);
            }
            set
            {
                if (!value)
                {
                    titlepanel.Controls.Remove(button2);
                }
                else if (!titlepanel.Contains(button2))
                {
                    titlepanel.Controls.Add(button2);
                }
            }
        }
        public new bool MinimizeBox
        {
            get
            {
                return titlepanel.Contains(button3);
            }
            set
            {
                if (!value)
                {
                    titlepanel.Controls.Remove(button3);
                }
                else if (!titlepanel.Contains(button3))
                {
                    titlepanel.Controls.Add(button3);
                }
            }
        }

        private void ResetTitlePanel()
        {
            base.ControlBox = false;
            base.Text = null;
            SetToolTip(button1, "關閉");
            button2.Size = button1.Size;
            SetToolTip(button2, "最大化或還原");
            button3.Size = button1.Size;
            SetToolTip(button3, "最小化");
        }

        private void SetToolTip(Control ctrl, string tip)
        {
            new ToolTip().SetToolTip(ctrl, tip);
        }

        public TitleForm()
        {
            InitializeComponent();
            ResetTitlePanel();
        }

        private void Titlebutton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case "close":
                    
                    this.Close();
                    break;
                case "max":
                    
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Maximized;
                    }
                    break;
                case "min":
                    
                    if (this.WindowState != FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                    break;
            }
        }

        private void Titlepanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                return;
            }
            //Titlepanel.Cursor = Cursors.NoMove2D;
            oldMousePosition = e.Location;
            moving = true;
        }

        private void Titlepanel_MouseUp(object sender, MouseEventArgs e)
        {
            //Titlepanel.Cursor = Cursors.Default;
            moving = false;
        }

        private void Titlepanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving)
            {
                Point newPosition = new Point(e.Location.X - oldMousePosition.X, e.Location.Y - oldMousePosition.Y);
                this.Location += new Size(newPosition);
            }
        }

        private void Titlepanel_DoubleClick(object sender, EventArgs e)
        {
            if (titlepanel.Contains(button2))
            {
                button2.PerformClick();
            }
        }

        private void titlepanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            switch (e.Control.Name)
            {
                case "button2":

                    if (titlepanel.Contains(button3))
                    {
                        button3.Left = button1.Left - button1.Width;
                    }
                    break;
            }
        }

        private void titlepanel_ControlAdded(object sender, ControlEventArgs e)
        {
            switch (e.Control.Name)
            {
                case "button2":
                    
                    if (titlepanel.Contains(button3))
                    {
                        button3.Left = button2.Left - button2.Width;
                    }
                    break;
                case "button3":
                    
                    if (titlepanel.Contains(button2))
                    {
                        button3.Left = button2.Left - button2.Width;
                    }
                    break;
            }
        }

        #region button滑鼠改變
        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Red;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.DarkOliveGreen;
        }
        #endregion

    }
}
