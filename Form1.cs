using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Топовый_калькулятор__Тимур_ИС_22_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool CanUseZap = true,
             CanUseD = true;
        bool isDark = true;

        double num1, num2;
        char znak;


        //Кнопки цифры
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += 1;
            CanUseD = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
            CanUseD = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;
            CanUseD = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
            CanUseD = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
            CanUseD = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;
            CanUseD = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
            CanUseD = true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += 8;
            CanUseD = true;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += 9;
            CanUseD = true;
        }
        private void Zero_btn_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0;
            CanUseD = true;
        }
        //Кнопки цифры конец


        //Конверт в число
        private double ToDoub(string str)
        {
            double res = double.Parse(str);
            return res;
        }

        //Копка запятая
        private void Point_btn_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;

            if (CanUseZap && textBox1.Text != "")
            {
                if (str[str.Length - 1] == '+' || str[str.Length - 1] == '-' || str[str.Length - 1] == '/' || str[str.Length - 1] == '*' || str[str.Length - 1] == '(')
                {
                    textBox1.Text += "0,";
                }
                else
                {
                    textBox1.Text += ",";
                }
                CanUseZap = false;
            }
            else if (CanUseZap && textBox1.Text == "")
            {
                textBox1.Text += "0,";
                CanUseZap = false;
            }
            else
            {
                MessageBox.Show("Нельзя ставить две запятые в одном числе или в начале!",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }


        //Перевод из десят и двоич сист счис
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string numstr = textBox1.Text;
                bool CanConv2 = true;
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Невозможно преобразовать в двочиную систему! Строка пустая!",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    CanConv2 = false;
                }
                else
                {
                    for (int i = 0; i < numstr.Length; i++)
                    {
                        if (numstr[i] == ',' || numstr[i] == '+' || numstr[i] == '-' || numstr[i] == '*' || numstr[i] == '/')
                        {
                            MessageBox.Show("Невозможно преобразовать в десятичную систему! Проверте корректность вводимых данных",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            CanConv2 = false;
                            break;
                        }
                    }
                }
                if (CanConv2)
                {
                    int num = Convert.ToInt32(numstr, 2);
                    textBox1.Text = num.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно преобразовать в десятичную систему! Проверьте правильность данных!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
        private void вДесятичнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string numstr = textBox1.Text;
            bool CanConv2 = true;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Невозможно преобразовать в двочиную систему! Строка пустая!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                CanConv2 = false;
            }
            else
            {
                for (int i = 0; i < numstr.Length; i++)
                {
                    if (numstr[i] == ',' || numstr[i] == '+' || numstr[i] == '-' || numstr[i] == '*' || numstr[i] == '/')
                    {
                        MessageBox.Show("Невозможно преобразовать в двочиную систему! Проверте корректность вводимых данных",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        CanConv2 = false;
                        break;
                    }
                }
            }
            if (CanConv2)
            {
                int num = Convert.ToInt32(textBox1.Text);
                textBox1.Text = Convert.ToString(num, 2);
            }
        }
        //Перевод из десят и двоич сист счис конец


        //Кнопка равно
        private void Ravno_btn_Click(object sender, EventArgs e)
        {
            try
            {
                num2 = ToDoub(textBox1.Text);
                double res = 0;
                if (num2 == 0)
                {
                    label1.Text = "ERROR";
                    MessageBox.Show("Делить на НОЛЬ нельзя!",
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                else if(num2 < 0)
                {
                    switch (znak)
                    {
                        case '+':
                            label1.Text += $" ({num2})";
                            res = num1 + num2;
                            break;

                        case '-':
                            label1.Text += $" ({num2})";
                            res = num1 - num2;
                            break;

                        case '/':
                            label1.Text += $" ({num2})";
                            res = num1 / num2;
                            break;

                        case '*':
                            label1.Text += $" ({num2})";
                            res = num1 * num2;
                            break;
                        case '^':
                            label1.Text += $" ({num2})";
                            res = Math.Pow(num1, num2);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (znak)
                    {
                        case '+':
                            label1.Text += $" {num2}";
                            res = num1 + num2;
                            break;

                        case '-':
                            label1.Text += $" {num2}";
                            res = num1 - num2;
                            break;

                        case '/':
                            label1.Text += $" {num2}";
                            res = num1 / num2;
                            break;

                        case '*':
                            label1.Text += $" {num2}";
                            res = num1 * num2;
                            break;
                        case '^':
                            label1.Text += $" {num2}";
                            res = Math.Pow(num1, num2);
                            break;
                        default:
                            break;
                    }
                }
                textBox1.Text = res.ToString();
                CanUseD = true;
            }
            catch { }
        }

        //Очистка текст бокс
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            CanUseD = true;
            CanUseZap = true;
            label1.Text = "";
        }
        //Очистка текст бокс на одну единицу
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text,
                str2 = "";
                if (str[str.Length - 1] == '+' || str[str.Length - 1] == '-' || str[str.Length - 1] == '*' || str[str.Length - 1] == '/')
                {
                    CanUseD = true;
                }
                if (str[str.Length - 1] == ',')
                {
                    CanUseZap = true;
                }
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str2 += str[i].ToString();
                }
                textBox1.Text = str2;
            }
            catch (Exception)
            {

            }

        }


        //Знаки / * - +
        private void DoZnak(string znak)
        {
            string str = textBox1.Text;
            if (CanUseD && !(str[str.Length - 1] == '+' || str[str.Length - 1] == '-' || str[str.Length - 1] == '*' || str[str.Length - 1] == '/'))
            {
                CanUseD = false;
                CanUseZap = true;
            }
            else
            {
                MessageBox.Show("Нельзя ставить два знака подряд!",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
        private void FindNum(string str)
        {

        }
        private void Del_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(CanUseD)
                {
                    num1 = ToDoub(textBox1.Text);
                    label1.Text = num1.ToString() + " ÷";
                    textBox1.Text = "";
                    znak = '/';
                    CanUseD = false;
                    CanUseZap = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void Umn_btn_Click(object sender, EventArgs e)
        {
            try
            {

                if (CanUseD)
                {
                    num1 = ToDoub(textBox1.Text);
                    label1.Text = num1.ToString() + " *";
                    textBox1.Text = "";
                    znak = '*';
                    CanUseD = false;
                    CanUseZap = true;
                }
            }
            catch (Exception)
            {

            }
        }
        private void Plus_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(CanUseD) 
                {
                    num1 = ToDoub(textBox1.Text);
                    label1.Text = num1.ToString() + " +";
                    textBox1.Text = "";
                    znak = '+';
                    CanUseD = false;
                    CanUseZap = true;
                }             
            }
            catch (Exception)
            {

            }
        }
        //Знаки / * - + конец

        private void Minus_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                if (textBox1.Text == "")
                {
                    textBox1.Text += "-";
                    CanUseD = false;
                }
                else if (CanUseD && !(str[str.Length - 1] == '+' || str[str.Length - 1] == '-' || str[str.Length - 1] == '*' || str[str.Length - 1] == '/'))
                {
                    num1 = ToDoub(textBox1.Text);
                    label1.Text = num1.ToString() + " -";
                    textBox1.Text = "";
                    CanUseD = false;
                    CanUseZap = true;
                    znak = '-';
                }
                else
                {
                    MessageBox.Show("Нельзя ставить два знака подряд!",
                        "Предупреждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {

            }
        }

        //Светлая и Темная тема
        private void button24_Click(object sender, EventArgs e)
        {
            if (isDark)
            {
                button24.BackgroundImage = Image.FromFile("theme/moon.png");
                isDark = false;
                menuStrip1.BackColor = Color.DarkGray;
                textBox1.BackColor = Color.WhiteSmoke;
                BackColor = Color.LightGray;
                label1.ForeColor = Color.White;
                foreach(Button btn in Controls.OfType<Button>())
                {
                    btn.BackColor = Color.FromArgb(224, 224, 224);
                    btn.ForeColor = Color.Black;
                }
                button1.BackColor = Color.DarkGray;
                button2.BackColor = Color.DarkGray;
                button3.BackColor = Color.DarkGray;
                button4.BackColor = Color.DarkGray;
                button5.BackColor = Color.DarkGray;
                button6.BackColor = Color.DarkGray;
                button7.BackColor = Color.DarkGray;
                button8.BackColor = Color.DarkGray;
                button9.BackColor = Color.DarkGray;
                Zero_btn.BackColor = Color.DarkGray;

                menuStrip1.Items[0].ForeColor = Color.Black;
                menuStrip1.Items[1].ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                textBox1.ForeColor = Color.Black;
            }

            else
            {
                button24.BackgroundImage = Image.FromFile("theme/sun.png");
                isDark = true;
                menuStrip1.BackColor = Color.FromArgb(33, 33, 33);
                textBox1.BackColor = Color.FromArgb(56, 56, 56);
                BackColor = Color.FromArgb(56, 56, 56);
                foreach (Button btn in Controls.OfType<Button>())
                {
                    btn.BackColor = Color.FromArgb(90, 90, 90);
                    btn.ForeColor = Color.White;
                }
                button1.BackColor = Color.FromArgb(33, 33, 33);
                button2.BackColor = Color.FromArgb(33, 33, 33);
                button3.BackColor = Color.FromArgb(33, 33, 33);
                button4.BackColor = Color.FromArgb(33, 33, 33);
                button5.BackColor = Color.FromArgb(33, 33, 33);
                button6.BackColor = Color.FromArgb(33, 33, 33);
                button7.BackColor = Color.FromArgb(33, 33, 33);
                button8.BackColor = Color.FromArgb(33, 33, 33);
                button9.BackColor = Color.FromArgb(33, 33, 33);
                Zero_btn.BackColor = Color.FromArgb(33, 33, 33);
               
                menuStrip1.Items[0].ForeColor = Color.White;
                menuStrip1.Items[1].ForeColor = Color.White;
                label1.ForeColor = Color.White;
                textBox1.ForeColor = Color.White;
            }
        }


        //sin cos tg ctg
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                double res = ToDoub(textBox1.Text);
                button10_Click(sender, e);
                label1.Text = $"sin({res})";
                textBox1.Text = Math.Sin(res).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка формата ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                double res = ToDoub(textBox1.Text);
                button10_Click(sender, e);
                label1.Text = $"cos({res})";
                textBox1.Text = Math.Cos(res).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка формата ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                double res = ToDoub(textBox1.Text);
                button10_Click(sender, e);
                label1.Text = $"tan({res})";
                textBox1.Text = Math.Tan(res).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка формата ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                double res = ToDoub(textBox1.Text);
                double sin = Math.Sin(res), cos = Math.Cos(res);
                button10_Click(sender, e);
                label1.Text = $"ctan({res})";
                textBox1.Text = (cos / sin).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка формата ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //sin cos tg ctg end

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                textBox1.Text = (num / 100).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ABS
        private void button21_Click_1(object sender, EventArgs e)
        {
            try
            {
                double num = ToDoub(textBox1.Text);
                label1.Text = $"|{num}|";
                textBox1.Text = Math.Abs(num).ToString();
                CanUseD = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //!
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                double num = ToDoub(textBox1.Text);
                if(num < 0)
                {
                    label1.Text = "ERROR";
                    MessageBox.Show("Невозможно посчитать! В интернете написано, что отрицательного фактариала не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    double res = 1;
                    for (int i = 1; i <= num; i++)
                    {
                        res *= i;
                    }
                    label1.Text = num + "!";
                    textBox1.Text = res.ToString();
                }       
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Возведение в какую хочешь степень
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (CanUseD)
                {
                    num1 = ToDoub(textBox1.Text);
                    label1.Text = num1.ToString() + " ^ ";
                    textBox1.Text = "";
                    znak = '^';
                    CanUseD = false;
                    CanUseZap = true;
                }
            }
            catch (Exception)
            {

            }
        }

        //Логарифм 10
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                if(num < 0)
                {
                    label1.Text = "ERROR";
                    MessageBox.Show("Число меньше 0! Невозможно посчитать!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    label1.Text = $"lg({num})";
                    textBox1.Text = Math.Log10(num).ToString();
                }             
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Число ПИ
        private void button23_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += 3.14;
            CanUseD = true;
        }

        //Отрицает число
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                label1.Text = $"-({num})";
                textBox1.Text = (-1 * num).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Возведение во 2 степень
        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                label1.Text = $"{num}^2";
                textBox1.Text = Math.Pow(num, 2).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Логарифм
        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                label1.Text = $"ln({num})";
                textBox1.Text = Math.Log(num).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Кнопка для размера
        private void button28_Click(object sender, EventArgs e)
        {
            if(Width == 309)
            {
                Width= 455;
                button28.Text = "less";
                button24.Location = new Point(411, 0);
                textBox1.Width = 415;
                textBox1.Location = new Point(12, 95);
            }
            else
            {
                Width = 309;
                button28.Text = "more";
                button24.Location = new Point(265, 0);
                textBox1.Width = 269;
                textBox1.Location = new Point(12, 95);

            }
        }

        //Округление
        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                textBox1.Text = Math.Round(num, 2).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                label1.Text = Math.Exp(num).ToString();
                textBox1.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Корень
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                if(num < 0)
                {
                    MessageBox.Show("Невозможно вычисть отрицательный корень!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label1.Text = "ERROR";
                }
                else
                {
                    label1.Text = $"√{num}";
                    textBox1.Text = Math.Sqrt(num).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //1/x
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                double num = ToDoub(textBox1.Text);
                textBox1.Text = (1 / num).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно посчитать! Возможно виноват сам калькулятор, либо вы!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}