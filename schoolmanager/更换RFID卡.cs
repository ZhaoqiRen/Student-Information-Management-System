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
    public partial class 更换RFID卡 : Form
    {
        public 更换RFID卡()
        {
            InitializeComponent();
        }
        private static ReaderHandle reader;
        private void 更换RFID卡_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            关闭读写器();
            MessageBox.Show("读写器已断开");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = reader.ReadEpc();
            textBox3.Text = reader.ReadTID();
        }

        private void button3_Click(object sender, EventArgs e)
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
            textBox2.Text = reader.ReadEpc();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string studentid = textBox1.Text.Trim().ToString();
            string epc = textBox2.Text.Trim().ToString();
            string tid = textBox3.Text.Trim().ToString();

            string sql = "update studentRFID set TID = '"+tid+"',EPC = '"+ epc +"'  WHERE studentid = '"+studentid+"'";
            if (DataAccess.sql_command(sql))
            {
                MessageBox.Show("RFID存储成功");
            }
            else MessageBox.Show("存储失败");
        }

        private void 更换RFID卡_FormClosed(object sender, FormClosedEventArgs e)
        {
            关闭读写器();
        }
    }
}
