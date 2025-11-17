using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesYGrafos
{
    /// <summary>
    /// Clase que representa el resultado del algoritmo Dijkstra
    /// Contiene la ruta más corta y la distancia total
    /// </summary>
    public class DijkstraResult
    {
        /// <summary>
        /// Lista de nodos que forman la ruta más corta
        /// </summary>
        public List<string> Ruta { get; set; }

        /// <summary>
        /// Distancia total de la ruta más corta
        /// </summary>
        public int DistanciaTotal { get; set; }

        /// <summary>
        /// Constructor para crear un resultado de Dijkstra
        /// </summary>
        /// <param name="ruta">Lista de nodos de la ruta</param>
        /// <param name="distanciaTotal">Distancia total de la ruta</param>
        public DijkstraResult(List<string> ruta, int distanciaTotal)
        {
            Ruta = ruta;
            DistanciaTotal = distanciaTotal;
        }
    }

    /// <summary>
    /// Clase que representa un grafo no dirigido y ponderado
    /// para modelar las rutas entre edificios del parque tecnológico
    /// </summary>
    public class Graph
    {
        // Diccionario que representa la lista de adyacencia del grafo
        // Key: nombre del nodo (edificio)
        // Value: lista de tuplas (destino, distancia)
        public Dictionary<string, List<(string destino, int distancia)>> Ady =
            new Dictionary<string, List<(string destino, int distancia)>>();

        /// <summary>
        /// Agrega un nuevo nodo (edificio) al grafo si no existe
        /// </summary>
        /// <param name="nombre">Nombre del nodo/edificio a agregar</param>
        public void AgregarNodo(string nombre)
        {
            // Solo agregar si el nodo no existe previamente
            if (!Ady.ContainsKey(nombre))
                Ady[nombre] = new List<(string destino, int distancia)>();
        }

        /// <summary>
        /// Agrega una conexión bidireccional entre dos nodos con una distancia específica
        /// </summary>
        /// <param name="origen">Nodo de origen</param>
        /// <param name="destino">Nodo de destino</param>
        /// <param name="distancia">Distancia entre los nodos</param>
        public void AgregarConexion(string origen, string destino, int distancia)
        {
            // Asegurar que ambos nodos existan antes de conectar
            AgregarNodo(origen);
            AgregarNodo(destino);

            // Agregar conexión bidireccional (grafo no dirigido)
            Ady[origen].Add((destino, distancia));
            Ady[destino].Add((origen, distancia));
        }

        /// <summary>
        /// Obtiene todas las conexiones de un nodo específico
        /// </summary>
        /// <param name="nodo">Nodo del cual obtener las conexiones</param>
        /// <returns>Lista de conexiones (nodo destino, distancia)</returns>
        public List<(string nodo, int distancia)> ObtenerConexiones(string nodo)
        {
            // Verificar que el nodo exista antes de obtener conexiones
            if (!Ady.ContainsKey(nodo))
                return new List<(string nodo, int distancia)>();

            return Ady[nodo];
        }

        /// <summary>
        /// Determina si el grafo es conexo (todos los nodos están conectados)
        /// usando el algoritmo BFS (Breadth-First Search)
        /// </summary>
        /// <returns>True si el grafo es conexo, False en caso contrario</returns>
        public bool EsConexo()
        {
            // Grafo vacío se considera conexo
            if (Ady.Count == 0) return true;

            // Estructuras para BFS
            HashSet<string> visitados = new HashSet<string>();
            Queue<string> cola = new Queue<string>();

            // Tomar cualquier nodo como punto de inicio
            string inicio = new List<string>(Ady.Keys)[0];

            // Iniciar BFS desde el nodo inicial
            cola.Enqueue(inicio);
            visitados.Add(inicio);

            // Recorrer todos los nodos conectados
            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();

                // Visitar todos los vecinos del nodo actual
                foreach (var vecino in Ady[actual])
                {
                    if (!visitados.Contains(vecino.destino))
                    {
                        visitados.Add(vecino.destino);
                        cola.Enqueue(vecino.destino);
                    }
                }
            }

            // El grafo es conexo si visitamos todos los nodos
            return visitados.Count == Ady.Count;
        }

        /// <summary>
        /// Implementa el algoritmo Dijkstra para encontrar la ruta más corta
        /// entre dos nodos en un grafo ponderado
        /// </summary>
        /// <param name="inicio">Nodo de inicio</param>
        /// <param name="fin">Nodo de destino</param>
        /// <returns>Objeto DijkstraResult con la ruta y distancia total</returns>
        public DijkstraResult Dijkstra(string inicio, string fin)
        {
            // Verificar que los nodos existan
            if (!Ady.ContainsKey(inicio) || !Ady.ContainsKey(fin))
                return new DijkstraResult(new List<string>(), int.MaxValue);

            // Estructuras para Dijkstra
            Dictionary<string, int> dist = new Dictionary<string, int>();    // Distancias mínimas
            Dictionary<string, string> prev = new Dictionary<string, string>(); // Nodos anteriores
            HashSet<string> visitados = new HashSet<string>();               // Nodos ya procesados

            // Inicializar todas las distancias como infinito y predecesores como nulo
            foreach (var nodo in Ady.Keys)
            {
                dist[nodo] = int.MaxValue;  // Distancia infinita inicialmente
                prev[nodo] = null;          // Sin predecesor
            }

            // La distancia al nodo inicial es 0
            dist[inicio] = 0;

            // Procesar todos los nodos
            while (visitados.Count < Ady.Count)
            {
                // Encontrar el nodo no visitado con la distancia mínima
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

                // Si no hay nodos alcanzables, terminar
                if (actual == null) break;

                visitados.Add(actual);

                // Actualizar distancias de los vecinos
                foreach (var vecino in Ady[actual])
                {
                    // Solo procesar vecinos no visitados
                    if (!visitados.Contains(vecino.destino))
                    {
                        int nuevaDist = dist[actual] + vecino.distancia;

                        // Si encontramos un camino más corto, actualizar
                        if (nuevaDist < dist[vecino.destino])
                        {
                            dist[vecino.destino] = nuevaDist;
                            prev[vecino.destino] = actual;
                        }
                    }
                }
            }

            // Reconstruir la ruta desde el fin hasta el inicio
            List<string> ruta = new List<string>();
            string temp = fin;

            // Seguir la cadena de predecesores hasta llegar al inicio
            while (temp != null)
            {
                ruta.Insert(0, temp);  // Insertar al inicio para mantener el orden
                temp = prev[temp];
            }

            // Verificar si se encontró una ruta válida
            if (ruta.Count == 0 || dist[fin] == int.MaxValue)
            {
                return new DijkstraResult(new List<string>(), int.MaxValue);
            }

            return new DijkstraResult(ruta, dist[fin]);
        }

        /// <summary>
        /// Obtiene una lista con todos los nodos (edificios) del grafo
        /// </summary>
        /// <returns>Lista de nombres de todos los nodos</returns>
        public List<string> ObtenerTodosLosNodos()
        {
            return new List<string>(Ady.Keys);
        }

        /// <summary>
        /// Verifica si un nodo existe en el grafo
        /// </summary>
        /// <param name="nombre">Nombre del nodo a verificar</param>
        /// <returns>True si el nodo existe, False en caso contrario</returns>
        public bool ExisteNodo(string nombre)
        {
            return Ady.ContainsKey(nombre);
        }
    }
}