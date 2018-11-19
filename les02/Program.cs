using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace les02
{
    abstract class TableFun
    {
        public abstract double F(double x);
        public void Table(double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
    }
    class SimpleFun : TableFun
    {
        public override double F(double x)
        {
            return x * x;
        }
    }
    class SinFun : TableFun
    {
        public override double F(double x)
        {
            return Math.Sin(x);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TableFun a = new SinFun();
            Console.WriteLine("Таблица функции Sin:");
            a.Table(-2, 2);
            a = new SimpleFun();
            Console.WriteLine("Таблица функции Simple:");
            a.Table(0, 3);
        }
    }

}
