using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicConstructor
{
    public partial class MyMessage : Form
    {
        public MyMessage()
        {
            InitializeComponent();
        }

        public static void ShowWindow(string msg)
        {
            MyMessage form = new MyMessage();
            form.richTextBox1.Text = msg;
            // выделения подстроки
            string str = msg;
            // разбор тегов
            List<int> leftL = new List<int>();
            List<int> rightL = new List<int>();
            //обычный
            string strR1 = "<r>";
            string strR2 = "<|r>";
            //жирный
            string strB1 = "<b>";
            string strB2 = "<|b>";
            // курсив
            string strI1 = "<i>";
            string strI2 = "<|i>";
            //перечеркнутый
            string strS1 = "<s>";
            string strS2 = "<|s>";
            //подчеркнутый
            string strU1 = "<u>";
            string strU2 = "<|u>";
            //MessageBox.Show(msg);
            //FindWort(wort1, msg);
            //FindWort(wort2, msg);
            int j = 0;
            char ch = '0';
            if ((str.IndexOf(strR1) != -1) & (str.IndexOf(strR1)) != -1)
                ch = 'r';
            if ((str.IndexOf(strB1) != -1) & (str.IndexOf(strB1)) != -1)
                ch = 'b';
            if ((str.IndexOf(strI1) != -1) & (str.IndexOf(strI1)) != -1)
                ch = 'i';
            if ((str.IndexOf(strS1) != -1) & (str.IndexOf(strS1)) != -1)
                ch = 's';
            if ((str.IndexOf(strU1) != -1) & (str.IndexOf(strU1)) != -1)
                ch = 'u';
            switch (ch)
            {
                case 'r':
                    {
                        //для обычного
                        str = GetLeftRightSelect(strR1, strR2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Regular);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    };
                    break;
                case 'b':
                    {

                        //для жирного
                        form.richTextBox1.Text = GetLeftRightSelect(strB1, strB2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Bold);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    };
                    break;
                case 'i':
                    {
                        //для курсива
                        form.richTextBox1.Text = GetLeftRightSelect(strI1, strI2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Italic);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    };
                    break;
                case 's':
                    {
                        //для зачеркнутого
                        form.richTextBox1.Text = GetLeftRightSelect(strS1, strS2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Strikeout);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    };
                    break;
                case 'u':
                    {
                        //для подчеркнутого
                        form.richTextBox1.Text = GetLeftRightSelect(strU1, strU2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Underline);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    }
                    break;
                default: break;
            }
            form.Show();
        }
        public static void ShowDialogWindow(string msg)
        {
            MyMessage form = new MyMessage();
            form.richTextBox1.Text = msg;
            // выделения подстроки
            string str = msg;
            // разбор тегов
            List<int> leftL = new List<int>();
            List<int> rightL = new List<int>();
            //обычный
            string strR1 = "<r>";
            string strR2 = "<|r>";
            //жирный
            string strB1 = "<b>";
            string strB2 = "<|b>";
            // курсив
            string strI1 = "<i>";
            string strI2 = "<|i>";
            //перечеркнутый
            string strS1 = "<s>";
            string strS2 = "<|s>";
            //подчеркнутый
            string strU1 = "<u>";
            string strU2 = "<|u>";
            //MessageBox.Show(msg);
            //FindWort(wort1, msg);
            //FindWort(wort2, msg);
            int j = 0;
            char ch = '0';
            if ((str.IndexOf(strR1) != -1) & (str.IndexOf(strR1)) != -1)
                ch = 'r';
            if ((str.IndexOf(strB1) != -1) & (str.IndexOf(strB1)) != -1)
                ch = 'b';
            if ((str.IndexOf(strI1) != -1) & (str.IndexOf(strI1)) != -1)
                ch = 'i';
            if ((str.IndexOf(strS1) != -1) & (str.IndexOf(strS1)) != -1)
                ch = 's';
            if ((str.IndexOf(strU1) != -1) & (str.IndexOf(strU1)) != -1)
                ch = 'u';
            switch (ch)
            {
                case 'r':
                    {
                        //для обычного
                        str = GetLeftRightSelect(strR1, strR2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Regular);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    };
                    break;
                case 'b':
                    {

                        //для жирного
                        form.richTextBox1.Text = GetLeftRightSelect(strB1, strB2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Bold);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    };
                    break;
                case 'i':
                    {
                        //для курсива
                        form.richTextBox1.Text = GetLeftRightSelect(strI1, strI2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Italic);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    };
                    break;
                case 's':
                    {
                        //для зачеркнутого
                        form.richTextBox1.Text = GetLeftRightSelect(strS1, strS2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Strikeout);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    };
                    break;
                case 'u':
                    {
                        //для подчеркнутого
                        form.richTextBox1.Text = GetLeftRightSelect(strU1, strU2, str, leftL, rightL);
                        for (j = 0; j < leftL.Count; j++)
                        {
                            if ((leftL[j] < rightL[j]) & (leftL[j] >= 0) & (rightL[j] >= 0))
                                form.richTextBox1.Select(leftL[j], rightL[j] - leftL[j]);
                            form.richTextBox1.SelectionFont = new Font(form.richTextBox1.SelectionFont, FontStyle.Underline);
                            form.richTextBox1.DeselectAll();
                        }
                        leftL.Clear();
                        rightL.Clear();
                    }
                    break;
                default: break;
            }
            form.ShowDialog();
        }
        public static void WindowResize(int height, int width)
        {
            MyMessage form = new MyMessage();
            form.Width = width;
            form.Height = height;
            form.ResizeRedraw = true;

        }
        static string MyReplase(int StartIdx, string SubStr, string Str)
        {
            string StrNew = "";
            for (int j = 0; j < StartIdx; j++)
            {
                StrNew += Str[j];
            }
            for (int j = StartIdx + SubStr.Length; j <= Str.Length - 1; j++)
            {
                StrNew += Str[j];
            }
            return StrNew;
        }
        // заполняет списки левых и правых индексов и удаляет из строки теги
        static string GetLeftRightSelect(string TegStr1, string TegStr2, string str, List<int> leftL, List<int> rightL)
        {
            int lef = 0;
            int rig = 0;
            bool exist = true;
            while (exist)
            {
                if ((str.IndexOf(TegStr1) == -1) & (str.IndexOf(TegStr2)) == -1)
                    exist = false;
                else
                {
                    lef = str.IndexOf(TegStr1);
                    leftL.Add(lef);
                    str = MyReplase(lef, TegStr1, str);
                    rig = str.IndexOf(TegStr2);
                    rightL.Add(rig);
                    str = MyReplase(rig, TegStr2, str);
                }
            }
            return str;
        }
        // ищет в строке слово и выделяет его
        public string FindWort(string wort, string str)
        {
            string s = "";
            string subS = "";
            int i = 0;
            int j = 0;
            int k = 0;
            int isIn = 0;
            for (i = 0; i <= str.Length - 1; i++)
            {
                if (str.IndexOf(wort) != -1)
                {
                    if (str[i] == wort[0]) // сравниваем первый символ искомого слова с каждым символом заголовка
                    {
                        j = 0;
                        k = 0;
                        subS = "";
                        while (j <= wort.Length - 1)
                        {
                            subS += str[i];
                            if (str[i] != wort[j])
                            {
                                k = 1;
                                s += subS;
                                subS = "";
                            }
                            j++;
                            i++; //*
                        }
                        if (k == 0)
                        {
                            s += "<b>" + subS + "<|b>";
                            subS = "";
                            isIn = 1;
                        }
                        i--;// уменьшаем из-за лишнего инкрементирования в *
                    }
                    else
                    {
                        s += str[i];
                    }
                }
            }
            if (isIn == 1)
            {
                s += ".";
                str = s;
                isIn = 0;
                return str;
            }
            else
            {
                str = "";
                return str;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MyMessage_Load(object sender, EventArgs e)
        {

        }

        private void MyMessage_Resize(object sender, EventArgs e)
        {
            MyMessage form = new MyMessage();
            form.Text = Convert.ToString(form.Height) + Convert.ToString(form.Width);
        }
    }
}
