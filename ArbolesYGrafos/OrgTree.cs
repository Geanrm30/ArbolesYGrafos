using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesYGrafos
{
    public class TreeNode
    {
        public string Nombre { get; set; }
        public List<TreeNode> Hijos { get; set; }

        public TreeNode(string nombre)
        {
            Nombre = nombre;
            Hijos = new List<TreeNode>();
        }
    }
    public class OrgTree
    {
        public TreeNode Raiz { get; set; }

        public OrgTree(string nombreRaiz)
        {
            Raiz = new TreeNode(nombreRaiz);
        }

        public void AgregarNodo(TreeNode padre, string nombreHijo)
        {
            padre.Hijos.Add(new TreeNode(nombreHijo));
        }

        public TreeNode Buscar(TreeNode actual, string nombre)
        {
            if (actual.Nombre == nombre) return actual;

            foreach (var hijo in actual.Hijos)
            {
                var encontrado = Buscar(hijo, nombre);
                if (encontrado != null) return encontrado;
            }

            return null;
        }

        public int ContarNodos(TreeNode actual)
        {
            int total = 1;
            foreach (var hijo in actual.Hijos)
                total += ContarNodos(hijo);

            return total;
        }

        public int Nivel(TreeNode actual, string nombre, int nivel)
        {
            if (actual.Nombre == nombre) return nivel;

            foreach (var hijo in actual.Hijos)
            {
                int encontrado = Nivel(hijo, nombre, nivel + 1);
                if (encontrado != -1) return encontrado;
            }

            return -1;
        }

        public List<string> PreOrdenJerarquico(TreeNode actual, int nivel = 0)
        {
            List<string> lista = new List<string>();
            string indentacion = new string(' ', nivel * 3);
            lista.Add(indentacion + actual.Nombre);

            foreach (var hijo in actual.Hijos)
            {
                lista.AddRange(PreOrdenJerarquico(hijo, nivel + 1));
            }

            return lista;
        }
    }
}
