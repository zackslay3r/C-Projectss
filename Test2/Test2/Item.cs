using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class Item
    {

        public Point startPoint = new Point();
        public Point endPoints = new Point();

        public PointD startUVpoint = new PointD();
        public PointD endUVpoint = new PointD();

        public Rectangle rectangle = new Rectangle();

        public string name { get; set; }

        //public Point startPoint;
        //public Point endPoints;

        //public PointD startUVpoint;
        //public PointD endUVpoint;

        //public Rectangle rectangle;

        //public string name;
    }
}
