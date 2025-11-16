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
        private OrgTree arbol;
        public Form1()
        {
            InitializeComponent();
            arbol = new OrgTree("Innovatec");
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
    }
}
