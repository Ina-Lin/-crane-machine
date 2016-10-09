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
    public partial class Form1 : Form
    {
        public int add1;
        public int add2;
        public int add3;
        Form3 FM3 = new Form3();
        System.Random ran1 = new Random();
        public int op; int bear;
        float count=0; float spend=0;
        float money=0; float total=0;
        float cash; float coin;
        float cost; int many;
        int i; int j; int x2;
        int x = 77; int y=9;
        
        public Form1()
        {
            InitializeComponent();
        }

        //遊戲開始 投幣鈕
        private void button1_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            bear = ran1.Next(1,7);
            x2 = ran1.Next(3, 146);
            coin = Convert.ToInt64(label4.Text);
            if (coin > 0)
            {
                coin -= 10;
                label4.Text = coin.ToString();
                pictureBox1.Enabled = true;
                pictureBox2.Enabled = true;
                pictureBox3.Enabled = true;
                switch(bear)
                {
                    case 1:
                    case 2:
                        pictureBox5.Image = Image.FromFile(Application.StartupPath + @"\bear.jpg");
                        break;
                    case 3:
                        pictureBox5.Image = Image.FromFile(Application.StartupPath + @"\bear2.jpg");
                        break;
                    case 4:
                    case 5:
                    case 6:
                        pictureBox5.Image = Image.FromFile(Application.StartupPath + @"\bear3.jpg");
                        break;
                }
                pictureBox5.Location=new Point(x2,189);
                if ((y != 62)&&(op!=2))
                {
                    x = 77;
                    y = 9;
                    pictureBox4.Location = new Point(x, y);
                }
            }
            else
            {
                MessageBox.Show("餘額不足");
            }
        }

        //商店物品A
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            i += 1;
            if (i % 2 != 0)
            {
                comboBox1.Enabled = true;
                if((i>=3)&&(comboBox1.Text!="數量"))
                {
                    count=15*Convert.ToSingle(comboBox1.Text);
                    total += count;
                    label8.Text = total.ToString();
                }
            }
            else
            {
                comboBox1.Enabled = false;
                total -= count;
                label8.Text = total.ToString();
                count = 0;
            }
        }

        //商點物品B
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            j += 1;
            if (j % 2 != 0)
            {
                comboBox2.Enabled = true;
                if ((j >= 3)&&(comboBox2.Text!="數量"))
                {
                    money = 25 * Convert.ToSingle(comboBox2.Text);
                    total += money;
                    label8.Text = total.ToString();
                }
            }
            else
            {
                comboBox2.Enabled = false;
                total -= money;
                label8.Text = total.ToString();
                money = 0;
            }
        }

        //購買確認鍵
        private void button2_Click(object sender, EventArgs e)
        {
            spend = Convert.ToSingle(label8.Text);
            cash = Convert.ToSingle(label2.Text);
            if ((checkBox1.Checked==true)&&(comboBox1.Text == "數量"))
            {
                MessageBox.Show("請選擇數量");
            }
            else if ((comboBox2.Text=="數量")&&(checkBox2.Checked==true))
            {
                MessageBox.Show("請選擇數量");
            }
            else if ((checkBox1.Checked == false) && (checkBox2.Checked == false))
            {
                MessageBox.Show("請選擇購買項目");
            }
            else
            {
                if (total>cash)
                {
                    MessageBox.Show("餘額不足");
                }
                else
                {
                    Form2 FM2 = new Form2();
                    FM2.FM1 = this;
                    FM2.ShowDialog();
                    if (op == 1)
                    {
                        if ((comboBox1.Text != "數量"))
                        {
                            many = Convert.ToInt32(label10.Text);
                            many += Convert.ToInt32(comboBox1.Text);
                            label10.Text = many.ToString();
                        }
                        if ((comboBox2.Text != "數量"))
                        {
                            many = Convert.ToInt32(label11.Text);
                            many += Convert.ToInt32(comboBox2.Text);
                            label11.Text = many.ToString();
                        }
                        MessageBox.Show("購買成功");
                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        comboBox1.Text = "數量";
                        comboBox2.Text = "數量";
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        i = 0;
                        j = 0;
                        cash -= spend;
                        label2.Text = cash.ToString();
                        total = 0;
                        spend = 0;
                        label8.Text = total.ToString();
                    }
                }
            }
        }

        //遊戲幣兌換(CASH)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            string Str = textBox1.Text.Trim();
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            if (textBox1.Text.Trim() == String.Empty)
            {
                textBox1.AcceptsReturn = false;
            }
            if (isNum)
            {
                double change = Convert.ToInt64(textBox1.Text) * 1.5;
                textBox2.Text = change.ToString();
            }
            else
            {
                textBox2.Text = "0";
            }
        }

        //兌幣鈕
        private void button3_Click(object sender, EventArgs e)
        {
            string Str = textBox2.Text.Trim();
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            if (isNum)
            {
                coin = Convert.ToSingle(label4.Text);
                cash = Convert.ToSingle(label2.Text);
                spend = Convert.ToSingle(textBox1.Text);
                cost = Convert.ToSingle(textBox2.Text);
                if ((cost > 0)&&(cash>=spend))
                {
                    cash -= spend;
                    label2.Text = cash.ToString();
                    spend = 0;
                    coin += cost;
                    cost = 0;
                    label4.Text = coin.ToString();
                    MessageBox.Show("兌換成功");    
                }
                if (cash < spend)
                {
                    MessageBox.Show("餘額不足");
                }
                textBox1.Text = "0";
                textBox2.Text = "0";
                button3.Enabled = false;
            }
        }

        //清除鍵
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        //左箭頭
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (x > 3)
            {
                x--;
                pictureBox4.Location = new Point(x, y);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (x > 3)
            {
                x--;
                pictureBox4.Location = new Point(x, y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer2.Stop();
        }
        //下箭頭
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            timer1.Enabled = true;
            timer1.Start();
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (y < 189)
            {
                y++;
                pictureBox4.Location = new Point(x, y);
            }
            if (y == 189)
            {
                timer1.Stop();
            }
            if (op == 2)
            {
                if (y == 189)
                {
                    if ((-15<=(x-x2)) && ((x - x2)<=15))
                    {
                        MessageBox.Show("獲得一隻熊");
                        x = 77;
                        y = 9;
                        pictureBox4.Location = new Point(x, y);
                        pictureBox4.Size = new Size(36, 34);
                        this.AddOwnedForm(FM3);
                        switch(bear)
                        {
                            case 1:
                            case 2:
                                add1 = Convert.ToInt32(FM3.label1.Text);
                                add1++;
                                FM3.label1.Text = add1.ToString();
                                break;
                            case 3:
                                add2++;
                                FM3.label2.Text = add2.ToString();
                                break;
                            case 4:
                            case 5:
                            case 6:
                                add3++;
                                FM3.label3.Text = add3.ToString();
                                break;
                        }
                    }
                }
                op = 0;
            }
            else
            {
                if (pictureBox4.Location == pictureBox5.Location)
                {
                    MessageBox.Show("獲得一隻熊");
                    x = 77;
                    y = 9;
                    pictureBox4.Location = new Point(x, y);
                    switch(bear)
                        {
                            case 1:
                            case 2:
                                add1 = Convert.ToInt32(FM3.label1.Text);
                                add1++;
                                FM3.label1.Text = add1.ToString();
                                break;
                            case 3:
                                add2++;
                                FM3.label2.Text = add2.ToString();
                                break;
                            case 4:
                            case 5:
                            case 6:
                                add3++;
                                FM3.label3.Text = add3.ToString();
                                break;
                        }
                    }
                
                else if ((x != x2) && (y == 189))
                {
                    MessageBox.Show("再試一次 加油!");
                    x = 77;
                    y = 9;
                    pictureBox4.Location = new Point(x, y);
                }
            }
        }

        //右箭頭
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (x < 145)
            {
                x++;
                pictureBox4.Location = new Point(x, y);
            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (x < 145)
            {
                x++;
                pictureBox4.Location = new Point(x, y);
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            timer3.Stop();
        }

        //遊戲官方網站連結
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.yahoo.com.tw");
        }

        //商品A詳情
        private void checkBox1_MouseHover(object sender, EventArgs e)
        {
            label12.Text = "發射器及目標距離縮短";
        }

        //商品B詳情
        private void checkBox2_MouseHover(object sender, EventArgs e)
        {
            label12.Text = "發射範圍增加";
        }

        //隱藏商品A詳情
        private void checkBox1_MouseLeave(object sender, EventArgs e)
        {
            label12.Text = "  ~ U     F     O ~";
        }

        //隱藏商品B詳情
        private void checkBox2_MouseLeave(object sender, EventArgs e)
        {
            label12.Text = "  ~ U     F     O ~";
        }

        //商品A數量 金額
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string Str = comboBox1.Text.Trim();
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            if (isNum)
            {
                count = 15 * Convert.ToSingle(comboBox1.Text);
                total = money + count;
                label8.Text = total.ToString();
            }
        }

        //商品B數量 金額
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            string Str = comboBox2.Text.Trim();
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            if (isNum)
            {
                money = 25 * Convert.ToSingle(comboBox2.Text);
                total = money + count;
                label8.Text = total.ToString();
            }
        }

        //投幣鈕顯示價錢
        private void button1_MouseHover(object sender, EventArgs e)
        {
            label9.Text = "10Coin";
        }

        //隱藏價錢
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label9.Text = "";
        }

        //清空textbox1 開始輸入數字
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        //道具裝備
        private void button5_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                if (Convert.ToInt32(label10.Text) > 0)
                {
                    many = Convert.ToInt32(label10.Text);
                    many--;
                    label10.Text = many.ToString();
                    y = 62;
                    pictureBox4.Location = new Point(x,y);
                    radioButton1.Checked = false;
                    MessageBox.Show("已裝備道具");
                }
                else
                {
                    MessageBox.Show("請購買道具");
                }
            }
            else if(radioButton2.Checked==true)
            {
                if (Convert.ToInt32(label11.Text) > 0)
                {
                    many = Convert.ToInt32(label11.Text);
                    many--;
                    label11.Text = many.ToString();
                    op = 2;
                    pictureBox4.Size = new Size(40, 38);
                    x = 75;
                    pictureBox4.Location = new Point(x, y);
                    radioButton2.Checked = false;
                    MessageBox.Show("已裝備道具");
                }
                else
                {
                    MessageBox.Show("請購買道具");
                }
            }
            else
            {
                MessageBox.Show("請選擇道具");
            }
        }

        //裝備道具取消鍵
        private void button6_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        //背包
        private void button7_Click(object sender, EventArgs e)
        {
            FM3.ShowDialog();
        }
    }
}