/*
 * Created by JFormDesigner on Sun Jun 12 18:23:21 CST 2022
 */

package com.company;

import java.awt.*;
import java.awt.event.*;
import java.sql.*;
import java.util.Vector;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;

import net.miginfocom.swing.*;

/**
 * @author Brainrain
 */
public class Index extends JFrame {
    public Index() {
        initComponents();
        this.setSize(800, 600);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(true);
    }
    //查询
    public void showData() {
        String sql = "select * from tb_Order";
        Connection conn = BaseDAO.getConnection();
        try {
            PreparedStatement ps = conn.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();
            data = new Vector<Vector<Object>>();
            while (rs.next()) {
                Vector<Object> data1 = new Vector<Object>();
                data1.add(rs.getInt("orderId"));
                data1.add(rs.getString("foodName"));
                data1.add(rs.getInt("numbers"));
                data1.add(rs.getString("isM"));
                data1.add(rs.getString("sendTime"));
                data1.add(rs.getString("toAddress"));
                data1.add(rs.getString("isSended"));
                data.add(data1);
            }
            BaseDAO.closeConnection(rs, ps, conn);

            Vector<String> heads = new Vector<String>();
            heads.add("订餐编号");
            heads.add("菜名");
            heads.add("份数");
            heads.add("是否麻辣");
            heads.add("送餐时间");
            heads.add("送餐目的地");
            heads.add("是否配送");

            DefaultTableModel dtm = new DefaultTableModel(data, heads);
            table1.setModel(dtm);

        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
    }
    //添加
    public void addData(String foodName, int numbers, String isM, String sendTime, String toAddress, String isSended) {
        String sql = "insert into tb_Order values(null,?,?,?,?,?,?)";
        Connection conn = BaseDAO.getConnection();
        try {
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, foodName);
            ps.setInt(2, numbers);
            ps.setString(3, isM);
            ps.setString(4, sendTime);
            ps.setString(5, toAddress);
            ps.setString(6, isSended);
            int i = ps.executeUpdate();
            if (i > 0) {
                showData();
                JOptionPane.showMessageDialog(null, "添加成功");
            } else {
                JOptionPane.showMessageDialog(null, "添加失败");
            }
            BaseDAO.closeConnection(null, ps, conn);
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
    }
    public void empty() {
        textField1.setText("");
        textField2.setText("");
        textField3.setText("");
        textField4.setText("");
        textField5.setText("");
        textField6.setText("");
    }
    //查询按钮
    private void button1MouseClicked(MouseEvent e) {
        // TODO add your code here
        showData();
    }
    //添加窗口
    private void button2MouseClicked(MouseEvent e) {
        // TODO add your code here
        dialog1.setModal(true);
        dialog1.setSize(400,400);
        dialog1.setVisible(true);
    }
    //删除
    private void button3MouseClicked(MouseEvent e) {
        // TODO add your code here
        int index = table1.getSelectedRow();
        if(index != -1){
            if (JOptionPane.showConfirmDialog(null, "确认删除?") == 0) {
                String sql = "delete from tb_Order where orderId=?";
                int id = (int) data.get(index).get(0);
                Connection conn = BaseDAO.getConnection();
                try {
                    PreparedStatement ps = conn.prepareStatement(sql);
                    ps.setInt(1, id);
                    if (ps.executeUpdate() > 0) {
                        showData();
                        JOptionPane.showMessageDialog(null, "删除成功！");
                    } else {
                        JOptionPane.showMessageDialog(null, "删除失败！");
                    }
                } catch (SQLException throwables) {
                    throwables.printStackTrace();
                }
            }
        }else{
            JOptionPane.showMessageDialog(null, "您未选中任意一行!");
        }
    }
    //添加
    private void button4MouseClicked(MouseEvent e) {
        // TODO add your code here
        addData(textField1.getText(), Integer.parseInt(textField2.getText()),
                textField3.getText(), textField4.getText(),
                textField5.getText(), textField6.getText());
        empty();
    }
    //返回主界面
    private void button5MouseClicked(MouseEvent e) {
        // TODO add your code here
        dialog1.dispose();
        empty();
    }

    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        button1 = new JButton();
        button2 = new JButton();
        button3 = new JButton();
        panel1 = new JPanel();
        scrollPane1 = new JScrollPane();
        table1 = new JTable();
        dialog1 = new JDialog();
        label1 = new JLabel();
        textField1 = new JTextField();
        textField2 = new JTextField();
        textField3 = new JTextField();
        textField4 = new JTextField();
        textField5 = new JTextField();
        textField6 = new JTextField();
        label2 = new JLabel();
        label3 = new JLabel();
        label4 = new JLabel();
        label5 = new JLabel();
        label6 = new JLabel();
        button4 = new JButton();
        button5 = new JButton();

        //======== this ========
        Container contentPane = getContentPane();
        contentPane.setLayout(null);

        //---- button1 ----
        button1.setText("\u67e5\u8be2");
        button1.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button1MouseClicked(e);
            }
        });
        contentPane.add(button1);
        button1.setBounds(new Rectangle(new Point(115, 45), button1.getPreferredSize()));

        //---- button2 ----
        button2.setText("\u6dfb\u52a0");
        button2.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button2MouseClicked(e);
            }
        });
        contentPane.add(button2);
        button2.setBounds(new Rectangle(new Point(240, 45), button2.getPreferredSize()));

        //---- button3 ----
        button3.setText("\u5220\u9664");
        button3.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button3MouseClicked(e);
            }
        });
        contentPane.add(button3);
        button3.setBounds(new Rectangle(new Point(380, 45), button3.getPreferredSize()));

        //======== panel1 ========
        {
            panel1.setLayout(new MigLayout(
                "hidemode 3",
                // columns
                "[fill]" +
                "[fill]",
                // rows
                "[]" +
                "[]" +
                "[]"));

            //======== scrollPane1 ========
            {
                scrollPane1.setViewportView(table1);
            }
            panel1.add(scrollPane1, "cell 0 0");
        }
        contentPane.add(panel1);
        panel1.setBounds(new Rectangle(new Point(70, 95), panel1.getPreferredSize()));

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
            Container dialog1ContentPane = dialog1.getContentPane();
            dialog1ContentPane.setLayout(null);

            //---- label1 ----
            label1.setText("\u83dc\u540d\uff1a");
            dialog1ContentPane.add(label1);
            label1.setBounds(new Rectangle(new Point(65, 25), label1.getPreferredSize()));
            dialog1ContentPane.add(textField1);
            textField1.setBounds(150, 18, 150, 30);
            dialog1ContentPane.add(textField2);
            textField2.setBounds(150, 68, 150, 30);
            dialog1ContentPane.add(textField3);
            textField3.setBounds(150, 118, 150, 30);
            dialog1ContentPane.add(textField4);
            textField4.setBounds(150, 168, 150, 30);
            dialog1ContentPane.add(textField5);
            textField5.setBounds(150, 218, 150, 30);
            dialog1ContentPane.add(textField6);
            textField6.setBounds(150, 268, 150, 30);

            //---- label2 ----
            label2.setText("\u4efd\u6570\uff1a");
            dialog1ContentPane.add(label2);
            label2.setBounds(new Rectangle(new Point(65, 75), label2.getPreferredSize()));

            //---- label3 ----
            label3.setText("\u662f\u5426\u9ebb\u8fa3\uff1a");
            dialog1ContentPane.add(label3);
            label3.setBounds(new Rectangle(new Point(41, 125), label3.getPreferredSize()));

            //---- label4 ----
            label4.setText("\u9001\u9910\u65f6\u95f4\uff1a");
            dialog1ContentPane.add(label4);
            label4.setBounds(new Rectangle(new Point(41, 175), label4.getPreferredSize()));

            //---- label5 ----
            label5.setText("\u9001\u9910\u76ee\u7684\u5730\uff1a");
            dialog1ContentPane.add(label5);
            label5.setBounds(new Rectangle(new Point(29, 225), label5.getPreferredSize()));

            //---- label6 ----
            label6.setText("\u662f\u5426\u914d\u9001\uff1a");
            dialog1ContentPane.add(label6);
            label6.setBounds(new Rectangle(new Point(41, 275), label6.getPreferredSize()));

            //---- button4 ----
            button4.setText("\u786e\u5b9a");
            button4.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button4MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button4);
            button4.setBounds(new Rectangle(new Point(70, 325), button4.getPreferredSize()));

            //---- button5 ----
            button5.setText("\u8fd4\u56de");
            button5.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button5MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button5);
            button5.setBounds(new Rectangle(new Point(205, 325), button5.getPreferredSize()));

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
    private JButton button1;
    private JButton button2;
    private JButton button3;
    private JPanel panel1;
    private JScrollPane scrollPane1;
    private JTable table1;
    private JDialog dialog1;
    private JLabel label1;
    private JTextField textField1;
    private JTextField textField2;
    private JTextField textField3;
    private JTextField textField4;
    private JTextField textField5;
    private JTextField textField6;
    private JLabel label2;
    private JLabel label3;
    private JLabel label4;
    private JLabel label5;
    private JLabel label6;
    private JButton button4;
    private JButton button5;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
    private static Vector<Vector<Object>> data;
}
