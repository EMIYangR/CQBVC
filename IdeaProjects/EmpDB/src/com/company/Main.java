package com.company;

import java.sql.*;

public class Main {

    public static void main(String[] args) {
        //连接数据库
        Connection conn = null;
        try {
            Class.forName("com.mysql.jdbc.Driver");
            conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/EmpDB", "root", "123456");
            if (conn != null) {
                System.out.println("连接成功");
            }
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        //创建Statement对象
        Statement stmt = null;
        try {
            stmt = conn.createStatement();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        //执行SQL语句
        try {
            ResultSet rs = stmt.executeQuery("select * from tb_emp");
            while (rs.next()) {
                System.out.println(rs.getString("id") + " " + rs.getString("name"));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
