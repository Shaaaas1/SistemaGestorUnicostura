namespace UnicosturaAdminEnC
{
    partial class AdministarClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_IdCliente = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbx_NombreCliente = new System.Windows.Forms.TextBox();
            this.tbx_NumeroCliente = new System.Windows.Forms.TextBox();
            this.tbx_Direccion = new System.Windows.Forms.TextBox();
            this.tbx_Rut = new System.Windows.Forms.TextBox();
            this.tbx_Alias = new System.Windows.Forms.TextBox();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_EliminardeGrilla = new System.Windows.Forms.Button();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbx_Fuente = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rut";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Alias";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fuente";
            // 
            // tbx_IdCliente
            // 
            this.tbx_IdCliente.AutoSize = true;
            this.tbx_IdCliente.Location = new System.Drawing.Point(130, 18);
            this.tbx_IdCliente.Name = "tbx_IdCliente";
            this.tbx_IdCliente.Size = new System.Drawing.Size(65, 13);
            this.tbx_IdCliente.TabIndex = 7;
            this.tbx_IdCliente.Text = "txt_IdCliente";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 189);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // tbx_NombreCliente
            // 
            this.tbx_NombreCliente.Location = new System.Drawing.Point(95, 39);
            this.tbx_NombreCliente.Name = "tbx_NombreCliente";
            this.tbx_NombreCliente.Size = new System.Drawing.Size(100, 20);
            this.tbx_NombreCliente.TabIndex = 9;
            // 
            // tbx_NumeroCliente
            // 
            this.tbx_NumeroCliente.Location = new System.Drawing.Point(95, 68);
            this.tbx_NumeroCliente.Name = "tbx_NumeroCliente";
            this.tbx_NumeroCliente.Size = new System.Drawing.Size(100, 20);
            this.tbx_NumeroCliente.TabIndex = 10;
            // 
            // tbx_Direccion
            // 
            this.tbx_Direccion.Location = new System.Drawing.Point(95, 94);
            this.tbx_Direccion.Name = "tbx_Direccion";
            this.tbx_Direccion.Size = new System.Drawing.Size(100, 20);
            this.tbx_Direccion.TabIndex = 11;
            // 
            // tbx_Rut
            // 
            this.tbx_Rut.Location = new System.Drawing.Point(247, 68);
            this.tbx_Rut.Name = "tbx_Rut";
            this.tbx_Rut.Size = new System.Drawing.Size(100, 20);
            this.tbx_Rut.TabIndex = 12;
            // 
            // tbx_Alias
            // 
            this.tbx_Alias.Location = new System.Drawing.Point(247, 98);
            this.tbx_Alias.Name = "tbx_Alias";
            this.tbx_Alias.Size = new System.Drawing.Size(100, 20);
            this.tbx_Alias.TabIndex = 13;
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(207, 37);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_Agregar.TabIndex = 15;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(288, 37);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 16;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Location = new System.Drawing.Point(369, 38);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(75, 23);
            this.btn_Modificar.TabIndex = 17;
            this.btn_Modificar.Text = "Modificar";
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(450, 38);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar.TabIndex = 18;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_EliminardeGrilla
            // 
            this.btn_EliminardeGrilla.Location = new System.Drawing.Point(671, 122);
            this.btn_EliminardeGrilla.Name = "btn_EliminardeGrilla";
            this.btn_EliminardeGrilla.Size = new System.Drawing.Size(101, 23);
            this.btn_EliminardeGrilla.TabIndex = 19;
            this.btn_EliminardeGrilla.Text = "Eliminar de Grilla";
            this.btn_EliminardeGrilla.UseVisualStyleBackColor = true;
            this.btn_EliminardeGrilla.Click += new System.EventHandler(this.btn_EliminardeGrilla_Click);
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.Location = new System.Drawing.Point(13, 120);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(101, 23);
            this.btn_Actualizar.TabIndex = 20;
            this.btn_Actualizar.Text = "Actualizar";
            this.btn_Actualizar.UseVisualStyleBackColor = true;
            this.btn_Actualizar.Click += new System.EventHandler(this.btn_Actualizar_Click);
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataSource = typeof(UnicosturaAdminEnC.Clases.Cliente);
            // 
            // tbx_Fuente
            // 
            this.tbx_Fuente.FormattingEnabled = true;
            this.tbx_Fuente.Items.AddRange(new object[] {
            "Celular Unicose",
            "Celular Vero",
            "Messenger Unicose",
            "Messenger Vero",
            "Mary"});
            this.tbx_Fuente.Location = new System.Drawing.Point(399, 68);
            this.tbx_Fuente.Name = "tbx_Fuente";
            this.tbx_Fuente.Size = new System.Drawing.Size(121, 21);
            this.tbx_Fuente.TabIndex = 21;
            // 
            // AdministarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 348);
            this.Controls.Add(this.tbx_Fuente);
            this.Controls.Add(this.btn_Actualizar);
            this.Controls.Add(this.btn_EliminardeGrilla);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.tbx_Alias);
            this.Controls.Add(this.tbx_Rut);
            this.Controls.Add(this.tbx_Direccion);
            this.Controls.Add(this.tbx_NumeroCliente);
            this.Controls.Add(this.tbx_NombreCliente);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbx_IdCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdministarClientes";
            this.Text = "AdministarClientes";
            this.Load += new System.EventHandler(this.AdministarClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label tbx_IdCliente;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbx_NombreCliente;
        private System.Windows.Forms.TextBox tbx_NumeroCliente;
        private System.Windows.Forms.TextBox tbx_Direccion;
        private System.Windows.Forms.TextBox tbx_Rut;
        private System.Windows.Forms.TextBox tbx_Alias;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_EliminardeGrilla;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}