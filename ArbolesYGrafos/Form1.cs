using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolesYGrafos
{
    public partial class Form1 : Form
    {
        // Declaración de variables para manejar el árbol organizativo y el grafo de rutas
        private OrgTree arbol;  // Instancia del árbol para la jerarquía organizativa
        private Graph grafo;    // Instancia del grafo para las rutas entre edificios

        // Constructor principal del formulario
        public Form1()
        {
            InitializeComponent(); 

            // Inicializar el árbol con "Innovatec" como nodo raíz de la organización
            arbol = new OrgTree("Innovatec");

            // Inicializar el grafo vacío para las conexiones entre edificios
            grafo = new Graph();

            // Actualizar la visualización del árbol en el TreeView
            ActualizarTreeViewArbol();
        }

        /// <summary>
        /// Actualiza el TreeView con la estructura completa del árbol organizativo
        /// </summary>
        private void ActualizarTreeViewArbol()
        {
            // Limpiar todos los nodos existentes en el TreeView
            tvArbol.Nodes.Clear();

            // Verificar que el árbol tenga una raíz antes de proceder
            if (arbol.Raiz != null)
            {
                // Crear el nodo raíz para el TreeView usando el nombre de la raíz del árbol
                System.Windows.Forms.TreeNode nodoRaiz = new System.Windows.Forms.TreeNode(arbol.Raiz.Nombre);

                // Agregar el nodo raíz al TreeView
                tvArbol.Nodes.Add(nodoRaiz);

                // Llamar al método recursivo para agregar todos los hijos de la raíz
                AgregarHijosTreeView(arbol.Raiz, nodoRaiz);

                // Expandir todos los nodos para que el usuario vea toda la estructura inmediatamente
                tvArbol.ExpandAll();
            }
        }

        /// <summary>
        /// Método recursivo para agregar hijos al TreeView
        /// </summary>
        /// <param name="nodoArbol">Nodo del árbol lógico (nuestra clase TreeNode)</param>
        /// <param name="nodoUI">Nodo del TreeView (TreeNode de Windows Forms)</param>
        private void AgregarHijosTreeView(TreeNode nodoArbol, System.Windows.Forms.TreeNode nodoUI)
        {
            // Recorrer cada hijo del nodo actual del árbol lógico
            foreach (var hijo in nodoArbol.Hijos)
            {
                // Crear un nuevo nodo en el TreeView para representar al hijo
                System.Windows.Forms.TreeNode hijoUI = new System.Windows.Forms.TreeNode(hijo.Nombre);

                // Agregar el nodo hijo al nodo padre en el TreeView
                nodoUI.Nodes.Add(hijoUI);

                // Llamar recursivamente a esta función para procesar los hijos del hijo actual
                // Esto construye todo el árbol de forma recursiva
                AgregarHijosTreeView(hijo, hijoUI);
            }
        }

        /// <summary>
        /// Maneja el evento de selección de nodo en el TreeView
        /// Cuando el usuario hace click en un nodo, se autocompletan los campos de texto
        /// </summary>
        private void treeViewArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Verificar que se haya seleccionado un nodo válido
            if (e.Node != null)
            {
                // Auto-completar los campos de texto con el nombre del nodo seleccionado
                // Esto facilita las operaciones al usuario evitando que tenga que escribir manualmente
                tbPadre.Text = e.Node.Text;   // Para agregar como padre
                tbBuscar.Text = e.Node.Text;  // Para buscar
                tbNivel.Text = e.Node.Text;   // Para calcular nivel
            }
        }

        /// <summary>
        /// Agrega un nuevo nodo hijo al árbol organizativo
        /// Se ejecuta cuando el usuario hace click en el botón "Agregar"
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los textos de los campos de entrada, eliminando espacios en blanco
            string nombrePadre = tbPadre.Text.Trim();
            string nombreHijo = tbHijo.Text.Trim();

            // Validar que ambos campos tengan contenido
            if (string.IsNullOrWhiteSpace(nombrePadre) || string.IsNullOrWhiteSpace(nombreHijo))
            {
                MessageBox.Show("Ingrese nombre de padre y de hijo.");
                return;  // Salir del método si la validación falla
            }

            // Buscar el nodo padre en el árbol comenzando desde la raíz
            var padre = arbol.Buscar(arbol.Raiz, nombrePadre);

            // Verificar si se encontró el nodo padre
            if (padre != null)
            {
                // Agregar el nuevo nodo hijo al padre encontrado
                arbol.AgregarNodo(padre, nombreHijo);

                // Actualizar la visualización del TreeView para reflejar el cambio
                ActualizarTreeViewArbol();

                // Notificar al usuario que la operación fue exitosa
                MessageBox.Show("Nodo agregado.");
            }
            else
            {
                // Informar al usuario que el nodo padre no existe
                MessageBox.Show("Padre no encontrado.");
            }
        }

        /// <summary>
        /// Busca un nodo en el árbol organizativo por nombre
        /// Se ejecuta cuando el usuario hace click en el botón "Buscar"
        /// </summary>
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            // Buscar el nodo en el árbol usando el texto del campo de búsqueda
            var encontrado = arbol.Buscar(arbol.Raiz, tbBuscar.Text.Trim());

            // Mostrar el resultado de la búsqueda usando operador ternario para mensaje condicional
            MessageBox.Show(encontrado != null ? "Nodo encontrado." : "No existe.");
        }

        /// <summary>
        /// Cuenta y muestra el total de nodos en el árbol organizativo
        /// Se ejecuta cuando el usuario hace click en el botón "Contar"
        /// </summary>
        private void btnContar_Click_1(object sender, EventArgs e)
        {
            // Llamar al método que cuenta todos los nodos recursivamente comenzando desde la raíz
            int total = arbol.ContarNodos(arbol.Raiz);

            // Mostrar el resultado del conteo al usuario
            MessageBox.Show("Total de nodos: " + total);
        }

        /// <summary>
        /// Calcula y muestra el nivel de un nodo en el árbol organizativo
        /// Se ejecuta cuando el usuario hace click en el botón "Nivel"
        /// </summary>
        private void btnNivel_Click_1(object sender, EventArgs e)
        {
            // Obtener el nombre del nodo cuyo nivel se quiere calcular
            string nombreNodo = tbNivel.Text.Trim();

            // Validar que se haya ingresado un nombre
            if (string.IsNullOrWhiteSpace(nombreNodo))
            {
                MessageBox.Show("Ingrese un nombre de nodo.");
                return;
            }

            // Calcular el nivel del nodo (0 para raíz, 1 para hijos directos, etc.)
            int nivel = arbol.Nivel(arbol.Raiz, nombreNodo, 0);

            // Mostrar el resultado según si se encontró o no el nodo
            if (nivel != -1)
                MessageBox.Show($"El nodo '{nombreNodo}' está en el nivel {nivel}.");
            else
                MessageBox.Show($"El nodo '{nombreNodo}' no existe en el árbol.");
        }

        /// <summary>
        /// Actualiza la lista visual del grafo mostrando edificios y conexiones
        /// Este método se llama cada vez que hay cambios en el grafo
        /// </summary>
        private void ActualizarListaGrafo()
        {
            // Limpiar todos los items existentes en el ListBox
            lsbGrafo.Items.Clear();

            // Obtener la lista de todos los edificios (nodos) registrados en el grafo
            var edificios = grafo.ObtenerTodosLosNodos();

            // Verificar si hay edificios registrados
            if (edificios.Count == 0)
            {
                lsbGrafo.Items.Add("No hay edificios registrados.");
                return;  // Salir si no hay edificios
            }

            // Agregar encabezado para la sección de edificios
            lsbGrafo.Items.Add("=== LISTA DE EDIFICIOS ===");

            // Recorrer y mostrar cada edificio con un icono
            foreach (var edificio in edificios)
            {
                lsbGrafo.Items.Add($"{edificio}");
            }

            // Agregar separador y encabezado para la sección de conexiones
            lsbGrafo.Items.Add("");
            lsbGrafo.Items.Add("=== CONEXIONES EXISTENTES ===");

            // Usar HashSet para evitar mostrar conexiones duplicadas (A→B y B→A)
            HashSet<string> conexionesMostradas = new HashSet<string>();
            bool hayConexiones = false;  // Bandera para verificar si hay al menos una conexión

            // Recorrer todos los nodos del grafo y sus conexiones
            foreach (var nodo in grafo.Ady.Keys)
            {
                foreach (var conexion in grafo.ObtenerConexiones(nodo))
                {
                    // Crear claves únicas para ambas direcciones de la conexión
                    string clave1 = $"{nodo}→{conexion.nodo}";
                    string clave2 = $"{conexion.nodo}→{nodo}";

                    // Verificar si esta conexión ya fue mostrada (en cualquier dirección)
                    if (!conexionesMostradas.Contains(clave1) && !conexionesMostradas.Contains(clave2))
                    {
                        // Agregar la conexión al ListBox con formato visual
                        lsbGrafo.Items.Add($"{nodo} ↔ {conexion.nodo} ({conexion.distancia} m)");

                        // Marcar esta conexión como mostrada
                        conexionesMostradas.Add(clave1);
                        hayConexiones = true;  // Indicar que existe al menos una conexión
                    }
                }
            }

            // Mostrar mensaje si no se encontraron conexiones
            if (!hayConexiones)
            {
                lsbGrafo.Items.Add("No hay conexiones entre edificios.");
            }
        }

        /// <summary>
        /// Agrega una nueva conexión entre dos edificios en el grafo
        /// Se ejecuta cuando el usuario hace click en el botón "Agregar Conexión"
        /// </summary>
        private void AgregarConexion_Click(object sender, EventArgs e)
        {
            // Obtener los nombres de origen y destino de los campos de texto
            string origen = tbOrigen.Text.Trim();
            string destino = tbDestino.Text.Trim();

            // Validar que ambos campos tengan contenido
            if (string.IsNullOrWhiteSpace(origen) || string.IsNullOrWhiteSpace(destino))
            {
                MessageBox.Show("Ingrese origen y destino.");
                return;
            }

            // Evitar que un edificio se conecte consigo mismo
            if (origen == destino)
            {
                MessageBox.Show("El origen y destino no pueden ser iguales.");
                return;
            }

            // Verificar que el edificio de origen exista en el grafo
            if (!grafo.ExisteNodo(origen))
            {
                MessageBox.Show($"El edificio '{origen}' no existe. Agreguelo primero.");
                return;
            }

            // Verificar que el edificio de destino exista en el grafo
            if (!grafo.ExisteNodo(destino))
            {
                MessageBox.Show($"El edificio '{destino}' no existe. Agreguelo primero.");
                return;
            }

            // Validar que la distancia sea un número entero positivo
            if (!int.TryParse(tbDistancia.Text.Trim(), out int distancia) || distancia <= 0)
            {
                MessageBox.Show("Ingrese una distancia válida mayor a 0.");
                return;
            }

            // Agregar la conexión bidireccional al grafo
            grafo.AgregarConexion(origen, destino, distancia);

            // Notificar al usuario del éxito de la operación
            MessageBox.Show($"Conexión agregada: {origen} ↔ {destino} ({distancia} m)");

            // Actualizar la visualización del grafo
            ActualizarListaGrafo();

            // Limpiar los campos de entrada para prepararlos para una nueva entrada
            tbOrigen.Clear();
            tbDestino.Clear();
            tbDistancia.Clear();
        }

        /// <summary>
        /// Calcula y muestra la ruta más corta entre dos edificios usando el algoritmo de Dijkstra
        /// Se ejecuta cuando el usuario hace click en el botón "Calcular Ruta"
        /// </summary>
        private void tbRuta_Click(object sender, EventArgs e)
        {
            // Obtener los puntos de inicio y fin de la ruta
            string inicio = tbInicio.Text.Trim();
            string fin = tbFin.Text.Trim();

            // Validar que ambos campos tengan contenido
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

            // Usar bloque try-catch para manejar posibles errores en el cálculo de la ruta
            try
            {
                // Ejecutar el algoritmo Dijkstra para encontrar la ruta más corta
                var res = grafo.Dijkstra(inicio, fin);

                // Verificar si se encontró una ruta válida
                if (res == null || res.Ruta.Count == 0 || res.DistanciaTotal == int.MaxValue)
                {
                    MessageBox.Show("No hay ruta entre esos edificios.");
                    return;
                }

                // Mostrar la ruta encontrada y la distancia total
                MessageBox.Show($"Ruta más corta:\n{string.Join(" → ", res.Ruta)}\n\nDistancia Total: {res.DistanciaTotal} m");
            }
            catch (Exception ex)
            {
                // Capturar y mostrar cualquier error que ocurra durante el cálculo
                MessageBox.Show("Error al calcular la ruta: " + ex.Message);
            }
        }

        /// <summary>
        /// Valida si el grafo es conexo (todos los edificios están conectados)
        /// Se ejecuta cuando el usuario hace click en el botón "Validar Conexo"
        /// </summary>
        private void tbValidarConexo_Click(object sender, EventArgs e)
        {
            // Llamar al método que verifica si el grafo es conexo usando BFS
            bool esConexo = grafo.EsConexo();

            // Mostrar el resultado usando operador ternario para mensaje condicional
            MessageBox.Show(esConexo ?
                "El grafo es conexo. Todos los edificios están conectados." :
                "El grafo NO es conexo. Hay edificios aislados.");
        }

        /// <summary>
        /// Muestra las conexiones específicas de un edificio en particular
        /// Se ejecuta cuando el usuario hace click en el botón "Mostrar Conexiones"
        /// </summary>
        private void btnMostrarConexiones_Click_1(object sender, EventArgs e)
        {
            // Obtener el nombre del edificio cuyas conexiones se quieren ver
            string nodo = tbMostrarNodo.Text.Trim();

            // Validar que se haya ingresado un nombre
            if (string.IsNullOrWhiteSpace(nodo))
            {
                MessageBox.Show("Ingrese un nombre de edificio.");
                return;
            }

            // Verificar que el edificio exista en el grafo
            if (!grafo.ExisteNodo(nodo))
            {
                MessageBox.Show($"El edificio '{nodo}' no existe.");
                return;
            }

            // Limpiar el ListBox antes de mostrar las nuevas conexiones
            lsbGrafo.Items.Clear();

            // Obtener todas las conexiones del edificio especificado
            var conexiones = grafo.ObtenerConexiones(nodo);

            // Verificar si el edificio tiene conexiones
            if (conexiones.Count == 0)
            {
                lsbGrafo.Items.Add($"El edificio '{nodo}' no tiene conexiones.");
                return;
            }

            // Agregar encabezado con el nombre del edificio en mayúsculas
            lsbGrafo.Items.Add($"=== CONEXIONES DE {nodo.ToUpper()} ===");

            // Recorrer y mostrar cada conexión con su distancia
            foreach (var c in conexiones)
                lsbGrafo.Items.Add($"  → {c.nodo} (distancia: {c.distancia} m)");
        }

        /// <summary>
        /// Agrega un nuevo edificio al grafo
        /// Se ejecuta cuando el usuario hace click en el botón "Agregar Edificio"
        /// </summary>
        private void btnAgregarEdificio_Click(object sender, EventArgs e)
        {
            // Obtener el nombre del nuevo edificio
            string nombreEdificio = tbNombreEdificio.Text.Trim();

            // Validar que se haya ingresado un nombre
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

            // Actualizar la visualización del grafo
            ActualizarListaGrafo();

            // Notificar al usuario del éxito de la operación
            MessageBox.Show($"Edificio '{nombreEdificio}' agregado correctamente.");

            // Limpiar el campo de texto para prepararlo para una nueva entrada
            tbNombreEdificio.Clear();
        }
    }
}