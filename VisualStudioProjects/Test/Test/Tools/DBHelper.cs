using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp12
{
    //对数据库做查询、增删改、聚合函数
    class DBHelper
    {
        //连接字符串
        public static string connString = "server=.;database=TestDb;Integrated Security=true";
											// "server=.;database=Stu_Info_MS;uid=sa;pwd=123456";

        //连接对象
        public static SqlConnection conn=null;
        
        //初始化数据库连接
        public static void InitConnection()
        {
            //如果连接对象不存在，则创建
            if (conn==null)
            {
                conn = new SqlConnection(connString);
            }

            //如果连接被关闭，要打开
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }

            //如果连接中断，重启
            if (conn.State==ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }            
        }

        //查询   
        public static SqlDataReader GetDataReader(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr,conn);
            //如果reader被关闭，自动关闭占用的连接对象
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);            
        }

        //增删改
        public static bool ExecuteNonQuery(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr,conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }

        //聚合函数
        public static object ExecuteScalar(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            object result =  cmd.ExecuteScalar();
            conn.Close();
            return result;
        }
    } 
}
