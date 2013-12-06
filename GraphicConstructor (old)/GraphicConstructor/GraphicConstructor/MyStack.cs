using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicConstructor
{
    class MyStack
    {
        char[] stck; //массив для хранения данных стека
        int tos;     // индекс вершины стека
        
        // создание стека
        public MyStack (int size)
        {
            stck = new char[size];//выделяем память для стека
            tos = 0;
        }

        // заполнение стека
        public void push(char ch)
        {
            if (tos == stck.Length)
            {
                MessageBox.Show("Стек заполнен");
                return;
            }

            stck[tos] = ch;
            tos++;
        }

        // извлечение символа из стека
        public char pop()
        {
            if (tos == 0)
            {
                MessageBox.Show("Стек пуст");
                return (char) 0;
            }

            tos--;
            return stck[tos];
        }

        // возвращает true, если стек полон
        public bool full()
        {
            return tos == stck.Length;
        }

        // возвращает true, если стек пуст
        public bool empty()
        {
            return tos == 0;
        }

        // возвращает объем стека
        public int capacity()
        {
            return stck.Length;
        }

        // возвращает текущее количество объектов в стеке
        public int getNum()
        {
            return tos;
        }
    }
}
