using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicConstructor
{
    class Function
    {
        public void SetFunc(string f)
        {
            StackString op = new StackString();
            stack.Clear();

            if (String.IsNullOrEmpty(f))
                return;

            f = f.ToLower();
            f = f.Replace(" ", "");

            //перебрать все символы строки
            for (int i = 0; i < f.Length; i++)
            {
                //извлечь подстроку
                string element = f[i].ToString();
                if (IsArg(f[i].ToString()))
                {
                    while (true)
                    {
                        if (i + 1 >= f.Length)
                            break;
                        char c = f[i + 1];
                        if (IsArg(c.ToString()))
                        {
                            element += c;
                            i++;
                        }
                        else
                            break;
                    }
                }
                
                //обработать подстроку
                if (IsArg(element))
                {
                    if (IsFunc(element))
                        op.Push(element);
                    else
                        stack.Push(element);
                }
                else if (element == "(")
                    op.Push(element);
                else if (element == ")")
                {
                    while (op.Top != "(" && op.Count > 0)
                        stack.Push(op.Pop());
                    if (op.Top == "(")
                        op.Pop();
                }
                else
                {
                    int p = Priority(element);
                    while (Priority(op.Top) > p && op.Count > 0)
                        stack.Push(op.Pop());
                    op.Push(element);
                }
            }

            //добираем остаток
            while (op.Count > 0)
                stack.Push(op.Pop());
        }

        public double Calc(double x)
        {
            StackDouble nbr = new StackDouble();

            for (int i = 0; i < stack.Count; i++)
            {
                string element = stack.ItemAt(i);
                if (IsArg(element) && !IsFunc(element))
                {
                    if (element == "x")
                        nbr.Push(x);
                    else
                    {
                        try
                        {
                            nbr.Push(double.Parse(element));
                        }
                        catch
                        {
                            nbr.Push(0);
                        }
                        
                    }
                }
                else
                {
                    try
                    {
                        element = element.ToLower();
                        switch (element)
                        {
                            case "exp":
                                {
                                    nbr.Push(Math.E);
                                    break;
                                }
                            case "pi":
                                {
                                    nbr.Push(Math.PI);
                                    break;
                                }
                            case "sqrt":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Sqrt(arg));
                                    break;
                                }
                            case "arctg":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Atan(arg));
                                    break;
                                }
                            case "arcsin":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Asin(arg));
                                    break;
                                }
                            case "arccos":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Acos(arg));
                                    break;
                                }
                            case "th":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Tanh(arg));
                                    break;
                                }
                            case "sh":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Sinh(arg));
                                    break;
                                }
                            case "ch":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Cosh(arg));
                                    break;
                                }
                            case "ln":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Log10(arg));
                                    break;
                                }
                            case "log":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Log(arg));
                                    break;
                                }
                            case "trunc":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Truncate(arg));
                                    break;
                                }
                            case "tg":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Tan(arg));
                                    break;
                                }
                            case "sin":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Sin(arg));
                                    break;
                                }
                            case "cos":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Cos(arg));
                                    break;
                                }
                            case "abs":
                                {
                                    double arg = nbr.Pop();
                                    nbr.Push(Math.Abs(arg));
                                    break;
                                }
                            case "+":
                                {
                                    double arg2 = nbr.Pop();
                                    double arg1 = nbr.Pop();
                                    nbr.Push(arg1 + arg2);
                                    break;
                                }
                            case "-":
                                {
                                    double arg2 = nbr.Pop();
                                    double arg1 = nbr.Pop();
                                    nbr.Push(arg1 - arg2);
                                    break;
                                }
                            case "*":
                                {
                                    double arg2 = nbr.Pop();
                                    double arg1 = nbr.Pop();
                                    nbr.Push(arg1 * arg2);
                                    break;
                                }
                            case "/":
                                {
                                    double arg2 = nbr.Pop();
                                    double arg1 = nbr.Pop();
                                    nbr.Push(arg1 / arg2);
                                    break;
                                }
                            case "^":
                                {
                                    double arg2 = nbr.Pop();
                                    double arg1 = nbr.Pop();
                                    nbr.Push(Math.Pow(arg1, arg2));
                                    break;
                                }
                        }
                    }
                    catch
                    {
                        nbr.Push(0);
                    }
                }
            }

            return nbr.Top;
        }

        bool IsArg(string element)
        {
            if
            (
                element != "," &&
                element != "+" &&
                element != "-" &&
                element != "*" &&
                element != "/" &&
                element != "^" &&
                element != "(" &&
                element != ")"
            )
                return true;

            return false;
        }

        bool IsFunc(string element)
        {
            if
            (
                element == "exp"    ||
                element == "pi"     ||
                element == "sqrt"   ||
                element == "arctg"  ||
                element == "arcsin" ||
                element == "arccos" ||
                element == "th"     ||
                element == "sh"     ||
                element == "ch"     ||
                element == "ln"     ||
                element == "log"    ||
                element == "trunc"  ||
                element == "tg"     ||
                element == "sin"    ||
                element == "cos"    ||
                element == "abs"
            )
                return true;

            return false;
        }

        int Priority(string element)
        {
            if (element == ",")
                return 0;
            if (element == "+" || element == "-")
                return 1;
            if (element == "*" || element == "/")
                return 2;
            if (element == "^")
                return 3;

            return 100;
        }

        StackString stack = new StackString();
    }
}
