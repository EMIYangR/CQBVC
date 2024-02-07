/*
 * Created by JFormDesigner on Thu Jun 16 14:01:09 CST 2022
 */

package com.company;

import java.awt.*;
import java.awt.event.*;
import java.sql.*;
import java.util.*;
import javax.swing.*;
import javax.swing.table.*;

/**
 * @author Brainrain
 */
public class OrderDAO extends JFrame {
    public OrderDAO() {
        initComponents();
        showData("");
        this.setSize(800,600);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(true);
    }

    public void showData(String OrderID){
        String sql = "select * from tb_order where orderId like ?";
        Connection conn = BaseDAO.getConnection();
        try {
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1,"%"+OrderID+"%");
            ResultSet rs = ps.executeQuery();
            data = new Vector<Vector<Object>>();
            while (rs.next()) {
                Vector<Object> data1 = new Vector<Object>();
                data1.add(rs.getInt("id"));
                data1.add(rs.getString("name"));
                data1.add(rs.getDouble("price"));
                data1.add(rs.getString("orderId"));
                data1.add(rs.getString("descinfo"));
                data.add(data1);
            }
            BaseDAO.closeConnection(rs, ps, conn);

            Vector<String> heads = new Vector<String>();

            heads.add("编号");
            heads.add("商品名称");
            heads.add("价格");
            heads.add("所属订单单号");
            heads.add("描述");

            DefaultTableModel dtm = new DefaultTableModel(data, heads);
            table1.setModel(dtm);

        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
    }
    //请空输入框
    public void ClearData(){
        textField2.setText("");
        textField3.setText("");
        textField4.setText("");
        textField5.setText("");
    }
    //模糊查
    private void button1MouseClicked(MouseEvent e) {
        // TODO add your code here
        showData(textField1.getText());
    }
    //添加
    private void button2MouseClicked(MouseEvent e) {
        // TODO add your code here
        dialog1.setSize(350,350);
        dialog1.setVisible(true);
    }
    //确定
    private void button4MouseClicked(MouseEvent e) {
        // TODO add your code here
        Order order = new Order();

        order.setName(textField2.getText());
        order.setPrice(Double.parseDouble((textField3.getText())));
        order.setOrderId(textField4.getText());
        order.setDescinfo(textField5.getText());

        String sql="insert tb_order values (0,?,?,?,?)";
        Connection conn=BaseDAO.getConnection();
        try {
            PreparedStatement ps=conn.prepareStatement(sql);
            ps.setString(1,order.getName());
            ps.setDouble(2,order.getPrice());
            ps.setString(3,order.getOrderId());
            ps.setString(4,order.getDescinfo());
            if (ps.executeUpdate()>0){
                showData("");
                ClearData();
                JOptionPane.showMessageDialog(null,"添加成功！");
            }else {
                JOptionPane.showMessageDialog(null,"添加失败！");
            }
        } catch (SQLException ex) {
            ex.printStackTrace();
        }
    }
    //取消
    private void button5MouseClicked(MouseEvent e) {
        // TODO add your code here
        dialog1.dispose();
        ClearData();
    }

    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        textField1 = new JTextField();
        button1 = new JButton();
        button2 = new JButton();
        panel1 = new JPanel();
        scrollPane1 = new JScrollPane();
        table1 = new JTable();
        dialog1 = new JDialog();
        label1 = new JLabel();
        label2 = new JLabel();
        label3 = new JLabel();
        label4 = new JLabel();
        textField2 = new JTextField();
        textField3 = new JTextField();
        textField4 = new JTextField();
        textField5 = new JTextField();
        button4 = new JButton();
        button5 = new JButton();

        //======== this ========
        setTitle("\u7269\u6d41\u8ddf\u8e2a\u7ba1\u7406\u7cfb\u7edf");
        Container contentPane = getContentPane();
        contentPane.setLayout(null);
        contentPane.add(textField1);
        textField1.setBounds(45, 25, 450, 30);

