using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace schoolmanager
{

    public partial class frm_markEdit : Form
    {

        private static ReaderHandle _reader;
        private static bool _isConnected = false;
        internal Button button1;
        internal Button button2;
        private Label 批改作业;
        private static string _comPort;

        public static ReaderHandle Reader
        {
            set { _reader = value; }
            get { return _reader; }
        }

        public static bool IsConnected
        {
            set { _isConnected = value; }
            get { return _isConnected; }
        }

        public static string ComPort
        {
            set { _comPort = value; }
            get { return _comPort; }
        }


        public frm_markEdit()
        {
            InitializeComponent();
        }
        string strSql;
        string strWhereID;

        string STUDENTID;
        string STUDENTName;
        string score;
        internal Button cmdDelData;
        internal Button cmdClose;
        internal Button cmdSave;
        internal Button cmdAddNew;
        internal TextBox textBox2;
        internal Label Label2;
        internal TextBox textBox3;
        internal Label Label3;
        internal TextBox textBox4;
        internal Label Label4;
        internal DateTimePicker textBox5;
        internal Label Label5;
        string ADDDATE;
        //定义字段变量
        //赋值检测数据
        public bool isChkValuse()
        {




            if (textBox2.Text.Trim() == "")
            {
                // -------------------STUDENTID             
                MessageBox.Show("必填项 学号 不能为空!");
                textBox2.Focus();
                return false;
            }



            if (textBox3.Text.Trim() == "")
            {
                // -------------------STUDENTName             
                MessageBox.Show("必填项 学生姓名 不能为空!");
                textBox3.Focus();
                return false;
            }

            if (textBox4.Text.Trim() == "")
            {
                // -------------------score             
                MessageBox.Show("必填项 成绩 不能为空!");
                textBox4.Focus();
                return false;
            }

            //赋值变量
            STUDENTID = textBox2.Text.Trim().Replace("'", "''");
            STUDENTName = textBox3.Text.Trim().Replace("'", "''");
            score = textBox4.Text.Trim().Replace("'", "''");
            ADDDATE = textBox5.Value.ToString("yyyy-MM-dd").Replace("'", "''");

            return true;
        }

        //清空控件为初始状态
        public void ClearCtl()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Value = DateTime.Now;

        }

        public void cmdClose_Click(System.Object sender, System.EventArgs e)
        {
            //关闭按钮
            Close();
        }


        public void cmdDelData_Click(System.Object sender, System.EventArgs e)
        {

            //删除按钮

            DataAccess.sql_command("delete from mark" + strWhereID);
            cmdClose_Click(null, null);
        }

        public void cmdSave_Click(System.Object sender, System.EventArgs e)
        {

            //编辑
            if (isChkValuse() == true)
            {
                //检查必填项




                strSql = "Update mark set STUDENTID ='" + STUDENTID + "' ,STUDENTName ='" + STUDENTName + "' ,score ='" + score + "' ,ADDDATE ='" + ADDDATE + "' " + strWhereID;
                DataAccess.sql_command(strSql);
                cmdClose_Click(null, null);
            }
        }

        public void cmdAddNew_Click(System.Object sender, System.EventArgs e)
        {

            //新增
            if (isChkValuse() == true)
            {

                //若今天 有成绩 就删除 已经存在的记录 新增记录


                string strSql = "Select ID From mark where  STUDENTID='" + STUDENTID + "' and ADDDATE='" + ADDDATE + "'";
                //查询表查询 学号 和 日期  看看 是否记录
                DataTable tb = DataAccess.GetDataSetBySql(strSql).Tables[0];


                if (tb.Rows.Count != 0)
                {//有记录  清除记录
                    DataAccess.sql_command("delete     From mark where  STUDENTID='" + STUDENTID + "' and ADDDATE='" + ADDDATE + "'");
                }




                strSql = "Insert into  mark (STUDENTID,STUDENTName,score,ADDDATE)values('" + STUDENTID + "','" + STUDENTName + "','" + score + "','" + ADDDATE + "')";
                DataAccess.sql_command(strSql);


                cmdClose_Click(null, null);
            }
        }


        public void frm_markEdit_Load(System.Object sender, System.EventArgs e)
        {
            硬件连接();
            textBox5.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //当期日期

            if (this.Tag + "" != "")
            {//若是编辑模式

                cmdSave.Enabled = true;
                cmdAddNew.Enabled = false;
                cmdDelData.Enabled = true;
            }

            else
            {//新增时
                ClearCtl();
                cmdSave.Enabled = false;
                cmdDelData.Enabled = false;
                cmdAddNew.Enabled = true;

                return;
            }
            strWhereID = "";

            strWhereID = "	where ID=" + this.Tag; //查询对应的记录
            //构造查询条件
            strSql = "select * from  mark" + strWhereID;
            DataTable tb = DataAccess.GetDataSetBySql(strSql).Tables[0];

            if (tb.Rows.Count > 0)
            {
                //若有记录 ,给控件赋值
                DataRow row = tb.Rows[0]; //得到第一行记录控件赋值
                STUDENTID = row["STUDENTID"].ToString().Trim();
                STUDENTName = row["STUDENTName"].ToString().Trim();
                score = row["score"].ToString().Trim();
                ADDDATE = row["ADDDATE"].ToString().Trim();

                textBox2.Text = STUDENTID;
                textBox3.Text = STUDENTName;
                textBox4.Text = score;
                textBox5.Value = System.Convert.ToDateTime(ADDDATE);

            }
        }
        #region 初始化
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.批改作业 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdDelData
            // 
            this.cmdDelData.Location = new System.Drawing.Point(226, 57);
            this.cmdDelData.Name = "cmdDelData";
            this.cmdDelData.Size = new System.Drawing.Size(64, 23);
            this.cmdDelData.TabIndex = 58;
            this.cmdDelData.Text = "删除(&D)";
            this.cmdDelData.UseVisualStyleBackColor = true;
            this.cmdDelData.Click += new System.EventHandler(this.cmdDelData_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(305, 57);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 55;
            this.cmdClose.Text = "关闭(&C)";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(145, 57);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 57;
            this.cmdSave.Text = "保存(&S)";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdAddNew
            // 
            this.cmdAddNew.Location = new System.Drawing.Point(59, 57);
            this.cmdAddNew.Name = "cmdAddNew";
            this.cmdAddNew.Size = new System.Drawing.Size(75, 23);
            this.cmdAddNew.TabIndex = 56;
            this.cmdAddNew.Text = "添加(&A)";
            this.cmdAddNew.UseVisualStyleBackColor = true;
            this.cmdAddNew.Click += new System.EventHandler(this.cmdAddNew_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(145, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(135, 21);
            this.textBox2.TabIndex = 48;
            this.textBox2.Tag = "1";
            this.textBox2.Text = "STUDENTID";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(81, 97);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(29, 12);
            this.Label2.TabIndex = 47;
            this.Label2.Text = "学号";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(145, 121);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(135, 21);
            this.textBox3.TabIndex = 50;
            this.textBox3.Tag = "";
            this.textBox3.Text = "STUDENTName";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Location = new System.Drawing.Point(68, 124);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(53, 12);
            this.Label3.TabIndex = 49;
            this.Label3.Text = "学生姓名";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(145, 144);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(135, 21);
            this.textBox4.TabIndex = 52;
            this.textBox4.Tag = "";
            this.textBox4.Text = "score";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Location = new System.Drawing.Point(81, 150);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(29, 12);
            this.Label4.TabIndex = 51;
            this.Label4.Text = "成绩";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(145, 171);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(135, 21);
            this.textBox5.TabIndex = 54;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Location = new System.Drawing.Point(68, 177);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(53, 12);
            this.Label5.TabIndex = 53;
            this.Label5.Text = "加入时间";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 56;
            this.button1.Text = "读取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 56;
            this.button2.Text = "写入用户区";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 批改作业
            // 
            this.批改作业.AutoSize = true;
            this.批改作业.BackColor = System.Drawing.Color.Transparent;
            this.批改作业.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.批改作业.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.批改作业.Location = new System.Drawing.Point(12, 9);
            this.批改作业.Name = "批改作业";
            this.批改作业.Size = new System.Drawing.Size(137, 29);
            this.批改作业.TabIndex = 59;
            this.批改作业.Text = "批改作业";
            // 
            // frm_markEdit
            // 
            this.BackgroundImage = global::schoolmanager.Properties.Resources._123;
            this.ClientSize = new System.Drawing.Size(406, 265);
            this.Controls.Add(this.批改作业);
            this.Controls.Add(this.cmdDelData);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_markEdit_FormClosed);
            this.Load += new System.EventHandler(this.frm_markEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion



        //----------------------------硬件


        // 连接读写器
        private void Connect()
        {
            if (_reader == null)
            {
                _reader = new ReaderHandle();

                _isConnected = _reader.Connect();
            }

            if (!_isConnected)
            {
                MessageBox.Show("读写器连接失败");
            }
            else
            {
                MessageBox.Show("读写器连接成功");
            }

        }

        // 关闭读写器
        private void 关闭读写器()
        {
            if (_reader != null)
            {
                _reader.DisConnect();
                _isConnected = false;
                _reader = null;
            }
        }


        // 读取epc编号
        private string 读取epc编号()
        {
            return _reader.ReadEpc();
        }

        // 写入EPC编号
        private void 写入EPC编号(string s)
        {
            bool writeStatus = _reader.WriteEpc(s.Trim());
            if (writeStatus)
            {
                MessageBox.Show("EPC写入成功");
            }

        }

        //读TID
        private string 读TID()
        {
            return _reader.ReadTID();
        }

        // 写用户区
        private void 写用户区(string s)
        {
            string hexecp = _reader.ReadEpc();

            //起始位置 0   写入2 位   不足两位  用0 填充

          s = String.Format("{0:00}", Int32.Parse(s));
            if (_reader.WriteUserData(hexecp,0,  s))
            {
                MessageBox.Show("用户区写入成功");
            }
            else
            {
                MessageBox.Show("用户区写入失败");
            }
        }

        // 读用户区
        private string 读用户区()
        {



            string hexecp = _reader.ReadEpc();
            //起始位置 0   写入2 位   不足两位  用0 填充
            string ss = _reader.ReadUserData(hexecp, "0", "2");
            ss = ss.Substring(0, 2);
            //强制取2位值
            try
            {
                ss = Int32.Parse(ss).ToString();
                //去掉1位数字前面的0
            }
            catch
            {
                ss = "-1";
            }

            return ss;
        }


        private void 硬件连接()
        {
            _reader = null;
            //txbEpc.Text = "";
            Connect();
        }

        private void frm_markEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            关闭读写器();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sEPC = 读取epc编号();
            var sName = "";
            string strSql = "Select NAME From STU where  STUDENTID='" + sEPC + "'";
            //查询表查询 学生姓名
            DataTable tb = DataAccess.GetDataSetBySql(strSql).Tables[0];


            if (tb.Rows.Count == 0)
            {//无记录
                sName = "";
            }
            else
            {
                DataRow dr;
                dr = tb.Rows[0];

                sName = dr[0].ToString();
                //有值把姓名赋值
            }


            if (sName == "")
            {
                MessageBox.Show("读取epc编号为 " + sEPC + " 查询不到学生姓名,读取的 学号无效！");
                return;
            }
            else
            {
                textBox2.Text = sEPC;
                textBox3.Text = sName;

            }
            var sScore = 读用户区();
            if (sScore == "-1")
            {
                MessageBox.Show("初次使用 用户区未存成绩 ");
            }
            textBox4.Text = sScore;
            //成绩
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            写用户区(textBox4.Text);
        }



        //----------------------------硬件
    }
}

