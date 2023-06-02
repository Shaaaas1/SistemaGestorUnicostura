namespace UnicosturaAdminEnC
{
    partial class SistemaGestorUnicostura
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_AdminClientes = new System.Windows.Forms.Button();
            this.btn_AdminPedidos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 95);
            this.button1.TabIndex = 0;
            this.button1.Text = "Administrar Base de Datos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Btn_AdministrarBaseDeDatos);
            // 
            // btn_AdminClientes
            // 
            this.btn_AdminClientes.Location = new System.Drawing.Point(344, 135);
            this.btn_AdminClientes.Name = "btn_AdminClientes";
            this.btn_AdminClientes.Size = new System.Drawing.Size(208, 95);
            this.btn_AdminClientes.TabIndex = 1;
            this.btn_AdminClientes.Text = "Administrar Clientes";
            this.btn_AdminClientes.UseVisualStyleBackColor = true;
            // 
            // btn_AdminPedidos
            // 
            this.btn_AdminPedidos.Location = new System.Drawing.Point(344, 34);
            this.btn_AdminPedidos.Name = "btn_AdminPedidos";
            this.btn_AdminPedidos.Size = new System.Drawing.Size(208, 95);
            this.btn_AdminPedidos.TabIndex = 2;
            this.btn_AdminPedidos.Text = "Administrar Pedidos";
            this.btn_AdminPedidos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "SISTEMA GESTOR DE PEDIDOS:\r\nUNICOSTURA - TALCAHUANO";
            this.label1.UseWaitCursor = true;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SistemaGestorUnicostura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 350);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_AdminPedidos);
            this.Controls.Add(this.btn_AdminClientes);
            this.Controls.Add(this.button1);
            this.Name = "SistemaGestorUnicostura";
            this.Text = "Sistema Gestor de Unicostura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_AdminClientes;
        private System.Windows.Forms.Button btn_AdminPedidos;
        private System.Windows.Forms.Label label1;
    }
}

