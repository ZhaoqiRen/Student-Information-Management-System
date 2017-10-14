using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ModuleTech;
using System.Diagnostics;
using ModuleTech.Gen2;
using System.IO;
using ModuleLibrary;
using System.Data.SqlClient;
using PositionManage;
using Kinectmanager;
using AudioBasics_WPF;


namespace schoolmanager
{
    public partial class BASAISFUCTION : Form
    {
        public string mytype;
        public string myname;
        public PictureBox[] pb;


        public BASAISFUCTION(string mytype,string myname)
        {
            InitializeComponent();

            this.mytype = mytype;
            this.myname = myname;

        }

        //设置IP地址
        public static string conip1 = "192.168.0.102";
        public static string conip2 = "192.168.0.103"; 

        //初始化2个reader
        public Reader doordr = null;
        public Reader activedr = null;

        //建立同步基元
        Mutex tagMutex1 = new Mutex();
        Mutex tagMutex2 = new Mutex();
        Mutex tagMutex3 = new Mutex();



        //创建list临时存储学生活动情况     
        List<string> refreshlist = new List<string>();
        List<string> libraryrefreshlist = new List<string>();
        List<string> classrefreshlist1 = new List<string>();
        List<string> classrefreshlist2 = new List<string>();
        List<string> computerrefreshlist = new List<string>();
        //Dictionary<string, DateTime> refreshdictionary = new Dictionary<string, DateTime>();        
        
  
        private void button3_Click(object sender, EventArgs e)
        {
            (new frm_markManage()).ShowDialog();
            // mark管理 作业情况
        }

        private void 基本功能界面_Load(object sender, EventArgs e)
        {
            string str1;
            if (mytype == "administrator")
            {
                str1 = "管理员";
                this.Text = this.mytype + this.myname + ",欢迎你！";
            }
            if (mytype == "teacher") 
            {
                str1 = "老师";
                this.Text = this.myname + this.mytype + ",欢迎你！";
                设备管理ToolStripMenuItem.Enabled = false;
                学生RFID卡管理ToolStripMenuItem.Enabled = false;
            }
            label2.Text = myname;
            label4.Text = mytype;
            createpicbox();
           
           
        }

        private void readtimer1_Tick(object sender, EventArgs e)
        {
            tagMutex1.WaitOne();
            int flag = 0;


            int[] ant = (int[])doordr.ParamGet("ConnectedAntennas");
            SimpleReadPlan readplan = new SimpleReadPlan(TagProtocol.GEN2, ant);
            doordr.ParamSet("ReadPlan", readplan);
            //doordr.ParamGet("RfPowerMax");

             TagReadData[] reads = doordr.Read(500);

            //如果读取到数据
             if (reads.Length != 0)
             {
                 //遍历独到的数组的每一个值
                 foreach (TagReadData tag in reads)
                 {
                     //如果不是以D开头的则抛弃
                     if (tag.EPCString.First() != 'D')
                         continue;

                     //将该标签的EPC和时间戳存到临时变量里
                     string studentid = tag.EPCString;
                     string time = tag.Time.ToString();

                     //判断连接的天线
                     if (tag.Antenna == 1)
                     {
                         //判断得到的EPC是否在刷新列表中
                         foreach (string epc in refreshlist)                         
                         {
                             if (studentid == epc)
                             {
                                 //如果在列表中，则flag置为1，避免后续继续判断
                                 flag = 1;
                             }
                         }

                         //foreach (string key in refreshdictionary.Keys)
                         //{
                         //    if (studentid == key)
                         //    {
                         //        flag = 1;
                         //    }
                         //}


                         if (flag == 0)
                         {
                             pictureBox1.Visible = true;
                             try
                             {
                                 pictureBox1.Image = Image.FromFile(Application.StartupPath +"\\image\\"+ studentid + ".jpg");
                             }
                             catch (Exception ee)
                             {
                                 pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\\人.jpg");
                             }
                             label6.Text = studentid;
                             label6.Visible = true;
                             label7.Text = time;
                             label7.Visible = true;
                             string str1 = "select * from doortime where studentid  = '"+ studentid+"'";
                             bool exist = DataAccess.sql_exist(str1);

                             if (exist)
                             {
                                 refreshlist.Add(studentid);
                                 //refreshdictionary.Add(studentid, tag.Time.AddSeconds(10));
                                 string str2 = "select top 1  state  from doortime where studentid = '" + studentid + "' order by id desc";
                                 DataSet ds = DataAccess.GetDataSetBySql(str2);
                                 string state = ds.Tables[0].Rows[0][0].ToString();
                                 if (state == "进入")
                                 {
                                     string str3 = "insert into doortime values ('" + studentid + " ','" + time + " ','离开')";
                                     DataAccess.sql_command(str3);
                                     
                                 }
                                 if (state == "离开")
                                 {
                                     string str3 = "insert into doortime values ('" + studentid + " ','" + time + " ','进入')";
                                     DataAccess.sql_command(str3);                                    
                                 }
                             }
                             else
                             {
                                 string str3 = "insert into doortime values ('" + studentid + " ','" + time + " ','进入')";
                                 DataAccess.sql_command(str3);                       
                             }                                   
                         }
                     }
                 }
             }
             tagMutex1.ReleaseMutex();
        }

