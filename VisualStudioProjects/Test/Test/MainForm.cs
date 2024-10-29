using ConsoleApp12;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class MainForm : Form
    {
        public static int Aid = 0;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //查询、模糊查
        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text.Trim();

            //string sql = "select * from Student s join Address a on a.Aid=s.Aid where Name like '%@Name%'";
            string sql = "select s.Id,s.Name,s.Age,a.Address " +
                "from Student s join Address a on a.Aid=s.Aid " +
                "where Name like '%" + textBox1.Text + "%'";
            SqlDataReader sdr = DBHelper.GetDataReader(sql);

            //dataGridView1.DataSource = sdr;



            //SqlParameter[] paras = new SqlParameter[1];
            //paras[0] = new SqlParameter("@Name", Name);

            //DataTable dt = DBHelperSQL.GetDataTable(sql);
            //dataGridView1.AutoGenerateColumns = false;//取消自动创建列
            //dataGridView1.DataSource = dt;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDGV();//刷新
        }

        private void RefreshDGV()
        {
            string sql = "select s.Id,s.Name,s.Age,a.Address from Student s join Address a on s.Aid = a.Aid";
            SqlConnection conn = new SqlConnection("server =.; database=TestDB;Integrated Security = true");
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;

            //DataTable dt = DBHelperSQL.GetDataTable(sql);
            //dataGridView1.AutoGenerateColumns = false;//取消自动创建列
            //dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Student s = new Student()
            {
                Name1 = textBox2.Text,
                Age1 = int.Parse(textBox3.Text),
                Aid1 = int.Parse(textBox4.Text)

                //ProductName = textBox1.Text,
                //ProductPrice = decimal.Parse(textBox2.Text),
                //ClassID = (int)comboBox1.SelectedValue  //下拉框选中的值
            };
            //执行写入操作
            string sql = string.Format("insert Student values('{0}',{1},{2})", s.Name1, s.Age1, s.Aid1);
            if (DBHelper.ExecuteNonQuery(sql))
            {
                MessageBox.Show("添加成功!");
                RefreshDGV();//刷新
            }
            else
            {
                MessageBox.Show("添加失败!");
            }
        }
    }
}