using System;
using System.Collections.Generic;
using System.Text;
using ZedGraph;

namespace ResearchSchema
{
    public class SchemaDataMethod
    {
        public SchemaDataMethod()
        {
            ;
        }
        public double k0 = 0;
        public double kN = 0;
        public double alpha0 = 0;
        public double alphaN = 0;
        public double L = 0;
        public double t0 = 0;
        public double R = 0;
        public double F0 = 0;
        public double h = 0;
        public double a1 = 0.0134;
        public double a2 = 2.049;
        public double b1 = 1;
        public double b2 = 0.563 * 1e-3;
        public double c1 = 4.35 * 1e-4;
        public double c2 = 0.528 * 1e-5;
        public double m1 = 1;
        public double m2 = 1;
        public PointPairList list1 = new PointPairList();
    }
}
