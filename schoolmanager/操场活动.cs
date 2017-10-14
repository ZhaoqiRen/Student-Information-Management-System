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
    public partial class 操场活动 : Form
    {
        public 操场活动()
        {
            InitializeComponent();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> mysql = new List<string>(); ;
            if (checkBox1.Checked == true)
            {
                mysql.Add("grade =" + comboBox1.Text.Trim());
            }
            if (checkBox1.Checked == false) mysql.Add("grade = grade");

            if (checkBox2.Checked == true)
            {
                mysql.Add(" class =" + comboBox2.Text.Trim());
            }
            if (checkBox2.Checked == false) mysql.Add("class = class");

            if (checkBox3.Checked == true)
            {
                mysql.Add(" play.StudentId = '" + comboBox3.Text.Trim() + "'");
            }
            else mysql.Add(" play.StudentId = play.StudentId ");

            if (checkBox4.Checked == true)
            {
                mysql.Add(" name = '" + comboBox4.Text.Trim() + "'");
            }
            else mysql.Add(" name = name ");

            if (checkBox5.Checked == true)
            {
                mysql.Add(" place ='" + comboBox5.Text.Trim() + "'");
            }
            if (checkBox5.Checked == false) mysql.Add(" place = place ");

            if (checkBox6.Checked == true)
            {
                mysql.Add("DATEDIFF(day ,begintime,'" + dateTimePicker1.Value.ToShortDateString() + "')=0");

            }
            if (checkBox6.Checked == false) mysql.Add("begintime = begintime ");

            string sql = "select play.StudentId,name,grade,class,place,begintime,finishtime,processtime from play,stu where ";
            sql = sql + mysql[0] + " and " + mysql[1] + " and " + mysql[2] + " and " + mysql[3] + " and " +
                mysql[4] + " and " + mysql[5] + " and play.StudentId=stu.StudentId ";

            DataSet ds = DataAccess.GetDataSetBySql(sql);
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from play";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = ds.Tables[0];
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = true;
                comboBox1.Enabled = true;
                string sql = " select grade from  stu group by grade";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                List<string> alist = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alist.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                comboBox1.DataSource = alist;
            }
            if (checkBox1.Checked == false)
            {
                comboBox1.Enabled = false;
                checkBox2.Enabled = false;
            }                           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                comboBox2.Enabled = true;
                string sql = "select class from  stu where grade = " + comboBox1.Text.Trim() + "  group by class";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                List<string> alist = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alist.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                comboBox2.DataSource = alist;
            }
            if (checkBox2.Checked == false)
            {
                comboBox2.Enabled = false;
            }
        }

        private void 操场活动_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;  //设置列标题不换行            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked == true)
            {
                MessageBox.Show("学号与姓名只能选一个");
                checkBox3.Checked = false;
                return;
            }
            if (checkBox3.Checked == true)
            {
                comboBox3.Enabled = true;
                if (checkBox1.Checked == true)
                {
                    if (checkBox2.Checked == true)
                    {
                        string sql = "select StudentId from stu where grade = " + comboBox1.Text.Trim() + "and class = " + comboBox2.Text.Trim() + "group by StudentId";
                        DataSet ds = DataAccess.GetDataSetBySql(sql);
                        List<string> alist = new List<string>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            alist.Add(ds.Tables[0].Rows[i][0].ToString());
                        }
                        comboBox3.DataSource = alist;
                    }
                    if (checkBox2.Checked == false)
                    {
                        comboBox3.Enabled = true;
                        string sql = "select StudentId from  stu where grade = " + comboBox1.Text.Trim() + "  group by StudentId";
                        DataSet ds = DataAccess.GetDataSetBySql(sql);
                        List<string> alist = new List<string>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            alist.Add(ds.Tables[0].Rows[i][0].ToString());
                        }
                        comboBox3.DataSource = alist;

                    }

                }
                if (checkBox1.Checked == false)
                {
                    comboBox3.Enabled = true;
                    string sql = "select StudentId from  stu group by StudentId";
                    DataSet ds = DataAccess.GetDataSetBySql(sql);
                    List<string> alist = new List<string>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        alist.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                    comboBox3.DataSource = alist;
                }
            }
            if (checkBox3.Checked == false)
            {
                comboBox3.Enabled = false;
            }
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                MessageBox.Show("学号与姓名只能选一个");
                checkBox4.Checked = false;
                return;
            }

            if (checkBox4.Checked == true)
            {
                comboBox4.Enabled = true;
                if (checkBox1.Checked == true)
                {
                    if (checkBox2.Checked == true)
                    {
                        string sql = "select name from stu where grade = " + comboBox1.Text.Trim() + "and class = " + comboBox2.Text.Trim() + "group by name";
                        DataSet ds = DataAccess.GetDataSetBySql(sql);
                        List<string> alist = new List<string>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            alist.Add(ds.Tables[0].Rows[i][0].ToString());
                        }
                        comboBox4.DataSource = alist;
                    }
                    if (checkBox2.Checked == false)
                    {
                        comboBox4.Enabled = true;
                        string sql = "select name from  stu where grade = " + comboBox1.Text.Trim() + "  group by name";
                        DataSet ds = DataAccess.GetDataSetBySql(sql);
                        List<string> alist = new List<string>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            alist.Add(ds.Tables[0].Rows[i][0].ToString());
                        }
                        comboBox4.DataSource = alist;

                    }

                }
                else
                {
                    string sql = "select name from stu";
                    DataSet ds = DataAccess.GetDataSetBySql(sql);
                    List<string> alist = new List<string>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        alist.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                    comboBox4.DataSource = alist;
                }

                if (checkBox1.Checked == false)
                {
                    comboBox4.Text = "";
                }
            }
            if (checkBox4.Checked == false)
            {
                comboBox4.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                comboBox5.Enabled = true;
                string sql = "select place from play group by place";
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                List<string> alist = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alist.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                comboBox5.DataSource = alist;
            }
            if (checkBox5.Checked == false)
            {
                comboBox5.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox2.Checked = true;
            }
            if (checkBox3.Checked == true)
            {
                checkBox3.Checked = false;
                checkBox3.Checked = true;
            }
            if (checkBox4.Checked == true)
            {
                checkBox4.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox3.Checked = false;
                checkBox3.Checked = true;
            }
            if (checkBox4.Checked == true)
            {
                checkBox4.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}
