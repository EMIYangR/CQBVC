package com.company;

import java.sql.*;

public class BaseDAO {
    private static final String URL = "jdbc:mysql://localhost:3306/myofficedb",
                                User = "root", Pwd = "123456",
                                DriverName = "com.mysql.jdbc.Driver";

    static {
        try {
            Class.forName(DriverName);
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
    //打开连接
    public static Connection getConnection(){
        try {
            return DriverManager.getConnection(URL,User,Pwd);
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return null;
    }
    //关闭连接
    public static void closeConnection(ResultSet rs, PreparedStatement ps, Connection conn){
        try {
            if (rs != null)  rs.close();
            if (ps != null)  ps.cancel();
            if (conn != null)  conn.close();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
    }
    //查询
    public static boolean zsg(String sql,Object...args){
        try {
            Connection conn=BaseDAO.getConnection();
            PreparedStatement ps=conn.prepareStatement(sql);
            for (int i = 0; i < args.length; i++) {
                ps.setObject(i+1, args[i]);//sql语句参数化输入
            }
            int result=ps.executeUpdate();
            BaseDAO.closeConnection(null,ps,conn);
            return result>0;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return false;
    }
}
