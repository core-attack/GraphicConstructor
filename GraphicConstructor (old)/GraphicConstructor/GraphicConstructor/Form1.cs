using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
//using GraphicConstructor.Parser;




namespace GraphicConstructor
{
    public partial class Form1 : Form
    {
        System.Globalization.NumberFormatInfo format;
        // * и ** эквивалентны, но ** работает быстрее
        Parser p = new Parser();//*
        enum Errors { SYNTAX, UNBALPARENTS, NOEXP, DIVBYZERO, OTHER };
        Function f = new Function();//**
        PointPairList list1 = new PointPairList();

        List<List<double>> listDlt = new List<List<double>>(); // коллекция коллекций               
        //List<List<double>> listY = new List<List<double>>();
        List<double> listFirstElem = new List<double>(); // для первых элементов подколлекций
        List<double> listWidth = new List<double>(); // для толщины всех окрестностей
        List<string> listFunc = new List<string>();
        //MyMessage Mes = new MyMessage();
        bool IsGraphCreate = false;
        double widthforDelt = 0; 
        int CountClick = 0;
        int OldCountClick = 0;
        int chet = 1; // для отсечения дублированного вывода в listBox_Width значений

        public Form1()
        {
            //меняем раскладку на английскую
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            if (InputLanguage.CurrentInputLanguage != InputLanguage.FromCulture(culture))
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(culture);
            p.form1 = this;
            format = new System.Globalization.NumberFormatInfo();
            format.NumberDecimalSeparator = ","; // установили раздлитель дробной части чисел
            
            InitializeComponent();

            textBoxDbeg.Text = "-pi/2";//"eps/2";//"-Pi/2";
            textBoxDend.Text = "pi/2";//"eps";//"Pi/2";
            textBoxEpsStep.Text = "0,001";
            textBoxY0.Text = "5,0";
            textBox_Function.Text = "abs(sin(1/x))";
            //textBox_Function.Text = "(x-3)*(x+2)*(x-1)*x*(x+1)*(x-2)*(x+3)";
            textBoxEpsStep.Text = "0,01";
            textBoxY0.Text = "0";
            // по умолчанию нет ошибки
            p.err = Parser.Errors.NOERR;
            Clear_button.Enabled = false;
            
        }

        private void textBoxDbeg_Click(object sender, EventArgs e)
        {
            textBoxDbeg.SelectAll();
        }

        private void textBoxDend_Click(object sender, EventArgs e)
        {
            textBoxDend.SelectAll();
        }

        private void textBoxEpsStep_Click(object sender, EventArgs e)
        {
            textBoxEpsStep.SelectAll();
        }

        private void textBoxY0_Click(object sender, EventArgs e)
        {
            textBoxY0.SelectAll();
        }

        private void textBoxDbeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDbeg.Text = textBoxDbeg.Text.ToLower();
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b') // /b - это для backspace
            {
                //запрет на ввод более одной десятичной точки и тире
                if (
                    (e.KeyChar != ',' || textBoxDbeg.Text.IndexOf(",") != -1) && (e.KeyChar != '-' || textBoxDbeg.Text.IndexOf("-") != -1)
                    && (e.KeyChar != 'P') && (e.KeyChar != 'p') && (e.KeyChar != 'I') && (e.KeyChar != 'i')
                    && (e.KeyChar != 'E') && (e.KeyChar != 'e') && (e.KeyChar != 'S') && (e.KeyChar != 's')
                    && (e.KeyChar != '*') && (e.KeyChar != '^')
                    && (e.KeyChar != '-') && (e.KeyChar != '/')
                    && (e.KeyChar != '+')
                    && (e.KeyChar != '(') && (e.KeyChar != ')')
                   )
                {
                    e.Handled = true;
                }
            }
            
        }