        private void refreshtimer_Tick(object sender, EventArgs e)
        {
            //DateTime dt = DateTime.Now;
            //foreach (string key in refreshdictionary.Keys)
            //{
            //    if (refreshdictionary[key] <= dt.AddSeconds(2) || refreshdictionary[key] >= dt.AddSeconds(-2))
            //    {
            //        refreshdictionary.Remove(key);
            //    }
            //}
            //textBox1.Text = dt.ToString();
            refreshlist = new List<string>();
            libraryrefreshlist = new List<string>();
            classrefreshlist1 = new List<string>();
            classrefreshlist2 = new List<string>();
            computerrefreshlist = new List<string>();
        }

        private void readtimer2_Tick(object sender, EventArgs e)
        {
            tagMutex3.WaitOne();

            int[] ant = (int[])activedr.ParamGet("ConnectedAntennas");
            SimpleReadPlan readplan = new SimpleReadPlan(TagProtocol.GEN2, ant);
            activedr.ParamSet("ReadPlan", readplan);
            
            int flag = 0;
            int count = 0;           
            
            TagReadData[] reads = activedr.Read(500);

            //如果读取到数据
            if (reads.Length != 0)
            {
                //遍历独到的数组的每一个值
                foreach (TagReadData tag in reads)
                {
                    //如果不是以D开头的则抛弃
                    if (tag.EPCString.First() != 'D')
                        continue;
                    
                    //将该标签的EPC和时间戳存到临时变量里
                    string studentid = tag.EPCString;
                    string time = tag.Time.ToString();

                    //判断连接的天线
                    if (tag.Antenna == 2)
                    {
                        //判断得到的EPC是否在刷新列表中
                        foreach (string epc in libraryrefreshlist)
                        {
                            if (studentid == epc)
                            {
                                    //如果在列表中，则flag置为1，避免后续继续判断
                                    flag = 1;
                             }
                        }

                        if (flag == 0)
                        {                         
                            //pictureBox4.Visible = true;
                            //try
                            //{
                            //    pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\image\\" + studentid + ".jpg");
                            //}
                            //catch (Exception ee)
                            //{
                            //    pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\image\\人.jpg");
                            //}


                            label10.Text = studentid;
                            label10.Visible = true;
                            label14.Visible = true;
                            label14.Text = time;
                            string str1 = "select * from activetime where studentid  = '" + studentid + "' and place = '图书馆'";
                            bool exist = DataAccess.sql_exist(str1);
                            if (exist)
                            {
                                string str2 = "select top 1  state  from activetime where studentid = '" + studentid + "' and place = '图书馆' order by id desc";
                                DataSet ds = DataAccess.GetDataSetBySql(str2);
                                string state = ds.Tables[0].Rows[0][0].ToString();
                                if (state == "进入")
                                {
                                    string str3 = "update  activetime set finishtime = '" + time + "',state = '离开' where studentid = '" + studentid + "' and state = '进入'";
                                    DataAccess.sql_command(str3);
                                    libraryrefreshlist.Add(studentid);
                                    foreach (PictureBox pic in pb)
                                    {
                                        if (studentid == pic.Tag.ToString())
                                        {
                                            leave(pic);
                                        }
                                    }

                                }
                                if (state == "离开")
                                {
                                    string str3 = "insert into activetime(studentid,begintime,place,state) values ('" + studentid + "','" + time + "','图书馆','进入')";
                                    DataAccess.sql_command(str3);
                                    libraryrefreshlist.Add(studentid);
                                    foreach (PictureBox pic in pb)
                                    {
                                        if (studentid == pic.Tag.ToString())
                                        {
                                            enterlibrary(pic);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string str3 = "insert into activetime(studentid,begintime,place,state) values ('" + studentid + "','" + time + "','图书馆','进入')";
                                DataAccess.sql_command(str3);
                                libraryrefreshlist.Add(studentid);
                                foreach (PictureBox pic in pb)
                                {
                                    if (studentid == pic.Tag.ToString())
                                    {
                                        enterlibrary(pic);
                                    }
                                }
                            }
                        }                        
                       
                    }
                    //判断连接的天线
                    if (tag.Antenna ==1)
                    {                        
                        foreach (string epc in classrefreshlist1)
                        {
                            if (studentid == epc)
                            {                               
                                flag = 1;
                            }
                        }

                        if (flag == 0)
                        {
                            //pictureBox2.Visible = true;
                            //try
                            //{
                            //    pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\image\\" + studentid + ".jpg");
                            //}
                            //catch (Exception ee)
                            //{
                            //    pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\image\\人.jpg");
                            //}
                            label8.Text = studentid;
                            label8.Visible = true;
                            label12.Visible = true;
                            label12.Text = time;
                            string str1 = "select * from activetime where studentid  = '" + studentid + "' and place = '教室1'";
                            bool exist = DataAccess.sql_exist(str1);
                            if (exist)
                            {
                                string str2 = "select top 1  state  from activetime where studentid = '" + studentid + "' and place = '教室1' order by id desc";
                                DataSet ds = DataAccess.GetDataSetBySql(str2);
                                string state = ds.Tables[0].Rows[0][0].ToString();
                                if (state == "进入")
                                {
                                    string str3 = "update  activetime set finishtime = '" + time + "',state = '离开' where studentid = '" + studentid + "' and state = '进入' ";
                                    DataAccess.sql_command(str3);
                                    classrefreshlist1.Add(studentid);
                                    foreach (PictureBox pic in pb)
                                    {
                                        if (studentid == pic.Tag.ToString())
                                        {
                                            leave(pic);
                                        }
                                    }
                                }
                                if (state == "离开")
                                {
                                    string str3 = "insert into activetime(studentid,begintime,place,state) values ('" + studentid + "','" + time + "','教室1','进入')";
                                    DataAccess.sql_command(str3);
                                    classrefreshlist1.Add(studentid);
                                    foreach (PictureBox pic in pb)
                                    {
                                        if (studentid == pic.Tag.ToString())
                                        {
                                            enterclassroom1(pic);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string str3 = "insert into activetime(studentid,begintime,place,state) values ('" + studentid + "','" + time + "','教室1','进入')";
                                DataAccess.sql_command(str3);
                                classrefreshlist1.Add(studentid);
                                foreach (PictureBox pic in pb)
                                {
                                    if (studentid == pic.Tag.ToString())
                                    {
                                        enterclassroom1(pic);
                                    }
                                }
                            }
                        }

                    }
                    //判断连接的天线
                    if (tag.Antenna == 3)
                    {
                        foreach (string epc in classrefreshlist2)
                        {
                            if (studentid == epc)
                            {
                                flag = 1;
                            }
                        }

                        if (flag == 0)
                        {
                            //pictureBox3.Visible = true;
                            //try
                            //{
                            //    pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\image\\" + studentid + ".jpg");
                            //}
                            //catch (Exception ee)
                            //{
                            //    pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\image\\人.jpg");
                            //}
                            label9.Text = studentid;
                            label9.Visible = true;
                            label13.Text = time;
                            label13.Visible = true;
                            string str1 = "select * from activetime where studentid  = '" + studentid + "' and place = '教室2'";
                            bool exist = DataAccess.sql_exist(str1);
                            if (exist)
                            {
                                string str2 = "select top 1  state  from activetime where studentid = '" + studentid + "' and place = '教室2' order by id desc";
                                DataSet ds = DataAccess.GetDataSetBySql(str2);
                                string state = ds.Tables[0].Rows[0][0].ToString();
                                if (state == "进入")
                                {
                                    string str3 = "update  activetime set finishtime = '" + time + "',state = '离开' where studentid = '" + studentid + "' and state = '进入'";
                                    DataAccess.sql_command(str3);
                                    classrefreshlist2.Add(studentid);
                                    foreach (PictureBox pic in pb)
                                    {
                                        if (studentid == pic.Tag.ToString())
                                        {
                                            leave(pic);
                                        }
                                    }
                                }
                                if (state == "离开")
                                {
                                    string str3 = "insert into activetime(studentid,begintime,place,state) values ('" + studentid + "','" + time + "','教室2','进入')";
                                    DataAccess.sql_command(str3);
                                    classrefreshlist2.Add(studentid);
                                    foreach (PictureBox pic in pb)
                                    {
                                        if (studentid == pic.Tag.ToString())
                                        {
                                            enterclassroom2(pic);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string str3 = "insert into activetime(studentid,begintime,place,state) values ('" + studentid + "','" + time + "','教室2','进入')";
                                DataAccess.sql_command(str3);
                                classrefreshlist2.Add(studentid);
                                foreach (PictureBox pic in pb)
                                {
                                    if (studentid == pic.Tag.ToString())
                                    {
                                        enterclassroom2(pic);
                                    }
                                }
                            }
                        }
                        

                    }

                    //判断连接的天线
                    if (tag.Antenna == 4)
                    {
                        foreach (string epc in computerrefreshlist)
                        {
                            if (studentid == epc)
                            {
                                flag = 1;
                            }
                        }

                        if (flag == 0)
                        {
                            //pictureBox5.Visible = true;
                            //try
                            //{
                            //    pictureBox5.Image = Image.FromFile(Application.StartupPath + "\\image\\" + studentid + ".jpg");
                            //}
                            //catch (Exception ee)
                            //{
                            //    pictureBox5.Image = Image.FromFile(Application.StartupPath + "\\image\\人.jpg");
                            //}
                            label11.Text = studentid;
                            label11.Visible = true;
                            label15.Text = time;
                            label15.Visible = true;
                            string str1 = "select * from activetime where studentid  = '" + studentid + "' and place = '机房'";
                            bool exist = DataAccess.sql_exist(str1);
                            if (exist)
                            {
                                string str2 = "select top 1  state  from activetime where studentid = '" + studentid + "' and place = '机房' order by id desc";
                                DataSet ds = DataAccess.GetDataSetBySql(str2);
                                string state = ds.Tables[0].Rows[0][0].ToString();
                                if (state == "进入")
                                {
                                    string str3 = "update  activetime set finishtime = '" + time + "',state = '离开' where studentid = '" + studentid + "' and state = '进入'";
                                    DataAccess.sql_command(str3);
                                    computerrefreshlist.Add(studentid);
                                    foreach (PictureBox pic in pb)
                                    {
                                        if (studentid == pic.Tag.ToString())
                                        {
                                            leave(pic);
                                        }
                                    }
                                }
                                if (state == "离开")
                                {
                                    string str3 = "insert into activetime(studentid,begintime,place,state) values ('" + studentid + "','" + time + "','机房','进入')";
                                    DataAccess.sql_command(str3);
                                    computerrefreshlist.Add(studentid);
                                    foreach (PictureBox pic in pb)
                                    {
                                        if (studentid == pic.Tag.ToString())
                                        {
                                            computerroom(pic);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string str3 = "insert into activetime(studentid,begintime,place,state) values ('" + studentid + "','" + time + "','机房','进入')";
                                DataAccess.sql_command(str3);
                                computerrefreshlist.Add(studentid);
                                foreach (PictureBox pic in pb)
                                {
                                    if (studentid == pic.Tag.ToString())
                                    {
                                        computerroom(pic);
                                    }
                                }
                            }
                        }

                    }


                }
                    
            }
            tagMutex3.ReleaseMutex();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dingwei f = new dingwei();

            f.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            (new 操场活动()).ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            学生信息管理 xf = new 学生信息管理();
            xf.Show();
        }

        private void 开始监管ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //连接读写器,创建reader
            try
            {
                //连接门口的读写器
                doordr = Reader.Create(conip1, ModuleTech.Region.NA, (ReaderType)1);
                //连接柜子里的的读写器，4跟天线分别作为教室和图书馆、机房
                activedr = Reader.Create(conip2, ModuleTech.Region.NA, (ReaderType)1);

                MessageBox.Show("成功");
            }
            catch (Exception ex)
            {
                //连接失败抛出异常
                MessageBox.Show("连接失败" + ex.ToString());
                return;
            }
            //3个timer开始运行
            readtimer1.Enabled = true;
            readtimer2.Enabled = true;
            refreshtimer.Enabled = true;

            panel2.BackgroundImage = Image.FromFile("绿灯.png");
        }

        private void 学生到校情况查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            到校时刻查询 dx = new 到校时刻查询();
            dx.Show();
        }

        private void 学生活动情况查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            活动时刻查询 af = new 活动时刻查询();
            af.Show();
        }

        private void 教师批改作业ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frm_markEdit()).ShowDialog();
        }

        private void 学生作业情况查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frm_markManage()).ShowDialog();
        }

        private void 操场活动定位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dingwei f = new dingwei();

            f.Show();
        }

        private void 操场活动情况管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new 操场活动()).ShowDialog();
        }

        private void 结束监管ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //停止2个timer的运行
            readtimer1.Enabled = false;
            readtimer2.Enabled = false;
            refreshtimer.Enabled = false;

            //断开2个读写器的连接
            try
            {
                doordr.Disconnect();
                activedr.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("断开出现问题" + ex.ToString());
                return;
            }
            MessageBox.Show("已断开");
            panel2.BackgroundImage = Image.FromFile("红灯.png");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void 设备管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查询学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            学生信息管理 xxgl = new 学生信息管理 ();
            xxgl.Show();
        }

        private void 新增学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            增加学生信息 zj = new 增加学生信息();
            zj.Show();
        }

