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

namespace FilesMove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.SelectionMode = SelectionMode.MultiExtended;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] files = openFileDialog1.FileNames;
                foreach (string item in files)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string movePath = textBox1.Text;
            if (!String.IsNullOrEmpty(movePath))
            {
                if (!Directory.Exists(movePath))
                {
                    Directory.CreateDirectory(movePath);
                }
                if (listBox1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择移动项！");
                }
                List<string> ls = new List<string>();
                foreach (string item in listBox1.SelectedItems)
                {
                    string newPath = movePath + "\\" + Path.GetFileName(item);
                    File.Move(item, newPath);
                    listBox1.Items.Add(newPath);
                    ls.Add(item);
                }
                foreach (string item in ls)
                {
                    listBox1.Items.Remove(item);
                }
                MessageBox.Show("文件移动完成！");
            }
            else
            {
                MessageBox.Show("请选择文件保存路径！");

            }
        }
    }
}