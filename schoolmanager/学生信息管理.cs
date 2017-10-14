using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schoolmanager
{
    public partial class 学生信息管理 : Form
    {
        public 学生信息管理()
        {
            InitializeComponent();
        }
        public string studentid;
        public string name;
        public string gender;
        public int grade;
        public int classnumber;
        public string father;
        public string fatherphone;
        public string mother;
        public string motherphone;
        public string address;

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select * from stu";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            bindingSource1.DataSource = ds.Tables[0];
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[0].HeaderCell.Value = "序号";
            dataGridView1.Columns[1].HeaderCell.Value = "学号";
            dataGridView1.Columns[2].HeaderCell.Value = "姓名";
            dataGridView1.Columns[3].HeaderCell.Value = "性别";
            dataGridView1.Columns[4].HeaderCell.Value = "年级";
            dataGridView1.Columns[5].HeaderCell.Value = "班级";
            dataGridView1.Columns[6].HeaderCell.Value = "父亲姓名";
            dataGridView1.Columns[7].HeaderCell.Value = "父亲电话";
            dataGridView1.Columns[8].HeaderCell.Value = "母亲姓名";
            dataGridView1.Columns[9].HeaderCell.Value = "母亲电话";
            dataGridView1.Columns[10].HeaderCell.Value = "家庭住址";

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            增加学生信息 zj = new 增加学生信息();
            zj.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "学号")
            {
                string sql = "select studentid from  stu group by studentid";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                List<string> alist = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alist.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                comboBox2.DataSource = alist;
            }
            if(comboBox1.Text.Trim () == "姓名")
            {
                string sql = "select name from  stu group by name";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                List<string> alist = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alist.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                comboBox2.DataSource = alist;
            }
            if (comboBox1.Text .Trim() == "年级")
            {
                string sql = "select grade from  stu group by grade";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                List<string> alist = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alist.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                comboBox2.DataSource = alist;
            }
            if (comboBox1.Text.Trim() == "班级")
            {
                label3.Visible = true;
                label4.Visible = true;
                comboBox3.Visible = true;
                string sql = "select grade from  stu group by grade";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                List<string> alist = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alist.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                comboBox2.DataSource = alist;
            }
            if (comboBox1.Text.Trim() != "班级")
            {
                label3.Visible = false;
                label4.Visible = false;
                comboBox3.Visible = false;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "学号")
            {
                string sql = "select * from stu where studentid = '"+ comboBox2.Text.Trim()+"'";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                bindingSource1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
            if (comboBox1.Text.Trim() == "姓名")
            {
                string sql = "select * from stu where name = '" + comboBox2.Text.Trim() + "'";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                bindingSource1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
            if (comboBox1.Text.Trim() == "年级")
            {
                string sql = "select * from stu where grade = " + comboBox2.Text.Trim();
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                bindingSource1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
            if (comboBox1.Text.Trim() == "班级")
            {
                string sql = "select * from stu where grade = " + comboBox2.Text.Trim() + "and class = " + comboBox3.Text.Trim();               
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                bindingSource1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[0].HeaderCell.Value = "序号";
            dataGridView1.Columns[1].HeaderCell.Value = "学号";
            dataGridView1.Columns[2].HeaderCell.Value = "姓名";
            dataGridView1.Columns[3].HeaderCell.Value = "性别";
            dataGridView1.Columns[4].HeaderCell.Value = "年级";
            dataGridView1.Columns[5].HeaderCell.Value = "班级";
            dataGridView1.Columns[6].HeaderCell.Value = "父亲姓名";
            dataGridView1.Columns[7].HeaderCell.Value = "父亲电话";
            dataGridView1.Columns[8].HeaderCell.Value = "母亲姓名";
            dataGridView1.Columns[9].HeaderCell.Value = "母亲电话";
            dataGridView1.Columns[10].HeaderCell.Value = "家庭住址";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text .Trim () == "班级")
            {
                string sql = "select class from  stu where grade = '"+comboBox2.Text.Trim()+"' group by class";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                List<string> alist = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alist.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                comboBox3.DataSource = alist;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            更换RFID卡 gh = new 更换RFID卡();
            gh.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void 学生信息管理_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;  //设置列标题不换行            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            richTextBox1.Enabled = false;
            button4.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            studentid  = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["studentid"].Value.ToString();
            name  = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["name"].Value.ToString();
            gender = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["gender"].Value.ToString();
            grade = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["grade"].Value.ToString());
            classnumber = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["class"].Value.ToString());
            father = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["fathername"].Value.ToString();
            fatherphone = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["fatherphone"].Value.ToString();
            mother = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["mothername"].Value.ToString();
            motherphone = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["motherphone"].Value.ToString();
            address = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["address"].Value.ToString();
            textBox1.Text = studentid;
            textBox2.Text = name;
            textBox3.Text = gender;
            textBox4.Text = grade.ToString() ;
            textBox5.Text = classnumber.ToString();
            textBox6.Text = father;
            textBox7.Text = fatherphone;
            textBox8.Text = mother;
            textBox9.Text = motherphone;
            richTextBox1.Text = address;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if(btnedit.Text == "编辑")
            {
                //textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                richTextBox1.Enabled = true;
                button4.Enabled = true;
                btnedit.Text = "结束编辑";
                return;
            }
            if(btnedit.Text == "结束编辑")
            {
                //textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                richTextBox1.Enabled = false;
                btnedit.Text = "编辑";
                button4.Enabled = false;
                return;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            studentid = textBox1.Text.Trim().ToString();
            name = textBox2.Text.Trim().ToString();
            gender = textBox3.Text.Trim().ToString();
            grade = int.Parse(textBox4.Text.Trim().ToString());
            classnumber = int.Parse(textBox5.Text.Trim().ToString());
            father = textBox6.Text.Trim().ToString();
            fatherphone = textBox7.Text.Trim().ToString();
            mother = textBox8.Text.Trim().ToString();
            motherphone = textBox9.Text.Trim().ToString();
            address = richTextBox1.Text.Trim().ToString();

            string sql = "update stu set name = '"+name+"',gender = '"+gender+"',grade = "+grade+",class = "+classnumber 
                +",fathername = '"+ father+"',fatherphone = '"+fatherphone+"',mothername = '"+mother +"',motherphone = '"+
                motherphone + " ',address = '"+address+"' where studentid = '"+studentid+"'";
            if (DataAccess.sql_command(sql))
            {
                MessageBox.Show("存储成功");
            }
            else MessageBox.Show("存储失败");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentid = textBox1.Text.Trim().ToString();
            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("未选中信息");
                return;            
            }
            DialogResult fan = MessageBox.Show("确定要删除"+textBox2.Text.Trim()+"的信息吗？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (fan == DialogResult.Yes)
            {
                string sql = "delete from stu where studentid = '" + studentid + "'";
                bool del = DataAccess.sql_command(sql);
                if (del)
                {
                    MessageBox.Show("删除成功");
                }
                else MessageBox.Show("删除失败");

            }

        }
    }
}
