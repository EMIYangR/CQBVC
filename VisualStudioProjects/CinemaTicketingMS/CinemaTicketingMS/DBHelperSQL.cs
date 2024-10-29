using System;
using System.Collections;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

namespace CinemaTicketingMS
{
    class DBHelperSQL
    {
        private static string connString =
            "server=.;database=lingju;uid=sa;pwd=123456;";
        //"server=.;databse=JW3_Test;Integrated Security=true;";

        private static SqlConnection conn = null;
        //初始化连接
        public static void InitConnection()
        {
            if (conn == null)//为空则初始化
                conn = new SqlConnection(connString);
            if (conn.State == ConnectionState.Closed)//关闭则打开
                conn.Open();
            if (conn.State == ConnectionState.Broken)//损坏则重启
            {
                conn.Close();
                conn.Open();
            }
        }
        //1.1、查询  非断开式
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
        //1.2、查询  带参数输入返回SqlDataReader
        public static SqlDataReader GetDataReaderByParas(string SQLString,
            params SqlParameter[] cmdParms)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, conn, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }

        }

        //1.3、查询  断开式  获取DataTable，与Winform中控件绑定更方便
        public static DataTable GetDataTable(string sql)
        {
            try
            {
                InitConnection();
                DataSet ds = new DataSet();//缓存区
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//输水管
                sda.Fill(ds);//将数据放入缓冲区  数据库->内存
                conn.Close();
                return ds.Tables[0];//取第一张表
            }
            catch (Exception)
            {
                throw;
            }
        }
        //1.4、查询 带参数输入返回DataSet
        public static DataSet GetDataSetByParas(string SQLString,
            params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, conn, null, SQLString, cmdParms);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        //2.1、增删改
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
        //2.2、带参数的sql语句 增删改
        public static int ExecuteNonQueryByParas(string SQLString,
            params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, conn, null, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
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


        //4、 执行存储过程，返回SqlDataReader 
        public static SqlDataReader GetDataReaderByProc(string procName,
            IDataParameter[] parameters)
        {
            InitConnection();
            SqlCommand cmd = BuildQueryCommand(conn, procName, parameters);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;//一定要关闭dr  dr.Close()
        }
        private static SqlCommand BuildQueryCommand(SqlConnection conn,
                            string procName, IDataParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(procName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput ||
                        parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
            return cmd;
        }

        //5、执行存储过程，返回受影响行数
        public static int ExecuteNonQueryByProc(string procName, IDataParameter[] parameters,
            out int rowsAffected)
        {
            InitConnection();
            SqlCommand command = BuildIntCommand(conn, procName, parameters);
            rowsAffected = command.ExecuteNonQuery();
            int result = (int)command.Parameters["ReturnValue"].Value;
            conn.Close();
            return result;
            //rowsAffected为存储过程实际影响行数，result为存储过程返回值(默认为0成功)
        }
        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string procName,
                        IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, procName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        //6、字段是否存在
        public static bool ColumnExists(string tableName, string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = GetDataReader(sql);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }
        //7、获取最大编号+1
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetDataReader(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        //8、表是否存在
        public static bool TabExists(string TableName)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = GetDataReader(strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //9、一次性执行多条sql语句，带事务
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            InitConnection();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    //循环
                    foreach (DictionaryEntry myDE in SQLStringList)
                    {
                        string cmdText = myDE.Key.ToString();
                        SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                        PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }

        }
    }
}
