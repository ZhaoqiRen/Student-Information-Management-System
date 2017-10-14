using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace schoolmanager
{
    public partial class 增加学生信息 : Form
    {
        public 增加学生信息()
        {
            InitializeComponent();
        }

        private static ReaderHandle reader ;
        public string imgpath;
        public OpenFileDialog op1 = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        // 连接读写器
        private void Connect()
        {
            reader = new ReaderHandle();
            if (reader.Connect())
            {

                MessageBox.Show("读写器连接成功");
            }
            else MessageBox.Show("读写器连接失败");            
        }

        // 关闭读写器
        private void 关闭读写器()
        {
            if (reader != null)
            {
                reader.DisConnect();                
                reader = null;
            }
        }
       
        // 写入EPC编号
        private void 写入EPC编号(string s)
        {
            bool writeStatus = reader.WriteEpc(textBox1.Text.Trim().ToString());
            if (writeStatus)
            {
                MessageBox.Show("EPC写入成功");
            }

        }
        //读取当前RFID卡的EPC编号，如果不符则修改
        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Text = reader.ReadEpc();
            textBox8.Text = reader.ReadTID();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox1.Text.Trim() == null)
            {
                MessageBox.Show("请输入学号");
                return;
            }
            string str = textBox1.Text.Trim().ToString();
            bool writestatus = reader.WriteEpc(str);
            if (writestatus)
            {
                MessageBox.Show("学号写入成功");
            }
            textBox7.Text = reader.ReadEpc();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            关闭读写器();
            MessageBox.Show("读写器已断开");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            string studentid = textBox1.Text.Trim().ToString();
            string epc = textBox7.Text.Trim().ToString();
            string tid = textBox8.Text.Trim().ToString();
            
            string sql = "insert into studentRFID values('"+studentid+"','"+epc +"','"+tid +"')";
            if (DataAccess.sql_command(sql))
            {
                MessageBox.Show("RFID存储成功");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入学号");
                return;
            }
            string studentid = textBox1.Text.Trim().ToString();

            if(textBox2.Text .Trim() == "")
            {
                MessageBox.Show("请输入姓名");
                return;        
            }
            string name = textBox2.Text.Trim().ToString();
            
            string gender = comboBox1.Text.Trim();
            int grade = int.Parse(comboBox2.Text.Trim());
            int classnumber = int.Parse(comboBox3.Text.Trim());

            if(textBox3.Text.Trim() == "")
            {
                MessageBox.Show("请输入父亲姓名");
                return;
            }
            string father = textBox3.Text.Trim();

            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("请输入父亲电话");
                return;
            }
            string fatherphone = textBox4.Text.Trim();

            if (textBox5.Text.Trim() == "")
            {
                MessageBox.Show("请输入母亲姓名");
                return;
            }
            string mother = textBox5.Text.Trim();

            if(textBox6.Text.Trim() == "")
            {
                MessageBox.Show("请输入母亲电话");
                return;
            }
            string motherphone = textBox6.Text.Trim();

            if(richTextBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入家庭住址");
                return;
            }
            string address = richTextBox1.Text.Trim().ToString();

            string sql = "insert into stu values('"+studentid+"','"+ name  +"','"+gender+"','"+grade+"','"+classnumber+"','"+father+"','"+fatherphone+"','"+mother+"','"+motherphone+"','"+address+"')";
            bool judge = DataAccess.sql_command(sql);
            if (judge)
            {
                MessageBox.Show("提交成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("提交失败");
                return;
            }           
        }

        private void 增加学生信息_Load(object sender, EventArgs e)
        {

        }

        private void btnsearh_Click(object sender, EventArgs e)
        {
            op1.Filter = " Image Files(*.bmp;*.ico;*.gif;*jpeg;*.jpg;*.png;*.tif;*.tiff)|*.bmp;*.ico;*.gif;*jpeg;*.jpg;*.png;*.tif;*.tiff";
            op1.ShowDialog();
            imgpath = op1.FileName;
            textBox9.Text = imgpath;
            pictureBox1.ImageLocation = imgpath;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (imgpath == "")
            {
                MessageBox.Show("请选择图片！");
                return;
            }
            if (textBox1.Text.Trim().ToString() == "")
            {
                MessageBox.Show("请输入学号");
                return;
            }
            try
            {
                FileInfo info = new FileInfo(imgpath);
                info.CopyTo(Application.StartupPath + "\\image\\"+ textBox1.Text.Trim().ToString() + ".jpg", true);
                MessageBox.Show("提交成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！");
            }
        }

        private void 增加学生信息_FormClosed(object sender, FormClosedEventArgs e)
        {
            关闭读写器();
        }
    }
}
