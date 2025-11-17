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
       public bool EsConexo()
        {
            if (Ady.Count == 0) return true;

            HashSet<string> visitados = new HashSet<string>();
            Queue<string> cola = new Queue<string>();
            string inicio = new List<string>(Ady.Keys)[0];

            cola.Enqueue(inicio);
            visitados.Add(inicio);

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();
                foreach (var vecino in Ady[actual])
                {
                    if (!visitados.Contains(vecino.destino))
                    {
                        visitados.Add(vecino.destino);
                        cola.Enqueue(vecino.destino);
                    }
                }
            }

            return visitados.Count == Ady.Count;
        }

        public DijkstraResult Dijkstra(string inicio, string fin)
        {
            Dictionary<string, int> dist = new Dictionary<string, int>();
            Dictionary<string, string> prev = new Dictionary<string, string>();
            HashSet<string> visitados = new HashSet<string>();

            foreach (var nodo in Ady.Keys)
            {
                dist[nodo] = int.MaxValue;
                prev[nodo] = null;
            }

            dist[inicio] = 0;

            while (visitados.Count < Ady.Count)
            {
                string actual = null;
                int menor = int.MaxValue;

                foreach (var nodo in Ady.Keys)
                {
                    if (!visitados.Contains(nodo) && dist[nodo] < menor)
                    {
                        menor = dist[nodo];
                        actual = nodo;
                    }
                }

                if (actual == null) break;
                visitados.Add(actual);

                foreach (var vecino in Ady[actual])
                {
                    int nuevaDist = dist[actual] + vecino.distancia;
                    if (nuevaDist < dist[vecino.destino])
                    {
                        dist[vecino.destino] = nuevaDist;
                        prev[vecino.destino] = actual;
                    }
                }
            }

            List<string> ruta = new List<string>();
            string temp = fin;

            while (temp != null)
            {
                ruta.Insert(0, temp);
                temp = prev[temp];
            }

            return new DijkstraResult(ruta, dist[fin]);
        }
        public List<string> ObtenerTodosLosNodos()
        {
            return new List<string>(Ady.Keys);
        }

        public bool ExisteNodo(string nombre)
        {
            return Ady.ContainsKey(nombre);
        }
    }
}
