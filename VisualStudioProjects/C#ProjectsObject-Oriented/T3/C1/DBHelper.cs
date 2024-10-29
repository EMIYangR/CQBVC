using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

namespace T12
{
    class DBHelper
    {
        private static string connString =
            "server=.;database=sa;uid=sa;pwd=123456;";
        //"server=.;databse=FreshLiveDB;Integrated Security=true;";

        private static SqlConnection conn = null;
        //初始化连接
        public static void InitConnection()
        {
            if (conn==null)//为空则初始化
                conn = new SqlConnection(connString);
            if (conn.State == ConnectionState.Closed)//关闭则打开
                conn.Open();
            if (conn.State == ConnectionState.Broken)//损坏则重启
            {
                conn.Close();
                conn.Open();
            }
        }
        //1、查询
        public static SqlDataReader GetDataReader(string sql)
        {
            try
            {
                InitConnection();
                SqlCommand cmd = new SqlCommand(sql, conn);//用于执行sql的对象
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);//执行完成自动关闭conn
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        //2、增删改
        public static bool ExecuteNonQuery(string sql)
        {
            try
            {
                InitConnection();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//增删改
                conn.Close();
                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        //3、聚合函数
        public static object ExecuteScalar(string sql)
        {
            try
            {
                InitConnection();
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();//聚合函数
                conn.Close();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
