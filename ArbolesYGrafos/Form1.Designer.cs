namespace ArbolesYGrafos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsbArbol = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNivel = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNivel = new System.Windows.Forms.Button();
            this.btnContar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.tbHijo = new System.Windows.Forms.TextBox();
            this.tbPadre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNombreEdificio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbRuta = new System.Windows.Forms.Button();
            this.btnMostrarConexiones = new System.Windows.Forms.Button();
            this.tbValidarConexo = new System.Windows.Forms.Button();
            this.tbFin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbInicio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMostrarNodo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lsbGrafo = new System.Windows.Forms.ListBox();
            this.tbDistancia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AgregarConexion = new System.Windows.Forms.Button();
            this.tbDestino = new System.Windows.Forms.TextBox();
            this.tbOrigen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregarEdificio = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbArbol);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNivel);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnNivel);
            this.groupBox1.Controls.Add(this.btnContar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.tbBuscar);
            this.groupBox1.Controls.Add(this.tbHijo);
            this.groupBox1.Controls.Add(this.tbPadre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 547);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arbol Organizativo";
            // 
            // lsbArbol
            // 
            this.lsbArbol.FormattingEnabled = true;
            this.lsbArbol.ItemHeight = 16;
            this.lsbArbol.Location = new System.Drawing.Point(9, 217);
            this.lsbArbol.Name = "lsbArbol";
            this.lsbArbol.Size = new System.Drawing.Size(397, 324);
            this.lsbArbol.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nivel:";
            // 
            // tbNivel
            // 
            this.tbNivel.Location = new System.Drawing.Point(56, 169);
            this.tbNivel.Name = "tbNivel";
            this.tbNivel.Size = new System.Drawing.Size(144, 22);
            this.tbNivel.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(226, 98);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(141, 27);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // btnNivel
            // 
            this.btnNivel.Location = new System.Drawing.Point(226, 169);
            this.btnNivel.Name = "btnNivel";
            this.btnNivel.Size = new System.Drawing.Size(141, 27);
            this.btnNivel.TabIndex = 7;
            this.btnNivel.Text = "Obtener Nivel";
            this.btnNivel.UseVisualStyleBackColor = true;
            this.btnNivel.Click += new System.EventHandler(this.btnNivel_Click_1);
            // 
            // btnContar
            // 
            this.btnContar.Location = new System.Drawing.Point(226, 131);
            this.btnContar.Name = "btnContar";
            this.btnContar.Size = new System.Drawing.Size(141, 32);
            this.btnContar.TabIndex = 6;
            this.btnContar.Text = "Contar Nodos";
            this.btnContar.UseVisualStyleBackColor = true;
            this.btnContar.Click += new System.EventHandler(this.btnContar_Click_1);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(226, 59);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(141, 33);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar Nodo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // tbBuscar
            // 
            this.tbBuscar.Location = new System.Drawing.Point(56, 103);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(144, 22);
            this.tbBuscar.TabIndex = 4;
            // 
            // tbHijo
            // 
            this.tbHijo.Location = new System.Drawing.Point(56, 64);
            this.tbHijo.Name = "tbHijo";
            this.tbHijo.Size = new System.Drawing.Size(144, 22);
            this.tbHijo.TabIndex = 3;
            // 
            // tbPadre
            // 
            this.tbPadre.Location = new System.Drawing.Point(59, 28);
            this.tbPadre.Name = "tbPadre";
            this.tbPadre.Size = new System.Drawing.Size(144, 22);
            this.tbPadre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hijo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Padre:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregarEdificio);
            this.groupBox2.Controls.Add(this.tbNombreEdificio);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbRuta);
            this.groupBox2.Controls.Add(this.btnMostrarConexiones);
            this.groupBox2.Controls.Add(this.tbValidarConexo);
            this.groupBox2.Controls.Add(this.tbFin);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbInicio);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbMostrarNodo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lsbGrafo);
            this.groupBox2.Controls.Add(this.tbDistancia);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.AgregarConexion);
            this.groupBox2.Controls.Add(this.tbDestino);
            this.groupBox2.Controls.Add(this.tbOrigen);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(430, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 547);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grafo";
            // 
            // tbNombreEdificio
            // 
            this.tbNombreEdificio.Location = new System.Drawing.Point(118, 28);
            this.tbNombreEdificio.Name = "tbNombreEdificio";
            this.tbNombreEdificio.Size = new System.Drawing.Size(144, 22);
            this.tbNombreEdificio.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Agregar Edificio:";
            // 
            // tbRuta
            // 
            this.tbRuta.Location = new System.Drawing.Point(291, 141);
            this.tbRuta.Name = "tbRuta";
            this.tbRuta.Size = new System.Drawing.Size(138, 27);
            this.tbRuta.TabIndex = 21;
            this.tbRuta.Text = "Ruta mas corta";
            this.tbRuta.UseVisualStyleBackColor = true;
            this.tbRuta.Click += new System.EventHandler(this.tbRuta_Click);
            // 
            // btnMostrarConexiones
            // 
            this.btnMostrarConexiones.Location = new System.Drawing.Point(291, 108);
            this.btnMostrarConexiones.Name = "btnMostrarConexiones";
            this.btnMostrarConexiones.Size = new System.Drawing.Size(138, 27);
            this.btnMostrarConexiones.TabIndex = 20;
            this.btnMostrarConexiones.Text = "Mostrar Ruta";
            this.btnMostrarConexiones.UseVisualStyleBackColor = true;
            this.btnMostrarConexiones.Click += new System.EventHandler(this.btnMostrarConexiones_Click_1);
            // 
            // tbValidarConexo
            // 
            this.tbValidarConexo.Location = new System.Drawing.Point(291, 174);
            this.tbValidarConexo.Name = "tbValidarConexo";
            this.tbValidarConexo.Size = new System.Drawing.Size(138, 27);
            this.tbValidarConexo.TabIndex = 19;
            this.tbValidarConexo.Text = "Validar Conexo";
            this.tbValidarConexo.UseVisualStyleBackColor = true;
            this.tbValidarConexo.Click += new System.EventHandler(this.tbValidarConexo_Click);
            // 
            // tbFin
            // 
            this.tbFin.Location = new System.Drawing.Point(173, 174);
            this.tbFin.Name = "tbFin";
            this.tbFin.Size = new System.Drawing.Size(82, 22);
            this.tbFin.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Fin:";
            // 
            // tbInicio
            // 
            this.tbInicio.Location = new System.Drawing.Point(53, 172);
            this.tbInicio.Name = "tbInicio";
            this.tbInicio.Size = new System.Drawing.Size(82, 22);
            this.tbInicio.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Inicio:";
            // 
            // tbMostrarNodo
            // 
            this.tbMostrarNodo.Location = new System.Drawing.Point(111, 131);
            this.tbMostrarNodo.Name = "tbMostrarNodo";
            this.tbMostrarNodo.Size = new System.Drawing.Size(144, 22);
            this.tbMostrarNodo.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Nodo a mostar:";
            // 
            // lsbGrafo
            // 
            this.lsbGrafo.FormattingEnabled = true;
            this.lsbGrafo.ItemHeight = 16;
            this.lsbGrafo.Location = new System.Drawing.Point(9, 217);
            this.lsbGrafo.Name = "lsbGrafo";
            this.lsbGrafo.Size = new System.Drawing.Size(416, 324);
            this.lsbGrafo.TabIndex = 12;
            // 
            // tbDistancia
            // 
            this.tbDistancia.Location = new System.Drawing.Point(372, 86);
            this.tbDistancia.Name = "tbDistancia";
            this.tbDistancia.Size = new System.Drawing.Size(57, 22);
            this.tbDistancia.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Distancia (en metros):";
            // 
            // AgregarConexion
            // 
            this.AgregarConexion.Location = new System.Drawing.Point(229, 53);
            this.AgregarConexion.Name = "AgregarConexion";
            this.AgregarConexion.Size = new System.Drawing.Size(133, 30);
            this.AgregarConexion.TabIndex = 4;
            this.AgregarConexion.Text = "Agregar Conexion";
            this.AgregarConexion.UseVisualStyleBackColor = true;
            this.AgregarConexion.Click += new System.EventHandler(this.AgregarConexion_Click);
            // 
            // tbDestino
            // 
            this.tbDestino.Location = new System.Drawing.Point(68, 89);
            this.tbDestino.Name = "tbDestino";
            this.tbDestino.Size = new System.Drawing.Size(144, 22);
            this.tbDestino.TabIndex = 3;
            // 
            // tbOrigen
            // 
            this.tbOrigen.Location = new System.Drawing.Point(68, 53);
            this.tbOrigen.Name = "tbOrigen";
            this.tbOrigen.Size = new System.Drawing.Size(144, 22);
            this.tbOrigen.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Destino:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Origen:";
            // 
            // btnAgregarEdificio
            // 
            this.btnAgregarEdificio.Location = new System.Drawing.Point(268, 21);
            this.btnAgregarEdificio.Name = "btnAgregarEdificio";
            this.btnAgregarEdificio.Size = new System.Drawing.Size(157, 31);
            this.btnAgregarEdificio.TabIndex = 24;
            this.btnAgregarEdificio.Text = "Agregar Edificio";
            this.btnAgregarEdificio.UseVisualStyleBackColor = true;
            this.btnAgregarEdificio.Click += new System.EventHandler(this.btnAgregarEdificio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 571);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lsbArbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNivel;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNivel;
        private System.Windows.Forms.Button btnContar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.TextBox tbHijo;
        private System.Windows.Forms.TextBox tbPadre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AgregarConexion;
        private System.Windows.Forms.TextBox tbDestino;
        private System.Windows.Forms.TextBox tbOrigen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDistancia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lsbGrafo;
        private System.Windows.Forms.TextBox tbInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMostrarNodo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button tbRuta;
        private System.Windows.Forms.Button btnMostrarConexiones;
        private System.Windows.Forms.Button tbValidarConexo;
        private System.Windows.Forms.TextBox tbNombreEdificio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAgregarEdificio;
    }
}

