using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicConstructor
{
    class StackString
    {
        public void Push(string str)
        {
            if (size < arr.Length)
            {
                arr[size] = str;
                size++;
            }
        }
        public string Pop()
        {
            if (size > 0)
            {
                size--;
                return arr[size];
            }
            return "";
        }
        public int Count
        {
            get { return size; }
        }
        public string Top
        {
            get
            {
                if (size <= 0)
                    return "";
                return arr[size - 1];
            }
        }
        public string ItemAt(int indX)
        {
            if (indX < 0 || indX >= size)
                return "";
            return arr[indX];
        }
        public void Clear()
        {
            size = 0;
        }
        string[] arr = new string[100];
        int size = 0;
    }
}