        //---- button1 ----
        button1.setText("\u641c\u7d22");
        button1.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button1MouseClicked(e);
            }
        });
        contentPane.add(button1);
        button1.setBounds(new Rectangle(new Point(500, 25), button1.getPreferredSize()));

        //---- button2 ----
        button2.setText("\u6dfb\u52a0");
        button2.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button2MouseClicked(e);
            }
        });
        contentPane.add(button2);
        button2.setBounds(new Rectangle(new Point(600, 25), button2.getPreferredSize()));

        //======== panel1 ========
        {
            panel1.setLayout(null);

            //======== scrollPane1 ========
            {
                scrollPane1.setViewportView(table1);
            }
            panel1.add(scrollPane1);
            scrollPane1.setBounds(0, 0, 600, scrollPane1.getPreferredSize().height);

            {
                // compute preferred size
                Dimension preferredSize = new Dimension();
                for(int i = 0; i < panel1.getComponentCount(); i++) {
                    Rectangle bounds = panel1.getComponent(i).getBounds();
                    preferredSize.width = Math.max(bounds.x + bounds.width, preferredSize.width);
                    preferredSize.height = Math.max(bounds.y + bounds.height, preferredSize.height);
                }
                Insets insets = panel1.getInsets();
                preferredSize.width += insets.right;
                preferredSize.height += insets.bottom;
                panel1.setMinimumSize(preferredSize);
                panel1.setPreferredSize(preferredSize);
            }
        }
        contentPane.add(panel1);
        panel1.setBounds(new Rectangle(new Point(45, 85), panel1.getPreferredSize()));

        {
            // compute preferred size
            Dimension preferredSize = new Dimension();
            for(int i = 0; i < contentPane.getComponentCount(); i++) {
                Rectangle bounds = contentPane.getComponent(i).getBounds();
                preferredSize.width = Math.max(bounds.x + bounds.width, preferredSize.width);
                preferredSize.height = Math.max(bounds.y + bounds.height, preferredSize.height);
            }
            Insets insets = contentPane.getInsets();
            preferredSize.width += insets.right;
            preferredSize.height += insets.bottom;
            contentPane.setMinimumSize(preferredSize);
            contentPane.setPreferredSize(preferredSize);
        }
        pack();
        setLocationRelativeTo(getOwner());

        //======== dialog1 ========
        {
            dialog1.setTitle("\u65b0\u589e\u8ba2\u5355");
            Container dialog1ContentPane = dialog1.getContentPane();
            dialog1ContentPane.setLayout(null);

            //---- label1 ----
            label1.setText("\u5546\u54c1\u540d\u79f0\uff1a");
            dialog1ContentPane.add(label1);
            label1.setBounds(new Rectangle(new Point(45, 25), label1.getPreferredSize()));

            //---- label2 ----
            label2.setText("\u5546\u54c1\u4ef7\u683c\uff1a");
            dialog1ContentPane.add(label2);
            label2.setBounds(new Rectangle(new Point(45, 75), label2.getPreferredSize()));

            //---- label3 ----
            label3.setText("\u8ba2\u5355\u7f16\u53f7\uff1a");
            dialog1ContentPane.add(label3);
            label3.setBounds(new Rectangle(new Point(45, 125), label3.getPreferredSize()));

            //---- label4 ----
            label4.setText("\u8ba2\u5355\u63cf\u8ff0\uff1a");
            dialog1ContentPane.add(label4);
            label4.setBounds(new Rectangle(new Point(45, 175), label4.getPreferredSize()));
            dialog1ContentPane.add(textField2);
            textField2.setBounds(125, 18, 175, 30);
            dialog1ContentPane.add(textField3);
            textField3.setBounds(125, 68, 175, 30);
            dialog1ContentPane.add(textField4);
            textField4.setBounds(125, 118, 175, 30);
            dialog1ContentPane.add(textField5);
            textField5.setBounds(125, 168, 175, 30);

            //---- button4 ----
            button4.setText("\u786e\u5b9a");
            button4.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button4MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button4);
            button4.setBounds(new Rectangle(new Point(75, 235), button4.getPreferredSize()));

            //---- button5 ----
            button5.setText("\u53d6\u6d88");
            button5.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button5MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button5);
            button5.setBounds(new Rectangle(new Point(205, 235), button5.getPreferredSize()));

            {
                // compute preferred size
                Dimension preferredSize = new Dimension();
                for(int i = 0; i < dialog1ContentPane.getComponentCount(); i++) {
                    Rectangle bounds = dialog1ContentPane.getComponent(i).getBounds();
                    preferredSize.width = Math.max(bounds.x + bounds.width, preferredSize.width);
                    preferredSize.height = Math.max(bounds.y + bounds.height, preferredSize.height);
                }
                Insets insets = dialog1ContentPane.getInsets();
                preferredSize.width += insets.right;
                preferredSize.height += insets.bottom;
                dialog1ContentPane.setMinimumSize(preferredSize);
                dialog1ContentPane.setPreferredSize(preferredSize);
            }
            dialog1.pack();
            dialog1.setLocationRelativeTo(dialog1.getOwner());
        }
        // JFormDesigner - End of component initialization  //GEN-END:initComponents
    }

    // JFormDesigner - Variables declaration - DO NOT MODIFY  //GEN-BEGIN:variables
    private JTextField textField1;
    private JButton button1;
    private JButton button2;
    private JPanel panel1;
    private JScrollPane scrollPane1;
    private JTable table1;
    private JDialog dialog1;
    private JLabel label1;
    private JLabel label2;
    private JLabel label3;
    private JLabel label4;
    private JTextField textField2;
    private JTextField textField3;
    private JTextField textField4;
    private JTextField textField5;
    private JButton button4;
    private JButton button5;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
    private static Vector<Vector<Object>> data;

}
