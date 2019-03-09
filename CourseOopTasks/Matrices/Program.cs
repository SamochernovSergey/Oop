using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(3, 5);
            Console.WriteLine(a);
            Matrix b = new Matrix(a);
            Console.WriteLine(b);
            double[,] z = new double[,]
            { {1, 2, 3, 4, 5, 6, 7},
              {0, 0, 1, 0, 0, 0, 0},
              {1, 1, 0, 2, 3, 9, 9},
              {1, 2, 3, 8, 9, 7, 6},
              {2, 3, 4, 5, 6, 7, 1} };
            Matrix c = new Matrix(z);
            Console.WriteLine(c);
            double[] p = { 1, 2, 3, 4, 5, 6, 7 };
            Vector v1 = new Vector(4, p);
            double[] o = { 0, 1, 0, 0, 0, 0 };
            Vector v2 = new Vector(4, o);
            double[] u = { 1, 1, 0, 2, 3, 9, 9 };
            Vector v3 = new Vector(3, u);
            double[] y = { 1, 2, 3, 8, 9, 7, 6 };
            Vector v4 = new Vector(y);
            double[] t = { 2, 3, 4, 5, 6, 7, 1 };
            Vector v5 = new Vector(t);
            Vector[] x = new Vector[7] { v1, v2, v3, v4, v5, v3, v3 };
            Matrix d = new Matrix(x);
            Console.WriteLine(d);
            Console.WriteLine(d.GetColumns());
            Console.WriteLine(d.GetRows());
            Console.WriteLine("GetVectorByIndex  1");
            Console.WriteLine(d.GetRowByIndex(1));
            d.SetRowByIndex(2, v5);
            Console.WriteLine(d);
            Console.WriteLine("GetColumnByIndex  2");
            Console.WriteLine(d.GetColumnByIndex(2));
            Console.WriteLine("оригинальная матрица");
            Console.WriteLine(d);
            d.Transpose();
            Console.WriteLine("перевернутая матрица");
            Console.WriteLine(d);
            /*Console.WriteLine("Умножение на скаляр 2");
            d.MultiplicationOnScalar(2);
            Console.WriteLine(d);
            double[,] f = new double[,]
            {{2, -1, 3, 2},
             {3, 1, 7, 0 },
             {-4, -1, 2, 1},
             {-6, 7, 1, -1 } };
            Matrix g = new Matrix(f);
            Console.WriteLine("Определитель матрицы = ");
            Console.WriteLine(g.GetDeterminant());            
            double[] l = new double[] { 2, 3, -1, 4 };
            Vector r = new Vector(l);            
            Console.WriteLine("MultiplicationOnVector");
            Console.WriteLine("матрица");
            Console.WriteLine(g);
            Console.WriteLine("вектор");
            Console.WriteLine(r);
            Console.WriteLine("Результат");
            Console.WriteLine(g.MultiplicationOnVector(r));

            double[,] mu1 = new double[,]
            { {1, 2, 2},
              {3, 1, 1} };

            double[,] mu2 = new double[,]
            { {4, 2},
              {3, 1},
              {1, 5} };            
            Matrix mul1 = new Matrix(mu1);
            Matrix mul2 = new Matrix(mu2);
            Console.WriteLine("Умножение матриц");
            Console.WriteLine("матрица 1 {0}", mul1);
            Console.WriteLine("матрица 2 {0}", mul2);
            Console.WriteLine(Matrix.Multiplication(mul1, mul2));*/
        }
    }
}