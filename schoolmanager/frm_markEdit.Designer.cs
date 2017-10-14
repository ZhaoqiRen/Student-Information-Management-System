namespace myCode
{
    partial class frm_markEdit
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
            this.cmdDelData = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdAddNew = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdDelData
            // 
            this.cmdDelData.Location = new System.Drawing.Point(187, 11);
            this.cmdDelData.Name = "cmdDelData";
            this.cmdDelData.Size = new System.Drawing.Size(64, 23);
            this.cmdDelData.TabIndex = 58;
            this.cmdDelData.Text = "删除(&D)";
            this.cmdDelData.UseVisualStyleBackColor = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(263, 11);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 55;
            this.cmdClose.Text = "关闭(&C)";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(100, 11);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 57;
            this.cmdSave.Text = "保存(&S)";
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // cmdAddNew
            // 
            this.cmdAddNew.Location = new System.Drawing.Point(13, 11);
            this.cmdAddNew.Name = "cmdAddNew";
            this.cmdAddNew.Size = new System.Drawing.Size(75, 23);
            this.cmdAddNew.TabIndex = 56;
            this.cmdAddNew.Text = "添加(&A)";
            this.cmdAddNew.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(145, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(135, 21);
            this.textBox2.TabIndex = 48;
            this.textBox2.Tag = "1";
            this.textBox2.Text = "STUDENTID";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(81, 70);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(77, 12);
            this.Label2.TabIndex = 47;
            this.Label2.Text = "STUDENTID(*)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(145, 117);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(135, 21);
            this.textBox3.TabIndex = 50;
            this.textBox3.Tag = "";
            this.textBox3.Text = "STUDENTName";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(81, 123);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(71, 12);
            this.Label3.TabIndex = 49;
            this.Label3.Text = "STUDENTName";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(145, 88);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(135, 21);
            this.textBox4.TabIndex = 52;
            this.textBox4.Tag = "";
            this.textBox4.Text = "score";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(81, 94);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(35, 12);
            this.Label4.TabIndex = 51;
            this.Label4.Text = "score";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(145, 141);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(135, 21);
            this.textBox5.TabIndex = 54;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(81, 147);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(65, 12);
            this.Label5.TabIndex = 53;
            this.Label5.Text = "ADDDATE(*)";
            // 
            // frm_markEdit
            // 
            this.ClientSize = new System.Drawing.Size(406, 222);
            this.Controls.Add(this.cmdDelData);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdAddNew);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.Label5);
            this.Name = "frm_markEdit";
            this.Text = "批改作业";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdDelData;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.Button cmdAddNew;
		
		internal System.Windows.Forms.Label Label2;
		 
        internal System.Windows.Forms.TextBox textBox2;
		
		internal System.Windows.Forms.Label Label3;
		 
        internal System.Windows.Forms.TextBox textBox3;
		
		internal System.Windows.Forms.Label Label4;
		 
        internal System.Windows.Forms.TextBox textBox4;
		
		internal System.Windows.Forms.Label Label5;
		 
        internal System.Windows.Forms.DateTimePicker textBox5;
		
       
    }
}
