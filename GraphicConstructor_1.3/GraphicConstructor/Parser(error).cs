using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicConstructor
{
    class ParserException : ApplicationException
    {
        public ParserException(string str) : base(str) { }

        public override string ToString()
        {
            return Message;
        }
    }
    class Parser // вариант без переменных (точнее с недоработанными переменными)
    {
        // перечисляем типы лексем
        enum Types { NONE, DELIMITER /*разделитель*/, VARIABLE, FUNCTION, NUMBER};
        // перечисляем типы ошибок
        enum Errors { SYNTAX, UNBALPARENTS, NOEXP, DIVBYZERO };

        string exp; // ссылка на строку выражения
        int expIdx; // текущий индекс в выражении
        string token; // текущая лексема
        //string nextToken; // следующая лексема
        Types tokType; // тип лексемы
        double minValue; // левое значение интервала, для значения х по умолчанию 
        
        // входная точка анализатора
        public double Evaluate(string expstr)
        {
            double result;

            exp = expstr;
            expIdx = 0;

            try
            {
                GetToken();
                if (token == "")
                {
                    SyntaxErr(Errors.NOEXP); // выражение отсутствует

                    return 0.0;
                }

                EvalExp2(out result);

                if (token != "") // последняя лексема должна быть null-значением
                    SyntaxErr(Errors.SYNTAX);

                return result;
            }
            catch (ParserException exc)
            {
                // при необходимости обработку других ошибок добавлять сюда
                MessageBox.Show(exc.Message);

                return 0.0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
                return 0.0;
            }
        }
        
        // Сложение или вычитание двух членов выражения
        void EvalExp2(out double result)
        {
            string op;
            double partialResult;

            EvalExp3(out result);
            while ((op = token) == "+" || op == "-")
            {
                GetToken();
                EvalExp3(out partialResult);
                switch (op)
                {
                    case "-":
                        result = result - partialResult;
                        break;
                    case "+":
                        result = result + partialResult;
                        break;
                }
            }
        }

        // умножение или деление двух множителей
        void EvalExp3(out double result)
        {
            string op;
            double partialResult = 0.0;

            EvalExp4(out result);
            while ((op = token) == "*" || op == "/" || op == "%")
            {
                GetToken();
                EvalExp4(out partialResult);
                switch (op)
                {
                    case "*":
                        result = result * partialResult;
                        break;
                    case "/":
                        if (partialResult == 0.0)
                            SyntaxErr(Errors.DIVBYZERO);
                        result = result / partialResult;
                        break;
                    case "%":
                        if (partialResult == 0.0)
                            SyntaxErr(Errors.DIVBYZERO);
                        result = (int)result % (int)partialResult;
                        break;
                }
            }
        }

        // возведение в степень
        void EvalExp4(out double result)
        {
            double partialResult, ex;
            int t;

            EvalExp5(out result);
            if (token == "^")
            {
                GetToken();
                EvalExp4(out partialResult);
                ex = result;
                if (partialResult == 0.0)
                {
                    result = 1.0;
                    return;
                }
                for (t = (int)partialResult - 1; t > 0; t--)
                    result = result * (double)ex;
            }
        }

        // выполнение операции унарного + или -
        void EvalExp5(out double result)
        {
            string op;

            op = "";
            if (
                   ((tokType == Types.DELIMITER) && token == "+" || token == "-")
                ||
                   ((tokType == Types.FUNCTION) && token == "Sin" || token == "Cos" ||
                   token == "Tan" ||  token == "Sqrt" || token == "Arcsin" || 
                   token == "Arccos" || token == "Arctan" || token == "Cosh" || 
                   token == "Sinh" || token == "Tanh" || token == "Log" || token == "Ln" ||
                   token == "Truncate" || token == "Exp" || token == "e" || token == "Pi" 
                   //|| token == "x"
                   )
                )
            {
                op = token;
                GetToken();
            }
            if (tokType != Types.VARIABLE)
            {
                EvalExp6(out result);

                if (op == "-")
                    result = -result;
                if (op == "Sin")
                    result = Math.Sin(result);
                if (op == "Cos")
                    result = Math.Cos(result);
                if (op == "Tan")
                    result = Math.Tan(result);
                if (op == "Sqrt")
                    result = Math.Sqrt(result);
                if (op == "Arccos")
                    result = Math.Acos(result);
                if (op == "Arcsin")
                    result = Math.Asin(result);
                if (op == "Arctan")
                    result = Math.Atan(result);
                if (op == "Cosh")
                    result = Math.Cosh(result);
                if (op == "Sinh")
                    result = Math.Sinh(result);
                if (op == "Tanh")
                    result = Math.Tanh(result);
                if (op == "Log")
                    result = Math.Log(result);
                if (op == "Ln")
                    result = Math.Log10(result);
                if (op == "Truncate")
                    result = Math.Truncate(result);
                if (op == "Exp")
                    result = Math.Exp(result);
                if (op == "e")
                    result = Math.E;
                if (op == "Pi")
                    result = Math.PI;
                if (op == "Abs")
                    result = Math.Abs(result);
            }
            else
            {
                //Parser P = new Parser();
                //P.Evaluate();
                result = minValue;
            }
            //if (op == "x")
                //result = 0; // в случае переменной возвращаем левую границу области определния

        }

        // обработка выражения в круглых скобках
        void EvalExp6(out double result)
        {
            if ((token == "("))
            {
                GetToken();
                EvalExp2(out result);
                if (token != ")")
                    SyntaxErr(Errors.UNBALPARENTS);
                GetToken();
            }
            else
                Atom(out result);
        }

        // получаем значение числа
        void Atom(out double result)
        {
            switch (tokType)
            {
                case Types.NUMBER:
                    try
                    {
                        result = Double.Parse(token);
                    }
                    catch (FormatException)
                    {
                        result = 0.0;
                        SyntaxErr(Errors.SYNTAX);
                    }
                    GetToken();
                    return;
                
                default:
                    result = 0.0;
                    SyntaxErr(Errors.SYNTAX);
                    break;
            }
        }

        // обрабатываем синтаксическую ошибку
        void SyntaxErr(Errors error)
        {
            string[] err = 
            {
                "Синтаксическая ошибка",
                "Дисбаланс скобок",
                "Выражение отсутствует",
                "Деление на нуль"
            };

            throw new ParserException(err[(int)error]);
        }

        // получаем следующую лексему
        void GetToken()
        {
            tokType = Types.NONE;
            token = "";

            if (expIdx == exp.Length) 
                return; // конец выражения

            // пропускаем пробелы
            while (expIdx < exp.Length && Char.IsWhiteSpace(exp[expIdx])) ++expIdx;

            // хвостовой пробел завершает выражение
            if (expIdx == exp.Length) 
                return;

            if (IsDelim(exp[expIdx])) // это оператор?
            {
                token += exp[expIdx];
                expIdx++;
                tokType = Types.DELIMITER;
            }
            else if (Char.IsLetter(exp[expIdx])) // это переменная или функция?
            {
                while (!IsDelim(exp[expIdx]))
                {
                    token += exp[expIdx];
                    expIdx++;
                    if (expIdx >= exp.Length)
                        break;
                }
                if (token != "Sin" && token != "Cos" && token != "Tan" && token != "Sqrt" && token != "Abs" &&
                    token != "Arcsin" && token != "Arccos" && token != "Arctan" && token != "Sinh" && token != "Cosh" &&
                    token != "Tanh" && token != "Exp" && token != "Pi" && token != "e" && token != "Truncate" &&
                    token != "Log" && token != "Ln" && 
                    token == "x") // пока пусть будет ограничение это
                    tokType = Types.VARIABLE;
                else 
                    tokType = Types.FUNCTION;
            }
            else if (Char.IsDigit(exp[expIdx])) // это число?
            {
                while (!IsDelim(exp[expIdx]))
                {
                    token += exp[expIdx];
                    expIdx++;
                    if (expIdx >= exp.Length)
                        break;
                }
                tokType = Types.NUMBER;
            }
        }

        // метод возвращает значение true, если символ с является разделителем
        bool IsDelim(char c)
        {
            if ((" +-/*%^=()".IndexOf(c) != -1))
                return true;
            return false;
        }

        
    }
}
