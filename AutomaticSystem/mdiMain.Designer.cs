
namespace AutomaticSystem
{
    partial class mdiMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblDatetime = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExpand = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnControl = new System.Windows.Forms.ToolStripButton();
            this.tbtnReport = new System.Windows.Forms.ToolStripButton();
            this.tbtnQuery = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tlblDatetime});
            this.statusStrip1.Location = new System.Drawing.Point(10, 453);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(960, 32);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(853, 27);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "ISO15066 自動化系統";
            // 
            // tlblDatetime
            // 
            this.tlblDatetime.BackColor = System.Drawing.Color.White;
            this.tlblDatetime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlblDatetime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tlblDatetime.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.tlblDatetime.Name = "tlblDatetime";
            this.tlblDatetime.Size = new System.Drawing.Size(90, 27);
            this.tlblDatetime.Text = "現在時間";
            // 
            // btnExpand
            // 
            this.btnExpand.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExpand.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExpand.Location = new System.Drawing.Point(951, 30);
            this.btnExpand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(19, 423);
            this.btnExpand.TabIndex = 11;
            this.btnExpand.Text = "<";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnControl,
            this.tbtnReport,
            this.tbtnQuery});
            this.toolStrip1.Location = new System.Drawing.Point(10, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(941, 39);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnControl
            // 
            this.tbtnControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tbtnControl.Image = global::AutomaticSystem.Properties.Resources.control;
            this.tbtnControl.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnControl.Name = "tbtnControl";
            this.tbtnControl.Size = new System.Drawing.Size(172, 36);
            this.tbtnControl.Text = "Control System";
            this.tbtnControl.Click += new System.EventHandler(this.tbtnControl_Click);
            // 
            // tbtnReport
            // 
            this.tbtnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tbtnReport.Image = global::AutomaticSystem.Properties.Resources.excel11;
            this.tbtnReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnReport.Name = "tbtnReport";
            this.tbtnReport.Size = new System.Drawing.Size(102, 36);
            this.tbtnReport.Text = "Report";
            this.tbtnReport.Click += new System.EventHandler(this.tbtnReport_Click);
            // 
            // tbtnQuery
            // 
            this.tbtnQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tbtnQuery.Image = ((System.Drawing.Image)(resources.GetObject("tbtnQuery.Image")));
            this.tbtnQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnQuery.Name = "tbtnQuery";
            this.tbtnQuery.Size = new System.Drawing.Size(98, 36);
            this.tbtnQuery.Text = "Query";
            this.tbtnQuery.Click += new System.EventHandler(this.tbtnQuery_Click);
            // 
            // mdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(980, 495);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "mdiMain";
            this.Title = "ISO15066 自動化系統";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mdiMain_Load);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.btnExpand, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tlblDatetime;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnControl;
        private System.Windows.Forms.ToolStripButton tbtnReport;
        private System.Windows.Forms.ToolStripButton tbtnQuery;
    }
}

