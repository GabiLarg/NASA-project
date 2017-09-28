using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars
{
    class Program
    {
        public static string[] movements = { "L", "R", "M" };
  

        static void Main(string[] args)
        {
            
            Mesh mesh = new Mesh();
            Probe probe = new Probe();
           
            //set start position for the mesh
            mesh.startPoint = new Point();
            mesh.startPoint.X = 0;
            mesh.startPoint.Y = 0;

            string[] entryMeshEndPoint;
            string[] entryProbePointDirection;
            string line = null;
            int step = 0;

            Console.WriteLine("************************************************************\n" +
                                "************************PROJECT MARS************************\n"+
                                "************************************************************\n"+
                                "Insira os parâmetros da malha no seguinte formato: \n" +
                                "X Y ==>Coordenada supeior direita da malha \n"+
                                "Insira os parâmetros da sonda no seguinte formato: \n" +
                                "X Y D ==> Coordenadas iniciais da sonda e direção(N, E, S, W) \n" +
                                "LRM ==> Série de instrições de movimento da sonda (L: esquerda, R: direira, M: mover) \n" +
                                "Insira uma linha com 0 para finalizar o programa.");

            while (line != "0")
            {
                line = Console.ReadLine();
                if (line == "0") continue;
                if (step == 0)
                {
                    entryMeshEndPoint = line.Split();
                    mesh.endPoint = new Point();
                    if ( validadeMeshEntry(entryMeshEndPoint, mesh)) { step = 1; }
                    continue;
                }
                else if (step == 1)
                {
                 
                    entryProbePointDirection = line.Split();
                    probe = validateProbeEntry(entryProbePointDirection, mesh);
                    if (probe != null) step = 2;
                    continue;
                }
                else if (step == 2)
                {
                    validateMovesEntry(line, probe, mesh);
                    Console.WriteLine("{0} {1} {2}", probe.position.X, probe.position.Y, probe.direction);
                    step = 1;
                }

            }
        }
        
        static bool validadeMeshEntry(string[]positions, Mesh mesh)
        {
            if (positions.Length < 2) {
                Console.WriteLine("Entrada inválida. Tente novamente.");
                return false;
            }
            int Xvalid;
            int Yvalid;
            if (Int32.TryParse(positions[0], out Xvalid) && Int32.TryParse(positions[1], out Yvalid))
            {
                if (Xvalid < 0 || Yvalid < 0)
                {
                    Console.WriteLine("Posição superior direita não pode ser negativa. Tente novamente.");
                    return false;
                }
                //set highest postion in the mesh
                mesh.endPoint.X = Xvalid;
                mesh.endPoint.Y = Yvalid;
                return true;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
                return false;
            }
        }

        static Probe validateProbeEntry(string[] parameters, Mesh mesh)
        {
            Probe probe = new Probe();
            probe.position = new Point();
            if (parameters.Length < 3)
            {
                Console.WriteLine("Entrada de parâmetros inválida. Entre com os parâmetros da sonda novamente.");
                return null;
            }
            int Xvalid;
            int Yvalid;
            if (Int32.TryParse(parameters[0], out Xvalid) && Int32.TryParse(parameters[1], out Yvalid) && referenceCompassRose.Contains(parameters[2]))
            {
                //verify if out of range
                if (Xvalid > mesh.endPoint.X || Xvalid < mesh.startPoint.X || Yvalid > mesh.endPoint.Y || Yvalid < mesh.startPoint.Y)
                {
                    Console.WriteLine("A sonda está fora da malha. Entre com os parâmetros da sonda novamente.");
                    return null;
                }
                //set entry position
                probe.position.X = Xvalid;
                probe.position.Y = Yvalid;
                probe.direction = parameters[2];
            }
            else
            {
            
                Console.WriteLine("Entrada de parâmetros inválida. Entre com os parâmetros da sonda novamente.");
                return null;
            }
            return probe;
        }
        static void validateMovesEntry(string moves, Probe probe, Mesh mesh)
        {
            
        }

    }
}