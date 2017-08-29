using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Tool
{
   public class PointD
    {
        public double x { get; set; }
        public double y { get; set; }

        public PointD(double xval, double yval)
        {
            x = xval;
            y = yval;
        }

        public PointD()
        {

        }
    }
}
