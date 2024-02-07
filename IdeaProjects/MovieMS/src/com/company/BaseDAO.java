package com.company;

import java.sql.*;

public class BaseDAO {
    private static final String url="jdbc:mysql://localhost:3306/moviedb",
    user="root",pwd="123456",DriverName="com.mysql.jdbc.Driver";
    static {
        try {
            Class.forName(DriverName);
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
    public static Connection getconn(){
        try {
            return DriverManager.getConnection(url,user,pwd);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
    public static void closeconn(ResultSet rs, PreparedStatement ps,Connection conn){
                try {
                    if (rs != null)
                        rs.close();
                    if (ps !=null)
                        ps.cancel();
                    if (conn !=null)
                        conn.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

        }