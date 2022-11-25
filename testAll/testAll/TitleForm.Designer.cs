namespace testAll
{
    partial class TitleForm
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
            this.titlepanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.titlelabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titlepanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlepanel
            // 
            this.titlepanel.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.titlepanel.Controls.Add(this.button2);
            this.titlepanel.Controls.Add(this.titlelabel);
            this.titlepanel.Controls.Add(this.button3);
            this.titlepanel.Controls.Add(this.button1);
            this.titlepanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlepanel.Location = new System.Drawing.Point(0, 0);
            this.titlepanel.Name = "titlepanel";
            this.titlepanel.Size = new System.Drawing.Size(800, 30);
            this.titlepanel.TabIndex = 4;
            this.titlepanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.titlepanel_ControlAdded);
            this.titlepanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.titlepanel_ControlRemoved);
            this.titlepanel.DoubleClick += new System.EventHandler(this.Titlepanel_DoubleClick);
            this.titlepanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Titlepanel_MouseDown);
            this.titlepanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Titlepanel_MouseMove);
            this.titlepanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Titlepanel_MouseUp);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.button2.Image = global::testAll.Properties.Resources.icons8_rounded_square_16;
            this.button2.Location = new System.Drawing.Point(744, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 2;
            this.button2.Tag = "max";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Titlebutton_Click);
            this.button2.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.titlelabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.titlelabel.Location = new System.Drawing.Point(9, 5);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(28, 21);
            this.titlelabel.TabIndex = 3;
            this.titlelabel.Text = "HI";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.button3.Image = global::testAll.Properties.Resources.icons8_minus_16;
            this.button3.Location = new System.Drawing.Point(716, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 23);
            this.button3.TabIndex = 2;
            this.button3.Tag = "min";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Titlebutton_Click);
            this.button3.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.button1.Image = global::testAll.Properties.Resources.icons8_multiply;
            this.button1.Location = new System.Drawing.Point(770, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Titlebutton_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 440);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(790, 10);
            this.panel4.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(790, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 420);
            this.panel3.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 410);
            this.panel1.TabIndex = 7;
            // 
            // TitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.titlepanel);
            this.Name = "TitleForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.titlepanel.ResumeLayout(false);
            this.titlepanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel titlepanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
    }
}

