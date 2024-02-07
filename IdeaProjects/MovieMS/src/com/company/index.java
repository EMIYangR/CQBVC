/*
 * Created by JFormDesigner on Tue Jun 14 17:52:16 CST 2022
 */

package com.company;

import java.awt.*;
import java.awt.event.*;
import java.math.BigDecimal;
import java.sql.*;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Vector;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;

/**
 * @author Brainrain
 */
public class index extends JFrame {
    public index() {
        initComponents();
        setSize(800,600);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setVisible(true);
    }
    private void showData(String name){
        String sql="select * from movies where name like ? order by price desc";
        Connection conn= BaseDAO.getconn();
        try {
            PreparedStatement ps=conn.prepareStatement(sql);
            ps.setString(1,"%"+name+"%");
            ResultSet rs=ps.executeQuery();
            data=new Vector<Vector<Object>>();
            while (rs.next()){
                Vector<Object> data1=new Vector<Object>();
                data1.add(rs.getInt("movieID"));
                data1.add(rs.getString("name"));
                data1.add(rs.getInt("duration"));
                data1.add(rs.getString("area"));
                data1.add(rs.getString("date"));
                data1.add(rs.getBigDecimal("price"));
                data1.add(rs.getString("addTime"));
                data.add(data1);
            }
            BaseDAO.closeconn(rs,ps,conn);
            Vector<String> heads=new Vector<String>();
            heads.add("序号");
            heads.add("片名");
            heads.add("时长");
            heads.add("地区");
            heads.add("上映日期");
            heads.add("票价");
            heads.add("添加时间");
            DefaultTableModel dtm=new DefaultTableModel(data,heads);
            table1.setModel(dtm);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    private void ClearBase(){
        textField2.setText("");
        textField3.setText("");
        textField4.setText("");
        textField5.setText("");
        textField6.setText("");
    }

    private void button1MouseClicked(MouseEvent e) {
        // TODO add your code here
        showData(textField1.getText());
        if (data.size()==0) JOptionPane.showMessageDialog(null, "暂无数据!");
    }

    private void button2MouseClicked(MouseEvent e) {
        // TODO add your code here
        dialog1.setSize(400,400);
        dialog1.setModal(true);
        dialog1.setVisible(true);
    }

    private void button4MouseClicked(MouseEvent e) {
        // TODO add your code here
        dialog1.dispose();
        ClearBase();
    }

    private void button3MouseClicked(MouseEvent e) {
        // TODO add your code here
        Movies s=new Movies();
        s.setName(textField2.getText());
        s.setDuration(Integer.parseInt(textField3.getText()));
        s.setArea(textField4.getText());
        s.setDate(textField5.getText());
        s.setPrice(BigDecimal.valueOf(Long.parseLong(textField6.getText())));
        String sql="insert movies values (0,?,?,?,?,?,?)";
        Connection conn= BaseDAO.getconn();
        try {
            PreparedStatement ps=conn.prepareStatement(sql);
            ps.setString(1,s.getName());
            ps.setInt(2,s.getDuration());
            ps.setString(3,s.getArea());
            ps.setString(4,s.getDate());
            ps.setBigDecimal(5,s.getPrice());
            String dtf= LocalDateTime.now().format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
            LocalDateTime localDateTime = LocalDateTime.parse(dtf, DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
            ps.setString(6, localDateTime.toString());
            if (ps.executeUpdate()>0){
                showData("");
                dialog1.dispose();
                ClearBase();
                JOptionPane.showMessageDialog(null,"添加成功！");
            }else {
                JOptionPane.showMessageDialog(null,"添加失败！");
            }
        } catch (SQLException ex) {
            ex.printStackTrace();
        }
    }

    private void textField1KeyPressed(KeyEvent e) {
        // TODO add your code here
    }
    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        panel1 = new JPanel();
        scrollPane1 = new JScrollPane();
        table1 = new JTable();
        button1 = new JButton();
        button2 = new JButton();
        textField1 = new JTextField();
        dialog1 = new JDialog();
        label1 = new JLabel();
        textField2 = new JTextField();
        label2 = new JLabel();
        textField3 = new JTextField();
        label3 = new JLabel();
        textField4 = new JTextField();
        label4 = new JLabel();
        textField5 = new JTextField();
        label5 = new JLabel();
        textField6 = new JTextField();
        button3 = new JButton();
        button4 = new JButton();

        //======== this ========
        setTitle("\u5f71\u9662\u552e\u7968\u7cfb\u7edf");
        Container contentPane = getContentPane();
        contentPane.setLayout(null);

        //======== panel1 ========
        {
            panel1.setLayout(new GridLayout());
        }
        contentPane.add(panel1);
        panel1.setBounds(new Rectangle(new Point(115, 110), panel1.getPreferredSize()));

        //======== scrollPane1 ========
        {
            scrollPane1.setViewportView(table1);
        }
        contentPane.add(scrollPane1);
        scrollPane1.setBounds(40, 65, 700, 325);

        //---- button1 ----
        button1.setText("\u67e5\u8be2");
        button1.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button1MouseClicked(e);
            }
        });
        contentPane.add(button1);
        button1.setBounds(new Rectangle(new Point(545, 10), button1.getPreferredSize()));

