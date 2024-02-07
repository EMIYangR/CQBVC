/*
 * Created by JFormDesigner on Mon Jun 13 17:45:00 CST 2022
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
        showData();
        this.setSize(600, 550);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(true);
    }
    //查询
    public void showData() {
        String sql = "select * from tb_supply";
        Connection conn = BaseDAO.getConnection();
        try {
            PreparedStatement ps = conn.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();
            data = new Vector<Vector<Object>>();
            while (rs.next()) {
                Vector<Object> data1 = new Vector<Object>();
                data1.add(rs.getInt("id"));
                data1.add(rs.getString("name"));
                data1.add(rs.getString("model"));
                data1.add(rs.getInt("quantity"));
                data.add(data1);
            }
            BaseDAO.closeConnection(rs, ps, conn);

            Vector<String> heads = new Vector<String>();
            heads.add("物品编号");
            heads.add("物品名称");
            heads.add("物品规格");
            heads.add("库存数量");

            DefaultTableModel dtm = new DefaultTableModel(data, heads);
            table1.setModel(dtm);

        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
    }

    //出库
    public  static boolean update (int num,int id){
        String sql="update tb_supply set quantity = quantity - ? where id = ?";
        return BaseDAO.zsg(sql,num,id);
    }

    private void button1MouseClicked(MouseEvent e) {
        // TODO add your code here
        dialog1.setVisible(true);
    }

    //出库按钮
    private void button2MouseClicked(MouseEvent e) {
        // TODO add your code here
        int index = table1.getSelectedRow();
        if(index != -1) {
            int id = (int) data.get(index).get(0);
            if (update(Integer.parseInt(textField1.getText()), id)) {
                showData();
                JOptionPane.showMessageDialog(null, "出库成功");
                dialog1.setVisible(false);
                textField1.setText("");
            } else {
                JOptionPane.showMessageDialog(null, "出库失败");
            }
        } else {
            JOptionPane.showMessageDialog(null, "未选中出库的物品");
        }
    }

    private void button3MouseClicked(MouseEvent e) {
        // TODO add your code here
        dialog1.dispose();
        textField1.setText("");
    }
    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        panel1 = new JPanel();
        scrollPane1 = new JScrollPane();
        table1 = new JTable();
        button1 = new JButton();
        dialog1 = new JDialog();
        label1 = new JLabel();
        textField1 = new JTextField();
        button2 = new JButton();
        button3 = new JButton();

        //======== this ========
        setTitle("\u529e\u516c\u7528\u54c1\u7ba1\u7406\u7cfb\u7edf");
        Container contentPane = getContentPane();
        contentPane.setLayout(null);

        //======== panel1 ========
        {
            panel1.setLayout(null);

            //======== scrollPane1 ========
            {
                scrollPane1.setViewportView(table1);
            }
            panel1.add(scrollPane1);
            scrollPane1.setBounds(new Rectangle(new Point(0, 0), scrollPane1.getPreferredSize()));

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
        panel1.setBounds(new Rectangle(new Point(15, 15), panel1.getPreferredSize()));

        //---- button1 ----
        button1.setText("\u51fa\u5e93");
        button1.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button1MouseClicked(e);
                button1MouseClicked(e);
            }
        });
        contentPane.add(button1);
        button1.setBounds(new Rectangle(new Point(380, 455), button1.getPreferredSize()));

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
            label1.setText("\u8bf7\u8f93\u5165\u4f60\u8981\u51fa\u5e93\u7684\u6570\u91cf\uff1a");
            dialog1ContentPane.add(label1);
            label1.setBounds(55, 10, 220, 30);
            dialog1ContentPane.add(textField1);
            textField1.setBounds(55, 50, 295, textField1.getPreferredSize().height);

            //---- button2 ----
            button2.setText("\u786e\u5b9a");
            button2.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button2MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button2);
            button2.setBounds(new Rectangle(new Point(85, 105), button2.getPreferredSize()));

            //---- button3 ----
            button3.setText("\u53d6\u6d88");
            button3.addMouseListener(new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    button3MouseClicked(e);
                }
            });
            dialog1ContentPane.add(button3);
            button3.setBounds(new Rectangle(new Point(235, 105), button3.getPreferredSize()));

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
    private JPanel panel1;
    private JScrollPane scrollPane1;
    private JTable table1;
    private JButton button1;
    private JDialog dialog1;
    private JLabel label1;
    private JTextField textField1;
    private JButton button2;
    private JButton button3;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
    private static Vector<Vector<Object>> data;
}
