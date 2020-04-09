using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchSchemaODU
{
    public class Research
    {
        static double Kx(double x, SchemaDataMethod data)
        {
            double k0 = data.k0;
            double kn = data.kN;
            double l = data.L;
            double b = (kn * l) / (kn - k0);
            double a = -b * k0;
            return a / (x - b);
        }

        static double Alphax(double x, SchemaDataMethod data)
        {
            double a0 = data.alpha0;
            double an = data.alphaN;
            double l = data.L;
            double d = an * l / (an - a0);
            double c = -a0 * d;
            return c / (x - d);
        }

        static double P(double x, SchemaDataMethod data)
        {
            return 2 * Alphax(x, data) / data.R;
        }

        static double F(double x, SchemaDataMethod data)
        {
            return 2 * data.t0 * Alphax(x, data) / data.R;
        }

        static double KHIminus12(double x, SchemaDataMethod data)
        {
            return (2 * Kx(x, data) * Kx(x - data.h, data) / (Kx(x, data) + Kx(x - data.h, data)));
        }
        static double KHIplus12(double x, SchemaDataMethod data)
        {
            return (2 * Kx(x, data) * Kx(x + data.h, data) / (Kx(x, data) + Kx(x + data.h, data))); ;
        }

        static public SchemaDataMethod coumputeResult(SchemaDataMethod data)
        {
            double h = 1e-3;
            data.h = h;
            List<double> An = new List<double>();
            List<double> Bn = new List<double>();
            List<double> Cn = new List<double>();
            List<double> Dn = new List<double>();
            List<double> KSIn = new List<double>();
            List<double> ETAn = new List<double>();

            double xBegin = 0;

            double KHI12 = KHIplus12(xBegin, data);

            //Левые краевые
            double p0 = P(xBegin, data);
            double p1 = P(xBegin + h, data);
            double p12 = (p0 + p1) / 2;

            double f0 = F(xBegin, data);
            double f1 = F(xBegin + data.h, data);
            double f12 = (f0 + f1) / 2;

            double K0 = KHI12 + h * h * p12 / 8 + h * h * p0 / 4;
            double M0 = -KHI12 + h * h * p12 / 8;
            double P0 = h * data.F0 + h * h * (f12 + f0) / 4;

            // Правые краевые
            KHI12 = KHIminus12(data.L, data);

            double pn = P(data.L, data);
            double pn1 = P(data.L - h, data);
            double pn12 = (pn + pn1) / 2;

            double fn = F(data.L, data);
            double fn1 = F(data.L - data.h, data);
            double fn12 = (fn + fn1) / 2;
            
            double Kn = -KHI12 - data.alphaN * h - h * h * pn12 / 8 - h * h * pn / 4;
            double Mn = KHI12 - h * h * p12 / 8;
            double Pn = -data.alphaN * data.t0 * h - h * h * (fn12 + fn) / 4;

            // Коэффициенты

            for (double x = xBegin; x < data.L; x += h)
            {
                double A = KHIplus12(x, data) / h;
                double C = KHIminus12(x, data) / h;
                double B = A + C + P(x, data) * h;
                double D = F(x, data) * h;

                An.Add(A);
                Cn.Add(C);
                Bn.Add(B);
                Dn.Add(D);
            }

            double KSI = -M0 / K0;
            double ETA = P0 / K0;
            KSIn.Add(KSI);
            ETAn.Add(ETA);
            // may be from 1
            for (int i = 1; i < An.Count() - 1; i++)
            {
                double KSI1 = Cn[i] / (Bn[i] - An[i] * KSI);
                double ETA1 = (Dn[i] + An[i] * ETA) / (Bn[i] - An[i] * KSI);
                KSIn.Add(KSI1);
                ETAn.Add(ETA1);
                KSI = KSI1;
                ETA = ETA1;
            }

            // Обратный ход
            
            double yn = (Pn - Mn * ETA) / (Kn + Mn * KSI);
            data.list1.Add(data.L, yn);
            double j = 1;
            for (int i = An.Count() - 2; i >= 0; i--)
            {
                yn = KSIn[i] * yn + ETAn[i];
                data.list1.Add(xBegin + i * h, yn);
                j++;
            }
            data.list1.Sort();


            return data;
        }
    }
}
