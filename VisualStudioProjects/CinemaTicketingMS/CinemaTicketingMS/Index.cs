using CinemaTicketingMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaTicketingMS
{
    public partial class Index : Form
    {
        Pager pager = new Pager();
        public Index()
        {
            InitializeComponent();
        }
        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();//关闭时退出整个应用程序，Hide()后用
        }
        private void Index_Load(object sender, EventArgs e)
        {
            label1.Text = "欢迎您，" + Login._ui.UserName1;

            //string sql = "select * from Product p join ProductClass pc on p.ClassID=pc.ClassID";
            //DataTable dt = DBHelperSQL.GetDataTable(sql);
            //dataGridView1.AutoGenerateColumns = false;//取消自动创建列
            //dataGridView1.DataSource = dt;
        }
        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            string sql1 = "select ROW_NUMBER() over(order by MovieID)  num,MovieName,MovieLength,Director,Actors,Inproduce,Price from Movies where MovieName like '%" + textBox1.Text + "%'";
            DataTable dt = DBHelperSQL.GetDataTable(sql1);
            dataGridView1.AutoGenerateColumns = false;//取消自动创建列
            dataGridView1.DataSource = dt;
        }

        //查看订单
        private void button2_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            orders.ShowDialog();
            this.Hide();
        }
        //跳转首页
        private void button3_Click(object sender, EventArgs e)
        {
            pager.FirstPage();
        }
        //跳转尾页
        private void button6_Click(object sender, EventArgs e)
        {
            pager.LastPage();
        }
        //前往上一页
        private void button4_Click(object sender, EventArgs e)
        {
            pager.PrevPage();
        }
        //前往下一页
        private void button5_Click(object sender, EventArgs e)
        {
            pager.NextPage();
        }
        //跳转指定页
        private void button7_Click(object sender, EventArgs e)
        {
            pager.ToPage(int.Parse(textBox2.Text));
        }

    }
}
