using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultifileMove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(fileName);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    File.Move(fileName, String.Format("{0}/{1}", textBox1.Text, Path.GetFileName(fileName)));
                }
                MessageBox.Show("文件移动成功！");
            }
            else
            {
                MessageBox.Show("请选择路径！");
            }
        }
    }
}
