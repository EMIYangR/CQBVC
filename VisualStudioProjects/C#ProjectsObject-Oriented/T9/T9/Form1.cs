using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T9
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
                string name = openFileDialog1.FileName;
                textBox1.Text = name;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                textBox1.Text = fileName;
                Goods goods = new Goods();
                goods.Id = 1;
                goods.Name = textBox4.Text;
                goods.Price = Double.Parse(textBox5.Text);
                goods.Inpuduce = textBox6.Text;

                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                try
                {
                    sw.WriteLine(goods.ToString());
                    sw.Close();
                    fs.Close();
                }
                catch (Exception)
                {

                    throw;
                }
                MessageBox.Show("文件写入成功！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                //textBox6.Text = sr.ReadToEnd();
                //sr.Close();
                //fs.Close();
                BinaryFormatter bf = new BinaryFormatter();
                Goods goods=bf.Deserialize(fs) as Goods;
                textBox6.Text = goods.ToString();
                fs.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("文件不存在！");
            }
        }
    }
}
