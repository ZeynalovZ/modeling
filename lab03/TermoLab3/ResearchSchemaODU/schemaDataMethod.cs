using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace ResearchSchemaODU
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
        public PointPairList list1 = new PointPairList();
    }
}
