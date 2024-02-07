/*
 * Created by JFormDesigner on Sun Jun 19 01:22:00 CST 2022
 */

package com.company;

import java.awt.*;
import java.awt.event.*;
import java.sql.*;
import java.util.Vector;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;

/**
 * @author Brainrain
 */
public class Index extends JFrame {
    public Index() {
        initComponents();
        showData("");
        this.setSize(800,600);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(true);
    }

    public void showData(String Name){
        String sql = "select * from studentinfo where stu_name like ?";
        Connection conn = BaseDAO.GetConnection();
        try {
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1,"%"+Name+"%");
            ResultSet rs = ps.executeQuery();
            data = new Vector<>();
            while (rs.next()){
                Vector<Object> data1 = new Vector<>();
                data1.add(rs.getInt("stu_id"));
                data1.add(rs.getString("stu_name"));
                data1.add(rs.getInt("stu_age"));
                data1.add(rs.getString("stu_phone"));
                data1.add(rs.getDouble("stu_score"));
                data.add(data1);
            }
            BaseDAO.CloseConnection(rs,ps,conn);

            Vector<String> heads = new Vector<>();
            heads.add("编号");
            heads.add("姓名");
            heads.add("年龄");
            heads.add("电话");
            heads.add("成绩");

            DefaultTableModel dtm = new DefaultTableModel(data,heads);
            table1.setModel(dtm);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void ClearData(){
        textField2.setText("");
        textField3.setText("");
        textField4.setText("");
        textField5.setText("");
    }

    private void button1MouseClicked(MouseEvent e) {
        // TODO add your code here
        showData(textField1.getText());
    }

    private void button2MouseClicked(MouseEvent e) {
        // TODO add your code here
        dialog1.setModal(true);
        dialog1.setVisible(true);
    }

    private void button3MouseClicked(MouseEvent e) {
        // TODO add your code here
        StudentInfo stu = new StudentInfo();

        stu.setStu_name(textField2.getText());
        stu.setStu_age(Integer.parseInt(textField3.getText()));
        stu.setStu_phone(textField2.getText());
        stu.setStu_score(Double.parseDouble(textField2.getText()));

        String sql = "insert studentinfo values(0,?,?,?,?)";
        Connection conn = BaseDAO.GetConnection();
        try {
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1,stu.getStu_name());
            ps.setInt(2,stu.getStu_age());
            ps.setString(3,stu.getStu_phone());
            ps.setDouble(4,stu.getStu_score());
            if (ps.executeUpdate()>0){
                showData("");
                ClearData();
                JOptionPane.showMessageDialog(null,"添加成功");
            } else {
                JOptionPane.showMessageDialog(null,"添加失败");
            }
        } catch (SQLException ex) {
            ex.printStackTrace();
        }
    }

    private void button4MouseClicked(MouseEvent e) {
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
        button3 = new JButton();
        button4 = new JButton();

        //======== this ========
        setTitle("\u5b66\u751f\u4fe1\u606f\u7ba1\u7406\u7cfb\u7edf");
        Container contentPane = getContentPane();
        contentPane.setLayout(null);
        contentPane.add(textField1);
        textField1.setBounds(25, 25, 450, 30);

        //---- button1 ----
        button1.setText("\u67e5\u8be2");
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
            scrollPane1.setBounds(0, 0, 700, scrollPane1.getPreferredSize().height);

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
        panel1.setBounds(new Rectangle(new Point(25, 85), panel1.getPreferredSize()));

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
            dialog1.setTitle("\u6dfb\u52a0\u5b66\u751f\u4fe1\u606f");
            Container dialog1ContentPane = dialog1.getContentPane();
            dialog1ContentPane.setLayout(null);

            //---- label1 ----
            label1.setText("\u59d3\u540d\uff1a");
            dialog1ContentPane.add(label1);
            label1.setBounds(new Rectangle(new Point(50, 25), label1.getPreferredSize()));

            //---- label2 ----
            label2.setText("\u5e74\u9f84\uff1a");
            dialog1ContentPane.add(label2);
            label2.setBounds(new Rectangle(new Point(50, 75), label2.getPreferredSize()));

            //---- label3 ----
            label3.setText("\u7535\u8bdd\uff1a");
            dialog1ContentPane.add(label3);
            label3.setBounds(new Rectangle(new Point(50, 125), label3.getPreferredSize()));

            //---- label4 ----
            label4.setText("\u6210\u7ee9\uff1a");
            dialog1ContentPane.add(label4);
            label4.setBounds(new Rectangle(new Point(50, 175), label4.getPreferredSize()));
            dialog1ContentPane.add(textField2);
            textField2.setBounds(100, 18, 150, 30);
            dialog1ContentPane.add(textField3);
            textField3.setBounds(100, 68, 150, 30);
            dialog1ContentPane.add(textField4);
            textField4.setBounds(100, 118, 150, 30);
            dialog1ContentPane.add(textField5);
            textField5.setBounds(100, 168, 150, 30);

            //---- button3 ----
            button3.setText("\u786e\u5b9a");
            button3.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button3MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button3);
            button3.setBounds(new Rectangle(new Point(35, 220), button3.getPreferredSize()));

            //---- button4 ----
            button4.setText("\u53d6\u6d88");
            button4.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button4MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button4);
            button4.setBounds(new Rectangle(new Point(165, 220), button4.getPreferredSize()));

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
    private JButton button3;
    private JButton button4;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
    private static Vector<Vector<Object>> data;
}
