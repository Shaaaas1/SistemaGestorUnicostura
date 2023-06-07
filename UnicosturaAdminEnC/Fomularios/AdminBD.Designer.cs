namespace UnicosturaAdminEnC
{
    partial class AdminBD
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
            this.Btn_AdminTallas = new System.Windows.Forms.Button();
            this.btn_NumeroMoldes = new System.Windows.Forms.Button();
            this.btn_TipoPago = new System.Windows.Forms.Button();
            this.btn_Distribucion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_AdminTallas
            // 
            this.Btn_AdminTallas.Location = new System.Drawing.Point(12, 12);
            this.Btn_AdminTallas.Name = "Btn_AdminTallas";
            this.Btn_AdminTallas.Size = new System.Drawing.Size(227, 100);
            this.Btn_AdminTallas.TabIndex = 0;
            this.Btn_AdminTallas.Text = "Administrar Tallas";
            this.Btn_AdminTallas.UseVisualStyleBackColor = true;
            this.Btn_AdminTallas.Click += new System.EventHandler(this.Btn_AdminTallas_Click);
            // 
            // btn_NumeroMoldes
            // 
            this.btn_NumeroMoldes.Location = new System.Drawing.Point(12, 220);
            this.btn_NumeroMoldes.Name = "btn_NumeroMoldes";
            this.btn_NumeroMoldes.Size = new System.Drawing.Size(476, 100);
            this.btn_NumeroMoldes.TabIndex = 1;
            this.btn_NumeroMoldes.Text = "Numero de Moldes";
            this.btn_NumeroMoldes.UseVisualStyleBackColor = true;
            this.btn_NumeroMoldes.Click += new System.EventHandler(this.btn_NumeroMoldes_Click);
            // 
            // btn_TipoPago
            // 
            this.btn_TipoPago.Location = new System.Drawing.Point(12, 118);
            this.btn_TipoPago.Name = "btn_TipoPago";
            this.btn_TipoPago.Size = new System.Drawing.Size(227, 100);
            this.btn_TipoPago.TabIndex = 2;
            this.btn_TipoPago.Text = "Tipo de Pago";
            this.btn_TipoPago.UseVisualStyleBackColor = true;
            this.btn_TipoPago.Click += new System.EventHandler(this.btn_TipoPago_Click);
            // 
            // btn_Distribucion
            // 
            this.btn_Distribucion.Location = new System.Drawing.Point(261, 118);
            this.btn_Distribucion.Name = "btn_Distribucion";
            this.btn_Distribucion.Size = new System.Drawing.Size(227, 100);
            this.btn_Distribucion.TabIndex = 3;
            this.btn_Distribucion.Text = "Distribucion";
            this.btn_Distribucion.UseVisualStyleBackColor = true;
            this.btn_Distribucion.Click += new System.EventHandler(this.btn_Distribucion_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 100);
            this.button1.TabIndex = 4;
            this.button1.Text = "Administar Repartidores";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 332);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Distribucion);
            this.Controls.Add(this.btn_TipoPago);
            this.Controls.Add(this.btn_NumeroMoldes);
            this.Controls.Add(this.Btn_AdminTallas);
            this.Name = "AdminBD";
            this.Text = "AdminBD";
            this.Load += new System.EventHandler(this.AdminBD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_AdminTallas;
        private System.Windows.Forms.Button btn_NumeroMoldes;
        private System.Windows.Forms.Button btn_TipoPago;
        private System.Windows.Forms.Button btn_Distribucion;
        private System.Windows.Forms.Button button1;
    }
}