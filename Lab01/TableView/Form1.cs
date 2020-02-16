using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modeling;

namespace TableView
{

    

    public class configurationAxisMethod
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
    public delegate Polynomial funcPointerPoly(Polynomial u, Polynomial v);
    public delegate double funcPointer(double u, double v);
    public partial class Form1 : Form
    {

        public const int explicitOffset = 0;
        public const int implictOffset = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void pikardMethod(funcPointerPoly func, uint approximation, configurationAxisMethod cnf)
        {
            string resStringOfPolynoms = "";
            // initialize polynom
            List<double> list1 = new List<double>(1) { 0 };
            Polynomial poly1 = new Polynomial(list1);
            //poly1.printPolynomial();
            resStringOfPolynoms += poly1.printPolynomial() + "  == Это первый полином" + Environment.NewLine;

            List<double> list2 = new List<double>(2) { 1, 0 };
            Polynomial poly2 = new Polynomial(list2);
            resStringOfPolynoms += poly2.printPolynomial() + "  == Это второй полином" + Environment.NewLine;

            textBox1.Text = resStringOfPolynoms;

            Polynomial resPoly;


            for (uint i = 0; i <= approximation; i++)
            {
                //Console.WriteLine("==========");
                //Console.WriteLine("Current approximation is " + approximation);
                resPoly = func(poly1, poly2);
                resPoly.integrate();
                resPoly.printPolynomial();
                poly1 = (Polynomial)resPoly.Clone();

                int begin = 0;
                for (double j = cnf.x1; j < cnf.x2; j += cnf.h)
                {
                    double res = resPoly.computeResult(j, false);
                    dataGridView1.Rows[begin].HeaderCell.Value = j.ToString();
                    dataGridView1.Rows[begin].Cells[(int)i].Value = res;
                    begin++;
                }
            }
        }

        private void explicitMethod(uint approximation, funcPointer func, configurationAxisMethod cnf)
        {
            double yn = 0;
            double yn1 = 0;
            int tableBegin = 0;
            for (double i = cnf.x1; i < cnf.x2; i += cnf.h)
            {
                dataGridView1.Rows[tableBegin].Cells[(int)approximation + explicitOffset].Value = yn;
                yn1 = yn + cnf.h * func(yn, i);
                yn = yn1;
                tableBegin++;
            }
        }

        private void implicitMethod(uint approximation, funcPointer func, configurationAxisMethod cnf)
        {
            double yn = 0;
            double yn1 = 0;
            int tableBegin = 0;
            double x1 = cnf.x1;
            double x2 = cnf.x2;
            double h = cnf.h;
            for (double i = cnf.x1; i < cnf.x2; i += cnf.h)
            {
                dataGridView1.Rows[tableBegin].Cells[(int)approximation + implictOffset].Value = yn;
                yn1 = 1 / (2 * h) - Math.Sqrt(1 / (4 * h * h) - yn / h - Math.Pow(i + h, 2));
                
                yn = yn1;
                tableBegin++;
            }
        }

        

        private void fillTable(uint approximationCount)
        {
            
            dataGridView1.Rows[0].HeaderCell.Value = "X";
            for (uint i = 0; i < approximationCount; i++)
            {
                dataGridView1.Columns[(int)i].Width = 150;
                dataGridView1.Columns[(int)i].HeaderCell.Value = "приближение " + (i + 1);
            }
            dataGridView1.Columns[(int)approximationCount + explicitOffset].Width = 150;
            dataGridView1.Columns[(int)approximationCount + implictOffset].Width = 150;
            dataGridView1.Columns[(int)approximationCount + explicitOffset].HeaderCell.Value = "явный метод";
            dataGridView1.Columns[(int)approximationCount + implictOffset].HeaderCell.Value = "неявный метод";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x1 = 0;
            double x2 = 3;
            double h = 0.0001;
            uint approximation = 4;

            int tableHeight = (int)((x2 - x1) / h);
            int tableWidth = 3 + (int)approximation;

            dataGridView1.RowCount = tableHeight + 1 ;
            dataGridView1.ColumnCount = tableWidth;

            fillTable(approximation);

            funcPointerPoly funcPoly = testFunctionPoly;
            funcPointer func = testFunction;
            List<double> list1 = new List<double>(1) { 0 };
            List<double> list2 = new List<double>(2) { 1, 0 };
            configurationAxisMethod config = new configurationAxisMethod(x1, x2, h);
            


            pikardMethod(funcPoly, approximation, config);

            explicitMethod(approximation,func, config);

            implicitMethod(approximation, func, config);
            

            Polynomial poly = new Polynomial(list2);
            string res = poly.printPolynomial();
            //textBox1.Text = res;
        }

        
        public static Polynomial testFunctionPoly(Polynomial u, Polynomial v)
        {
            return u * u + v * v;
        }

        public static double testFunction(double u, double v)
        {
            return u * u + v * v;
        }

    }
}
