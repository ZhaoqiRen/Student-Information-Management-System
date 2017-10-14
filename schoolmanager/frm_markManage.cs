using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace schoolmanager
{
    public partial class frm_markManage : Form
    {
       

        internal Label Label2;
        internal ComboBox ComboBox1;
        internal Button cmdClose;
        internal Button cmdBack;
        internal Button cmdFilter;
        private DataGridView dataGridView1;
        internal Label Label1;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        internal TextBox TextBox1;
        private Label �ɼ���ѯ;
        string strSql;//����SQL
        public frm_markManage()
        {
            InitializeComponent();
        }


        public void frm_markManage_Load(System.Object sender, System.EventArgs e)
        {
            //���ÿؼ�����ѡ��
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //ֻ��ģʽ
            dataGridView1.ReadOnly = true;
            //��������
            cmdBack_Click(null, null);

            int i;

            for (i = 1; i <= dataGridView1.Columns.Count - 1; i++)
            {
                //���ұ�������ӵ������б������ѯ�ֶ�
                ComboBox1.Items.Add(dataGridView1.Columns[i].HeaderText);
            }		
            dataGridView1.Columns[0].Visible=false ;
			//ѡ���һ��
			ComboBox1.SelectedIndex = 0;
            
			//����ߴ�
			 frm_markManage_Resize(null, null);
			//��ʼ�� ʱ��ؼ�
			dateTimePicker1.Text = System.DateTime.Now.ToString();
			dateTimePicker2.Text = System.DateTime.Now.ToString();
			 
        }

        public void cmdClose_Click(System.Object sender, System.EventArgs e)
        {
            //�ر�
            Close();
        }

        private void frm_markManage_Resize(object sender, System.EventArgs e)
        {
            // ���ñ��ߴ�
            //dataGridView1.Height = this.Height;
            //dataGridView1.Width = this.Width;
            //this.groupBox1.Left = TextBox1.Left;
            //this.groupBox1.Top = TextBox1.Top;
        }

        public void cmdFilter_Click(System.Object sender, System.EventArgs e)
        {
            cmdBack_Click(null, null);
            //���¼��ز�ѯ���� ��������ѯʱʹ��

            //����ѯ����δѡ��
            if (ComboBox1.Text == "")
            {
                return;
            }
            //���޼�¼
            if (dataGridView1.Rows.Count <= 1)
            {
                return;
            }


            string sWhere;
            //�õ���һ����¼,��Ӧ�ֶε���������
            string strKey;//����ؼ��ֱ���
            strKey = TextBox1.Text.Replace("'", "''");
            //�ж��ֶε���������
            if ((dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.DateTime") || (dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.TimeSpan"))
            {
                //ʱ������
                //sWhere = "    datediff('d'," + ComboBox1.Text + " , " + C.sDateNowString + strKey + C.sDateNowString + ")=0";
                ////////////////////////////////////////////////////////////////////////////
                string mfS = dateTimePicker1.Value.ToString();
                string mfE = dateTimePicker2.Value.ToString();
                //STUDENTID as ѧ��,STUDENTName as ����,score as �ɼ�,ADDDATE  as ¼��ʱ��
                sWhere = " 	[ADDDATE]  between ' " + mfS + " ' and ' " + mfE + " '   ";
            }
            else if ((dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.Char") || (dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.String"))
            {
                var ss = "";
                //�ַ�������
                if (ComboBox1.Text == "ѧ��") ss = "STUDENTID";
                if (ComboBox1.Text == "����") ss = "STUDENTName";
                sWhere = "[" + ss + "]" + "  like \'%" + (strKey + "%\'");
            }
            else
            {
                //����, ��������
                sWhere = "[score]" + "  =" + (strKey + "");
            }
            strSql += " and  " + sWhere;
            dataGridView1.DataSource = DataAccess.GetDataSetBySql(strSql).Tables[0];
        }

        public void cmdBack_Click(System.Object sender, System.EventArgs e)
        {//���¼�������
            strSql = " Select ID,STUDENTID as ѧ��,STUDENTName as ����,score as �ɼ�,ADDDATE  as ¼��ʱ�� From mark  where 1=1 ";
            dataGridView1.DataSource = DataAccess.GetDataSetBySql(strSql).Tables[0];
        }

 

        public void DataGridView1_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //������ؼ�,�����ͷ����ѯ�ֶ�
            //C.msg(DataGridView1.CurrentCell.Value.GetType().ToString)
            ComboBox1.Text = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText;
        }

        public void DataGridView1_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
 
            //������ ����༭����
    
           var id=   dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            frm_markEdit frm = new frm_markEdit();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Tag = id;
            frm.ShowDialog();
       
            //�����ѯ����
            dataGridView1.DataSource = DataAccess.GetDataSetBySql(strSql).Tables[0];
            //ˢ�±��
        }
        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1) return;
            if ((dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.DateTime") || (dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.TimeSpan"))
            {//��ѡ���������ʱ��
                groupBox1.Visible = true;
            }
            else
            { groupBox1.Visible = false; }
        }
        #region ��ʼ��

       
        private void InitializeComponent()
        {
            this.Label2 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.�ɼ���ѯ = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(43, 102);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(101, 12);
            this.Label2.TabIndex = 27;
            this.Label2.Text = "˫���༭��Ӧ��¼";
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(102, 72);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(121, 20);
            this.ComboBox1.TabIndex = 22;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            this.ComboBox1.TextChanged += new System.EventHandler(this.ComboBox1_TextChanged);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(626, 69);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 23;
            this.cmdClose.Text = "�ر�(&C)";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.Location = new System.Drawing.Point(545, 69);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 23);
            this.cmdBack.TabIndex = 21;
            this.cmdBack.Text = "����(&S)";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(461, 69);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 23);
            this.cmdFilter.TabIndex = 20;
            this.cmdFilter.Text = "ɸѡ(&A)";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(45, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(723, 309);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(43, 80);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 25;
            this.Label1.Text = "��ѯɸѡ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(229, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 40);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "��";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "��";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(132, 13);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(88, 21);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(24, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(88, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(229, 71);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(224, 21);
            this.TextBox1.TabIndex = 19;
            this.TextBox1.Tag = "1";
            // 
            // �ɼ���ѯ
            // 
            this.�ɼ���ѯ.AutoSize = true;
            this.�ɼ���ѯ.BackColor = System.Drawing.Color.Transparent;
            this.�ɼ���ѯ.Font = new System.Drawing.Font("����", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.�ɼ���ѯ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.�ɼ���ѯ.Location = new System.Drawing.Point(24, 24);
            this.�ɼ���ѯ.Name = "�ɼ���ѯ";
            this.�ɼ���ѯ.Size = new System.Drawing.Size(137, 29);
            this.�ɼ���ѯ.TabIndex = 29;
            this.�ɼ���ѯ.Text = "�ɼ���ѯ";
            // 
            // frm_markManage
            // 
            this.BackgroundImage = global::schoolmanager.Properties.Resources._111;
            this.ClientSize = new System.Drawing.Size(842, 494);
            this.Controls.Add(this.�ɼ���ѯ);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdFilter);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TextBox1);
            this.Name = "frm_markManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "��ѯ�ɼ���";
            this.Load += new System.EventHandler(this.frm_markManage_Load);
            this.Resize += new System.EventHandler(this.frm_markManage_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


