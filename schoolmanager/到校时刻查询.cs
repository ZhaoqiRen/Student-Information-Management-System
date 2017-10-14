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
    public partial class 到校时刻查询 : Form
    {
        public 到校时刻查询()
        {
            InitializeComponent();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                getstudentidbyclass();
            }
            if (checkBox4.Checked == true)
            {
                getnamedbyclass();
            }
        }

        private void 到校时刻查询_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;  //设置列标题不换行            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                getclassbygrade();
            }
            if (checkBox3.Checked == true)
            {
                getstudentidbygrade();
            }
            if (checkBox4.Checked == true)
            {
                
                getnamebygrade();
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            List<string> mysql = new List<string>(); ;
            if (checkBox1.Checked == true)
            {
                mysql.Add("grade =" + comboBox1.Text.Trim());
            }
            if(checkBox1.Checked==false) mysql.Add("grade = grade");

            if (checkBox2.Checked == true)
            {
                mysql.Add(" class =" + comboBox2.Text.Trim());
            }
             if (checkBox2.Checked == false) mysql.Add("class = class");

            if (checkBox3.Checked == true)
            {
                mysql.Add(" doortime.studentid = '" + comboBox3.Text.Trim() + "'");
            }
            else mysql.Add(" doortime.studentid = doortime.studentid ");

            if (checkBox4.Checked == true)
            {
                mysql.Add(" name = '" + comboBox4.Text.Trim() + "'");
            }
            else mysql.Add(" name = name ");

            if (checkBox5.Checked == true)
            {
                mysql.Add("DATEDIFF(day ,time,'" + dateTimePicker1.Value.ToShortDateString() + "')=0");
            }
            if (checkBox5.Checked==false) mysql.Add(" time = time ");

            if (checkBox6.Checked == true)
            {
                if(comboBox5.Text == "迟到")
                {
                    string st = dateTimePicker1.Value.ToShortDateString();
                    string st1 = st + " 08:00:00";
                    string st2 = st + " 23:59:59";
                    
                    mysql.Add("time >= '" + st1 + "' and time <= '" + st2 + "' and state = '进入'");
                }
                if(comboBox5.Text == "按时到校")
                {
                    string st = dateTimePicker1.Value.ToShortDateString();
                    string st1 = st + " 00:00:00";
                    string st2 = st + " 08:00:00";
                    
                    mysql.Add("time >= '" + st1 + "' and time <= '" + st2 + "' and state = '进入'");
                }
                if(comboBox5.Text .Trim () == "")
                {
                    mysql.Add(" time = time ");
                }                
            }
            else mysql.Add(" time = time ");

            string sql = "select doortime.studentid,name,grade,class,time,state from doortime,stu where ";
            sql = sql + mysql[0] + " and " + mysql[1] + " and " + mysql[2] +" and " + mysql[3] + " and "+ 
                mysql[4] + " and " + mysql[5] + " and doortime.studentid=stu.StudentId";
            
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
                getgrade();
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
                getclassbygrade();
            }
            if (checkBox2.Checked == false)
            {
                comboBox2.Enabled = false;
            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                getstudentidbyname();
                comboBox3.Enabled = true;
            }
            else if (checkBox3.Checked == true)
            {
                comboBox3.Enabled = true;
                if (checkBox1.Checked == true)
                {
                    if (checkBox2.Checked == true)
                    {
                        getstudentidbyclass();
                    }
                    if (checkBox2.Checked == false)
                    {
                        getstudentidbygrade();
                    }
                }
                if (checkBox1.Checked == false)
                {
                    getstudentid();
                }
            }
            if (checkBox3.Checked == false)
            {
                comboBox3.Enabled = false;
            }
            
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                dateTimePicker1.Enabled = true;
            }
            if (checkBox5.Checked == false)
            {
                dateTimePicker1.Enabled = false;
            }
            

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                comboBox5.Enabled = true;
            }
            if (checkBox6.Checked == false)
            {
                comboBox5.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked == true)
            {
                if (checkBox3.Checked == true)
                {
                    MessageBox.Show("您已经勾选学号，无需勾选姓名");
                    checkBox4.Checked = false;
                    return;
                }

                comboBox4.Enabled = true;
                if (checkBox3.Checked == true)
                { 
                    return;
                }                
                if (checkBox1.Checked == true)
                {
                    if (checkBox2.Checked == true)
                    {
                        getnamedbyclass();
                    }
                    if (checkBox2.Checked == false)
                    {
                        getnamebygrade();
                    }
                }
                else
                {
                    getname();
                }
            }
            if (checkBox4.Checked == false)
            {
                comboBox4.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select doortime.studentid,name,grade,class,time,state from doortime,stu where doortime.studentid = stu.studentid";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = ds.Tables[0];

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void getgrade()
        {
            string sql = " select grade from  stu group by grade";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "grade";
        }

        public void getclassbygrade()
        {
            string sql = " select class from  stu where grade = "+comboBox1.Text.Trim().ToString()+" group by class";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            comboBox2.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = "class";
        }
        public void getstudentid()
        {
            string sql = "select studentid from stu group by studentid";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            comboBox3.DataSource = ds.Tables[0];
            comboBox3.DisplayMember = "studentid"; 
        }
        public void getstudentidbygrade()
        {
            string sql = "select studentid from stu where grade = "+comboBox1.Text.Trim().ToString() + "";
            try
            {
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                comboBox3.DataSource = ds.Tables[0];
            }
            catch (Exception w)
            {

            }
            comboBox3.DisplayMember = "studentid"; 
        }
        public void getstudentidbyclass()
        {
            string sql = "select studentid from stu where grade = " + comboBox1.Text.Trim().ToString() + " and class = " + comboBox2.Text.Trim() + "";
            try
            {
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                comboBox3.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {

            }
            comboBox3.DisplayMember = "studentid"; 
        }
        public void getstudentidbyname()
        {
            string sql = "select studentid from stu where name = '"+ comboBox4.Text.Trim().ToString() +"' group by studentid ";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            comboBox3.DataSource = ds.Tables[0];
            comboBox3.DisplayMember = "studentid"; 
        }
        public void getname()
        {
            string sql = "select name from stu group by name";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            comboBox4.DataSource = ds.Tables[0];
            comboBox4.DisplayMember = "name"; 
        }
        public void getnamebygrade()
        {            
            string sql = "select name from stu where grade = " + comboBox1.Text.Trim().ToString ()+ "";
            try
            {
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                comboBox4.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {                
            }           
            comboBox4.DisplayMember = "name";
           
            
        }
        public void getnamedbyclass()
        {
            string sql = "select name from stu where grade = " + comboBox1.Text.Trim().ToString() + " and class = " + comboBox2.Text.Trim() + "";
            try
            {
                DataSet ds = DataAccess.GetDataSetBySql(sql);
                comboBox4.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {

            }

            comboBox4.DisplayMember = "name";
        }
        public void getnamebystudentid()
        {
            string sql = "select name from stu where studentid = '" + comboBox3.Text.Trim().ToString() + "' group by name ";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            comboBox4.DataSource = ds.Tables[0];
            comboBox4.DisplayMember = "name";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                getnamebystudentid();
            }
            else
            {

            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                if (checkBox3.Checked == true)
                {
                    getstudentidbyname();
                }
            }
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
