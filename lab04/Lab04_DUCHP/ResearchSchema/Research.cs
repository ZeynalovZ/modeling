using System;
using System.Collections.Generic;
using System.Linq;
using ZedGraph;

namespace ResearchSchema
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

        static public double calculateK(double T, SchemaDataMethod data)
        {
            return data.a1 * (data.b1 + data.c1 * Math.Pow(T, data.m1));
        }

        static public double calculateC(double T, SchemaDataMethod data)
        {
            //return data.a2 + data.b2 * Math.Pow(T, data.m2) - data.c2 / (T * T);
            return 0;
        }

        static double KHIminus12(double x, SchemaDataMethod data)
        {
            return (2 * Kx(x, data) * Kx(x - data.h, data) / (Kx(x, data) + Kx(x - data.h, data)));
        }
        static double KHIplus12(double x, SchemaDataMethod data)
        {
            return (2 * Kx(x, data) * Kx(x + data.h, data) / (Kx(x, data) + Kx(x + data.h, data))); ;
        }
        static double CalcKHI(double T1, double T2, SchemaDataMethod data)
        {
            double k1 = calculateK(T1, data);
            double k2 = calculateK(T2, data);

            return 2 * k1 * k2 / (k1 + k2);
        }
        

        static public List<PointPairList> computeResult(SchemaDataMethod data)
        {
            double tau = 1e-1;
            data.h = 1e-3;
            double N = (int)(data.L / data.h) + 1;
            List<PointPairList> res = new List<PointPairList>();
            PointPairList curr = new PointPairList();
            PointPairList prev = new PointPairList();
            PointPairList currIter = new PointPairList();
            PointPairList prevIter = new PointPairList();
            for (int i = 0; i < N; i++)
            {
                curr.Add(0 + i * data.h, data.t0);
            }
            res.Add(curr);

            double eps = 1e-3;
            double t = 0;
            double tmp1 = 0;
            do
            {
                prev = curr;
                currIter = prev;
                do
                {
                    prevIter = currIter;
                    var tmp = ComputeT(data, prev, prevIter, tau, t);
                    currIter = tmp;
                    tmp1 = calcDiff(currIter, prevIter);
                }
                while (tmp1 > eps);
                curr = currIter;
                
                res.Add(curr);
                t += tau;
                tmp1 = calcDiff(curr, prev);
            }
            
            while (tmp1 > eps);

            return res;
        }

        static public double calcDiff(PointPairList curr, PointPairList prev)
        {
            List<double> diff = new List<double>();
            for (int i = 0; i < curr.Count; i++)
            {
                diff.Add(Math.Abs((curr[i].Y - prev[i].Y) / curr[i].Y));
            }
            return diff.Max();
        }

        static public PointPairList ComputeT(SchemaDataMethod data, PointPairList list, PointPairList listPrev, double tau, double t)
        {
            //if (t > tau * 400)
             //   data.F0 = 0;
            double h = data.h;
            double xBegin = 0;
            int N = (int)(data.L / data.h) + 1;
            List<double> An = new List<double>(N);
            List<double> Bn = new List<double>(N);
            List<double> Cn = new List<double>(N);
            List<double> Dn = new List<double>(N);
            List<double> KSIn = new List<double>(N);
            List<double> ETAn = new List<double>(N);



            double KHI12 = CalcKHI(listPrev[0].Y, listPrev[1].Y, data);
            //double KHI12 = KHIplus12(xBegin, data);
            //Левые краевые
            double p0 = P(xBegin, data);
            double p1 = P(xBegin + h, data);
            double p12 = (p0 + p1) / 2;

            double f0 = F(xBegin, data);
            double f1 = F(xBegin + data.h, data);
            double f12 = (f0 + f1) / 2;

            double c0 = calculateC(listPrev[0].Y, data);
            double c1 = calculateC(listPrev[1].Y, data);
            double c12 = (c0 + c1) / 2;

            double K0 = h / 8 * c12 + h / 4 * c0 + KHI12 * tau / h + tau * h / 8 * p12 + tau * h / 4 * p0;
            double M0 = h / 8 * c12 - KHI12 * tau / h + tau * h / 8 * p12;
            double P0 = h / 8 * c12 * (list[0].Y + list[1].Y) + h / 4 * c0 * list[0].Y + data.F0 * tau 
                + tau * h / 4 *  (f12 + f0);

            // Правые краевые
            KHI12 = CalcKHI(listPrev[listPrev.Count - 2].Y, listPrev[listPrev.Count - 1].Y, data);
            //KHI12 = KHIminus12(data.L, data);
            double pn = P(data.L, data);
            double pn1 = P(data.L - h, data);
            double pn12 = (pn + pn1) / 2;

            double fn = F(data.L, data);
            double fn1 = F(data.L - data.h, data);
            double fn12 = (fn + fn1) / 2;

            double cn = calculateC(listPrev[listPrev.Count - 1].Y, data);
            double cn1 = calculateC(listPrev[listPrev.Count - 2].Y, data);
            double cn12 = (c0 + c1) / 2;

            
            double Kn = h / 8 * cn12 - tau / h * KHI12 + h / 8 * tau * p12;
            double Mn = h / 4 * cn + h / 8 * cn12 + tau * data.alphaN + tau / h * KHI12 + h / 4 * tau
                * pn + h / 8 * tau * p12;
            double Pn = h / 4 * cn * list[list.Count - 1].Y + h / 8 * cn12 * (list[list.Count - 1].Y 
                + list[list.Count - 2].Y) + tau * data.alphaN * data.t0 + h / 4 * tau * (fn + f12);

            // Коэффициенты

            N = (int)(data.L / h) + 1;
            double x = xBegin;
            An.Add(0);
            Cn.Add(0);
            Bn.Add(0);
            Dn.Add(0);
            for (int i = 1; i < N - 1; i++)
            {
                double A = tau * CalcKHI(listPrev[i].Y, listPrev[i + 1].Y, data) / h;
                double C = tau * CalcKHI(listPrev[i].Y, listPrev[i - 1].Y, data) / h;
                //double A = tau * KHIplus12(x, data) / h;
                //double C = tau * KHIminus12(x, data) / h;
                
                double B = A + C + calculateC(listPrev[i].Y, data) * h +  P(x, data) * h * tau;
                double D = F(x, data) * h * tau + calculateC(listPrev[i].Y, data) * list[i].Y * h;

                An.Add(A);
                Cn.Add(C);
                Bn.Add(B);
                Dn.Add(D);
                x += h;
            }
            An.Add(0);
            Cn.Add(0);
            Bn.Add(0);
            Dn.Add(0);

            double KSI = -M0 / K0;
            double ETA = P0 / K0;
            KSIn.Add(KSI);
            ETAn.Add(ETA);

            for (int i = 1; i < An.Count - 1; i++)
            {
                double KSI1 = Cn[i] / (Bn[i] - An[i] * KSI);
                double ETA1 = (Dn[i] + An[i] * ETA) / (Bn[i] - An[i] * KSI);
                KSIn.Add(KSI1);
                ETAn.Add(ETA1);
                KSI = KSI1;
                ETA = ETA1;
            }

            // Обратный ход

            PointPairList prls = new PointPairList();
            double yn = (Pn - Mn * ETA) / (Kn + Mn * KSI);
            prls.Add(data.L, yn);
            //prls.Add(tau, yn);
            double j = 1;
            //double t = 0;
            for (int i = An.Count - 2; i >= 0; i--)
            {
                yn = KSIn[i] * yn + ETAn[i];
                prls.Add(xBegin + i * h, yn);
                //prls.Add(t, yn);
                j++;
                //t += tau;
            }
            prls.Sort();


            return prls;
        }
    }
}
