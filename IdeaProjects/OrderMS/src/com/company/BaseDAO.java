package com.company;

import java.sql.*;

public class BaseDAO {
    private static final String DRIVER = "com.mysql.jdbc.Driver",
            URL = "jdbc:mysql://localhost:3306/orderdb",
            USER = "root",
            PASSWORD = "123456";
    static {
        try {
            Class.forName(DRIVER);
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
    //打开连接
    public static Connection getConnection(){
        try {
            return DriverManager.getConnection(URL,USER,PASSWORD);
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
