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
            this.groupBox1.SuspendLayout();
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
            this.lsbArbol.Size = new System.Drawing.Size(312, 324);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 571);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

