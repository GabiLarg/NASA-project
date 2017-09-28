using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars
{
    class Mesh
    {
        private Point startPoint;
        private Point endPoint;

        public Mesh()
        {
            this.startPoint = new Point();
            this.endPoint = new Point();
        }

        public void setStartPoint(int X, int Y)
        {
            this.startPoint.setXY(X, Y);
        }

        public void setEndPoint(int X, int Y)
        {
            this.endPoint.setXY(X, Y);
        }

        public Point getstartPoint()
        {
            return this.startPoint;
        }

        public Point getEndPoin()
        {
            return this.endPoint;
        }
    }
        
}
