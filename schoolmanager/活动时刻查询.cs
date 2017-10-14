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
    public partial class 活动时刻查询 : Form
    {
        public 活动时刻查询()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != null)
            {

                if (comboBox1.Text.Trim() == "学号")
                {
                    string sql = " select studentid from activetime group by studentid";
                    DataSet ds = DataAccess.GetDataSetBySql(sql);
                    List<string> alist = new List<string>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        alist.Add(ds.Tables[0].Rows[i][0].ToString());
                    }

                    comboBox2.DataSource = alist;
                }
                if (comboBox1.Text.Trim() == "姓名")
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
                if (comboBox1.Text.Trim() == "年级")
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
                
                if (comboBox1.Text.Trim() == "地点")
                {
                    List<string> alist = new List<string>();
                    alist.Add("图书馆");
                    alist.Add("教室1");
                    alist.Add("机房");
                    comboBox2.DataSource = alist;
                }
                if (comboBox1.Text.Trim() != "班级")
                {
                    label3.Visible = false;
                    label4.Visible = false;
                    comboBox3.Visible = false;
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Trim().ToString() == "")
            {
                MessageBox.Show("请选择条件");
                return;

            }
            string sqlcombine = "";
            string st = dateTimePicker1.Value.ToShortDateString();
            string st1 = st + " 00:00:00";
            string st2 = st + " 23:59:59";
            if (checkBox1.Checked == true)
            {
                sqlcombine = "and begintime >= '" + st1 + "' and begintime <= '" + st2 + "'";
            }
            
            if (comboBox1.Text.Trim() == "学号")
            {
                string str1 = comboBox2.Text.Trim().ToString();
                DataSet ds = DataAccess.GetDataSetBySql("select activetime.studentid,name,grade,class,place,begintime,finishtime,processtime from activetime,stu where activetime.studentid = stu.studentid and activetime.studentid = '" + str1 + "'" + sqlcombine );
                dataGridView1.DataSource = bindingSource1;
                bindingSource1.DataSource = ds.Tables[0];
            }
            if (comboBox1.Text.Trim() == "姓名")
            {
                string sql = "select activetime.studentid,name,grade,class,place,begintime,finishtime,processtime from activetime,stu where activetime.studentid = stu.studentid and name = '" + comboBox2.Text.Trim() + "'" + sqlcombine;
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                bindingSource1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
            if (comboBox1.Text.Trim() == "年级")
            {
                string sql = "select activetime.studentid,name,grade,class,place,begintime,finishtime,processtime from activetime,stu where activetime.studentid = stu.studentid and grade = " + comboBox2.Text.Trim() + sqlcombine;
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                bindingSource1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
            if (comboBox1.Text.Trim() == "班级")
            {
                string sql = "select activetime.studentid,name,grade,class,place,begintime,finishtime,processtime from activetime,stu where activetime.studentid = stu.studentid and grade = " + comboBox2.Text.Trim() + "and class = " + comboBox3.Text.Trim() + sqlcombine;
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                bindingSource1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
            if (comboBox1.Text == "地点")
            {
                string sql = "select activetime.studentid,name,grade,class,place,begintime,finishtime,processtime from activetime,stu where activetime.studentid = stu.studentid and place = '" + comboBox2.Text.Trim() + "'" + sqlcombine;
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                bindingSource1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = bindingSource1;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "班级")
            {
                string sql = "select class from  stu where grade = " + comboBox2.Text.Trim() + " group by class";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                List<string> alist = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alist.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                comboBox3.DataSource = alist;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select activetime.studentid,name,grade,class,place,begintime,finishtime,processtime from activetime,stu where activetime.studentid = stu.studentid";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            bindingSource1.DataSource = ds.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void 活动时刻查询_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;  //设置列标题不换行            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
