using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesYGrafos
{
    /// <summary>
    /// Clase que representa un nodo en el árbol organizativo
    /// Cada nodo contiene un nombre y una lista de nodos hijos
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Nombre o identificador del nodo en el árbol organizativo
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Lista de nodos hijos que dependen de este nodo
        /// </summary>
        public List<TreeNode> Hijos { get; set; }

        /// <summary>
        /// Constructor para crear un nuevo nodo del árbol
        /// </summary>
        /// <param name="nombre">Nombre del nodo a crear</param>
        public TreeNode(string nombre)
        {
            Nombre = nombre;
            Hijos = new List<TreeNode>();
        }
    }

    /// <summary>
    /// Clase que representa un árbol general para la jerarquía organizativa
    /// del Parque Tecnológico Innovatec
    /// </summary>
    public class OrgTree
    {
        /// <summary>
        /// Nodo raíz del árbol organizativo (representa la organización principal)
        /// </summary>
        public TreeNode Raiz { get; set; }

        /// <summary>
        /// Constructor para inicializar el árbol con un nodo raíz
        /// </summary>
        /// <param name="nombreRaiz">Nombre del nodo raíz (ej: "Innovatec")</param>
        public OrgTree(string nombreRaiz)
        {
            Raiz = new TreeNode(nombreRaiz);
        }

        /// <summary>
        /// Agrega un nuevo nodo hijo a un nodo padre específico
        /// </summary>
        /// <param name="padre">Nodo padre al que se agregará el hijo</param>
        /// <param name="nombreHijo">Nombre del nuevo nodo hijo</param>
        public void AgregarNodo(TreeNode padre, string nombreHijo)
        {
            // Crear nuevo nodo hijo y agregarlo a la lista del padre
            padre.Hijos.Add(new TreeNode(nombreHijo));
        }

        /// <summary>
        /// Busca un nodo en el árbol por su nombre usando búsqueda en profundidad (DFS)
        /// </summary>
        /// <param name="actual">Nodo actual en la búsqueda recursiva</param>
        /// <param name="nombre">Nombre del nodo a buscar</param>
        /// <returns>El nodo encontrado o null si no existe</returns>
        public TreeNode Buscar(TreeNode actual, string nombre)
        {
            // Caso base: si encontramos el nodo, retornarlo
            if (actual.Nombre == nombre) return actual;

            // Buscar recursivamente en todos los hijos
            foreach (var hijo in actual.Hijos)
            {
                var encontrado = Buscar(hijo, nombre);
                if (encontrado != null) return encontrado;
            }

            // Si no se encontró en este subárbol, retornar null
            return null;
        }

        /// <summary>
        /// Cuenta el número total de nodos en el árbol de forma recursiva
        /// </summary>
        /// <param name="actual">Nodo actual en el conteo recursivo</param>
        /// <returns>Número total de nodos en el subárbol</returns>
        public int ContarNodos(TreeNode actual)
        {
            // Iniciar contador con el nodo actual
            int total = 1;

            // Sumar recursivamente los nodos de todos los hijos
            foreach (var hijo in actual.Hijos)
                total += ContarNodos(hijo);

            return total;
        }

        /// <summary>
        /// Calcula el nivel de un nodo específico en el árbol
        /// El nivel de la raíz es 0, sus hijos nivel 1, etc.
        /// </summary>
        /// <param name="actual">Nodo actual en la búsqueda recursiva</param>
        /// <param name="nombre">Nombre del nodo cuyo nivel se busca</param>
        /// <param name="nivel">Nivel actual en la búsqueda recursiva</param>
        /// <returns>Nivel del nodo o -1 si no se encuentra</returns>
        public int Nivel(TreeNode actual, string nombre, int nivel)
        {
            // Si encontramos el nodo, retornar el nivel actual
            if (actual.Nombre == nombre) return nivel;

            // Buscar en todos los hijos, incrementando el nivel
            foreach (var hijo in actual.Hijos)
            {
                int encontrado = Nivel(hijo, nombre, nivel + 1);
                if (encontrado != -1) return encontrado;
            }

            // Nodo no encontrado en este subárbol
            return -1;
        }
    }
}