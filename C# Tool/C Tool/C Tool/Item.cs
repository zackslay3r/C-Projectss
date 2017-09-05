using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Tool
{
    public class Item
    {
        public Point startPoint = new Point();
        public Point endPoints = new Point();

        public PointD startUVpoint = new PointD();
        public PointD endUVpoint = new PointD();

        public int width = new int();
        public int height = new int();

        public Rectangle rectangle = new Rectangle();

        
        public string name { get; set; }
    }
}
