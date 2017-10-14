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
        private Label ������ҵ;
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
        //�����ֶα���
        //��ֵ�������
        public bool isChkValuse()
        {




            if (textBox2.Text.Trim() == "")
            {
                // -------------------STUDENTID             
                MessageBox.Show("������ ѧ�� ����Ϊ��!");
                textBox2.Focus();
                return false;
            }



            if (textBox3.Text.Trim() == "")
            {
                // -------------------STUDENTName             
                MessageBox.Show("������ ѧ������ ����Ϊ��!");
                textBox3.Focus();
                return false;
            }

            if (textBox4.Text.Trim() == "")
            {
                // -------------------score             
                MessageBox.Show("������ �ɼ� ����Ϊ��!");
                textBox4.Focus();
                return false;
            }

            //��ֵ����
            STUDENTID = textBox2.Text.Trim().Replace("'", "''");
            STUDENTName = textBox3.Text.Trim().Replace("'", "''");
            score = textBox4.Text.Trim().Replace("'", "''");
            ADDDATE = textBox5.Value.ToString("yyyy-MM-dd").Replace("'", "''");

            return true;
        }

        //��տؼ�Ϊ��ʼ״̬
        public void ClearCtl()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Value = DateTime.Now;

        }

        public void cmdClose_Click(System.Object sender, System.EventArgs e)
        {
            //�رհ�ť
            Close();
        }


        public void cmdDelData_Click(System.Object sender, System.EventArgs e)
        {

            //ɾ����ť

            DataAccess.sql_command("delete from mark" + strWhereID);
            cmdClose_Click(null, null);
        }

        public void cmdSave_Click(System.Object sender, System.EventArgs e)
        {

            //�༭
            if (isChkValuse() == true)
            {
                //��������




                strSql = "Update mark set STUDENTID ='" + STUDENTID + "' ,STUDENTName ='" + STUDENTName + "' ,score ='" + score + "' ,ADDDATE ='" + ADDDATE + "' " + strWhereID;
                DataAccess.sql_command(strSql);
                cmdClose_Click(null, null);
            }
        }

        public void cmdAddNew_Click(System.Object sender, System.EventArgs e)
        {

            //����
            if (isChkValuse() == true)
            {

                //������ �гɼ� ��ɾ�� �Ѿ����ڵļ�¼ ������¼


                string strSql = "Select ID From mark where  STUDENTID='" + STUDENTID + "' and ADDDATE='" + ADDDATE + "'";
                //��ѯ���ѯ ѧ�� �� ����  ���� �Ƿ��¼
                DataTable tb = DataAccess.GetDataSetBySql(strSql).Tables[0];


                if (tb.Rows.Count != 0)
                {//�м�¼  �����¼
                    DataAccess.sql_command("delete     From mark where  STUDENTID='" + STUDENTID + "' and ADDDATE='" + ADDDATE + "'");
                }




                strSql = "Insert into  mark (STUDENTID,STUDENTName,score,ADDDATE)values('" + STUDENTID + "','" + STUDENTName + "','" + score + "','" + ADDDATE + "')";
                DataAccess.sql_command(strSql);


                cmdClose_Click(null, null);
            }
        }


        public void frm_markEdit_Load(System.Object sender, System.EventArgs e)
        {
            Ӳ������();
            textBox5.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //��������

            if (this.Tag + "" != "")
            {//���Ǳ༭ģʽ

                cmdSave.Enabled = true;
                cmdAddNew.Enabled = false;
                cmdDelData.Enabled = true;
            }

            else
            {//����ʱ
                ClearCtl();
                cmdSave.Enabled = false;
                cmdDelData.Enabled = false;
                cmdAddNew.Enabled = true;

                return;
            }
            strWhereID = "";

            strWhereID = "	where ID=" + this.Tag; //��ѯ��Ӧ�ļ�¼
            //�����ѯ����
            strSql = "select * from  mark" + strWhereID;
            DataTable tb = DataAccess.GetDataSetBySql(strSql).Tables[0];

            if (tb.Rows.Count > 0)
            {
                //���м�¼ ,���ؼ���ֵ
                DataRow row = tb.Rows[0]; //�õ���һ�м�¼�ؼ���ֵ
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
        #region ��ʼ��
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
            this.������ҵ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdDelData
            // 
            this.cmdDelData.Location = new System.Drawing.Point(226, 57);
            this.cmdDelData.Name = "cmdDelData";
            this.cmdDelData.Size = new System.Drawing.Size(64, 23);
            this.cmdDelData.TabIndex = 58;
            this.cmdDelData.Text = "ɾ��(&D)";
            this.cmdDelData.UseVisualStyleBackColor = true;
            this.cmdDelData.Click += new System.EventHandler(this.cmdDelData_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(305, 57);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 55;
            this.cmdClose.Text = "�ر�(&C)";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(145, 57);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 57;
            this.cmdSave.Text = "����(&S)";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdAddNew
            // 
            this.cmdAddNew.Location = new System.Drawing.Point(59, 57);
            this.cmdAddNew.Name = "cmdAddNew";
            this.cmdAddNew.Size = new System.Drawing.Size(75, 23);
            this.cmdAddNew.TabIndex = 56;
            this.cmdAddNew.Text = "���(&A)";
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
            this.Label2.Text = "ѧ��";
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
            this.Label3.Text = "ѧ������";
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
            this.Label4.Text = "�ɼ�";
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
            this.Label5.Text = "����ʱ��";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 56;
            this.button1.Text = "��ȡ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 56;
            this.button2.Text = "д���û���";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ������ҵ
            // 
            this.������ҵ.AutoSize = true;
            this.������ҵ.BackColor = System.Drawing.Color.Transparent;
            this.������ҵ.Font = new System.Drawing.Font("����", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.������ҵ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.������ҵ.Location = new System.Drawing.Point(12, 9);
            this.������ҵ.Name = "������ҵ";
            this.������ҵ.Size = new System.Drawing.Size(137, 29);
            this.������ҵ.TabIndex = 59;
            this.������ҵ.Text = "������ҵ";
            // 
            // frm_markEdit
            // 
            this.BackgroundImage = global::schoolmanager.Properties.Resources._123;
            this.ClientSize = new System.Drawing.Size(406, 265);
            this.Controls.Add(this.������ҵ);
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



        //----------------------------Ӳ��


        // ���Ӷ�д��
        private void Connect()
        {
            if (_reader == null)
            {
                _reader = new ReaderHandle();

                _isConnected = _reader.Connect();
            }

            if (!_isConnected)
            {
                MessageBox.Show("��д������ʧ��");
            }
            else
            {
                MessageBox.Show("��д�����ӳɹ�");
            }

        }

        // �رն�д��
        private void �رն�д��()
        {
            if (_reader != null)
            {
                _reader.DisConnect();
                _isConnected = false;
                _reader = null;
            }
        }


        // ��ȡepc���
        private string ��ȡepc���()
        {
            return _reader.ReadEpc();
        }

        // д��EPC���
        private void д��EPC���(string s)
        {
            bool writeStatus = _reader.WriteEpc(s.Trim());
            if (writeStatus)
            {
                MessageBox.Show("EPCд��ɹ�");
            }

        }

        //��TID
        private string ��TID()
        {
            return _reader.ReadTID();
        }

        // д�û���
        private void д�û���(string s)
        {
            string hexecp = _reader.ReadEpc();

            //��ʼλ�� 0   д��2 λ   ������λ  ��0 ���

          s = String.Format("{0:00}", Int32.Parse(s));
            if (_reader.WriteUserData(hexecp,0,  s))
            {
                MessageBox.Show("�û���д��ɹ�");
            }
            else
            {
                MessageBox.Show("�û���д��ʧ��");
            }
        }

        // ���û���
        private string ���û���()
        {



            string hexecp = _reader.ReadEpc();
            //��ʼλ�� 0   д��2 λ   ������λ  ��0 ���
            string ss = _reader.ReadUserData(hexecp, "0", "2");
            ss = ss.Substring(0, 2);
            //ǿ��ȡ2λֵ
            try
            {
                ss = Int32.Parse(ss).ToString();
                //ȥ��1λ����ǰ���0
            }
            catch
            {
                ss = "-1";
            }

            return ss;
        }


        private void Ӳ������()
        {
            _reader = null;
            //txbEpc.Text = "";
            Connect();
        }

        private void frm_markEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            �رն�д��();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sEPC = ��ȡepc���();
            var sName = "";
            string strSql = "Select NAME From STU where  STUDENTID='" + sEPC + "'";
            //��ѯ���ѯ ѧ������
            DataTable tb = DataAccess.GetDataSetBySql(strSql).Tables[0];


            if (tb.Rows.Count == 0)
            {//�޼�¼
                sName = "";
            }
            else
            {
                DataRow dr;
                dr = tb.Rows[0];

                sName = dr[0].ToString();
                //��ֵ��������ֵ
            }


            if (sName == "")
            {
                MessageBox.Show("��ȡepc���Ϊ " + sEPC + " ��ѯ����ѧ������,��ȡ�� ѧ����Ч��");
                return;
            }
            else
            {
                textBox2.Text = sEPC;
                textBox3.Text = sName;

            }
            var sScore = ���û���();
            if (sScore == "-1")
            {
                MessageBox.Show("����ʹ�� �û���δ��ɼ� ");
            }
            textBox4.Text = sScore;
            //�ɼ�
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            д�û���(textBox4.Text);
        }



        //----------------------------Ӳ��
    }
}

