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
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;


namespace schoolmanager
{
    public partial class 导出活动记录 : Form
    {
        public 导出活动记录()
        {
            InitializeComponent();
        }

        private void 导出活动记录_Load(object sender, EventArgs e)
        {
            string sql = "select studentid from stu group by studentid";
            DataSet ds = DataAccess.GetDataSetBySql(sql);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "studentid"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentid = comboBox1 .Text.Trim().ToString();            
            
            //新建文档
            Word.Application newapp = new Word.Application();
            Word.Document newdoc = new Word.Document(); ;
            object nothing = System.Reflection.Missing.Value;//用于作为函数的默认参数
            newdoc = newapp.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);//生成一个word文档
            newapp.Visible = false;//是否显示word程序界面

            //文字设置(Selection表示当前选择集，如果当前没有选择对像，则指对光标所在处进行设置)
            newapp.Selection.Font.Size = 14;
            newapp.Selection.Font.Bold = 0;
            newapp.Selection.Font.Color = Word.WdColor.wdColorBlack;
            newapp.Selection.Font.Name = "宋体";

            //插入日期
            string strContent = dateTimePicker1.Value.ToShortDateString() + "\n";            
            newdoc.Paragraphs.Last.Range.Text = strContent;

            //插入学生基本信息
            string sql1 = "select studentid,name,grade,class from stu where studentid = '" + studentid + "'";
            DataSet ds1 = DataAccess.GetDataSetBySql(sql1);
            string wordstrbasic = ds1.Tables[0].Rows[0][0].ToString() + " , " + ds1.Tables[0].Rows[0][1].ToString() + "," +
                ds1.Tables[0].Rows[0][2].ToString() + "年级" + ds1.Tables[0].Rows[0][3].ToString() + "班\n";
            newdoc.Paragraphs.Last.Range.Text = wordstrbasic ;

            //插入学生当天活动情况
            string sql2 = "select begintime,finishtime,processtime,place from activetime where studentid = '" + studentid + "' and DATEDIFF(day ,begintime,'" + dateTimePicker1.Value.ToShortDateString() + "')=0";
            bool active = DataAccess.sql_exist(sql2);
            if (active == true)
            {
                DataSet ds2 = DataAccess.GetDataSetBySql(sql2);

                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    string begintime = ds2.Tables[0].Rows[i][0].ToString();
                    string time1 = timecut(begintime);
                    string finishtime = ds2.Tables[0].Rows[i][1].ToString();
                    string time2 = timecut(finishtime);
                    string processtime = ds2.Tables[0].Rows[i][2].ToString();
                    string time3 = timecut(processtime);
                    string place = ds2.Tables[0].Rows[i][3].ToString();

                    string wordstractive = time1 + "进入" + place + "," + time2 + "离开" + place + ",在" + place + "学习时间为" + time3 + "。\n";
                    newdoc.Paragraphs.Last.Range.Text = wordstractive;
                }
            }
            if (active ==false )
            {
                MessageBox.Show("该生今天没有活动记录");
                string wordstrs = "该同学今天没有活动记录\n";
                newdoc.Paragraphs.Last.Range.Text = wordstrs;
            }   
        
            //插入当天运动记录
            string sql4 = " select top 1 begintime,finishtime,processtime,place from play where studentid = '" + studentid + "'order by finishtime desc";
            bool play = DataAccess.sql_exist(sql4);
            if (play == true)
            {
                DataSet ds4= DataAccess.GetDataSetBySql(sql4);
                string begintime = ds4.Tables[0].Rows[0][0].ToString();
                string time1 = timecut(begintime);
                string finishtime = ds4.Tables[0].Rows[0][1].ToString();
                string time2 = timecut(finishtime);
                string processtime = ds4.Tables[0].Rows[0][2].ToString();
                string time3 = timecut(processtime);
                string place = ds4.Tables[0].Rows[0][3].ToString();

                string wordstractive = time1 + "进入" + place + "," + time2 + "离开" + place + ",在" + place + "运动时间为" + time3 + "。\n";
                newdoc.Paragraphs.Last.Range.Text = wordstractive;
            }
            if (play == false)
            {
                MessageBox.Show("该生今天没有运动记录");
                string wordstrs = "该同学今天没有运动记录\n";
                newdoc.Paragraphs.Last.Range.Text = wordstrs;
            }
            
            

            //插入当天学习情况
            string sql3 = "select score from mark where studentid = '" + studentid + "' and DATEDIFF(day ,adddate,'" + dateTimePicker1.Value.ToShortDateString() + "')=0 ";
            bool score = DataAccess.sql_exist(sql3);
            if (score == false)
            {
                MessageBox.Show("该生今天没有录入成绩");
                string wordstrscore = "该同学今天没有录入成绩\n";
                newdoc.Paragraphs.Last.Range.Text = wordstrscore;

            }
            if (score == true)
            {
                DataSet ds3 = DataAccess.GetDataSetBySql(sql3);
                string wordstrscore = "该同学今天的成绩为" + ds3.Tables[0].Rows[0][0].ToString();
                newdoc.Paragraphs.Last.Range.Text = wordstrscore;
            }
            

            //保存文档
            string  dt = dateTimePicker1.Value.ToString();
            string dtstr = datecut(dt);

            object name = "D:\\"+studentid + dtstr +".doc"; 
            if (File.Exists((string)name))
            {
                File.Delete((string)name);
            }
            newdoc.SaveAs(ref name, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                   ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                   ref nothing, ref nothing);
            

            //关闭文档
            object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
            newdoc.Close(ref nothing, ref nothing, ref nothing);
            newapp.Application.Quit(ref saveOption, ref nothing, ref nothing);
            newdoc = null;
            newapp = null;
            MessageBox.Show("记录导出成功！请在本地磁盘D盘中查看！");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        public string timecut(string inputtime)
        {
            DateTime temptime = Convert.ToDateTime(inputtime);
            string hour = temptime.Hour.ToString();

            string minute = temptime.Minute.ToString();
            if (int.Parse(minute) <10)
            {
                minute = "0" + minute;
            }

            string second = temptime.Second.ToString();
            if (int.Parse(second) < 10)
            {
                second = "0" + second;
            }
            string outputtime = hour  + ":" + minute  + ":" + second;          
            return outputtime;
        }

        public string datecut(string inputtime)
        {
            DateTime temptime = Convert.ToDateTime(inputtime);
            string year = temptime.Year.ToString();

            string day = temptime.Day.ToString();
            if (int.Parse(day) < 10)
            {
                day = "0" + day;
            }

            string month = temptime.Month.ToString();
            if (int.Parse(month) < 10)
            {
                month  = "0" + month ;
            }
            string outputtime = year + month  + day;
            return outputtime;
        }
    }
}
