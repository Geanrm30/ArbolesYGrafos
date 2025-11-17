using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolesYGrafos
{
    /// <summary>
    /// Formulario principal para la gestión del árbol organizativo y grafo de rutas
    /// del Parque Tecnológico Innovatec
    /// </summary>
    public partial class Form1 : Form
    {
        // Instancias de las clases principales
        private OrgTree arbol;      // Árbol para la jerarquía organizativa
        private Graph grafo;        // Grafo para las rutas entre edificios

        /// <summary>
        /// Constructor principal del formulario
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Inicializar el árbol con la raíz "Innovatec"
            arbol = new OrgTree("Innovatec");

            // Inicializar el grafo vacío
            grafo = new Graph();

            // Mostrar el árbol inicial en la lista
            ActualizarListaArbol();
        }

        /// <summary>
        /// Actualiza la lista visual del árbol organizativo con el recorrido en preorden
        /// </summary>
        private void ActualizarListaArbol()
        {
            // Limpiar la lista antes de actualizar
            lsbArbol.Items.Clear();

            // Verificar que exista raíz para evitar errores
            if (arbol.Raiz != null)
            {
                // Obtener todos los nodos en orden jerárquico y agregarlos a la lista
                foreach (var item in arbol.PreOrdenJerarquico(arbol.Raiz))
                {
                    lsbArbol.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Calcula y muestra el nivel de un nodo en el árbol organizativo
        /// </summary>
        /// <param name="sender">Objeto que generó el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnNivel_Click_1(object sender, EventArgs e)
        {
            // Obtener y validar el nombre del nodo
            string nombreNodo = tbNivel.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombreNodo))
            {
                MessageBox.Show("Ingrese un nombre de nodo.");
                return;
            }

            // Buscar el nivel del nodo (0 para la raíz)
            int nivel = arbol.Nivel(arbol.Raiz, nombreNodo, 0);

            // Mostrar resultado según si se encontró o no
            if (nivel != -1)
                MessageBox.Show($"El nodo '{nombreNodo}' está en el nivel {nivel}.");
            else
                MessageBox.Show($"El nodo '{nombreNodo}' no existe en el árbol.");
        }

        /// <summary>
        /// Busca un nodo en el árbol organizativo por nombre
        /// </summary>
        /// <param name="sender">Objeto que generó el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            // Buscar el nodo en el árbol empezando desde la raíz
            var encontrado = arbol.Buscar(arbol.Raiz, tbBuscar.Text.Trim());

            // Mostrar resultado de la búsqueda
            MessageBox.Show(encontrado != null ? "Nodo encontrado." : "No existe.");
        }

        /// <summary>
        /// Cuenta y muestra el total de nodos en el árbol organizativo
        /// </summary>
        /// <param name="sender">Objeto que generó el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnContar_Click_1(object sender, EventArgs e)
        {
            // Contar todos los nodos recursivamente desde la raíz
            int total = arbol.ContarNodos(arbol.Raiz);

            // Mostrar el resultado
            MessageBox.Show("Total de nodos: " + total);
        }

        /// <summary>
        /// Agrega un nuevo nodo hijo al árbol organizativo
        /// </summary>
        /// <param name="sender">Objeto que generó el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener nombres del padre e hijo desde los textboxes
            string nombrePadre = tbPadre.Text.Trim();
            string nombreHijo = tbHijo.Text.Trim();

            // Validar que ambos campos tengan datos
            if (string.IsNullOrWhiteSpace(nombrePadre) || string.IsNullOrWhiteSpace(nombreHijo))
            {
                MessageBox.Show("Ingrese nombre de padre y de hijo.");
                return;
            }

            // Buscar el nodo padre en el árbol
            var padre = arbol.Buscar(arbol.Raiz, nombrePadre);

            // Si se encontró el padre, agregar el hijo
            if (padre != null)
            {
                arbol.AgregarNodo(padre, nombreHijo);
                ActualizarListaArbol();  // Actualizar la visualización
                MessageBox.Show("Nodo agregado.");
            }
            else
            {
                MessageBox.Show("Padre no encontrado.");
            }
        }

        /// <summary>
        /// Actualiza la lista visual del grafo mostrando edificios y conexiones
        /// </summary>
        private void ActualizarListaGrafo()
        {
            // Limpiar la lista antes de actualizar
            lsbGrafo.Items.Clear();
            var edificios = grafo.ObtenerTodosLosNodos();

            // Verificar si hay edificios registrados
            if (edificios.Count == 0)
            {
                lsbGrafo.Items.Add("No hay edificios registrados.");
                return;
            }

            // Mostrar lista de todos los edificios
            lsbGrafo.Items.Add("=== LISTA DE EDIFICIOS ===");
            foreach (var edificio in edificios)
            {
                lsbGrafo.Items.Add($"🏢 {edificio}");
            }

            lsbGrafo.Items.Add("");
            lsbGrafo.Items.Add("=== CONEXIONES EXISTENTES ===");

            // Usar HashSet para evitar mostrar conexiones duplicadas (A→B y B→A)
            HashSet<string> conexionesMostradas = new HashSet<string>();
            bool hayConexiones = false;

            // Recorrer todos los nodos y sus conexiones
            foreach (var nodo in grafo.Ady.Keys)
            {
                foreach (var conexion in grafo.ObtenerConexiones(nodo))
                {
                    // Crear claves únicas para la conexión en ambos sentidos
                    string clave1 = $"{nodo}→{conexion.nodo}";
                    string clave2 = $"{conexion.nodo}→{nodo}";

                    // Mostrar la conexión solo si no se ha mostrado antes
                    if (!conexionesMostradas.Contains(clave1) && !conexionesMostradas.Contains(clave2))
                    {
                        lsbGrafo.Items.Add($"🛣️  {nodo} ↔ {conexion.nodo} ({conexion.distancia} m)");
                        conexionesMostradas.Add(clave1);
                        hayConexiones = true;
                    }
                }
            }

            // Mensaje si no hay conexiones
            if (!hayConexiones)
            {
                lsbGrafo.Items.Add("No hay conexiones entre edificios.");
            }
        }

        /// <summary>
        /// Agrega una nueva conexión entre dos edificios en el grafo
        /// </summary>
        /// <param name="sender">Objeto que generó el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void AgregarConexion_Click(object sender, EventArgs e)
        {
            // Obtener origen y destino desde los textboxes
            string origen = tbOrigen.Text.Trim();
            string destino = tbDestino.Text.Trim();

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(origen) || string.IsNullOrWhiteSpace(destino))
            {
                MessageBox.Show("Ingrese origen y destino.");
                return;
            }

            // Evitar conexión de un edificio consigo mismo
            if (origen == destino)
            {
                MessageBox.Show("El origen y destino no pueden ser iguales.");
                return;
            }

            // Verificar que el edificio origen exista
            if (!grafo.ExisteNodo(origen))
            {
                MessageBox.Show($"El edificio '{origen}' no existe. Agreguelo primero.");
                return;
            }

            // Verificar que el edificio destino exista
            if (!grafo.ExisteNodo(destino))
            {
                MessageBox.Show($"El edificio '{destino}' no existe. Agreguelo primero.");
                return;
            }

            // Validar que la distancia sea un número positivo
            if (!int.TryParse(tbDistancia.Text.Trim(), out int distancia) || distancia <= 0)
            {
                MessageBox.Show("Ingrese una distancia válida mayor a 0.");
                return;
            }

            // Agregar la conexión bidireccional al grafo
            grafo.AgregarConexion(origen, destino, distancia);
            MessageBox.Show($"Conexión agregada: {origen} ↔ {destino} ({distancia} m)");
            ActualizarListaGrafo();

            // Limpiar campos para nueva entrada
            tbOrigen.Clear();
            tbDestino.Clear();
            tbDistancia.Clear();
        }

        /// <summary>
        /// Calcula y muestra la ruta más corta entre dos edificios usando el algoritmo de Dijkstra
        /// </summary>
        /// <param name="sender">Objeto que generó el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void tbRuta_Click(object sender, EventArgs e)
        {
            // Obtener puntos de inicio y fin desde los textboxes
            string inicio = tbInicio.Text.Trim();
            string fin = tbFin.Text.Trim();

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(inicio) || string.IsNullOrWhiteSpace(fin))
            {
                MessageBox.Show("Ingrese inicio y fin.");
                return;
            }

            // Verificar que el edificio de inicio exista
            if (!grafo.ExisteNodo(inicio))
            {
                MessageBox.Show($"El edificio '{inicio}' no existe.");
                return;
            }

            // Verificar que el edificio de fin exista
            if (!grafo.ExisteNodo(fin))
            {
                MessageBox.Show($"El edificio '{fin}' no existe.");
                return;
            }

            try
            {
                // Calcular ruta más corta usando Dijkstra
                var res = grafo.Dijkstra(inicio, fin);

                // Verificar si existe una ruta válida
                if (res == null || res.Ruta.Count == 0 || res.DistanciaTotal == int.MaxValue)
                {
                    MessageBox.Show("No hay ruta entre esos edificios.");
                    return;
                }

                // Mostrar la ruta y distancia total
                MessageBox.Show($"Ruta más corta:\n{string.Join(" → ", res.Ruta)}\n\nDistancia Total: {res.DistanciaTotal} m");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la ruta: " + ex.Message);
            }
        }

        /// <summary>
        /// Valida si el grafo es conexo (todos los edificios están conectados)
        /// </summary>
        /// <param name="sender">Objeto que generó el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void tbValidarConexo_Click(object sender, EventArgs e)
        {
            // Verificar si el grafo es conexo usando BFS
            bool esConexo = grafo.EsConexo();

            // Mostrar resultado de la validación
            MessageBox.Show(esConexo ?
                "El grafo es conexo. Todos los edificios están conectados." :
                "El grafo NO es conexo. Hay edificios aislados.");
        }

        /// <summary>
        /// Muestra las conexiones específicas de un edificio en particular
        /// </summary>
        /// <param name="sender">Objeto que generó el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnMostrarConexiones_Click_1(object sender, EventArgs e)
        {
            // Obtener nombre del edificio desde el textbox
            string nodo = tbMostrarNodo.Text.Trim();

            // Validar campo obligatorio
            if (string.IsNullOrWhiteSpace(nodo))
            {
                MessageBox.Show("Ingrese un nombre de edificio.");
                return;
            }

            // Verificar que el edificio exista
            if (!grafo.ExisteNodo(nodo))
            {
                MessageBox.Show($"El edificio '{nodo}' no existe.");
                return;
            }

            // Limpiar lista antes de mostrar nuevas conexiones
            lsbGrafo.Items.Clear();

            // Obtener todas las conexiones del edificio
            var conexiones = grafo.ObtenerConexiones(nodo);

            // Verificar si tiene conexiones
            if (conexiones.Count == 0)
            {
                lsbGrafo.Items.Add($"El edificio '{nodo}' no tiene conexiones.");
                return;
            }

            // Mostrar encabezado y lista de conexiones
            lsbGrafo.Items.Add($"=== CONEXIONES DE {nodo.ToUpper()} ===");
            foreach (var c in conexiones)
                lsbGrafo.Items.Add($"  → {c.nodo} (distancia: {c.distancia} m)");
        }

        /// <summary>
        /// Agrega un nuevo edificio al grafo
        /// </summary>
        /// <param name="sender">Objeto que generó el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnAgregarEdificio_Click(object sender, EventArgs e)
        {
            // Obtener nombre del nuevo edificio
            string nombreEdificio = tbNombreEdificio.Text.Trim();

            // Validar campo obligatorio
            if (string.IsNullOrWhiteSpace(nombreEdificio))
            {
                MessageBox.Show("Ingrese un nombre para el edificio.");
                return;
            }

            // Verificar que el edificio no exista previamente
            if (grafo.ExisteNodo(nombreEdificio))
            {
                MessageBox.Show("El edificio ya existe.");
                return;
            }

            // Agregar el nuevo edificio al grafo
            grafo.AgregarNodo(nombreEdificio);

            // Actualizar la visualización y mostrar confirmación
            ActualizarListaGrafo();
            MessageBox.Show($"Edificio '{nombreEdificio}' agregado correctamente.");

            // Limpiar el textbox para nueva entrada
            tbNombreEdificio.Clear();
        }
    }
}