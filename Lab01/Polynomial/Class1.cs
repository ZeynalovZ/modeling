using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling
{
    public class Polynomial : ICloneable
    {
        private List<double> polynom;
        private int polynomSize = 0;
        public Polynomial(int Size)
        {
            polynom = new List<double>(polynomSize);
            polynomSize = Size;
        }

        public Polynomial(List<double> polyCoeff)
        {
            polynomSize = polyCoeff.Count;

            polynom = new List<double>();

            for (int i = 0; i < polynomSize; i++)
            {
                polynom.Add(polyCoeff[i]);
            }

        }

        public object Clone()
        {
            Polynomial poly = new Polynomial(polynomSize);
            for (int i = 0; i < polynomSize; i++)
            {
                poly.polynom.Add(polynom[i]);
            }
            return poly;
        }

        public double computeResult(double xValue, bool printResult)
        {
            double res = 0;
            int size = polynomSize;
            if (size <= 0)
            {
                Console.WriteLine("argument couldnt be less or equal than zero");
            }
            else
            {
                for (int i = 0; i < size - 1; i++)
                {
                    res += polynom[i] * Math.Pow(xValue, size - i - 1);
                }
                res += polynom[size - 1];
            }
            if (printResult == true)
            {
                Console.WriteLine("P(" + xValue + ") = " + res);
            }
            return res;
        }
        //public static Polynomial operator +(Polynomial polynom1, Polynomial polynom2)
        //{
        //    int size1 = polynom1.polynomSize;
        //    int size2 = polynom2.polynomSize;
        //}

        public string printPolynomial()
        {
            string resultPolynomialString = "";
            if (this.polynomSize != 0)
            {
                int size = this.polynomSize;
                
                for (int i = 0; i < size; i++)
                {
                    if (polynom[i] != 0)
                    {
                        if (i != 0 && polynom[i] != 0)
                            if (polynom[i] > 0)
                                resultPolynomialString += " + ";
                            else
                                resultPolynomialString += " ";
                        if (polynom[i] != 0)
                            resultPolynomialString += polynom[i];

                        if (size - i - 1 != 0)
                        {
                            resultPolynomialString += "x";
                            resultPolynomialString += degreeToSingleSymbols((size - i - 1));
                        }
                    }

                }
                //Console.WriteLine("__________________________");
                //Console.WriteLine(resultPolynomialString);
                
            }
            return resultPolynomialString;
        }

        public string degreeToSingleSymbols(int num)
        {
            string res = "";
            string tmp = "";
            while (num != 0)
            {
                tmp += returnDegreeSymbol(num % 10);
                num /= 10;
            }
            // string reversing // tmp = source // res = result
            for (int i = tmp.Length - 1; i >= 0; i--)
            {
                res += tmp[i];
            }
            return res;
        }
        private string returnDegreeSymbol(int symbol)
        {
            string res = "";
            if (symbol < 10 && symbol >= 0)
            {

                switch (symbol)
                {
                    case 0:
                        res = "\u2070";
                        break;
                    case 1:
                        res = "\u00b9";
                        break;
                    case 2:
                        res = "\u00b2";
                        break;
                    case 3:
                        res = "\u00b3";
                        break;
                    case 4:
                        res = "\u2074";
                        break;
                    case 5:
                        res = "\u2075";
                        break;
                    case 6:
                        res = "\u2076";
                        break;
                    case 7:
                        res = "\u2077";
                        break;
                    case 8:
                        res = "\u2078";
                        break;
                    case 9:
                        res = "\u2079";
                        break;
                    default:
                        res = "error occured";
                        break;
                }

            }
            return res;
        }

        public static Polynomial operator +(Polynomial poly1, Polynomial poly2)
        {
            Polynomial poly;
            int size1 = poly1.polynomSize;
            int size2 = poly2.polynomSize;
            if (size1 != 0 && size2 != 0)
            {
                int resSize = (size1 > size2) ? size1 : size2;
                poly = new Polynomial(resSize);
                int poly1Index = size1 - 1;
                int poly2Index = size2 - 1;
                for (int i = 0; i < resSize; i++)
                {
                    double currentIterPolyRes = 0;
                    if (poly1Index >= 0)
                    {
                        currentIterPolyRes += poly1.polynom[poly1Index];
                        poly1Index--;
                    }
                    if (poly2Index >= 0)
                    {
                        currentIterPolyRes += poly2.polynom[poly2Index];
                        poly2Index--;
                    }
                    poly.polynom.Insert(0, currentIterPolyRes);
                }
            }
            else
            {
                throw new Exception("sizes couldnt be equals to zero");
            }

            return poly;
        }
        public static Polynomial operator -(Polynomial poly1, Polynomial poly2)
        {
            Polynomial poly;
            int size1 = poly1.polynomSize;
            int size2 = poly2.polynomSize;
            if (size1 != 0 && size2 != 0)
            {
                int resSize = (size1 > size2) ? size1 : size2;
                poly = new Polynomial(resSize);
                int poly1Index = size1 - 1;
                int poly2Index = size2 - 1;
                for (int i = 0; i < resSize; i++)
                {
                    double currentIterPolyRes = 0;
                    if (poly1Index >= 0)
                    {
                        currentIterPolyRes += poly1.polynom[poly1Index];
                        poly1Index--;
                    }
                    if (poly2Index >= 0)
                    {
                        currentIterPolyRes -= poly2.polynom[poly2Index];
                        poly2Index--;
                    }
                    poly.polynom.Insert(0, currentIterPolyRes);
                }
            }
            else
            {
                throw new Exception("sizes couldnt be equals to zero");
            }

            return poly;
        }

        public void integrate()
        {
            int size = polynomSize;
            int degree = size - 1;
            if (size != 0)
            {
                for (int i = 0; i < size; i++)
                {
                    if (polynom[i] != 0)
                        polynom[i] = polynom[i] / (degree + 1);
                    degree--;
                }
                polynom.Add(0);
                polynomSize += 1;
            }
        }

        public static Polynomial operator *(Polynomial poly1, Polynomial poly2)
        {
            Polynomial resPoly;
            int size1 = poly1.polynomSize;
            int size2 = poly2.polynomSize;
            int resSize = size1 + size2 - 1;
            List<double> resList = new List<double>(resSize);
            for (int i = 0; i < resSize; i++)
            {
                resList.Add(0);
            }
            if (size1 != 0 && size2 != 0)
            {
                int poly1Index = size1 - 1;
                int poly2Index = size2 - 1;
                double buff = 0;
                for (int i = 0; i < size1; i++)
                {
                    for (int j = 0; j < size2; j++)
                    {
                        buff = 0;
                        buff = poly1.polynom[i] * poly2.polynom[j];
                        if (buff != 0)
                        {
                            resList[i + j] += buff;
                        }
                        else
                            continue;
                    }
                }
                resPoly = new Polynomial(resList);
            }
            else
            {
                throw new Exception("sizes couldnt be equals to zero");
            }

            return resPoly;
        }
    }
}
