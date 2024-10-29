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
using ConsoleApp12;

namespace Test
{
    public partial class LoginForm : Form
    {
        public static int uid = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text.Trim();
            string Pwd = textBox2.Text.Trim();
            if (user != "" && Pwd != "")
            {
                string sql = "select * from user where UserAccount = " + user + " and UserPwd =" + Pwd;


                SqlDataReader sdr = DBHelper.GetDataReader(sql);
                if (sdr.HasRows)
                {
                    MessageBox.Show("登录成功！");
                    sdr.Close();
                    MainForm mf = new MainForm();
                    mf.Show();
                    this.Hide();
                }
                else
                {
                    sdr.Close();
                    MessageBox.Show("账号或密码不匹配！");
                }
            }
            else
            {
                MessageBox.Show("账号和密码不能为空！");
            }

            //string user = textBox1.Text.Trim();
            //string Pwd = textBox2.Text.Trim();
            //if (user != "" && Pwd != "")
            //{
            //    string sql = "select Userid from user where user=@user and Pwd=@Pwd";
            //    SqlParameter[] paras = new SqlParameter[2];
            //    paras[0] = new SqlParameter("@user", user);
            //    paras[1] = new SqlParameter("@Pwd", Pwd);

            //    DataSet ds = DBHelperSQL.GetDataSetByParas(sql, paras);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        uid = (int)ds.Tables[0].Rows[0][0];
            //        MainForm mf = new MainForm();
            //        this.Hide();
            //        mf.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBox.Show("账号或密码错误！");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("账号或密码不能为空!");
            //}
            //}
        }
    }
}
