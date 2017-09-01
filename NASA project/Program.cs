using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_project
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] direction = { "N", "E", "S", "W" };
            Mesh mesh = new Mesh();
            //set start position
            mesh.startMesh = new Position();
            mesh.startMesh.X = 0;
            mesh.startMesh.Y = 0;

            string[] finalposition;
            string[] parameters;
            Console.WriteLine("******************PROJECT MARS*****************");
            Console.WriteLine("Insira os parâmetros da malha no seguinte formato: \n" +
                                "X Y ==>Coordenada supeior direita da malha \n");


            string line = null;
            int numLine = 0;
            introMessage();
                        
            while (line != "0")
            {
                bool validate = false;
                line = Console.ReadLine();
                if (line == "0") continue;
                if (numLine == 0)
                {
                    finalposition = line.Split();
                    mesh.endMesh = new Position();
                    validate = validadeMeshEntry(finalposition, mesh);
                    if (validate) { numLine = 1; }
                    continue;
                }
                else if (numLine == 1)
                {
                    parameters = line.Split();
                    Probe probe = validateProbeEntry(parameters, direction);
                    if (probe != null) numLine = 2;
                    continue;
                }
                else if (numLine == 2)
                {
                    Console.WriteLine("Do nothing!");
                }

            }
        }
        static void introMessage()
        {;
            Console.WriteLine("Insira os parâmetros da sonda no seguinte formato: \n" +
                                "X Y D ==> Coordenadas iniciais da sonda e direção(N, E, S, W) \n" +
                                "LRM ==> Série de instrições de movimento da sonda (L: esquerda, R: direira, M: mover) \n" +
                                "Insira uma linha com 0 para finalizar.");
        }
        static bool validadeMeshEntry(string[]positions, Mesh mesh)
        {
            if (positions.Length < 2) {
                Console.WriteLine("Entrada inválida, tente novamente.");
                return false;
            }
            int Xvalid;
            int Yvalid;
            if (Int32.TryParse(positions[0], out Xvalid) && Int32.TryParse(positions[1], out Yvalid))
            {
                mesh.endMesh.X = Xvalid;
                mesh.endMesh.Y = Yvalid;
                return true;
            }
            else
            {
                Console.WriteLine("Entrada inválida, tente novamente.");
                return false;
            }
        }

        static Probe validateProbeEntry(string[] parameters, string[] directions)
        {
            Probe probe = new Probe();
            probe.position = new Position();
            if (parameters.Length < 3)
            {
                Console.WriteLine("Entrada de parâmetros inválida, entre com os parâmetros da sonda novamente.");
                return null;
            }
            int Xvalid;
            int Yvalid;
            if (Int32.TryParse(parameters[0], out Xvalid) && Int32.TryParse(parameters[1], out Yvalid) && directions.Contains(parameters[2]))
            {
                //set entry position
                probe.position.X = Xvalid;
                probe.position.Y = Yvalid;
                probe.direction = parameters[2];
            }
            else
            {
            
                Console.WriteLine("Entrada de parâmetros inválida, entre com os parâmetros da sonda novamente.");
                return null;
            }
            return probe;
        }

        static void turnLeft() { }

        static void turnRight() { }

        static void move() { }
        class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        class Probe
        {

            public Position position { get; set; }
            public string direction { get; set; }
        }

        class Mesh
        {
            public Position startMesh { get; set; }
            public Position endMesh { get; set; }
        }
    }
}