using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UnicosturaAdminEnC
{
    partial class AdministrarTallas
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_AgregarTalla = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_BuscarTalla = new System.Windows.Forms.Button();
            this.btn_ActualizarGrid = new System.Windows.Forms.Button();
            this.btn_EliminarTalla = new System.Windows.Forms.Button();
            this.Btn_EliminardeGrilla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 26);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de Talla:";
            // 
            // btn_AgregarTalla
            // 
            this.btn_AgregarTalla.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarTalla.Location = new System.Drawing.Point(146, 26);
            this.btn_AgregarTalla.Name = "btn_AgregarTalla";
            this.btn_AgregarTalla.Size = new System.Drawing.Size(127, 30);
            this.btn_AgregarTalla.TabIndex = 2;
            this.btn_AgregarTalla.Text = "Agregar";
            this.btn_AgregarTalla.UseVisualStyleBackColor = true;
            this.btn_AgregarTalla.Click += new System.EventHandler(this.btn_AgregarTalla_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(261, 411);
            this.dataGridView1.TabIndex = 3;
            // 
            // btn_BuscarTalla
            // 
            this.btn_BuscarTalla.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarTalla.Location = new System.Drawing.Point(279, 26);
            this.btn_BuscarTalla.Name = "btn_BuscarTalla";
            this.btn_BuscarTalla.Size = new System.Drawing.Size(155, 30);
            this.btn_BuscarTalla.TabIndex = 4;
            this.btn_BuscarTalla.Text = "Buscar";
            this.btn_BuscarTalla.UseVisualStyleBackColor = true;
            this.btn_BuscarTalla.Click += new System.EventHandler(this.btn_BuscarTalla_Click);
            // 
            // btn_ActualizarGrid
            // 
            this.btn_ActualizarGrid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ActualizarGrid.Location = new System.Drawing.Point(279, 62);
            this.btn_ActualizarGrid.Name = "btn_ActualizarGrid";
            this.btn_ActualizarGrid.Size = new System.Drawing.Size(155, 30);
            this.btn_ActualizarGrid.TabIndex = 5;
            this.btn_ActualizarGrid.Text = "Actualizar";
            this.btn_ActualizarGrid.UseVisualStyleBackColor = true;
            this.btn_ActualizarGrid.Click += new System.EventHandler(this.btn_ActualizarGrid_Click);
            // 
            // btn_EliminarTalla
            // 
            this.btn_EliminarTalla.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarTalla.Location = new System.Drawing.Point(279, 407);
            this.btn_EliminarTalla.Name = "btn_EliminarTalla";
            this.btn_EliminarTalla.Size = new System.Drawing.Size(155, 30);
            this.btn_EliminarTalla.TabIndex = 6;
            this.btn_EliminarTalla.Text = "Eliminar";
            this.btn_EliminarTalla.UseVisualStyleBackColor = true;
            this.btn_EliminarTalla.Click += new System.EventHandler(this.btn_EliminarTalla_Click);
            // 
            // Btn_EliminardeGrilla
            // 
            this.Btn_EliminardeGrilla.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_EliminardeGrilla.Location = new System.Drawing.Point(279, 443);
            this.Btn_EliminardeGrilla.Name = "Btn_EliminardeGrilla";
            this.Btn_EliminardeGrilla.Size = new System.Drawing.Size(155, 30);
            this.Btn_EliminardeGrilla.TabIndex = 7;
            this.Btn_EliminardeGrilla.Text = "Eliminar de Grilla";
            this.Btn_EliminardeGrilla.UseVisualStyleBackColor = true;
            this.Btn_EliminardeGrilla.Click += new System.EventHandler(this.Btn_EliminardeGrilla_Click);
            // 
            // AdministrarTallas
            // 
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(445, 485);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_AgregarTalla);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_BuscarTalla);
            this.Controls.Add(this.btn_ActualizarGrid);
            this.Controls.Add(this.btn_EliminarTalla);
            this.Controls.Add(this.Btn_EliminardeGrilla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdministrarTallas";
            this.Load += new System.EventHandler(this.AdministrarTallas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AgregarTalla;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_BuscarTalla;
        private System.Windows.Forms.Button btn_ActualizarGrid;
        private System.Windows.Forms.Button btn_EliminarTalla;
        private System.Windows.Forms.Button Btn_EliminardeGrilla;
    }
}