        private void 更换RFID卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            更换RFID卡 gh = new 更换RFID卡();
            gh.Show();
        }

        private void 导出活动记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //导出活动记录 dc = new 导出活动记录();
            //dc.Show();
        }

        public void createpicbox()
        {
            
            string sql = "select studentid from stu group by studentid";
            DataSet ds = DataAccess.GetDataSetBySql(sql);

            int num = ds.Tables[0].Rows.Count;
            pb =new  PictureBox[num];

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string studentid = ds.Tables[0].Rows[i][0].ToString();
                pb[i] = new PictureBox();
                pb[i].Tag = studentid;
                try
                {
                       pb[i].Image = Image.FromFile(Application.StartupPath + "\\image\\" + studentid + ".jpg");
                }
                catch (Exception e)
                {

                }
                pb[i].Width = 56;
                pb[i].Height = 64;
                panel1.Controls.Add(pb[i]);
                pb[i].Visible = false ;

            }
        }

        public void enterclassroom1(PictureBox pic)
        {
            Random rd = new Random();
            int left = rd.Next(807, 871);
            int top = rd.Next(73, 132);            
            pic.Location =new  Point(left,top);
            pic.Visible = true;
        }
        public void enterclassroom2(PictureBox pic)
        {
            Random rd = new Random();
            int left = rd.Next(807, 871);
            int top = rd.Next(206, 267);
            pic.Location = new Point(left, top);
            pic.Visible = true;
        }
        public void enterlibrary(PictureBox pic)
        {
            Random rd = new Random();
            int left = rd.Next(807, 871);
            int top = rd.Next(337, 396);
            pic.Location = new Point(left, top);
            pic.Visible = true;
        }
        public void computerroom(PictureBox pic)
        {
            Random rd = new Random();
            int left = rd.Next(807, 871);
            int top = rd.Next(470, 532);
            pic.Location = new Point(left, top);
            pic.Visible = true;
        }

        public void leave(PictureBox pic)
        {
            pic.Visible = false;
        }

        private void BASAISFUCTION_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void BASAISFUCTION_FormClosing(object sender, FormClosingEventArgs e)
        {
            //检查timer是否停止，如果没有停止3个timer的运行
            if (readtimer1.Enabled == true)
            {
                readtimer1.Enabled = false;
            }
            if (readtimer2.Enabled == true)
            {
                readtimer2.Enabled = false;
            }
            if (refreshtimer.Enabled == true)
            {
                refreshtimer.Enabled = false;
            }       
            
            //检查读写器是否断开，如果没有则断开，2个读写器的连接
            if (doordr != null)
            {
                doordr = null;
            }
            if (activedr != null)
            {
                activedr = null;
            }
            
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void 上课活动管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainWindow sk = new MainWindow();
            sk.Show();
            
        }

        private void 自习活动管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            audiowindow zx = new audiowindow();
            zx.Show();
        }

        private void 上课活动查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            上课活动查询 skhd = new 上课活动查询();
            skhd.Show();
        }
    }
    
    
}
