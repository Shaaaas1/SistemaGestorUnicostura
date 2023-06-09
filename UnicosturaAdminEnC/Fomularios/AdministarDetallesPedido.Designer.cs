namespace UnicosturaAdminEnC
{
    partial class AdministarDetallesPedido
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_IdDetallePedido = new System.Windows.Forms.Label();
            this.tbx_IdPedido = new System.Windows.Forms.Label();
            this.cbx_IdTalla = new System.Windows.Forms.ComboBox();
            this.tbx_CodigoMolde = new System.Windows.Forms.TextBox();
            this.chbx_MoldeEnStock = new System.Windows.Forms.CheckBox();
            this.chbx_MoldeFallido = new System.Windows.Forms.CheckBox();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chbx_PrecioVariable = new System.Windows.Forms.CheckBox();
            this.chbx_PrecioEspecial = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 257);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(855, 311);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "IdDetallePedido";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "IdPedido";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "IdTalla";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "CodigoMolde";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbx_IdDetallePedido
            // 
            this.tbx_IdDetallePedido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_IdDetallePedido.AutoSize = true;
            this.tbx_IdDetallePedido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_IdDetallePedido.Location = new System.Drawing.Point(144, 15);
            this.tbx_IdDetallePedido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tbx_IdDetallePedido.Name = "tbx_IdDetallePedido";
            this.tbx_IdDetallePedido.Size = new System.Drawing.Size(0, 19);
            this.tbx_IdDetallePedido.TabIndex = 7;
            this.tbx_IdDetallePedido.Click += new System.EventHandler(this.tbx_IdDetallePedido_Click);
            // 
            // tbx_IdPedido
            // 
            this.tbx_IdPedido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_IdPedido.AutoSize = true;
            this.tbx_IdPedido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_IdPedido.Location = new System.Drawing.Point(144, 64);
            this.tbx_IdPedido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tbx_IdPedido.Name = "tbx_IdPedido";
            this.tbx_IdPedido.Size = new System.Drawing.Size(110, 19);
            this.tbx_IdPedido.TabIndex = 8;
            this.tbx_IdPedido.Text = "tbx_IdPedido";
            this.tbx_IdPedido.Click += new System.EventHandler(this.tbx_IdPedido_Click);
            // 
            // cbx_IdTalla
            // 
            this.cbx_IdTalla.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbx_IdTalla.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_IdTalla.FormattingEnabled = true;
            this.cbx_IdTalla.Location = new System.Drawing.Point(144, 160);
            this.cbx_IdTalla.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbx_IdTalla.Name = "cbx_IdTalla";
            this.cbx_IdTalla.Size = new System.Drawing.Size(129, 27);
            this.cbx_IdTalla.TabIndex = 9;
            this.cbx_IdTalla.SelectedIndexChanged += new System.EventHandler(this.cbx_IdTalla_SelectedIndexChanged);
            // 
            // tbx_CodigoMolde
            // 
            this.tbx_CodigoMolde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_CodigoMolde.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_CodigoMolde.Location = new System.Drawing.Point(144, 111);
            this.tbx_CodigoMolde.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbx_CodigoMolde.Name = "tbx_CodigoMolde";
            this.tbx_CodigoMolde.Size = new System.Drawing.Size(129, 26);
            this.tbx_CodigoMolde.TabIndex = 10;
            this.tbx_CodigoMolde.TextChanged += new System.EventHandler(this.tbx_CodigoMolde_TextChanged);
            // 
            // chbx_MoldeEnStock
            // 
            this.chbx_MoldeEnStock.AutoSize = true;
            this.chbx_MoldeEnStock.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbx_MoldeEnStock.Location = new System.Drawing.Point(372, 112);
            this.chbx_MoldeEnStock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chbx_MoldeEnStock.Name = "chbx_MoldeEnStock";
            this.chbx_MoldeEnStock.Size = new System.Drawing.Size(139, 23);
            this.chbx_MoldeEnStock.TabIndex = 11;
            this.chbx_MoldeEnStock.Text = "MoldeEnStock";
            this.chbx_MoldeEnStock.UseVisualStyleBackColor = true;
            this.chbx_MoldeEnStock.CheckedChanged += new System.EventHandler(this.chbx_MoldeEnStock_CheckedChanged);
            // 
            // chbx_MoldeFallido
            // 
            this.chbx_MoldeFallido.AutoSize = true;
            this.chbx_MoldeFallido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbx_MoldeFallido.Location = new System.Drawing.Point(584, 112);
            this.chbx_MoldeFallido.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chbx_MoldeFallido.Name = "chbx_MoldeFallido";
            this.chbx_MoldeFallido.Size = new System.Drawing.Size(125, 23);
            this.chbx_MoldeFallido.TabIndex = 12;
            this.chbx_MoldeFallido.Text = "MoldeFallido";
            this.chbx_MoldeFallido.UseVisualStyleBackColor = true;
            this.chbx_MoldeFallido.CheckedChanged += new System.EventHandler(this.chbx_MoldeFallido_CheckedChanged);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Agregar.Location = new System.Drawing.Point(372, 19);
            this.btn_Agregar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(139, 34);
            this.btn_Agregar.TabIndex = 13;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar.Location = new System.Drawing.Point(521, 19);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(139, 34);
            this.btn_Buscar.TabIndex = 14;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Actualizar.Location = new System.Drawing.Point(20, 215);
            this.btn_Actualizar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(125, 34);
            this.btn_Actualizar.TabIndex = 16;
            this.btn_Actualizar.Text = "Actualizar";
            this.btn_Actualizar.UseVisualStyleBackColor = true;
            this.btn_Actualizar.Click += new System.EventHandler(this.btn_Actualizar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.Location = new System.Drawing.Point(750, 215);
            this.btn_Eliminar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(125, 34);
            this.btn_Eliminar.TabIndex = 17;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbx_IdDetallePedido, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbx_CodigoMolde, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbx_IdTalla, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbx_IdPedido, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(44, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.02041F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.97959F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 196);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // chbx_PrecioVariable
            // 
            this.chbx_PrecioVariable.AutoSize = true;
            this.chbx_PrecioVariable.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbx_PrecioVariable.Location = new System.Drawing.Point(369, 173);
            this.chbx_PrecioVariable.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chbx_PrecioVariable.Name = "chbx_PrecioVariable";
            this.chbx_PrecioVariable.Size = new System.Drawing.Size(205, 23);
            this.chbx_PrecioVariable.TabIndex = 20;
            this.chbx_PrecioVariable.Text = "Precio Variable ($3.500)";
            this.chbx_PrecioVariable.UseVisualStyleBackColor = true;
            this.chbx_PrecioVariable.CheckedChanged += new System.EventHandler(this.chbx_PrecioVariable_CheckedChanged);
            // 
            // chbx_PrecioEspecial
            // 
            this.chbx_PrecioEspecial.AutoSize = true;
            this.chbx_PrecioEspecial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbx_PrecioEspecial.Location = new System.Drawing.Point(584, 172);
            this.chbx_PrecioEspecial.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chbx_PrecioEspecial.Name = "chbx_PrecioEspecial";
            this.chbx_PrecioEspecial.Size = new System.Drawing.Size(209, 23);
            this.chbx_PrecioEspecial.TabIndex = 21;
            this.chbx_PrecioEspecial.Text = "Precio Especial ($6.000)";
            this.chbx_PrecioEspecial.UseVisualStyleBackColor = true;
            this.chbx_PrecioEspecial.CheckedChanged += new System.EventHandler(this.chbx_PrecioEspecial_CheckedChanged);
            // 
            // AdministarDetallesPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(889, 580);
            this.Controls.Add(this.chbx_PrecioEspecial);
            this.Controls.Add(this.chbx_PrecioVariable);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Actualizar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.chbx_MoldeFallido);
            this.Controls.Add(this.chbx_MoldeEnStock);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "AdministarDetallesPedido";
            this.Text = "AdministarDetallesPedido";
            this.Load += new System.EventHandler(this.AdministarDetallesPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tbx_IdDetallePedido;
        private System.Windows.Forms.Label tbx_IdPedido;
        private System.Windows.Forms.ComboBox cbx_IdTalla;
        private System.Windows.Forms.TextBox tbx_CodigoMolde;
        private System.Windows.Forms.CheckBox chbx_MoldeEnStock;
        private System.Windows.Forms.CheckBox chbx_MoldeFallido;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chbx_PrecioVariable;
        private System.Windows.Forms.CheckBox chbx_PrecioEspecial;
    }
}