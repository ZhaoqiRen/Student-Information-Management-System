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
        private Label 成绩查询;
        string strSql;//定义SQL
        public frm_markManage()
        {
            InitializeComponent();
        }


        public void frm_markManage_Load(System.Object sender, System.EventArgs e)
        {
            //设置控件整行选择
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //只读模式
            dataGridView1.ReadOnly = true;
            //加载数据
            cmdBack_Click(null, null);

            int i;

            for (i = 1; i <= dataGridView1.Columns.Count - 1; i++)
            {
                //查找表格标题添加到下拉列表里面查询字段
                ComboBox1.Items.Add(dataGridView1.Columns[i].HeaderText);
            }		
            dataGridView1.Columns[0].Visible=false ;
			//选择第一个
			ComboBox1.SelectedIndex = 0;
            
			//窗体尺寸
			 frm_markManage_Resize(null, null);
			//初始化 时间控件
			dateTimePicker1.Text = System.DateTime.Now.ToString();
			dateTimePicker2.Text = System.DateTime.Now.ToString();
			 
        }

        public void cmdClose_Click(System.Object sender, System.EventArgs e)
        {
            //关闭
            Close();
        }

        private void frm_markManage_Resize(object sender, System.EventArgs e)
        {
            // 设置表格尺寸
            //dataGridView1.Height = this.Height;
            //dataGridView1.Width = this.Width;
            //this.groupBox1.Left = TextBox1.Left;
            //this.groupBox1.Top = TextBox1.Top;
        }

        public void cmdFilter_Click(System.Object sender, System.EventArgs e)
        {
            cmdBack_Click(null, null);
            //重新加载查询条件 多条件查询时使用

            //若查询条件未选择
            if (ComboBox1.Text == "")
            {
                return;
            }
            //若无记录
            if (dataGridView1.Rows.Count <= 1)
            {
                return;
            }


            string sWhere;
            //得到第一个记录,对应字段的数据类型
            string strKey;//定义关键字变量
            strKey = TextBox1.Text.Replace("'", "''");
            //判定字段的数据类型
            if ((dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.DateTime") || (dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.TimeSpan"))
            {
                //时间类型
                //sWhere = "    datediff('d'," + ComboBox1.Text + " , " + C.sDateNowString + strKey + C.sDateNowString + ")=0";
                ////////////////////////////////////////////////////////////////////////////
                string mfS = dateTimePicker1.Value.ToString();
                string mfE = dateTimePicker2.Value.ToString();
                //STUDENTID as 学号,STUDENTName as 姓名,score as 成绩,ADDDATE  as 录入时间
                sWhere = " 	[ADDDATE]  between ' " + mfS + " ' and ' " + mfE + " '   ";
            }
            else if ((dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.Char") || (dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.String"))
            {
                var ss = "";
                //字符串类型
                if (ComboBox1.Text == "学号") ss = "STUDENTID";
                if (ComboBox1.Text == "姓名") ss = "STUDENTName";
                sWhere = "[" + ss + "]" + "  like \'%" + (strKey + "%\'");
            }
            else
            {
                //其它, 数字类型
                sWhere = "[score]" + "  =" + (strKey + "");
            }
            strSql += " and  " + sWhere;
            dataGridView1.DataSource = DataAccess.GetDataSetBySql(strSql).Tables[0];
        }

        public void cmdBack_Click(System.Object sender, System.EventArgs e)
        {//重新加载数据
            strSql = " Select ID,STUDENTID as 学号,STUDENTName as 姓名,score as 成绩,ADDDATE  as 录入时间 From mark  where 1=1 ";
            dataGridView1.DataSource = DataAccess.GetDataSetBySql(strSql).Tables[0];
        }

 

        public void DataGridView1_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //点击表格控件,获得列头到查询字段
            //C.msg(DataGridView1.CurrentCell.Value.GetType().ToString)
            ComboBox1.Text = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText;
        }

        public void DataGridView1_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
 
            //将主键 传入编辑窗体
    
           var id=   dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            frm_markEdit frm = new frm_markEdit();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Tag = id;
            frm.ShowDialog();
       
            //清除查询条件
            dataGridView1.DataSource = DataAccess.GetDataSetBySql(strSql).Tables[0];
            //刷新表格
        }
        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1) return;
            if ((dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.DateTime") || (dataGridView1.Rows[0].Cells[ComboBox1.Text].Value.GetType().ToString() == "System.TimeSpan"))
            {//若选择的类型是时间
                groupBox1.Visible = true;
            }
            else
            { groupBox1.Visible = false; }
        }
        #region 初始化

       
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
            this.成绩查询 = new System.Windows.Forms.Label();
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
            this.Label2.Text = "双击编辑对应记录";
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
            this.cmdClose.Text = "关闭(&C)";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.Location = new System.Drawing.Point(545, 69);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 23);
            this.cmdBack.TabIndex = 21;
            this.cmdBack.Text = "返回(&S)";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(461, 69);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 23);
            this.cmdFilter.TabIndex = 20;
            this.cmdFilter.Text = "筛选(&A)";
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
            this.Label1.Text = "查询筛选";
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
            this.label4.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "自";
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
            // 成绩查询
            // 
            this.成绩查询.AutoSize = true;
            this.成绩查询.BackColor = System.Drawing.Color.Transparent;
            this.成绩查询.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.成绩查询.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.成绩查询.Location = new System.Drawing.Point(24, 24);
            this.成绩查询.Name = "成绩查询";
            this.成绩查询.Size = new System.Drawing.Size(137, 29);
            this.成绩查询.TabIndex = 29;
            this.成绩查询.Text = "成绩查询";
            // 
            // frm_markManage
            // 
            this.BackgroundImage = global::schoolmanager.Properties.Resources._111;
            this.ClientSize = new System.Drawing.Size(842, 494);
            this.Controls.Add(this.成绩查询);
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
            this.Text = "查询成绩表";
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