        private void textBoxDend_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDend.Text = textBoxDend.Text.ToLower();
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                //запрет на ввод более одной десятичной точки и тире
                if (
                    (e.KeyChar != ',' || textBoxDend.Text.IndexOf(",") != -1) && (e.KeyChar != '-' || textBoxDend.Text.IndexOf("-") != -1)
                    && (e.KeyChar != 'P') && (e.KeyChar != 'p') && (e.KeyChar != 'I') && (e.KeyChar != 'i')
                    && (e.KeyChar != 'E') && (e.KeyChar != 'e') && (e.KeyChar != 'S') && (e.KeyChar != 's')
                    && (e.KeyChar != '*') && (e.KeyChar != '^')
                    && (e.KeyChar != '-') && (e.KeyChar != '/')
                    && (e.KeyChar != '+')
                    && (e.KeyChar != '(') && (e.KeyChar != ')')
                   )
                {
                    e.Handled = true;
                }
            }
            
        }
        // eps_step по умолчанию >0, поэтому в этом методе мы запрещаем возможность вводить тире
        private void textBoxEpsStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                if (e.KeyChar != ',' || textBoxEpsStep.Text.IndexOf(",") != -1)
                {
                    e.Handled = true;
                }

            }
        }

        private void textBoxY0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                //запрет на ввод более одной десятичной точки и тире
                if (
                    (e.KeyChar != ',' || textBoxY0.Text.IndexOf(",") != -1) && (e.KeyChar != '-' || textBoxY0.Text.IndexOf("-") != -1)
                   )
                {
                    e.Handled = true;
                }
                
            }
        }

        private void textBox_Function_Click(object sender, EventArgs e)
        {
            textBox_Function.SelectAll();
            if (!AlreadyHave(textBox_Function.Text) && textBox_Function.Text != "")
            {
                listFunc.Add(textBox_Function.Text);
                listBoxFunc.Items.Add(textBox_Function.Text);
            }
        }

        private bool AlreadyHave(string item)
        {
            string s = "";
            int k = 0;
            bool Ok = true;
            int j = 0;
            for (int i = 0; i < listFunc.Count; i++)
            {
                s = Convert.ToString(listFunc[i]);
                while (Ok)
                {
                    if (item == "")
                        break;
                    if (item[j] == s[j])
                        k++;
                    else
                        Ok = false;
                    if (j < item.Length - 1)
                        j++;
                    else
                        Ok = false;
                }
                if (k == item.Length)
                    return true;
                k = 0;
                j = 0;
                Ok = true;
            }
            return false;
        }
        
        // возвращаем начальное значение по оси Х
        public double Dbeg
        {
            get
            {
                if (textBoxDbeg.Text != "")
                    return Convert.ToDouble(p.Evaluate(textBoxDbeg.Text,0), format);
                else
                    return 0.0;
            }
        }
        // возвращаем конечное значение по оси Х
        public double Dend
        {
            get
            {
               if (textBoxDend.Text != "")
                  return Convert.ToDouble(p.Evaluate(textBoxDend.Text, 0), format);
               else
                  return 0.0;
            }
        }
        // возвращаем ординату точки y0
        public double y0
        {
            get
            {
                if (textBoxY0.Text != "")
                    return Convert.ToDouble(p.Evaluate(textBoxY0.Text, 0), format);
                else
                    return 0.0;
            }
        }
        // возвращаем эпсилон-шаг
        public double eps_step
        {
            get
            {
                if (textBoxEpsStep.Text != "")
                    return Convert.ToDouble(p.Evaluate(textBoxEpsStep.Text,0), format);
                else
                    return 0.00;
            }
        }
        // возвращает текст функции
        public string func
        {
            get
            {
                if (textBox_Function.Text != "")
                    return textBox_Function.Text;
                else
                {
                    //MyMessage.Show("<b>Ошибка<|b>: Функция не была введена.");
                    return "";
                }
            }
        }

        private void Build_button_Click(object sender, EventArgs e) //кнопка "Построить"
        {
            try
            {
                p.err = Parser.Errors.NOERR;
                textBox_MinWidth.Text = "";
                //textBoxDbeg.Text = Convert.ToString(p.Evaluate(textBoxDbeg.Text, 1));
                //textBoxDend.Text = Convert.ToString(p.Evaluate(textBoxDend.Text, 1));
                //textBoxY0.Text = Convert.ToString(p.Evaluate(textBoxY0.Text, 1)); ;
                if (textBoxDbeg.Text.IndexOf("ip") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("ip", "pi");
                if (textBoxDbeg.Text.IndexOf("pse") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("pse", "eps");
                if (textBoxDbeg.Text.IndexOf("sep") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("sep", "eps");
                if (textBoxDbeg.Text.IndexOf("pes") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("pes", "eps");
                if (textBoxDbeg.Text.IndexOf("spe") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("spe", "eps");
                if (textBoxDbeg.Text.IndexOf("esp") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("esp", "eps");
                if (textBoxDbeg.Text.IndexOf("ip") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("ip", "pi");
                if (textBoxDbeg.Text.IndexOf("pse") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("pse", "eps");
                if (textBoxDbeg.Text.IndexOf("sep") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("sep", "eps");
                if (textBoxDbeg.Text.IndexOf("pes") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("pes", "eps");
                if (textBoxDbeg.Text.IndexOf("spe") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("spe", "eps");
                if (textBoxDbeg.Text.IndexOf("esp") != -1)
                    textBoxDbeg.Text = textBoxDbeg.Text.Replace("esp", "eps");
                if (func == "")
                {
                    MyMessage.ShowDialogWindow("<b>Ошибка<|b>: Функция не была введена.");
                    textBox_Function.Text = "Введите сюда функцию";
                }
                else
                {
                    
                    if (Dbeg >= Dend)
                    {
                        MyMessage.ShowWindow("<b>Ошибка<|b>: Введите корректно концы интервала построения! \n<i>Замечание: левый конец интервала должен быть меньше правого<|i>.");
                    }
                    else
                    {
                        CountClick++;
                        // разбиваем поэлементно в польскую форму записи
                        //f.SetFunc(func);
                        // проверка
                        //textBox1.Text = Convert.ToString(f.Calc(1));

                        // заливка сзади графика
                        //GraphPane myPane = zedGraphControl1.GraphPane;
                        //Fill fill = new Fill(Color.Teal, Color.Yellow, Color.Tomato);  
                        //myPane.Fill = fill;

                        CreateGraph(zedGraphControl1, MyGraphColor, eps_step); // строим график 
                        SetSize(); // и устанавливаем его положение и размер
                        IsGraphCreate = true;
                        Clear_button.Enabled = true;
                        OldCountClick = CountClick;
                        Okrestnost_button.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string exept = ex.StackTrace;
                //Mes.FindWort(wort1, exept);
                //Mes.FindWort(wort2, exept);
                MyMessage.ShowDialogWindow("<b>Ошибка функционирования программы<|b>: \n" + ex.Message + " : \n" + "" + exept + "");
            }

        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxDbeg.Text = Convert.ToString(p.Evaluate(textBoxDbeg.Text, 1));
                textBoxDend.Text = Convert.ToString(p.Evaluate(textBoxDend.Text, 1));
                textBoxY0.Text = Convert.ToString(p.Evaluate(textBoxY0.Text, 1)); ;
                if (func == "")
                {
                    MyMessage.ShowDialogWindow("<b>Ошибка<|b>: Функция не была введена.");
                    textBox_Function.Text = "Введите сюда функцию";
                }
                else
                {
                    if (Dbeg >= Dend)
                    {
                        MyMessage.ShowDialogWindow("<b>Ошибка<|b>: Введите корректно концы интервала построения! \n<i>Замечание: левый конец интервала должен быть меньше правого<|i>.");
                    }
                    else
                    {
                        CountClick++;
                        // разбиваем поэлементно в польскую форму записи
                        f.SetFunc(func);
                        // проверка
                        textBox1.Text = Convert.ToString(f.Calc(1));

                        // заливка сзади графика
                        //GraphPane myPane = zedGraphControl1.GraphPane;
                        //Fill fill = new Fill(Color.Teal, Color.Yellow, Color.Tomato);  
                        //myPane.Fill = fill;
                        double eps = eps_step / 100;
                        CreateGraph(zedGraphControl1, MyGraphColor, eps); // строим график 
                        SetSize(); // и устанавливаем его положение и размер
                        IsGraphCreate = true;
                        OldCountClick = CountClick;
                        Update_button.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                string exept = ex.StackTrace;
                //Mes.FindWort(wort1, exept);
                //Mes.FindWort(wort2, exept);
                MyMessage.ShowDialogWindow("<b>Ошибка функционирования программы<|b>: \n" + ex.Message + " : \n" + "" + exept + "");
            }

        }

        private void Okrestnost_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsGraphCreate)
                {
                    listDlt.Clear();
                    listFirstElem.Clear();
                    listWidth.Clear();
                    //listY.Clear();
                    listBox_delta.Items.Clear();
                    listBox_Width.Items.Clear();
                    textBox_MinWidth.Text = "";
                    textBox_CurentWidth.Text = "";
                    chet = 1;
                    progressBar1.Value = 0;
                    BuildEpsTrub(zedGraphControl1, y0, MyEpsColor);
                    progressBar1.Increment(50);
                    BuildArrDelt(zedGraphControl1);
                    progressBar1.Increment(50);
                    //Update_button.Visible = true;
                    Update_button.Enabled = true;
                    //Build_button.Size.Height = 68;
                    Okrestnost_button.Enabled = false;

                }
                else
                {
                    MyMessage.ShowDialogWindow("<b>Ошибка <|b>: Сначала постройте график! \nЗамечание: Нажмите на кнопку <b>Построить<|b>");
                }
            }
            catch (Exception ex)
            {
                string exept = ex.StackTrace;
                //Mes.FindWort(wort1, exept);
                //Mes.FindWort(wort2, exept);
                MyMessage.ShowDialogWindow("<b>Ошибка функционирования программы<|b>: \n" + ex.Message + " : \n" + "" + exept + "");
            }
        }
        
        // Обработчик события Resize формы с графиком 
        private void Form1_Resize( object sender, EventArgs e ) 
        { 
            SetSize(); 
        } 

        // Фунция изменения размера и положения графика в зависимости от размера формы 
        private void SetSize() 
        {
            // задаем положение графика
            int XPoint = (int)Math.Round(Convert.ToDouble(zedGraphControl1.Location.X));
            int YPoint = (int)Math.Round(Convert.ToDouble(zedGraphControl1.Location.Y)); 
            zedGraphControl1.Location = new Point(XPoint, YPoint);  
            // размеры графика
            int Wdth = ClientRectangle.Width - 247;
            int Hght = ClientRectangle.Height - 25;
            zedGraphControl1.Size = new Size(Wdth,Hght);//(ClientRectangle.Width, ClientRectangle.Height);  
        } 

        // Функция построения графика 
        private void CreateGraph(ZedGraphControl zgc, Color MyGraphColor, double eps) 
        { 
            GraphPane myPane = zgc.GraphPane;
            PointPairList list1 = new PointPairList();
            
            progressBar1.Value = 0;

            // Задаем название графика и сторон 
            myPane.Title.IsVisible = false; // .Text = "Graphic Constructor (by PN)"; 
            myPane.XAxis.Title.IsVisible = false; // .Text = "Ось X"; 
            myPane.YAxis.Title.IsVisible = false; // .Text = "Ось Y"; 

            // строим график 
            double x, y; // переменные 
            x = Dbeg; // присваиваем левый конец интервала
            string sName = func;
            string s = func;
            try
            {
                y = p.Evaluate(func, x);
                switch (p.err)
                    {
                        case Parser.Errors.DIVBYZERO: { MyMessage.ShowDialogWindow("<b>Ошибка <|b>: Деление на нуль. \nЗамечание: недопустимая операция."); }
                            break;
                        case Parser.Errors.NOEXP: { MyMessage.ShowDialogWindow("<b>Ошибка <|b>: Выражение отсутствует. \nЗамечание: введите функцию в поле <b>f(x)<|b>."); }
                            break;
                        case Parser.Errors.OTHER: { MyMessage.ShowDialogWindow("<b>Ошибка <|b>: Нарушение алгоритма. \nЗамечание: обратитесь к разработчику."); }
                            break;
                        case Parser.Errors.SYNTAX: { MyMessage.ShowDialogWindow("<b>Ошибка <|b>: Синтаксическая ошибка. \nЗамечание: проверьте корректность введённой функции."); }
                            break;
                        case Parser.Errors.UNBALPARENTS: { MyMessage.ShowDialogWindow("<b>Ошибка <|b>: Дисбаланс скобок. \nЗамечание: Количество открывающих скобок не равно количеству закрывающих скобок."); }
                            break;
                        case Parser.Errors.NOERR:
                            {
                                do
                                {

                                    y = p.Evaluate(func, x);
                                    //y = f.Calc(x);
                                    list1.Add(x, y);
                                    x += eps;
                                }
                                while (x <= Dend); // и пока не равен правому конца зацикливаем
                                LineItem myCurve = myPane.AddCurve(sName, list1, MyGraphColor, SymbolType.Circle); // отрисовываем график 
                                zgc.AxisChange();
                            }
                            break;
                    }
            }
            catch
            {
                MyMessage.ShowDialogWindow("<b>Синтаксическая ошибка<|b>");
            }
            
            progressBar1.Increment(100);
        }

        Color MyGraphColor
        {
            get
            {
                Random rand = new Random();
                int n = rand.Next(12);
                switch (n)
                {
                    case 0: return Color.Blue;
                    case 1: return Color.Navy;
                    case 2: return Color.BlueViolet;
                    case 3: return Color.CadetBlue;
                    case 4: return Color.CornflowerBlue;
                    case 5: return Color.Chartreuse;
                    case 6: return Color.DarkBlue;
                    case 7: return Color.DarkSlateBlue;
                    case 8: return Color.DodgerBlue;
                    case 9: return Color.Indigo;
                    case 10: return Color.MediumBlue;
                    case 11: return Color.MidnightBlue;
                    case 12: return Color.RoyalBlue;
                    default: return Color.Blue;
                }
            }
        }

        Color MyEpsColor
        {
            get
            {
                Random rand = new Random();
                int n = rand.Next(12);
                switch (n)
                {
                    case 0: return Color.Gainsboro;
                    case 1: return Color.Lavender;
                    case 2: return Color.LightSalmon;
                    case 3: return Color.Lime;
                    case 4: return Color.LimeGreen;
                    case 5: return Color.MediumAquamarine;
                    case 6: return Color.MediumSpringGreen;
                    case 7: return Color.Moccasin;
                    case 8: return Color.PaleGreen;
                    case 9: return Color.PeachPuff;
                    case 10: return Color.Red;
                    case 11: return Color.YellowGreen;
                    case 12: return Color.Yellow;
                    default: return Color.DarkRed;
                }
            }
        }

        Color MyDeltColor
        {
            get
            {
                Random rand = new Random();
                int n = rand.Next(12);
                switch (n)
                {
                    case 0: return Color.DarkOrange;
                    case 1: return Color.DarkViolet;
                    case 2: return Color.DarkOrchid;
                    case 3: return Color.DarkSlateBlue;
                    case 4: return Color.DarkGoldenrod;
                    case 5: return Color.Tomato;
                    case 6: return Color.DimGray;
                    case 7: return Color.DarkCyan;
                    case 8: return Color.Teal;
                    case 9: return Color.Thistle;
                    case 10: return Color.DeepPink;
                    case 11: return Color.DarkTurquoise;
                    case 12: return Color.Crimson;
                    default: return Color.Fuchsia;
                }
            }
        }

        private void TextBoxEnter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        

        //строим эспилон окрестность заданной точки y0
        void BuildEpsTrub(ZedGraphControl zgc, double Y, Color MyColor)
        {
            progressBar1.Value = 0;
            double eps = eps_step / 100;
            
            GraphPane myPane = zgc.GraphPane;
            PointPairList listEps = new PointPairList();
            double x1 = Dbeg;
            double x2 = Dend;
            while (x1 <= Dend)
            {
                listEps.Add(x1, Y - eps_step);
                x1 += eps;
            }
            progressBar1.Increment(30);
            listEps.Add(Dend, Y - eps_step);
            listEps.Add(Dend, Y + eps_step);
            while (x2 >= Dbeg)
            {
                listEps.Add(x2, Y + eps_step);
                x2 -= eps;
            }
            progressBar1.Increment(30);
            LineItem myCurve2 = myPane.AddCurve("EpsTbk for " + func, listEps, MyColor, SymbolType.Square); // отрисовываем график 
            zgc.AxisChange();
            progressBar1.Increment(40);

        }

        //строим дельта трубку 
        void BuildDeltTrub(ZedGraphControl zgc, double Xbeg, double MinCountEps, double Y, Color MyColor)
        {
            progressBar1.Value = 0;
            
            GraphPane myPane = zgc.GraphPane;
            PointPairList listDlt = new PointPairList();
            double y1 = 0;
            double y2;
            if (Y > 0)
            {
                y2 = Y + eps_step;
                while (y1 < y2)
                {
                    listDlt.Add(Xbeg, y1);
                    y1 += eps_step;
                }
                listDlt.Add(Xbeg, y2);
                listDlt.Add(Xbeg + MinCountEps, y2);
                y1 = 0;
                while (y2 > y1)
                {
                    listDlt.Add(Xbeg + MinCountEps, y2);
                    y2 -= eps_step;
                }
                listDlt.Add(Xbeg + MinCountEps, y1);
                listDlt.Add(Xbeg, y1);
            }
            else if ((Y == 0)||(Y == Dbeg)||(Y == Dend))
            {
                y1 = Y + eps_step;
                y2 = Y - eps_step;
                if (yInTbk(p.Evaluate(textBoxDbeg.Text,0)) || yInTbk(p.Evaluate(textBoxDend.Text,0))) // начало графика уже в трубке
                {
                    while (y1 > y2)
                    {
                        listDlt.Add(Xbeg, y1);
                        y1 -= eps_step;
                    }
                    listDlt.Add(Xbeg, y2);
                    listDlt.Add(Xbeg + MinCountEps, y2);
                    y1 = Y + eps_step;
                    while (y2 < y1)
                    {
                        listDlt.Add(Xbeg + MinCountEps, y2);
                        y2 += eps_step;
                    }
                    listDlt.Add(Xbeg + MinCountEps, y1);
                    listDlt.Add(Xbeg, y1);
                }
                else
                {
                    while (y1 > y2)
                    {
                        listDlt.Add(Xbeg, y1);
                        y1 -= eps_step;
                    }
                    listDlt.Add(Xbeg, y2);
                    listDlt.Add(Xbeg + MinCountEps, y2);
                    y1 = Y + eps_step;
                    while (y2 < y1)
                    {
                        listDlt.Add(Xbeg + MinCountEps, y2);
                        y2 += eps_step;
                    }
                    listDlt.Add(Xbeg + MinCountEps, y1);
                    listDlt.Add(Xbeg, y1);
                }
            }
            else
            {
                y2 = Y - eps_step;
                while (y1 > y2)
                {
                    listDlt.Add(Xbeg, y1);
                    y1 -= eps_step;
                }
                listDlt.Add(Xbeg, y2);
                listDlt.Add(Xbeg + MinCountEps, y2);
                y1 = 0;
                while (y2 < y1)
                {
                    listDlt.Add(Xbeg + MinCountEps, y2);
                    y2 += eps_step;
                }
                listDlt.Add(Xbeg + MinCountEps, y1);
                listDlt.Add(Xbeg, y1);
            }
                
            LineItem myCurve2 = myPane.AddCurve("DltTbk for " + func, listDlt, MyColor, SymbolType.Square); // отрисовываем график 
            zgc.AxisChange();
            progressBar1.Increment(40);

        }

        bool yInTbk(double y)
        {
            double yUp,yDwn;
            yUp = y0 + eps_step;
            yDwn = y0 - eps_step;
            if (
                    ((y > yDwn) && (y < yUp)) // для возрастающей функции 
                    ||
                    ((y > yDwn) && (y < yUp)) // для убывающей функции
                   )
                return true;
            else
                return false;
        }    

        void BuildArrDelt(ZedGraphControl zgc)
        {
            progressBar1.Value = 0;
            
            //MessageBox.Show(whereI);

            double y = 0;
            double yNext = 0; 
            int idx = -1; // индекс подмассива
            bool Ent, Ext;
            Ent = false;
            Ext = false;
            double eps = eps_step/ 10;
            double ySec, yNextSec;
            double epsSec = eps / 100;
            bool firstEl = false;
            bool firstTBK = true; // для случая /***/
            //
            progressBar1.Increment(10);
            for (double x = Dbeg; x <= Dend; x += eps) // если ставить равное eps_step, то может просто перескочить через эпсилон-трупку
            {
                y = p.Evaluate(func, x);
                //y = f.Calc(x);
                yNext = p.Evaluate(func, x + eps_step);
                //yNext = f.Calc(x + eps_step);
                if (yInTbk(y) == false && yInTbk(yNext)) // y не в трубке, а yNext в трубке
                {
                    // вход в эпсилон трубку
                    Ent = true; 
                    firstEl = true;
                    // добавили в основную коллекцию
                    listDlt.Add(new List<double>());
                    //listY.Add(new List<double>());
                }
                else if (yInTbk(y) && yInTbk(yNext) == false)
                {
                    Ext = true;
                }
                else
                {
                    Ent = false;
                    Ext = false;
                }
                if (yInTbk(y))
                {/***/
                    if (firstTBK & (p.Evaluate(textBoxDbeg.Text,0) >= y - eps_step || p.Evaluate(textBoxDbeg.Text+ "+" + Convert.ToString(eps_step),0) <= y + eps_step) &  (p.Evaluate(textBoxDend.Text + "-" + Convert.ToString(eps_step),0) >= y - eps_step || p.Evaluate(textBoxDend.Text + "+" + Convert.ToString(eps_step),0) <= y + eps_step))
                    {
                        firstTBK = false;
                        Ent = true;
                        firstEl = true;
                        // добавили в основную коллекцию
                        listDlt.Add(new List<double>());
                        //listY.Add(new List<double>());
                    }
                    if (firstEl)
                    {
                        
                        idx++;
                        if (listFirstElem.Count == 0)
                        {
                            listFirstElem.Add(x);
                        }
                        else
                        {
                            if (Math.Abs(listFirstElem[listFirstElem.Count - 1] - x) > eps)
                            {
                                listFirstElem.Add(x);
                            }
                        }
                    }
                    firstEl = false;
                    listDlt[idx].Add(x);
                    //listY[idx].Add(y);
                    //listBox_SubDelta.Items.Add(Convert.ToString(x)); // вывод попадающих точек
                }
                else if
                    (
                     !yInTbk(y) && !yInTbk(yNext) && (y < y0 - eps_step) && (yNext > y0 + eps_step) ||
                     !yInTbk(y) && !yInTbk(yNext) && (y > y0 - eps_step) && (yNext < y0 + eps_step)
                    )
                {
                    
                    for (double xSec = x; xSec < x + eps_step; xSec += epsSec)
                    {
                        ySec = p.Evaluate(func, xSec);
                        //ySec = f.Calc(xSec);
                        yNextSec = p.Evaluate(func, xSec + epsSec);
                        //yNextSec = f.Calc(xSec + epsSec);
                        if (yInTbk(ySec) == false && yInTbk(yNextSec)) // y не в трубке, а yNextSec в трубке
                        {
                            Ent = true; //вход в эпсилон трубку
                            firstEl = true;

                            listDlt.Add(new List<double>());// добавили в основную коллекцию
                            //listY.Add(new List<double>());
                            idx++;
                        }
                        else if (yInTbk(ySec) && yInTbk(yNextSec) == false)
                        {
                            Ext = true;
                        }
                        else
                        {
                            Ent = false;
                            Ext = false;
                        }
                        if (yInTbk(ySec))
                        {
                            if (firstEl)
                            {
                                if (listFirstElem.Count == 0)
                                {
                                    listFirstElem.Add(xSec);
                                }
                                else
                                {
                                    if (Math.Abs(listFirstElem[listFirstElem.Count - 1] - xSec) > epsSec)
                                    {
                                        listFirstElem.Add(xSec);
                                    }
                                }
                            }
                            firstEl = false;
                                                    
                            listDlt[idx].Add(xSec);
                            //listY[idx].Add(ySec);
                            
                            //listBox_SubDelta.Items.Add(Convert.ToString(xSec));
                        }
                        
                    }
                }
                
            }
            progressBar1.Increment(60);

            // выводим в список начальных точек дельта-окрестностей в listBox_delta 
            for (int w = 0; w < listFirstElem.Count; w++)
            {
                listBox_delta.Items.Add(Convert.ToString(listFirstElem[w]));
            }
            progressBar1.Increment(20);
            int KolTbk = listFirstElem.Count;
            if (KolTbk > 50)
            {

                MyMessage.ShowDialogWindow("Количество найденных дельта-трубок равно: " + Convert.ToString(KolTbk) + 
                    ", что превышает допустимое количество на " + Convert.ToString(KolTbk - 50) + ". Будут показаны лишь первые 50 трубок.");
                KolTbk = 50;
            }
            // построение дельта-трубок минимальной ширины
            for (int ind = 0; ind < KolTbk; ind++)
            {
                widthforDelt = GetWidth();
                if (widthforDelt >= eps_step)
                {
                    widthforDelt = eps_step * 0.1;
                }
                BuildDeltTrub(zgc, listFirstElem[ind], widthforDelt, /*listY[ind][i]*/ y0, MyDeltColor);
            }
            string tmp = string.Format("{0:0.000000000000000}", widthforDelt);
            textBox_MinWidth.Text = tmp;
            progressBar1.Increment(10);
        }

        double GetWidth()
        {
            progressBar1.Value = 0;
            int i = 0;
            double x1, x2, firstX, lastX;
            x1 = x2 = firstX = lastX = 0;
            firstX = 0;
            double TbkWidth = 0;
            bool ExitTbk = false;
            //listBox_SubDelta.Items.Clear();
            if (listDlt.Count == 0)
            {
                MyMessage.ShowDialogWindow("Эпсилон-трубка <b>не<|b> пересекает график функции y = " + "" + func + "");
                progressBar1.Increment(100);
                return 0;
            }
            else
            {
                x1 = listDlt[0][0];
                while (i < listDlt.Count)
                {
                    if (i == 0)
                        firstX = listDlt[0][0];
                    for (int j = 0; j < listDlt[i].Count; j++)
                    {
                        x2 = listDlt[i][j];
                        if (Math.Abs(x1 - x2) < eps_step)
                        {
                            // в начале работы вводит в listBox_SubDelta все найденные точки
                            //после первого нажатия выводит все точки определенной дельта-окрестности
                            //listBox_SubDelta.Items.Add(Convert.ToString(x2));

                            x1 = x2;

                            if (ExitTbk)
                            {
                                x1 = lastX = x2;
                                TbkWidth = Math.Abs(firstX - lastX);
                                ExitTbk = false;
                            }
                        }
                        else
                        {
                            ExitTbk = true;
                            x1 = firstX = listDlt[i][j];
                        }
                    }
                    i++;

                }
                
                //
                progressBar1.Increment(50);
                if (chet == 1)
                {
                    chet = -chet;
                    for (int indx = 0; indx <= listFirstElem.Count - 1; indx++)
                    {
                        double x = GetCurWidth(indx);
                        if (x >= eps_step)
                        {
                            x = eps_step * 0.1;
                        }
                        string tmp = string.Format("{0:0.000000000000000}", x);
                        listBox_Width.Items.Add(tmp);
                        listWidth.Add(GetCurWidth(indx)); // заполнили коллекцию ширины дельта-трубки
                    }
                }
                progressBar1.Increment(20);

                // в первый раз список этот заполнен, но после очистки он не заполняется почему-то
                double minWidth = listWidth[0];
                int t = 0;

                do
                {
                    if (minWidth > listWidth[t])
                    {
                        if (listWidth[t] != 0)
                            minWidth = listWidth[t];
                    }
                    t++;
                }
                while (t < listWidth.Count);

                progressBar1.Increment(30);

                return minWidth;
            }
        }

        private void listBox_delta_SelectedIndexChanged(object sender, EventArgs e)
        {
            // в listBox_SubDelta должны отразиться точки выбранной окрестности
            //listBox_SubDelta.Items.Clear();
            int idx;
            idx = listBox_delta.SelectedIndex;
            
            double x = GetCurWidth(idx);
            string tmp = string.Format("{0:0.000000000000000}", x);
            textBox_CurentWidth.Text = tmp;
        }

        double GetCurWidth(int idx)
        {
            double firstX = 0;
            double lastX = 0;
            double CurWidth = 0;
            double x1 = firstX = listFirstElem[idx];
            double x2;
            int j = 0;

            while (j < listDlt.Count)
            {
                for (int i = 0; i < listDlt[j].Count; i++)
                {
                    x2 = listDlt[j][i];
                    if (Math.Abs(x1 - x2) < eps_step)
                    {
                        //listBox_SubDelta.Items.Add(Convert.ToString(x2));
                        x1 = lastX = x2;
                    }
                }
                j++;
            }
            CurWidth = Math.Abs(firstX - lastX);
            return CurWidth;
        }
       
        private void Clear_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтверждаете очистку холста?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                progressBar1.Value = 0;
                IsGraphCreate = false;
                textBox_MinWidth.Text = "0";
                textBox_CurentWidth.Text = "";
                listBox_delta.Items.Clear();
                listBox_Width.Items.Clear();
                listDlt = new List<List<double>>(); // коллекция коллекций               
                //listY = new List<List<double>>();
                listFirstElem = new List<double>(); // для первых элементов подколлекций
                listWidth = new List<double>();
                chet = 1;
                Update_button.Enabled = false;
                Okrestnost_button.Enabled = false;
                p.err = Parser.Errors.NOERR; 
                //Build_button.Size.Height = 119;
                //Build_button.Size.Width = 71;
                /*listDlt.Clear();
                listFirstElem.Clear();
                listWidth.Clear();
                listY.Clear();*/

                widthforDelt = 0;
                progressBar1.Increment(15);

                ZedGraph.MasterPane masterPane = zedGraphControl1.MasterPane;
                masterPane.PaneList.Clear();
                progressBar1.Increment(45);


                progressBar1.Increment(30);
                // Создаем экземпляр класса GraphPane, представляющий собой один график
                GraphPane pane = new GraphPane();
                // Добавим новый график в MasterPane
                masterPane.Add(pane);
                // бред, чтобы контор очищался без кликанья по нему
                Height += 1;
                Height -= 1;
                Width += 1;
                Width -= 1;

                progressBar1.Increment(10);
                Clear_button.Enabled = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (MessageBox.Show("Уверены, что хотите выйти?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            { }
            else 
            { 
                e.Cancel = true; 
            }
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            //Form helpForm = new Form();
            //helpForm.Text = "О программе";
            //helpForm.Show();
            //Mes.FindWort("Прог", "Программа: <b>GraphicConstructor<|b>" +
            //    "\nРазработчик: <b>Пискарев Николай Сергеевич<|b>" +
            //    "\n<b>Описание:<|b> программа вычисляет размеры дельта-трубок, исходя из определения непрерывности графика функции в точке.Может использоваться и для обычного построения графиков." +
            //    "\n<b>РФ, Ижевск, УдГУ, ФИТиВТ - 2011<|b>");
            //MyMessage.WindowResize(25 * 10, 40 * 10);
            MyMessage.ShowWindow(
                "Программа: <b>GraphicConstructor<|b>" + 
                "\nРазработчик: <b>Пискарев Николай Сергеевич<|b>" +
                "\n<b>Описание:<|b> программа вычисляет размеры дельта-трубок, исходя из определения непрерывности графика функции в точке.Может использоваться и для обычного построения графиков." +
                "\n" +
                "\n<b>Обозначения переменной:<|b>" +
                " x" +
                "\n<b>Обозначения функций:<|b> (далее значком @ будет обозначаться аргумент функции)" +
                "\n<b>sin(@)<|b> : синус;" + 
                "\n<b>cos(@)<|b> : косинус;" + 
                "\n<b>tg(@)<|b> : тангенс;" + 
                "\n<b>arcsin(@)<|b> : арксинус;" + 
                "\n<b>arccos(@)<|b> : арккосинус;" + 
                "\n<b>arctg(@)<|b> : арктангенс;" + 
                "\n<b>sinh(@)<|b> : гиперболический синус;" + 
                "\n<b>cosh(@)<|b> : гиперболический косинус;" + 
                "\n<b>tgh(@)<|b> : гиперболический тангенс;" + 
                "\n<b>exp(@)<|b> : экспонента в степени @;" + 
                "\n<b>log(@)(N)<|b> : логарифм @ по основанию N;" + 
                "\n<b>ln(@)<|b> : десятичный логарифм;" + 
                "\n<b>abs(@)<|b> : модуль;" +
                "\n<b>Обозначения констант:<|b>" +
                "\n<b>Pi<|b> : число Пи;" +
                "\n<b>e<|b> : экспонента." +
                "\n" +
                "\n<b>РФ, Ижевск, УдГУ, ФИТиВТ - 2011<|b>"); 
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Text = Convert.ToString(e.KeyCode); //e.KeyChar - вводимый символ
        }

        private void ViewTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            int strWidth = 0;
            if (listFirstElem.Count != 0)
                for (int i = 0; i < listFirstElem.Count; i++)
                {
                    s += "№" + Convert.ToString(i + 1) + "; начало в точке х = " + Convert.ToString(listFirstElem[i]) + "; ширина = " + Convert.ToString(listWidth[i]) + ";\n";
                    if (i == 0)
                        strWidth = s.Length;
                }
            else
                s = "Дельта-трубок нет либо они ещё не построены (После построения графика функции нажмите на кнопку \"Построить\")";

            //MyMessage.WindowResize(10 * listFirstElem.Count, strWidth);
            MyMessage.ShowWindow(s);
        }

        

        private void OldFuncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxFunc.Enabled = true;
            listBoxFunc.Visible = true;
            //for (int i = 0; i < listFunc.Count; i++)
            //    if (listFunc.Count == 0)
            //        listBoxFunc.Items.Add(listFunc[i]);
            //    else if (!AlreadyHave(listFunc[i]))
            //        listBoxFunc.Items.Add(listFunc[i]);
        }

        private void listBoxFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFunc.SelectedIndex != -1)
            {
                int idx = listBoxFunc.SelectedIndex;
                textBox_Function.Text = Convert.ToString(listBoxFunc.Items[idx]);
            }
        }

        private void listBoxFunc_Click(object sender, EventArgs e)
        {
            listBoxFunc.Visible = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.X < listBoxFunc.Location.X || e.X > (listBoxFunc.Location.X + listBoxFunc.Width))
                && (e.Y < listBoxFunc.Location.Y || e.Y > (listBoxFunc.Location.Y + listBoxFunc.Height)))
            {
                listBoxFunc.Visible = false;
            }
            //Text = Convert.ToString(e.X) + ":" + Convert.ToString(e.Y); 
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listFunc.Clear();
            listBoxFunc.Items.Clear();
        }

    }
}
