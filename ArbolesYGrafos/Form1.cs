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
    public partial class Form1 : Form
    {
        private OrgTree arbol;
        Graph grafo;
        public Form1()
        {
            InitializeComponent();
            arbol = new OrgTree("Innovatec");
            grafo = new Graph();
            ActualizarListaArbol();
        }
        private void ActualizarListaArbol()
        {
            lsbArbol.Items.Clear();

            if (arbol.Raiz != null)
            {

                foreach (var item in arbol.PreOrdenJerarquico(arbol.Raiz))
                {
                    lsbArbol.Items.Add(item);
                }
            }
        }
        private void btnNivel_Click_1(object sender, EventArgs e)
        {
            string nombreNodo = tbNivel.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombreNodo))
            {
                MessageBox.Show("Ingrese un nombre de nodo.");
                return;
            }

            int nivel = arbol.Nivel(arbol.Raiz, nombreNodo, 0);
            if (nivel != -1)
                MessageBox.Show($"El nodo '{nombreNodo}' está en el nivel {nivel}.");
            else
                MessageBox.Show($"El nodo '{nombreNodo}' no existe en el árbol.");
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            var encontrado = arbol.Buscar(arbol.Raiz, tbBuscar.Text.Trim());
            MessageBox.Show(encontrado != null ? "Nodo encontrado." : "No existe.");
        }

        private void btnContar_Click_1(object sender, EventArgs e)
        {
            int total = arbol.ContarNodos(arbol.Raiz);
            MessageBox.Show("Total de nodos: " + total);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombrePadre = tbPadre.Text.Trim();
            string nombreHijo = tbHijo.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombrePadre) || string.IsNullOrWhiteSpace(nombreHijo))
            {
                MessageBox.Show("Ingrese nombre de padre y de hijo.");
                return;
            }

            var padre = arbol.Buscar(arbol.Raiz, nombrePadre);

            if (padre != null)
            {
                arbol.AgregarNodo(padre, nombreHijo);
                ActualizarListaArbol();  // Actualizar automáticamente
                MessageBox.Show("Nodo agregado.");
            }
            else
            {
                MessageBox.Show("Padre no encontrado.");
            }
        }

        private void ActualizarListaGrafo()
        {
            lsbGrafo.Items.Clear();
            var edificios = grafo.ObtenerTodosLosNodos();

            if (edificios.Count == 0)
            {
                lsbGrafo.Items.Add("No hay edificios registrados.");
                return;
            }

            lsbGrafo.Items.Add("=== LISTA DE EDIFICIOS ===");
            foreach (var edificio in edificios)
            {
                lsbGrafo.Items.Add($"🏢 {edificio}");
            }

            lsbGrafo.Items.Add("");
            lsbGrafo.Items.Add("=== CONEXIONES EXISTENTES ===");

            HashSet<string> conexionesMostradas = new HashSet<string>();
            bool hayConexiones = false;

            foreach (var nodo in grafo.Ady.Keys)
            {
                foreach (var conexion in grafo.ObtenerConexiones(nodo))
                {
                    string clave1 = $"{nodo}→{conexion.nodo}";
                    string clave2 = $"{conexion.nodo}→{nodo}";

                    if (!conexionesMostradas.Contains(clave1) && !conexionesMostradas.Contains(clave2))
                    {
                        lsbGrafo.Items.Add($"🛣️  {nodo} ↔ {conexion.nodo} ({conexion.distancia} m)");
                        conexionesMostradas.Add(clave1);
                        hayConexiones = true;
                    }
                }
            }

            if (!hayConexiones)
            {
                lsbGrafo.Items.Add("No hay conexiones entre edificios.");
            }
        }

        private void AgregarConexion_Click(object sender, EventArgs e)
        {
            string origen = tbOrigen.Text.Trim();
            string destino = tbDestino.Text.Trim();

            if (string.IsNullOrWhiteSpace(origen) || string.IsNullOrWhiteSpace(destino))
            {
                MessageBox.Show("Ingrese origen y destino.");
                return;
            }

            if (origen == destino)
            {
                MessageBox.Show("El origen y destino no pueden ser iguales.");
                return;
            }

            // Verificar que ambos edificios existan
            if (!grafo.ExisteNodo(origen))
            {
                MessageBox.Show($"El edificio '{origen}' no existe. Agreguelo primero.");
                return;
            }

            if (!grafo.ExisteNodo(destino))
            {
                MessageBox.Show($"El edificio '{destino}' no existe. Agreguelo primero.");
                return;
            }

            if (!int.TryParse(tbDistancia.Text.Trim(), out int distancia) || distancia <= 0)
            {
                MessageBox.Show("Ingrese una distancia válida mayor a 0.");
                return;
            }

            grafo.AgregarConexion(origen, destino, distancia);
            MessageBox.Show($"Conexión agregada: {origen} ↔ {destino} ({distancia} m)");
            ActualizarListaGrafo();

            // Limpiar campos
            tbOrigen.Clear();
            tbDestino.Clear();
            tbDistancia.Clear();
        }



        private void tbRuta_Click(object sender, EventArgs e)
        {
            string inicio = tbInicio.Text.Trim();
            string fin = tbFin.Text.Trim();

            if (string.IsNullOrWhiteSpace(inicio) || string.IsNullOrWhiteSpace(fin))
            {
                MessageBox.Show("Ingrese inicio y fin.");
                return;
            }

            // Verificar que los edificios existan
            if (!grafo.ExisteNodo(inicio))
            {
                MessageBox.Show($"El edificio '{inicio}' no existe.");
                return;
            }

            if (!grafo.ExisteNodo(fin))
            {
                MessageBox.Show($"El edificio '{fin}' no existe.");
                return;
            }

            try
            {
                var res = grafo.Dijkstra(inicio, fin);

                if (res == null || res.Ruta.Count == 0 || res.DistanciaTotal == int.MaxValue)
                {
                    MessageBox.Show("No hay ruta entre esos edificios.");
                    return;
                }

                MessageBox.Show($"Ruta más corta:\n{string.Join(" → ", res.Ruta)}\n\nDistancia Total: {res.DistanciaTotal} m");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la ruta: " + ex.Message);
            }
        }

        private void tbValidarConexo_Click(object sender, EventArgs e)
        {
            bool esConexo = grafo.EsConexo();
            MessageBox.Show(esConexo ?
                "El grafo es conexo. Todos los edificios están conectados." :
                "El grafo NO es conexo. Hay edificios aislados.");
        }
        private void btnMostrarConexiones_Click_1(object sender, EventArgs e)
        {
            string nodo = tbMostrarNodo.Text.Trim();

            if (string.IsNullOrWhiteSpace(nodo))
            {
                MessageBox.Show("Ingrese un nombre de edificio.");
                return;
            }

            if (!grafo.ExisteNodo(nodo))
            {
                MessageBox.Show($"El edificio '{nodo}' no existe.");
                return;
            }

            lsbGrafo.Items.Clear();

            var conexiones = grafo.ObtenerConexiones(nodo);
            if (conexiones.Count == 0)
            {
                lsbGrafo.Items.Add($"El edificio '{nodo}' no tiene conexiones.");
                return;
            }

            lsbGrafo.Items.Add($"=== CONEXIONES DE {nodo.ToUpper()} ===");
            foreach (var c in conexiones)
                lsbGrafo.Items.Add($"  → {c.nodo} (distancia: {c.distancia} m)");
        }

        private void btnAgregarEdificio_Click(object sender, EventArgs e)
        {
            string nombreEdificio = tbNombreEdificio.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreEdificio))
            {
                MessageBox.Show("Ingrese un nombre para el edificio.");
                return;
            }

            if (grafo.ExisteNodo(nombreEdificio))
            {
                MessageBox.Show("El edificio ya existe.");
                return;
            }

            grafo.AgregarNodo(nombreEdificio);
            ActualizarListaGrafo();
            MessageBox.Show($"Edificio '{nombreEdificio}' agregado correctamente.");

            tbNombreEdificio.Clear();
        }
    }
}