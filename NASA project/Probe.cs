using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars
{
    class Probe
    {
        private Point probePointInMesh;
        private string direction;

        public Probe()
        {
            this.probePointInMesh = new Point();
        }
        public void setProvePointInMesh(int X, int Y)
        {
            this.probePointInMesh.setXY(X, Y);
        }

        public void setDirection(string direction)
        {
            this.direction = direction;
        }

        public Point getProbePointInMesh()
        {
            return this.probePointInMesh;
        }

        public string getDirection()
        {
            return this.direction;
        }

        public void turnRight(Probe probe, int index)
        {
            if (index == (referenceCompassRose.Length - 1)) probe.direction = referenceCompassRose[0];
            else
            {
                probe.direction = referenceCompassRose[index + 1];
            }

        }

        public void turnLeft(Probe probe, int index)
        {
            int lastIndex = referenceCompassRose.Length - 1;
            if (index == 0) probe.direction = referenceCompassRose[lastIndex];
            else
            {
                probe.direction = referenceCompassRose[index - 1];
            }
        }

        public void move(Probe probe, Mesh mesh)
        {
            int newY = 0;
            int newX = 0;
            switch (probe.direction)
            {
                case "N":
                    newY = probe.position.Y + 1;
                    if (newY <= mesh.endPoint.Y) probe.position.Y = newY;
                    else probe.position.Y = mesh.endPoint.Y;
                    break;
                case "E":
                    newX = probe.position.X + 1;
                    if (newX <= mesh.endPoint.X) probe.position.X = newX;
                    else probe.position.X = mesh.endPoint.X;
                    break;
                case "S":
                    newY = probe.position.Y - 1;
                    if (newY >= mesh.startPoint.Y) probe.position.Y = newY;
                    else probe.position.Y = mesh.startPoint.Y;
                    break;
                case "W":
                    newX = probe.position.X - 1;
                    if (newX >= mesh.startPoint.X) probe.position.X = newX;
                    else probe.position.X = mesh.startPoint.X;
                    break;
                default:
                    Console.WriteLine("Entrada de parâmetros inválida. Entre com os parâmetros da sonda novamente.");
                    return;
            }
        }
    }
    
}