        //---- button2 ----
        button2.setText("\u65b0\u589e");
        button2.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button2MouseClicked(e);
            }
        });
        contentPane.add(button2);
        button2.setBounds(new Rectangle(new Point(662, 10), button2.getPreferredSize()));

        //---- textField1 ----
        textField1.addKeyListener(new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent e) {
                textField1KeyPressed(e);
            }
        });
        contentPane.add(textField1);
        textField1.setBounds(40, 10, 450, 30);

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
            dialog1.setTitle("\u65b0\u589e\u5f71\u7247");
            Container dialog1ContentPane = dialog1.getContentPane();
            dialog1ContentPane.setLayout(null);

            //---- label1 ----
            label1.setText("\u7247\u540d\u79f0\uff1a");
            dialog1ContentPane.add(label1);
            label1.setBounds(new Rectangle(new Point(35, 20), label1.getPreferredSize()));
            dialog1ContentPane.add(textField2);
            textField2.setBounds(95, 13, 175, 30);

            //---- label2 ----
            label2.setText("\u65f6\u957f\uff1a");
            dialog1ContentPane.add(label2);
            label2.setBounds(new Rectangle(new Point(47, 70), label2.getPreferredSize()));
            dialog1ContentPane.add(textField3);
            textField3.setBounds(95, 63, 175, 30);

            //---- label3 ----
            label3.setText("\u5730\u533a\uff1a");
            dialog1ContentPane.add(label3);
            label3.setBounds(new Rectangle(new Point(47, 115), label3.getPreferredSize()));
            dialog1ContentPane.add(textField4);
            textField4.setBounds(95, 108, 175, 30);

            //---- label4 ----
            label4.setText("\u4e0a\u6620\u65e5\u671f\uff1a");
            dialog1ContentPane.add(label4);
            label4.setBounds(new Rectangle(new Point(23, 160), label4.getPreferredSize()));
            dialog1ContentPane.add(textField5);
            textField5.setBounds(95, 153, 175, 30);

            //---- label5 ----
            label5.setText("\u7968\u4ef7\uff1a");
            dialog1ContentPane.add(label5);
            label5.setBounds(new Rectangle(new Point(47, 205), label5.getPreferredSize()));
            dialog1ContentPane.add(textField6);
            textField6.setBounds(95, 198, 175, 30);

            //---- button3 ----
            button3.setText("\u65b0\u589e");
            button3.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button3MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button3);
            button3.setBounds(new Rectangle(new Point(80, 255), button3.getPreferredSize()));

            //---- button4 ----
            button4.setText("\u8fd4\u56de");
            button4.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button4MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button4);
            button4.setBounds(new Rectangle(new Point(192, 255), button4.getPreferredSize()));

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
        showData("");
    }

    // JFormDesigner - Variables declaration - DO NOT MODIFY  //GEN-BEGIN:variables
    private JPanel panel1;
    private JScrollPane scrollPane1;
    private JTable table1;
    private JButton button1;
    private JButton button2;
    private JTextField textField1;
    private JDialog dialog1;
    private JLabel label1;
    private JTextField textField2;
    private JLabel label2;
    private JTextField textField3;
    private JLabel label3;
    private JTextField textField4;
    private JLabel label4;
    private JTextField textField5;
    private JLabel label5;
    private JTextField textField6;
    private JButton button3;
    private JButton button4;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
    private static Vector<Vector<Object>> data;
}
