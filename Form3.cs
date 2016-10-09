using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _410275017
{
        
    public partial class Form3 : Form
    {
        int count1;
        int count2;
        int count3;
        public int a;
        public Form1 FM1 = null;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "名稱 : 可可熊\r\n\r\n特色 : 咖啡色的溫柔熊熊\r\n\r\n售價 : 20Coin";
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "名稱 : Pinky熊\r\n\r\n特色 : 粉紅色的甜心熊熊\r\n\r\n售價 : 50Coin";
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.BorderStyle = BorderStyle.None;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "名稱 : 小白熊\r\n\r\n特色 : 黃色的陽光熊熊\r\n\r\n售價 : 10Coin";
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                if (Convert.ToInt32(label1.Text)>0)
                {
                    a = Convert.ToInt32(FM1.label4.Text);
                    a = a + 20;
                    FM1.label4.Text = a.ToString();
                    count1 = Convert.ToInt32(FM1.label4.Text);
                    count1--;
                    label1.Text = count1.ToString();
                    radioButton1.Checked = false;
                    MessageBox.Show("成功售出");
                }
                else
                {
                MessageBox.Show("背包沒東西");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (Convert.ToInt32(FM1.label4.Text) > 0)
                {
                    a = Convert.ToInt32(FM1.label4.Text);
                    a += 50;
                    FM1.label4.Text = a.ToString();
                    count2 = Convert.ToInt32(label2.Text);
                    count2--;
                    label2.Text = count2.ToString();
                    radioButton2.Checked = false;
                    MessageBox.Show("成功售出");
                }
                else
                {
                    MessageBox.Show("背包沒東西");
                }
            }
            else if (radioButton3.Checked == true)
            {
                if (Convert.ToInt32(label3.Text) > 0)
                {
                    a = Convert.ToInt32(FM1.label4.Text);
                    a += 10;
                    FM1.label4.Text = a.ToString();
                    count3 = Convert.ToInt32(label3.Text);
                    count3--;
                    label3.Text = count3.ToString();
                    radioButton3.Checked = false;
                    MessageBox.Show("成功售出");
                }
                else
                {
                    MessageBox.Show("背包沒東西");
                }
            }
            else
            {
                MessageBox.Show("請選擇物品");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "名稱 : \r\n\r\n特色 : \r\n\r\n售價 : ";
        }
    }
}
