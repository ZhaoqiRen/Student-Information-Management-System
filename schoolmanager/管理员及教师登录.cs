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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     private void Form1_Load(object sender, EventArgs e)
        {

        }
        //定义2个变量存储name和password
        public string mname;
        public string mpass;       
        
        //结束按钮，退出系统
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close ();
        }

        //判断用户，进入主界面
        private void button1_Click_1(object sender, EventArgs e)
        {
            //存储用户名和密码
            mname = textBox1.Text.Trim().ToString();
            mpass = textBox2.Text.Trim().ToString();

            //判断是否输入用户名，如果为空则返回。
            if(mname == "")
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            //判断是否输入了密码，如果为空则返回。
            if (mpass == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
            //如果都用户名和密码都不为空，则通过sql语句查询用户是否存在，不存在则提示并返回
            string sql1 = "select * from ALLUSERS where USERNAME ='" + mname + "'";
            if (!DataAccess.sql_exist(sql1))
            {
                MessageBox.Show("该用户不存在");
                return;
            }
            //如果该用户名存在，则核对密码登录并打开主界面。将用户名字和类型传至主界面
            string sql2 = "select * from ALLUSERS where USERNAME='" + mname + "'and PWD='" + mpass + "'";
            if (DataAccess.sql_exist(sql2))
            {
                MessageBox.Show("登录成功！");
                string sql3 = "select TYPE from ALLUSERS where USERNAME= '" + mname + "'";
                DataSet ds = DataAccess.GetDataSetBySql(sql3);
                string str2 = ds.Tables[0].Rows[0][0].ToString();
                BASAISFUCTION b1= new BASAISFUCTION(str2,mname);
                b1.Show();
                this.Visible = false;
            }
            else
            {
                //如果密码错误，给出提示并返回
                MessageBox.Show("密码错误！");
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
