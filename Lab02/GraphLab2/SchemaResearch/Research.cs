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


        private static double functionF(double xn, double yn, double zn)
        {
            double Rp = calculateRp();
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

        private static double calculateRp()
        {
            return 0;
        }

        private static void RungeKutta4(double xn, double yn, double zn, double hn, out double yn_1, out double zn_1 )
        {
            double k1 = functionF(xn, yn, zn);
            double q1 = functionPHI(xn, yn, zn);

            double k2 = functionF(xn + hn / 2, yn + k1 * hn / 2, zn + q1 * hn / 2);
            double q2 = functionPHI(xn + hn / 2, yn + k1 * hn / 2, zn + q1 * hn / 2);

            double k3 = functionF(xn + hn / 2, yn + k2 * hn / 2, zn + q2 * hn / 2);
            double q3 = functionPHI(xn + hn / 2, yn + k2 * hn / 2, zn + q2 * hn / 2);

            double k4 = functionF(xn + hn / 2, yn + k3 * hn, zn + q3 * hn);
            double q4 = functionPHI(xn + hn / 2, yn + k3 * hn, zn + q3 * hn);

            yn_1 = yn + hn * (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            zn_1 = zn + hn * (q1 + 2 * q2 + 2 * q3 + q4) / 6;
        }

        private static double RungeKutta2(double xn, double yn, double zn, double hn)
        {
            double alpha = 1;
            double yn_1 = yn + hn * ((1 - alpha) * functionF(xn, yn, zn) +
                alpha * functionF(xn + hn / (2 * alpha), yn + hn / (2 * alpha), zn + hn / (2 * alpha)) *
                functionF(xn, yn, zn));
            double zn_1 = yn + hn * ((1 - alpha) * functionPHI(xn, yn, zn) +
                alpha * functionPHI(xn + hn / (2 * alpha), yn + hn / (2 * alpha), zn + hn / (2 * alpha)) *
                functionPHI(xn, yn, zn));

            return yn_1;
        }
    }
}
