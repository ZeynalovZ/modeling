using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeling;

namespace Lab01
{
    enum tableType { top, info, bot}

    class configurationAxisMethod
    {
        public double x1 = 0;
        public double x2 = 0;
        public double h = 0;
        public configurationAxisMethod(double x1, double x2, double h)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.h = h;
        }
    }

    

    class Program
    {

        public static void printTable(tableType t, uint xValue)
        {
            ;
        }

        public static void pikardMethod(funcPointer func, uint approximation, configurationAxisMethod cnf)
        {
            // initialize polynom
            List<double> list1 = new List<double>(1) { 0 };
            Polynomial poly1 = new Polynomial(list1);
            poly1.printPolynomial();

            List<double> list2 = new List<double>(2) { 1, 0 };
            Polynomial poly2 = new Polynomial(list2);
            poly2.printPolynomial();

            Polynomial resPoly;

            for (uint i = 0; i < approximation; i++)
            {
                //Console.WriteLine("==========");
                //Console.WriteLine("Current approximation is " + approximation);
                resPoly = func(poly1, poly2);
                resPoly.integrate();
                resPoly.printPolynomial();
                poly1 = (Polynomial)resPoly.Clone();

                for (double j = cnf.x1; j < cnf.x2; j += cnf.h)
                {
                    double res = resPoly.computeResult(j, false);
                }
            }


        }

        public delegate Polynomial funcPointer(Polynomial u, Polynomial v);
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            funcPointer func = testFunction;
            //testDeligate(func);
            //List<double> list1 = new List<double>(6) { 1, 0, 1, -2, 0, 3 };
            //List<double> list2 = new List<double>(5) { 2, -3, 4, 0, -1 };
            List<double> list1 = new List<double>(1) { 0 };
            List<double> list2 = new List<double>(2) { 1, 0 };

            //var random = new Random();
            //for (int i = 0; i < 9; i++)
            //{
            //    list.Add(random.Next(206, 507) / 10);
            //}
            configurationAxisMethod config = new configurationAxisMethod(0, 2, 0.05);
            uint approximation = 3;
            pikardMethod(func, approximation, config);



            //Polynomial poly1 = new Polynomial(list1);
            //poly1.printPolynomial();
            //poly1.computeResult(2);

            ////poly1.integrate();
            ////poly1.printPolynomial();

            //Polynomial poly2 = new Polynomial(list2);
            //poly2.printPolynomial();

            //Polynomial resPoly = func(poly1, poly2);
            //resPoly.integrate();
            //resPoly.printPolynomial();

            //Polynomial p = poly1 + poly2;
            //p.printPolynomial();


            Console.ReadLine();

        }

        public static Polynomial testFunction(Polynomial u, Polynomial v)
        {
            return u * u + v * v;
        }

    }
}
