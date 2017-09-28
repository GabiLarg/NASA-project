using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars
{
    class Point
    {
        private int axisX;
        private int axisY;


        public void setXY(int axisX, int axisY){
            this.axisX = axisX;
            this.axisY = axisY;
        }

        public int getX()
        {
            return this.axisX;
        }

        public int getY()
        {
            return this.axisY;
        }
        
    }
}
