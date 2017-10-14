namespace PositionManage
{
    partial class dingwei
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dingwei));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPosition = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPosition = new System.Windows.Forms.TabPage();
            this.panMap = new System.Windows.Forms.Panel();
            this.contextMenuStripPic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemVaryImg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemAddLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.lbLocation = new System.Windows.Forms.Label();
            this.tabData = new System.Windows.Forms.TabPage();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.colDataNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTagNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSignalStrength1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSignalStrength2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferNo3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSignalStrength3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.操场定位系统 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPosition.SuspendLayout();
            this.panMap.SuspendLayout();
            this.contextMenuStripPic.SuspendLayout();
            this.tabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(17, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 466);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnPosition);
            this.groupBox3.Location = new System.Drawing.Point(554, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 297);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "添加";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(112, 267);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(124, 21);
            this.textBox4.TabIndex = 17;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(112, 240);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(124, 21);
            this.textBox3.TabIndex = 16;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "当前时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "起始时间:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "初始化模式";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 145);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 21);
            this.textBox2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "定位人员：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "显示定位信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 213);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "所在场地：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnPosition
            // 
            this.btnPosition.Location = new System.Drawing.Point(26, 39);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(210, 27);
            this.btnPosition.TabIndex = 6;
            this.btnPosition.Text = "开始定位";
            this.btnPosition.UseVisualStyleBackColor = true;
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPosition);
            this.tabControl1.Controls.Add(this.tabData);
            this.tabControl1.Location = new System.Drawing.Point(21, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 450);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // tabPosition
            // 
            this.tabPosition.Controls.Add(this.panMap);
            this.tabPosition.Location = new System.Drawing.Point(4, 22);
            this.tabPosition.Name = "tabPosition";
            this.tabPosition.Padding = new System.Windows.Forms.Padding(3);
            this.tabPosition.Size = new System.Drawing.Size(525, 424);
            this.tabPosition.TabIndex = 0;
            this.tabPosition.Text = "定位地图";
            this.tabPosition.UseVisualStyleBackColor = true;
            // 
            // panMap
            // 
            this.panMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panMap.ContextMenuStrip = this.contextMenuStripPic;
            this.panMap.Controls.Add(this.lbLocation);
            this.panMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMap.Location = new System.Drawing.Point(3, 3);
            this.panMap.Name = "panMap";
            this.panMap.Size = new System.Drawing.Size(519, 418);
            this.panMap.TabIndex = 0;
            this.panMap.Paint += new System.Windows.Forms.PaintEventHandler(this.panMap_Paint);
            this.panMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panMap_MouseMove);
            // 
            // contextMenuStripPic
            // 
            this.contextMenuStripPic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemVaryImg,
            this.tsMenuItemAddLocation,
            this.tsMenuItemImport});
            this.contextMenuStripPic.Name = "contextMenuStripPic";
            this.contextMenuStripPic.Size = new System.Drawing.Size(149, 70);
            // 
            // tsMenuItemVaryImg
            // 
            this.tsMenuItemVaryImg.Name = "tsMenuItemVaryImg";
            this.tsMenuItemVaryImg.Size = new System.Drawing.Size(148, 22);
            this.tsMenuItemVaryImg.Text = "变更地图";
            this.tsMenuItemVaryImg.Click += new System.EventHandler(this.tsMenuItemVaryImg_Click);
            // 
            // tsMenuItemAddLocation
            // 
            this.tsMenuItemAddLocation.Name = "tsMenuItemAddLocation";
            this.tsMenuItemAddLocation.Size = new System.Drawing.Size(148, 22);
            this.tsMenuItemAddLocation.Text = "添加参考点";
            this.tsMenuItemAddLocation.Click += new System.EventHandler(this.tsMenuItemAddLocation_Click);
            // 
            // tsMenuItemImport
            // 
            this.tsMenuItemImport.Name = "tsMenuItemImport";
            this.tsMenuItemImport.Size = new System.Drawing.Size(148, 22);
            this.tsMenuItemImport.Text = "导入样点数据";
            this.tsMenuItemImport.Click += new System.EventHandler(this.tsMenuItemImport_Click);
            // 
            // lbLocation
            // 
            this.lbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(408, 404);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(41, 12);
            this.lbLocation.TabIndex = 4;
            this.lbLocation.Text = "坐标：";
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.dgData);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(525, 424);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "后台数据";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDataNo,
            this.colTagNo,
            this.colReferNo1,
            this.colSignalStrength1,
            this.colReferNo2,
            this.colSignalStrength2,
            this.colReferNo3,
            this.colSignalStrength3,
            this.colDataTime});
            this.dgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgData.Location = new System.Drawing.Point(3, 3);
            this.dgData.Name = "dgData";
            this.dgData.ReadOnly = true;
            this.dgData.RowHeadersVisible = false;
            this.dgData.RowTemplate.Height = 23;
            this.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgData.Size = new System.Drawing.Size(519, 418);
            this.dgData.TabIndex = 0;
            // 
            // colDataNo
            // 
            this.colDataNo.DataPropertyName = "RowNo";
            this.colDataNo.FillWeight = 60F;
            this.colDataNo.HeaderText = "序号";
            this.colDataNo.Name = "colDataNo";
            this.colDataNo.ReadOnly = true;
            this.colDataNo.Width = 60;
            // 
            // colTagNo
            // 
            this.colTagNo.DataPropertyName = "TagNo";
            this.colTagNo.FillWeight = 80F;
            this.colTagNo.HeaderText = "标签编号";
            this.colTagNo.Name = "colTagNo";
            this.colTagNo.ReadOnly = true;
            this.colTagNo.Width = 80;
            // 
            // colReferNo1
            // 
            this.colReferNo1.DataPropertyName = "ReferNo1";
            this.colReferNo1.FillWeight = 80F;
            this.colReferNo1.HeaderText = "参考点1";
            this.colReferNo1.Name = "colReferNo1";
            this.colReferNo1.ReadOnly = true;
            this.colReferNo1.Width = 80;
            // 
            // colSignalStrength1
            // 
            this.colSignalStrength1.DataPropertyName = "Distance1";
            this.colSignalStrength1.FillWeight = 60F;
            this.colSignalStrength1.HeaderText = "强度1";
            this.colSignalStrength1.Name = "colSignalStrength1";
            this.colSignalStrength1.ReadOnly = true;
            this.colSignalStrength1.Width = 60;
            // 
            // colReferNo2
            // 
            this.colReferNo2.DataPropertyName = "ReferNo2";
            this.colReferNo2.FillWeight = 80F;
            this.colReferNo2.HeaderText = "参考点2";
            this.colReferNo2.Name = "colReferNo2";
            this.colReferNo2.ReadOnly = true;
            this.colReferNo2.Width = 80;
            // 
            // colSignalStrength2
            // 
            this.colSignalStrength2.DataPropertyName = "Distance2";
            this.colSignalStrength2.FillWeight = 60F;
            this.colSignalStrength2.HeaderText = "强度2";
            this.colSignalStrength2.Name = "colSignalStrength2";
            this.colSignalStrength2.ReadOnly = true;
            this.colSignalStrength2.Width = 60;
            // 
            // colReferNo3
            // 
            this.colReferNo3.DataPropertyName = "ReferNo3";
            this.colReferNo3.FillWeight = 80F;
            this.colReferNo3.HeaderText = "参考点3";
            this.colReferNo3.Name = "colReferNo3";
            this.colReferNo3.ReadOnly = true;
            this.colReferNo3.Width = 80;
            // 
            // colSignalStrength3
            // 
            this.colSignalStrength3.DataPropertyName = "Distance3";
            this.colSignalStrength3.FillWeight = 60F;
            this.colSignalStrength3.HeaderText = "强度3";
            this.colSignalStrength3.Name = "colSignalStrength3";
            this.colSignalStrength3.ReadOnly = true;
            this.colSignalStrength3.Width = 60;
            // 
            // colDataTime
            // 
            this.colDataTime.DataPropertyName = "ReadDate";
            dataGridViewCellStyle1.Format = "T";
            dataGridViewCellStyle1.NullValue = null;
            this.colDataTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDataTime.HeaderText = "数据时间";
            this.colDataTime.Name = "colDataTime";
            this.colDataTime.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDisconnect);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.tbPort);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbIP);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(554, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 125);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "连接";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(161, 94);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(26, 94);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // 操场定位系统
            // 
            this.操场定位系统.AutoSize = true;
            this.操场定位系统.BackColor = System.Drawing.Color.Transparent;
            this.操场定位系统.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.操场定位系统.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.操场定位系统.Location = new System.Drawing.Point(12, 9);
            this.操场定位系统.Name = "操场定位系统";
            this.操场定位系统.Size = new System.Drawing.Size(199, 29);
            this.操场定位系统.TabIndex = 2;
            this.操场定位系统.Text = "操场定位系统";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "接收器IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口号:";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(89, 20);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(173, 21);
            this.tbIP.TabIndex = 1;
            this.tbIP.TextChanged += new System.EventHandler(this.tbIP_TextChanged);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(89, 57);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(64, 21);
            this.tbPort.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(181, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "配置设备";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "姓名：";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(112, 180);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(124, 21);
            this.textBox5.TabIndex = 20;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // dingwei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::PositionManage.Properties.Resources._111;
            this.ClientSize = new System.Drawing.Size(859, 536);
            this.Controls.Add(this.操场定位系统);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "dingwei";
            this.ShowIcon = false;
            this.Text = "定位程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPosition.ResumeLayout(false);
            this.panMap.ResumeLayout(false);
            this.panMap.PerformLayout();
            this.contextMenuStripPic.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPosition;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPosition;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.Panel panMap;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPic;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemVaryImg;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemAddLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSignalStrength1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSignalStrength2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferNo3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSignalStrength3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataTime;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemImport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label 操场定位系统;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
    }
}

