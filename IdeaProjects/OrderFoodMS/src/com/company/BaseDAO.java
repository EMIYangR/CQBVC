package com.company;

import java.sql.*;

public class BaseDAO {
    private static final String URL = "jdbc:mysql://localhost:3306/orderfooddb",
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
}
