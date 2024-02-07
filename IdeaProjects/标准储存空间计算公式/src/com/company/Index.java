/*
 * Created by JFormDesigner on Fri Jul 29 19:25:48 CST 2022
 */

package com.company;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

/**
 * @author EMI Yang
 */
public class Index extends JFrame {
    public Index() {
        initComponents();
        this.setSize(400,400);
        this.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        this.setVisible(true);
    }

    public void getGB(){
        try {
            double  inputGB = Double.parseDouble(textField1.getText()),
                    GB = 1000*1000*1000,
                    GiB = 1024*1024*1024,
                    B1,printGB;
            String message,Byte;
            if (Boolean) {
                printGB = inputGB * GB / GiB;
                message = "实际储存空间为";
                if (printGB >= 1024){
                    Byte = "TiB";
                    printGB = printGB / 1024;
                    B1 = 1;
                } else if (printGB >= 1){
                    Byte = "GiB";
                    B1 = 1;
                } else {
                    Byte = "MiB";
                    B1 = 1024;
                }
            } else {
                printGB = inputGB * GiB / GB;
                message = "理论储存空间为";
                if (printGB >= 1000){
                    Byte = "TB";
                    B1 = 0.001;
                } else if (printGB >= 1){
                    Byte = "GB";
                    B1 = 1;
                } else {
                    Byte = "MB";
                    B1 = 1000;
                }
            }

            JOptionPane.showMessageDialog(null,
                    message + String.format("%.2f", (printGB * B1)) + Byte);
        } catch (Exception e){
            JOptionPane.showMessageDialog(null,"请输入数据！");
        }
        textField1.setText("");
    }

    private void button1MouseClicked(MouseEvent e) {
        // TODO add your code here
        Boolean = true;
        getGB();
    }

    private void button2MouseClicked(MouseEvent e) {
        // TODO add your code here
        Boolean = false;
        getGB();
    }

    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        label1 = new JLabel();
        label2 = new JLabel();
        label3 = new JLabel();
        label4 = new JLabel();
        label5 = new JLabel();
        label6 = new JLabel();
        label7 = new JLabel();
        separator1 = new JSeparator();
        textField1 = new JTextField();
        button1 = new JButton();
        button2 = new JButton();

        //======== this ========
        setTitle("\u6807\u51c6\u7a7a\u95f4\u8ba1\u7b97\u7cfb\u7edf");
        Container contentPane = getContentPane();
        contentPane.setLayout(null);

        //---- label1 ----
        label1.setText("\u8bf7\u8f93\u5165GB\u6216GiB\uff1a");
        contentPane.add(label1);
        label1.setBounds(new Rectangle(new Point(25, 125), label1.getPreferredSize()));

        //---- label2 ----
        label2.setText("\u50a8\u5b58\u7a7a\u95f4\u8ba1\u7b97\u7cfb\u7edf");
        label2.setFont(new Font("\u65b9\u6b63\u4eff\u5b8b_GBK", Font.PLAIN, 30));
        contentPane.add(label2);
        label2.setBounds(new Rectangle(new Point(75, 45), label2.getPreferredSize()));

        //---- label3 ----
        label3.setText("\u8bf4\u660e\uff1a");
        contentPane.add(label3);
        label3.setBounds(new Rectangle(new Point(25, 265), label3.getPreferredSize()));

        //---- label4 ----
        label4.setText("1\u3001\u672c\u8f6f\u4ef6\u7528\u4e8e\u78c1\u76d8\u7b49\u5b58\u50a8\u5de5\u5177GiB\u4e0eGB\u7684\u6362\u7b97");
        contentPane.add(label4);
        label4.setBounds(25, 285, 335, label4.getPreferredSize().height);

        //---- label5 ----
        label5.setText("2\u3001\u5982\u82e5\u60a8\u7684\u5b58\u50a8\u5de5\u5177\u663e\u793a\u7ed3\u679c\u5927\u4e8e\u672c\u503c\uff0c\u8bf4\u660e\u60a8\u7684");
        contentPane.add(label5);
        label5.setBounds(new Rectangle(new Point(25, 305), label5.getPreferredSize()));

        //---- label6 ----
        label6.setText("\u00a9EMI \u7248\u6743\u6240\u6709");
        contentPane.add(label6);
        label6.setBounds(new Rectangle(new Point(155, 340), label6.getPreferredSize()));

        //---- label7 ----
        label7.setText("\u5b58\u50a8\u5de5\u5177\u5b58\u5728\u865a\u6807");
        contentPane.add(label7);
        label7.setBounds(new Rectangle(new Point(25, 325), label7.getPreferredSize()));
        contentPane.add(separator1);
        separator1.setBounds(0, 255, 400, separator1.getPreferredSize().height);
        contentPane.add(textField1);
        textField1.setBounds(25, 170, 350, textField1.getPreferredSize().height);

        //---- button1 ----
        button1.setText("\u8ba1\u7b97\u5b9e\u9645\u5b58\u50a8\u7a7a\u95f4");
        button1.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button1MouseClicked(e);
            }
        });
        contentPane.add(button1);
        button1.setBounds(new Rectangle(new Point(25, 215), button1.getPreferredSize()));

        //---- button2 ----
        button2.setText("\u8ba1\u7b97\u7406\u8bba\u5b58\u50a8\u7a7a\u95f4");
        button2.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                button2MouseClicked(e);
            }
        });
        contentPane.add(button2);
        button2.setBounds(new Rectangle(new Point(245, 215), button2.getPreferredSize()));

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
        // JFormDesigner - End of component initialization  //GEN-END:initComponents
    }

    // JFormDesigner - Variables declaration - DO NOT MODIFY  //GEN-BEGIN:variables
    private JLabel label1;
    private JLabel label2;
    private JLabel label3;
    private JLabel label4;
    private JLabel label5;
    private JLabel label6;
    private JLabel label7;
    private JSeparator separator1;
    private JTextField textField1;
    private JButton button1;
    private JButton button2;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
    private static boolean Boolean;
}
