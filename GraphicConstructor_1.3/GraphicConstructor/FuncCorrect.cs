using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicConstructor
{
    class FuncCorrect
    {
        // символ - скобка?
        bool Skobka(char S)
        {
            if ((S == '(') || (S == ')')) return true;
            else return false;
        }
        // символ - операция?
        bool Operaz(char S)
        {
            if (Skobka(S) == false || S == '+' || S == '-' || S == '*' || S == '/' || S == '^')
                return true;
            else return false;
        }
        // символ - цифра?
        bool Zifra(char S)
        {
            if (S == '1' || S == '2' || S == '3' || S == '4' || S == '5' || S == '6' ||
                S == '7' || S == '8' || S == '9' || S == '0')
                return true;
            else return false;
        }
        // в данной функции под Str имеется в виду вся строка-функция
        // проверяет подстроку на тождество с Pi, Eps или abs, sqr, sqrt 
        bool Chislo(string Str)
        {
            int i = 0;
            string SubStr = "";
            for (i = 1; i <= Str.Length; i++)
            {
                // если Str[i] не цифра, не операция и не скобка
                if (Zifra(Str[i]) == false || Operaz(Str[i]) == false || Skobka(Str[i]) == false)
                {
                    // смотрим, число это (Pi, Eps) или операция (sqr,sqrt,abs)
                    // ясно, что нужно накопить строку, т.к. длина вышеперечисленных больше 1
                    SubStr += Str[i];
                    if (SubStr == "Pi" || SubStr == "Eps" ||
                        SubStr == "pi" || SubStr == "eps")
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        // Функция?
        bool Funct(string SubStr)
        {
            if (SubStr == "Sqr" || SubStr == "Sqrt" || SubStr == "Abs" ||
                SubStr == "sqr" || SubStr == "sqrt" || SubStr == "abs")
                return true;
            else
                return false;
        }
        // Число и функция или нет
        bool ChisloAndFunc(string Str)
        {
            if (Str == "Sqr" || Str == "Sqrt" || Str == "Abs" ||
                Str == "sqr" || Str == "sqrt" || Str == "abs" ||
                Str == "Pi" || Str == "Eps" ||
                Str == "pi" || Str == "eps")
                return true;
            else return false;
        }

        // в данной функции под Str имеется в виду вся строка-функция
        public bool GoodFunc(string Str)
        {
            int i = 0;
            string SubStr = "";
            for (i = 0; i <= Str.Length; i++)
            {
                // SubStr - для проверки на числа и функции (eps, abs и т.п.)
                SubStr += Str[i];

                // если сейчас '(', 
                if (Str[i] == '(')
                {
                    // то после неё символ '(', 'x', 0 ... 9, '*','/','+','-','^', eps, Pi
                    if (Str[i + 1] == '(' || Str[i + 1] == 'x' || Zifra(Str[i + 1]) == true || Operaz(Str[i + 1]) == true || ChisloAndFunc(SubStr) == true)
                    {
                        SubStr = "";
                        return true;
                    }
                    else
                        return false; //if (Str[i + 1] != '(' && Str[i + 1] != 'x' && Zifra(Str[i + 1]) == false && Operaz(Str[i + 1]) == false && ChisloAndFunc(SubStr) == false)
                }

                // если сейчас ')'  
                if (Str[i] == ')')
                {
                    // то после него символ ')','*','/','+','-','^' 
                    if (Str[i + 1] == ')' || Operaz(Str[i + 1]) == true || i == Str.Length)
                        return true;
                    else
                        return false;
                }

                // если сейчас 'x'
                if (Str[i] == 'x')
                {
                    // следующий символ ')','*','/','+','-','^'
                    if (Str[i + 1] == ')' || Operaz(Str[i + 1]) == true)
                        return true;
                    else
                        return false;
                }

                // если сейчас '*','/','+','-','^', 
                if (Operaz(Str[i]) == true)
                {
                    //то после '(', 'x', 0 ... 9, eps, Pi, sqrt, abs, sqr
                    if (Str[i + 1] == '(' || Str[i + 1] == 'x' || Zifra(Str[i + 1]) == true || ChisloAndFunc(SubStr) == true)
                    {
                        SubStr = "";
                        return true;
                    }
                    else
                        return false;
                }

                // если сейчас sqrt,sqr,abs
                if (Funct(SubStr) == true)
                {
                    // после только '('
                    if (Str[i + 1] == '(')
                    {
                        SubStr = "";
                        return true;
                    }
                    else
                        return false;
                }

                // если сейчас 0 ... 9 или eps, Pi,
                if (Zifra(Str[i]) == true || Chislo(SubStr) == true)
                {
                    if (Chislo(SubStr) == true)
                        SubStr = "";
                    // то после ')','*','/','+','-','^', конец строки
                    if (Str[i + 1] == ')' || Operaz(Str[i + 1]) == true || i == Str.Length)
                        return true;
                    else
                        return false;
                }
            }
            if (Str.IndexOf("(") != Str.IndexOf(")") || (Str.IndexOf("(") == 0 && Str.IndexOf(")") == 0))
            {
                return true;
            }
            else
            {
                return false;

            }
            return false;
        }
        
    }
}
