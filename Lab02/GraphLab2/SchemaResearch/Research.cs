using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaResearch
{
    public class Research
    {
        public Research() 
        {
            List<List<double>> ItK = new List<List<double>>();
            List<List<double>> Tsiqma = new List<List<double>>();
        }

        public static ResearchConfiguration localConfig;

        static List<List<double>> ItK;
        static List<List<double>> Tsiqma;


        private static double functionF(double xn, double yn, double zn, int currentStepInRunge)
        {
            double Rp = calculateRp(yn);
            if (currentStepInRunge == 0)
            {
                localConfig.list3.Add(xn, Rp);
                localConfig.list4.Add(xn, yn * Rp);
            }
            return ((zn - (localConfig.Rk + Rp) * yn) / localConfig.Lk) ;
        }

        private static double functionPHI(double xn, double yn, double zn)
        {
            return -1 / localConfig.Ck * yn;
        }

        private static void readFromFile()
        {
            ItK = FileReader.readFile("ItK.txt");
            Tsiqma = FileReader.readFile("Tsiqma.txt");
        }

        public static ResearchConfiguration computeResult(ResearchConfiguration config)
        {
            localConfig = config;
            double t = config.Tbegin, tmax = config.Tend; // in sec
            double I = config.I0;
            double Uc = config.Uc0;
            double hn = config.Tstep;

            double I_1;
            double U_1;

            readFromFile();

            for (double i = t; i < tmax; i += hn)
            {
                config.list1.Add(i, I);
                config.list2.Add(i, Uc);
                RungeKutta4(i, I, Uc, hn, out I_1, out U_1);
                I = I_1;
                Uc = U_1;
            }
            return localConfig;
        }

        private static double calculateRp(double I)
        {
            double R = localConfig.R;
            double Le = localConfig.L0;
            double integral = integrateSimpson(I);
            return localConfig.L0 / (2 * Math.PI * R * R * integral);
        }

        public static double getTz(double T0, double m, double r)
        {
            double z = r / localConfig.R;
            return (localConfig.Tw - T0) * Math.Pow(z, m) + T0;
        }
        private static double siqmaFunc(double I, double z)
        {
            double m = interpolate(ItK, I, 0, 2);
            double T0 = interpolate(ItK, I, 0, 1);
            double Tz = getTz(T0, m, z);
            double siqma = interpolate(Tsiqma, Tz, 0, 1);
            return siqma;
        }

        private static double integrateSimpson(double I)
        {
            double test = I;
            double n = 40;
            double integrateBegin = 0;
            double integrateEnd = 1;
            double width = (integrateEnd - integrateBegin) / n;
            double result = 0;
            for (double step = 0; step < n; step++)
            {
                double x1 = integrateBegin + step * width;
                double x2 = integrateBegin + (step + 1) * width;
                result += (x2 - x1) / 6.0 * (siqmaFunc(I, x1) + 4.0 * siqmaFunc(I, 0.5 * (x1 + x2)) + siqmaFunc(I, x2));
            }
            return result;
        }

        

        private static double interpolate(List<List<double>> table, double xValue, int xIndex, int yIndex)
        {
            bool interpolateIndexFound = false;
            double x1 = 0, x2 = 0, y1 = 0, y2 = 0, yResult = 0;
            for (int i = 0; i < table.Count - 1; i++)
            {
                if (table[i][xIndex] <= xValue && table[i + 1][xIndex] >= xValue)
                {
                    y1 = table[i][yIndex];
                    y2 = table[i + 1][yIndex];
                    x1 = table[i][xIndex];
                    x2 = table[i + 1][xIndex];
                    interpolateIndexFound = true;
                }
            }
            if (interpolateIndexFound)
            {
                yResult = y1 + ((xValue - x1) / (x2 - x1)) * (y2 - y1);
            }
            else
            {
                if (xValue < table[0][xIndex])
                    yResult = table[0][yIndex];
                if (xValue > table[table.Count - 1][xIndex])
                    yResult = table[table.Count - 1][yIndex];
            }
            return yResult;
        }

        private static void RungeKutta4(double xn, double yn, double zn, double hn, out double yn_1, out double zn_1 )
        {
            double k1 = functionF(xn, yn, zn, 0);
            double q1 = functionPHI(xn, yn, zn);

            double k2 = functionF(xn + hn / 2, yn + k1 * hn / 2, zn + q1 * hn / 2, 1);
            double q2 = functionPHI(xn + hn / 2, yn + k1 * hn / 2, zn + q1 * hn / 2);

            double k3 = functionF(xn + hn / 2, yn + k2 * hn / 2, zn + q2 * hn / 2, 1);
            double q3 = functionPHI(xn + hn / 2, yn + k2 * hn / 2, zn + q2 * hn / 2);

            double k4 = functionF(xn + hn / 2, yn + k3 * hn, zn + q3 * hn, 1);
            double q4 = functionPHI(xn + hn / 2, yn + k3 * hn, zn + q3 * hn);

            yn_1 = yn + hn * (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            zn_1 = zn + hn * (q1 + 2 * q2 + 2 * q3 + q4) / 6;
        }

        private static double RungeKutta2(double xn, double yn, double zn, double hn)
        {
            double alpha = 1;
            double yn_1 = yn + hn * ((1 - alpha) * functionF(xn, yn, zn, 1) +
                alpha * functionF(xn + hn / (2 * alpha), yn + hn / (2 * alpha), zn + hn / (2 * alpha), 1) *
                functionF(xn, yn, zn, 1));
            double zn_1 = yn + hn * ((1 - alpha) * functionPHI(xn, yn, zn) +
                alpha * functionPHI(xn + hn / (2 * alpha), yn + hn / (2 * alpha), zn + hn / (2 * alpha)) *
                functionPHI(xn, yn, zn));

            return yn_1;
        }
    }
}
