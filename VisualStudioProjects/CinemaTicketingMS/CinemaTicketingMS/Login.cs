using CinemaTicketingMS;
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

namespace CinemaTicketingMS
{
    public partial class Login : Form
    {
        //登录时用户所有数据的存储
        public static UserInfo _ui;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                //获取输入文本存入对象
                _ui = new UserInfo()
                {
                    UserPwd1 = textBox2.Text,
                    UserAccount1 = textBox1.Text,
                };
                string sql = string.Format("select UserName,UserID from UserInfo where UserAccount='{0}' and UserPwd='{1}'",
                                        _ui.UserAccount1, _ui.UserPwd1);
                SqlDataReader dr = DBHelperSQL.GetDataReader(sql);
                if (dr.HasRows)//信息存在，账号密码匹配
                {
                    if (dr.Read())
                    {
                        _ui.UserName1 = dr["UserName"].ToString();//获取用户名也存入
                        _ui.UserID1 = (int)dr["UserID"];
                    }
                    dr.Close();
                    //跳转主窗体
                    Index index = new Index();
                    index.ShowDialog();
                    //隐藏当前窗体
                    this.Hide();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("账号或密码输入错误!");
                }
            }
            else
            {
                MessageBox.Show("文本框未输入完成!");
            }
        }
    }
}
