using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesYGrafos
{
   public class DijkstraResult
    {
        public List<string> Ruta { get; set; }
        public int DistanciaTotal { get; set; }

        public DijkstraResult(List<string> ruta, int distanciaTotal)
        {
            Ruta = ruta;
            DistanciaTotal = distanciaTotal;
        }
    }

    public class Graph
    {
        public Dictionary<string, List<(string destino, int distancia)>> Ady =
            new Dictionary<string, List<(string destino, int distancia)>>();

        public void AgregarNodo(string nombre)
        {
            if (!Ady.ContainsKey(nombre))
                Ady[nombre] = new List<(string destino, int distancia)>();
        }

        public void AgregarConexion(string origen, string destino, int distancia)
        {
            AgregarNodo(origen);
            AgregarNodo(destino);

            Ady[origen].Add((destino, distancia));
            Ady[destino].Add((origen, distancia));
        }

        public List<(string nodo, int distancia)> ObtenerConexiones(string nodo)
        {
            if (!Ady.ContainsKey(nodo))
                return new List<(string nodo, int distancia)>();
            return Ady[nodo];
        }
    }
}
