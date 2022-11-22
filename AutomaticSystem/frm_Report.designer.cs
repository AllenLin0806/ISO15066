
namespace AutomaticSystem
{
    partial class frm_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Report));
            this.pMain = new System.Windows.Forms.Panel();
            this.gbManual = new System.Windows.Forms.GroupBox();
            this.customBox1 = new AutomaticSystem.CustomBox();
            this.cbx10_1 = new AutomaticSystem.CustomBox();
            this.chb75SH70 = new System.Windows.Forms.CheckBox();
            this.chb60SH30 = new System.Windows.Forms.CheckBox();
            this.chb50SH30 = new System.Windows.Forms.CheckBox();
            this.chb40SH70 = new System.Windows.Forms.CheckBox();
            this.chb35SH30 = new System.Windows.Forms.CheckBox();
            this.chb30SH30 = new System.Windows.Forms.CheckBox();
            this.chb25SH70 = new System.Windows.Forms.CheckBox();
            this.chb10SH10 = new System.Windows.Forms.CheckBox();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.fbD_path = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHMI = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.txtdataID = new System.Windows.Forms.TextBox();
            this.btnDatamodify = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFS = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFT = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnNumber = new System.Windows.Forms.Button();
            this.LV2 = new System.Windows.Forms.ListView();
            this.btnUp = new System.Windows.Forms.Button();
            this.cbTester = new System.Windows.Forms.ComboBox();
            this.cbHW = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArmName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFilePath = new System.Windows.Forms.Button();
            this.btnFileplc = new System.Windows.Forms.Button();
            this.lblPlc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.gbUp = new System.Windows.Forms.GroupBox();
            this.LV1 = new System.Windows.Forms.ListView();
            this.cbLV = new System.Windows.Forms.ComboBox();
            this.btnClear2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTester2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnmodify = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHW2 = new System.Windows.Forms.TextBox();
            this.pMain.SuspendLayout();
            this.gbManual.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbData.SuspendLayout();
            this.gbUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.panel2);
            this.pMain.Controls.Add(this.gbManual);
            this.pMain.Controls.Add(this.txtPID);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(10, 30);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1360, 894);
            this.pMain.TabIndex = 68;
            // 
            // gbManual
            // 
            this.gbManual.Controls.Add(this.customBox1);
            this.gbManual.Controls.Add(this.cbx10_1);
            this.gbManual.Controls.Add(this.chb75SH70);
            this.gbManual.Controls.Add(this.chb60SH30);
            this.gbManual.Controls.Add(this.chb50SH30);
            this.gbManual.Controls.Add(this.chb40SH70);
            this.gbManual.Controls.Add(this.chb35SH30);
            this.gbManual.Controls.Add(this.chb30SH30);
            this.gbManual.Controls.Add(this.chb25SH70);
            this.gbManual.Controls.Add(this.chb10SH10);
            this.gbManual.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Bold);
            this.gbManual.Location = new System.Drawing.Point(426, 470);
            this.gbManual.Name = "gbManual";
            this.gbManual.Size = new System.Drawing.Size(611, 421);
            this.gbManual.TabIndex = 95;
            this.gbManual.TabStop = false;
            this.gbManual.Text = "Data-手動模式";
            // 
            // customBox1
            // 
            this.customBox1.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.customBox1.Location = new System.Drawing.Point(217, 101);
            this.customBox1.Name = "customBox1";
            this.customBox1.PlaceHolder = "";
            this.customBox1.Size = new System.Drawing.Size(81, 27);
            this.customBox1.TabIndex = 109;
            this.customBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbx10_1
            // 
            this.cbx10_1.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.cbx10_1.Location = new System.Drawing.Point(116, 101);
            this.cbx10_1.Name = "cbx10_1";
            this.cbx10_1.PlaceHolder = "";
            this.cbx10_1.Size = new System.Drawing.Size(81, 27);
            this.cbx10_1.TabIndex = 108;
            this.cbx10_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cbx10_1.Leave += new System.EventHandler(this.cbx10_1_Leave);
            // 
            // chb75SH70
            // 
            this.chb75SH70.AutoSize = true;
            this.chb75SH70.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.chb75SH70.Location = new System.Drawing.Point(10, 402);
            this.chb75SH70.Name = "chb75SH70";
            this.chb75SH70.Size = new System.Drawing.Size(98, 28);
            this.chb75SH70.TabIndex = 107;
            this.chb75SH70.Text = "75SH70";
            this.chb75SH70.UseVisualStyleBackColor = true;
            // 
            // chb60SH30
            // 
            this.chb60SH30.AutoSize = true;
            this.chb60SH30.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.chb60SH30.Location = new System.Drawing.Point(10, 359);
            this.chb60SH30.Name = "chb60SH30";
            this.chb60SH30.Size = new System.Drawing.Size(98, 28);
            this.chb60SH30.TabIndex = 106;
            this.chb60SH30.Text = "60SH30";
            this.chb60SH30.UseVisualStyleBackColor = true;
            // 
            // chb50SH30
            // 
            this.chb50SH30.AutoSize = true;
            this.chb50SH30.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.chb50SH30.Location = new System.Drawing.Point(10, 316);
            this.chb50SH30.Name = "chb50SH30";
            this.chb50SH30.Size = new System.Drawing.Size(98, 28);
            this.chb50SH30.TabIndex = 105;
            this.chb50SH30.Text = "50SH30";
            this.chb50SH30.UseVisualStyleBackColor = true;
            // 
            // chb40SH70
            // 
            this.chb40SH70.AutoSize = true;
            this.chb40SH70.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.chb40SH70.Location = new System.Drawing.Point(10, 273);
            this.chb40SH70.Name = "chb40SH70";
            this.chb40SH70.Size = new System.Drawing.Size(98, 28);
            this.chb40SH70.TabIndex = 104;
            this.chb40SH70.Text = "40SH70";
            this.chb40SH70.UseVisualStyleBackColor = true;
            // 
            // chb35SH30
            // 
            this.chb35SH30.AutoSize = true;
            this.chb35SH30.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.chb35SH30.Location = new System.Drawing.Point(10, 230);
            this.chb35SH30.Name = "chb35SH30";
            this.chb35SH30.Size = new System.Drawing.Size(98, 28);
            this.chb35SH30.TabIndex = 103;
            this.chb35SH30.Text = "35SH30";
            this.chb35SH30.UseVisualStyleBackColor = true;
            // 
            // chb30SH30
            // 
            this.chb30SH30.AutoSize = true;
            this.chb30SH30.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.chb30SH30.Location = new System.Drawing.Point(10, 187);
            this.chb30SH30.Name = "chb30SH30";
            this.chb30SH30.Size = new System.Drawing.Size(98, 28);
            this.chb30SH30.TabIndex = 102;
            this.chb30SH30.Text = "30SH30";
            this.chb30SH30.UseVisualStyleBackColor = true;
            // 
            // chb25SH70
            // 
            this.chb25SH70.AutoSize = true;
            this.chb25SH70.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.chb25SH70.Location = new System.Drawing.Point(10, 144);
            this.chb25SH70.Name = "chb25SH70";
            this.chb25SH70.Size = new System.Drawing.Size(98, 28);
            this.chb25SH70.TabIndex = 101;
            this.chb25SH70.Text = "25SH70";
            this.chb25SH70.UseVisualStyleBackColor = true;
            // 
            // chb10SH10
            // 
            this.chb10SH10.AutoSize = true;
            this.chb10SH10.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.chb10SH10.Location = new System.Drawing.Point(10, 101);
            this.chb10SH10.Name = "chb10SH10";
            this.chb10SH10.Size = new System.Drawing.Size(98, 28);
            this.chb10SH10.TabIndex = 100;
            this.chb10SH10.Text = "10SH10";
            this.chb10SH10.UseVisualStyleBackColor = true;
            // 
            // txtPID
            // 
            this.txtPID.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPID.Location = new System.Drawing.Point(441, 436);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(27, 25);
            this.txtPID.TabIndex = 91;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbUp);
            this.panel2.Controls.Add(this.lblHMI);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.gbData);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Controls.Add(this.cbTester);
            this.panel2.Controls.Add(this.cbHW);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtCbName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtArmName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnFilePath);
            this.panel2.Controls.Add(this.btnFileplc);
            this.panel2.Controls.Add(this.lblPlc);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtFileName);
            this.panel2.Controls.Add(this.lblFileName);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Controls.Add(this.txtPath);
            this.panel2.Controls.Add(this.lblPath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 425);
            this.panel2.TabIndex = 97;
            // 
            // lblHMI
            // 
            this.lblHMI.AutoSize = true;
            this.lblHMI.BackColor = System.Drawing.Color.PaleGreen;
            this.lblHMI.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblHMI.Location = new System.Drawing.Point(147, 274);
            this.lblHMI.Name = "lblHMI";
            this.lblHMI.Size = new System.Drawing.Size(102, 20);
            this.lblHMI.TabIndex = 209;
            this.lblHMI.Text = "HMI Version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label5.Location = new System.Drawing.Point(42, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 24);
            this.label5.TabIndex = 208;
            this.label5.Text = "HMI版本：";
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.txtdataID);
            this.gbData.Controls.Add(this.btnDatamodify);
            this.gbData.Controls.Add(this.label12);
            this.gbData.Controls.Add(this.txtFS);
            this.gbData.Controls.Add(this.label11);
            this.gbData.Controls.Add(this.txtFT);
            this.gbData.Controls.Add(this.lblType);
            this.gbData.Controls.Add(this.btnNumber);
            this.gbData.Controls.Add(this.LV2);
            this.gbData.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Bold);
            this.gbData.Location = new System.Drawing.Point(438, 2);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(611, 414);
            this.gbData.TabIndex = 207;
            this.gbData.TabStop = false;
            this.gbData.Text = "Data-正常模式";
            // 
            // txtdataID
            // 
            this.txtdataID.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtdataID.Location = new System.Drawing.Point(475, 92);
            this.txtdataID.Name = "txtdataID";
            this.txtdataID.Size = new System.Drawing.Size(30, 25);
            this.txtdataID.TabIndex = 97;
            this.txtdataID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdataID.Visible = false;
            // 
            // btnDatamodify
            // 
            this.btnDatamodify.AutoSize = true;
            this.btnDatamodify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDatamodify.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDatamodify.Enabled = false;
            this.btnDatamodify.FlatAppearance.BorderSize = 0;
            this.btnDatamodify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDatamodify.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.btnDatamodify.Location = new System.Drawing.Point(520, 92);
            this.btnDatamodify.Name = "btnDatamodify";
            this.btnDatamodify.Size = new System.Drawing.Size(88, 30);
            this.btnDatamodify.TabIndex = 96;
            this.btnDatamodify.Text = "確認修改";
            this.btnDatamodify.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 12F);
            this.label12.Location = new System.Drawing.Point(517, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 16);
            this.label12.TabIndex = 95;
            this.label12.Text = "FS：";
            // 
            // txtFS
            // 
            this.txtFS.Enabled = false;
            this.txtFS.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtFS.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFS.Location = new System.Drawing.Point(558, 57);
            this.txtFS.Name = "txtFS";
            this.txtFS.Size = new System.Drawing.Size(49, 29);
            this.txtFS.TabIndex = 94;
            this.txtFS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFS.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtFS.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 12F);
            this.label11.Location = new System.Drawing.Point(516, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 16);
            this.label11.TabIndex = 93;
            this.label11.Text = "FT：";
            // 
            // txtFT
            // 
            this.txtFT.Enabled = false;
            this.txtFT.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtFT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFT.Location = new System.Drawing.Point(558, 23);
            this.txtFT.Name = "txtFT";
            this.txtFT.Size = new System.Drawing.Size(49, 29);
            this.txtFT.TabIndex = 92;
            this.txtFT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFT.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtFT.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.SkyBlue;
            this.lblType.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.lblType.Location = new System.Drawing.Point(242, 80);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(69, 28);
            this.lblType.TabIndex = 91;
            this.lblType.Text = "None";
            // 
            // btnNumber
            // 
            this.btnNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNumber.FlatAppearance.BorderSize = 0;
            this.btnNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNumber.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNumber.Image = ((System.Drawing.Image)(resources.GetObject("btnNumber.Image")));
            this.btnNumber.Location = new System.Drawing.Point(3, 89);
            this.btnNumber.Name = "btnNumber";
            this.btnNumber.Size = new System.Drawing.Size(35, 38);
            this.btnNumber.TabIndex = 90;
            this.btnNumber.UseVisualStyleBackColor = true;
            // 
            // LV2
            // 
            this.LV2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LV2.Enabled = false;
            this.LV2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LV2.FullRowSelect = true;
            this.LV2.GridLines = true;
            this.LV2.HideSelection = false;
            this.LV2.Location = new System.Drawing.Point(3, 128);
            this.LV2.Name = "LV2";
            this.LV2.Size = new System.Drawing.Size(605, 283);
            this.LV2.TabIndex = 89;
            this.LV2.UseCompatibleStateImageBehavior = false;
            this.LV2.View = System.Windows.Forms.View.Details;
            // 
            // btnUp
            // 
            this.btnUp.AutoSize = true;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnUp.Location = new System.Drawing.Point(187, 379);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(67, 34);
            this.btnUp.TabIndex = 202;
            this.btnUp.Text = "進階";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // cbTester
            // 
            this.cbTester.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cbTester.FormattingEnabled = true;
            this.cbTester.Location = new System.Drawing.Point(148, 228);
            this.cbTester.Name = "cbTester";
            this.cbTester.Size = new System.Drawing.Size(112, 28);
            this.cbTester.TabIndex = 191;
            // 
            // cbHW
            // 
            this.cbHW.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cbHW.FormattingEnabled = true;
            this.cbHW.Location = new System.Drawing.Point(149, 23);
            this.cbHW.Name = "cbHW";
            this.cbHW.Size = new System.Drawing.Size(83, 28);
            this.cbHW.TabIndex = 187;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label7.Location = new System.Drawing.Point(47, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 24);
            this.label7.TabIndex = 206;
            this.label7.Text = "HW版本：";
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(259, 379);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 34);
            this.btnClear.TabIndex = 203;
            this.btnClear.Text = "全部清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label6.Location = new System.Drawing.Point(61, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 24);
            this.label6.TabIndex = 204;
            this.label6.Text = "Tester：";
            // 
            // txtCbName
            // 
            this.txtCbName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtCbName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCbName.Location = new System.Drawing.Point(148, 187);
            this.txtCbName.Name = "txtCbName";
            this.txtCbName.Size = new System.Drawing.Size(225, 29);
            this.txtCbName.TabIndex = 190;
            this.txtCbName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtCbName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label4.Location = new System.Drawing.Point(22, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 24);
            this.label4.TabIndex = 200;
            this.label4.Text = "電控箱名稱：";
            // 
            // txtArmName
            // 
            this.txtArmName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtArmName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtArmName.Location = new System.Drawing.Point(148, 146);
            this.txtArmName.Name = "txtArmName";
            this.txtArmName.Size = new System.Drawing.Size(225, 29);
            this.txtArmName.TabIndex = 189;
            this.txtArmName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtArmName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label3.Location = new System.Drawing.Point(7, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 24);
            this.label3.TabIndex = 199;
            this.label3.Text = "手臂名稱/SN：";
            // 
            // btnFilePath
            // 
            this.btnFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFilePath.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFilePath.FlatAppearance.BorderSize = 0;
            this.btnFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilePath.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnFilePath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFilePath.Image = ((System.Drawing.Image)(resources.GetObject("btnFilePath.Image")));
            this.btnFilePath.Location = new System.Drawing.Point(384, 99);
            this.btnFilePath.Name = "btnFilePath";
            this.btnFilePath.Size = new System.Drawing.Size(35, 38);
            this.btnFilePath.TabIndex = 198;
            this.btnFilePath.UseVisualStyleBackColor = true;
            this.btnFilePath.Click += new System.EventHandler(this.btnFilePath_Click);
            // 
            // btnFileplc
            // 
            this.btnFileplc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFileplc.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFileplc.FlatAppearance.BorderSize = 0;
            this.btnFileplc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileplc.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnFileplc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFileplc.Image = ((System.Drawing.Image)(resources.GetObject("btnFileplc.Image")));
            this.btnFileplc.Location = new System.Drawing.Point(383, 60);
            this.btnFileplc.Name = "btnFileplc";
            this.btnFileplc.Size = new System.Drawing.Size(35, 38);
            this.btnFileplc.TabIndex = 197;
            this.btnFileplc.UseVisualStyleBackColor = true;
            this.btnFileplc.Click += new System.EventHandler(this.btnFileplc_Click);
            // 
            // lblPlc
            // 
            this.lblPlc.AutoSize = true;
            this.lblPlc.BackColor = System.Drawing.Color.Gray;
            this.lblPlc.Font = new System.Drawing.Font("微軟正黑體", 10.5F);
            this.lblPlc.Location = new System.Drawing.Point(149, 68);
            this.lblPlc.Name = "lblPlc";
            this.lblPlc.Size = new System.Drawing.Size(78, 18);
            this.lblPlc.TabIndex = 196;
            this.lblPlc.Text = "請選擇公版";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label2.Location = new System.Drawing.Point(42, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 195;
            this.label2.Text = "文件公版：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(379, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 201;
            this.label1.Text = ".xlsx";
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtFileName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFileName.Location = new System.Drawing.Point(148, 308);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(225, 29);
            this.txtFileName.TabIndex = 192;
            this.txtFileName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtFileName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.lblFileName.Location = new System.Drawing.Point(41, 310);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(105, 24);
            this.lblFileName.TabIndex = 194;
            this.lblFileName.Text = "檔案名稱：";
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(352, 379);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(67, 34);
            this.btnStart.TabIndex = 205;
            this.btnStart.Text = "確認";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtPath.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPath.Location = new System.Drawing.Point(148, 104);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(225, 29);
            this.txtPath.TabIndex = 188;
            this.txtPath.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtPath.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.lblPath.Location = new System.Drawing.Point(41, 106);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(105, 24);
            this.lblPath.TabIndex = 193;
            this.lblPath.Text = "檔案路徑：";
            // 
            // gbUp
            // 
            this.gbUp.Controls.Add(this.LV1);
            this.gbUp.Controls.Add(this.cbLV);
            this.gbUp.Controls.Add(this.btnClear2);
            this.gbUp.Controls.Add(this.btnClose);
            this.gbUp.Controls.Add(this.btnOK);
            this.gbUp.Controls.Add(this.txtTester2);
            this.gbUp.Controls.Add(this.label10);
            this.gbUp.Controls.Add(this.btnDelete);
            this.gbUp.Controls.Add(this.btnAdd);
            this.gbUp.Controls.Add(this.btnmodify);
            this.gbUp.Controls.Add(this.label8);
            this.gbUp.Controls.Add(this.txtHW2);
            this.gbUp.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Bold);
            this.gbUp.Location = new System.Drawing.Point(1055, 2);
            this.gbUp.Name = "gbUp";
            this.gbUp.Size = new System.Drawing.Size(293, 414);
            this.gbUp.TabIndex = 210;
            this.gbUp.TabStop = false;
            this.gbUp.Text = "新增資訊";
            this.gbUp.Visible = false;
            // 
            // LV1
            // 
            this.LV1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LV1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LV1.FullRowSelect = true;
            this.LV1.GridLines = true;
            this.LV1.HideSelection = false;
            this.LV1.Location = new System.Drawing.Point(3, 272);
            this.LV1.Name = "LV1";
            this.LV1.Size = new System.Drawing.Size(287, 139);
            this.LV1.TabIndex = 89;
            this.LV1.UseCompatibleStateImageBehavior = false;
            this.LV1.View = System.Windows.Forms.View.Details;
            // 
            // cbLV
            // 
            this.cbLV.Font = new System.Drawing.Font("新細明體", 12F);
            this.cbLV.FormattingEnabled = true;
            this.cbLV.Location = new System.Drawing.Point(3, 240);
            this.cbLV.Name = "cbLV";
            this.cbLV.Size = new System.Drawing.Size(78, 24);
            this.cbLV.TabIndex = 81;
            // 
            // btnClear2
            // 
            this.btnClear2.AutoSize = true;
            this.btnClear2.BackColor = System.Drawing.Color.Pink;
            this.btnClear2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear2.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClear2.FlatAppearance.BorderSize = 0;
            this.btnClear2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear2.Location = new System.Drawing.Point(186, 69);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(84, 31);
            this.btnClear2.TabIndex = 64;
            this.btnClear2.Text = "全部清除";
            this.btnClear2.UseVisualStyleBackColor = false;
            this.btnClear2.Click += new System.EventHandler(this.btnClear2_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(235, 235);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 31);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "返回";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOK.Location = new System.Drawing.Point(173, 235);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 31);
            this.btnOK.TabIndex = 66;
            this.btnOK.Text = "確認";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTester2
            // 
            this.txtTester2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtTester2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTester2.Location = new System.Drawing.Point(120, 185);
            this.txtTester2.Name = "txtTester2";
            this.txtTester2.Size = new System.Drawing.Size(98, 29);
            this.txtTester2.TabIndex = 67;
            this.txtTester2.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtTester2.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(32, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 25);
            this.label10.TabIndex = 83;
            this.label10.Text = "Tester：";
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Plum;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(127, 69);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 31);
            this.btnDelete.TabIndex = 63;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAdd.Location = new System.Drawing.Point(11, 69);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 31);
            this.btnAdd.TabIndex = 61;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnmodify
            // 
            this.btnmodify.AutoSize = true;
            this.btnmodify.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnmodify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnmodify.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnmodify.FlatAppearance.BorderSize = 0;
            this.btnmodify.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnmodify.Location = new System.Drawing.Point(69, 69);
            this.btnmodify.Name = "btnmodify";
            this.btnmodify.Size = new System.Drawing.Size(56, 31);
            this.btnmodify.TabIndex = 62;
            this.btnmodify.Text = "修改";
            this.btnmodify.UseVisualStyleBackColor = false;
            this.btnmodify.Click += new System.EventHandler(this.btnmodify_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(13, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 25);
            this.label8.TabIndex = 64;
            this.label8.Text = "HW版本：";
            // 
            // txtHW2
            // 
            this.txtHW2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtHW2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtHW2.Location = new System.Drawing.Point(120, 142);
            this.txtHW2.Name = "txtHW2";
            this.txtHW2.Size = new System.Drawing.Size(69, 29);
            this.txtHW2.TabIndex = 65;
            this.txtHW2.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtHW2.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // frm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 934);
            this.Controls.Add(this.pMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Title = "報告製作";
            this.Load += new System.EventHandler(this.frm_Report_Load);
            this.Controls.SetChildIndex(this.pMain, 0);
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            this.gbManual.ResumeLayout(false);
            this.gbManual.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.gbUp.ResumeLayout(false);
            this.gbUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.FolderBrowserDialog fbD_path;
        private System.Windows.Forms.GroupBox gbManual;
        private System.Windows.Forms.CheckBox chb75SH70;
        private System.Windows.Forms.CheckBox chb60SH30;
        private System.Windows.Forms.CheckBox chb50SH30;
        private System.Windows.Forms.CheckBox chb40SH70;
        private System.Windows.Forms.CheckBox chb35SH30;
        private System.Windows.Forms.CheckBox chb30SH30;
        private System.Windows.Forms.CheckBox chb25SH70;
        private System.Windows.Forms.CheckBox chb10SH10;
        private CustomBox cbx10_1;
        private CustomBox customBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbUp;
        private System.Windows.Forms.ListView LV1;
        private System.Windows.Forms.ComboBox cbLV;
        private System.Windows.Forms.Button btnClear2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtTester2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnmodify;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHW2;
        public System.Windows.Forms.Label lblHMI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.TextBox txtdataID;
        private System.Windows.Forms.Button btnDatamodify;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFT;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnNumber;
        private System.Windows.Forms.ListView LV2;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ComboBox cbTester;
        private System.Windows.Forms.ComboBox cbHW;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArmName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFilePath;
        private System.Windows.Forms.Button btnFileplc;
        private System.Windows.Forms.Label lblPlc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
    }
}

