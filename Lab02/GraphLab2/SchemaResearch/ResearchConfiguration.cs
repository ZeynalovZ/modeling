using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace SchemaResearch
{
    public class ResearchConfiguration
    {
        public double R = 0;
        public double Tw = 0;
        public double Ck = 0;
        public double Lk = 0;
        public double Rk = 0;
        public double Uc0 = 0;
        public double I0 = 0;
        public double L0 = 0;

        public double Tbegin = 0;
        public double Tend = 1e-4;
        public double Tstep = 1e-6;

        public PointPairList list1;
        public PointPairList list2;
        public PointPairList list3;
        public PointPairList list4;
        public PointPairList list5;

        public ResearchConfiguration()
        {
            list1 = new PointPairList();
            list2 = new PointPairList();
            list3 = new PointPairList();
            list4 = new PointPairList();
            list5 = new PointPairList();
        }

        public ResearchConfiguration(double R,
        double Tw,
        double Ck,
        double Lk,
        double Rk,
        double Uc0,
        double I0,
        double L0)
        {
            this.R = R;
            this.Tw = Tw;
            this.Ck = Ck;
            this.Lk = Lk;
            this.Rk = Rk;
            this.Uc0 = Uc0;
            this.I0 = I0;
            this.L0 = L0;

            list1 = new PointPairList();
            list2 = new PointPairList();
            list3 = new PointPairList();
            list4 = new PointPairList();
            list5 = new PointPairList();

        }

        public void setTimeTable(double Begin, double End, double Step)
        {
            this.Tbegin = Begin;
            this.Tend = End;
            this.Tstep = Step;
        }
    }
}
