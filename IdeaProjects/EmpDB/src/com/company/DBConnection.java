package com.company;

import java.io.InputStream;
import java.sql.*;
import java.util.Properties;

public class DBConnection {
    private static String DriverName;
    private static String URL;
    private static String User,PassWord;
    //2、加载驱动
    static{
        try{
            InputStream is = ClassLoader.getSystemClassLoader().getResourceAsStream("jdbc.properties");
            Properties pros = new Properties();
            pros.load(is);
            DriverName=pros.getProperty("driverClass");
            URL=pros.getProperty("url");
            User=pros.getProperty("user");
            PassWord= pros.getProperty("pwd");
            Class.forName(DriverName);
        }catch (Exception e){
            e.printStackTrace();
        }
    }

    //3、获取数据库连接
    public static Connection getConnection() throws Exception{
        try {
            return DriverManager.getConnection(URL,User,PassWord);
        } catch (SQLException e) {
            e.printStackTrace();
            throw new Exception();
        }
    }
    //4、关闭连接
    public static void close(ResultSet rs, Statement stat, Connection conn){
        try {
            if (rs!=null){
                rs.close();//结果集关闭
            }
            if (stat!=null){
                stat.cancel();
            }
            if (conn!=null){
                conn.close();//连接对象关闭
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
