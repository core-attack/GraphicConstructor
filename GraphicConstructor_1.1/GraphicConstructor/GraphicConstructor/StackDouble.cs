using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicConstructor
{
    class StackDouble
    {
        public void Push(double x)
        {
            if (size < arr.Length)
            {
                arr[size] = x;
                size++;
            }
        }
        public double Pop()
        {
            if (size > 0)
            {
                size--;
                return arr[size];
            }
            return 0;
        }
        public int Count
        {
            get { return size; }
        }
        public double Top
        {
            get
            {
                if (size <= 0)
                    return 0;
                return arr[size - 1];
            }
        }
        public double ItemAt(int indX)
        {
            if (indX < 0 || indX >= size)
                return 0;
            return arr[indX];
        }
        public void Clear()
        {
            size = 0;
        }
        double[] arr = new double[1000];
        int size = 0;
    }
}
