namespace UnicosturaAdminEnC
{
    partial class AdministarPedidos
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
            this.tbx_IdCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_Direccion = new System.Windows.Forms.TextBox();
            this.cbx_NombreCliente = new System.Windows.Forms.ComboBox();
            this.cbx_Alias = new System.Windows.Forms.ComboBox();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.btn_EliminarDeGrilla = new System.Windows.Forms.Button();
            this.btn_AdminMoldesPedido = new System.Windows.Forms.Button();
            this.tbx_IdPedido = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbx_NumeroBoleta = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbx_TotalMoldes = new System.Windows.Forms.Label();
            this.tbx_ValorPedido = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Chbx_Impreso = new System.Windows.Forms.CheckBox();
            this.Chbx_Pagado = new System.Windows.Forms.CheckBox();
            this.Chbx_Boleta = new System.Windows.Forms.CheckBox();
            this.Chbx_Entregado = new System.Windows.Forms.CheckBox();
            this.tbx_IdEstados = new System.Windows.Forms.Label();
            this.cbx_CelularCliente = new System.Windows.Forms.ComboBox();
            this.cbx_Rut = new System.Windows.Forms.ComboBox();
            this.tbx_Fuente = new System.Windows.Forms.ComboBox();
            this.cbx_IdRepartidor = new System.Windows.Forms.ComboBox();
            this.cbx_IdDistribucion = new System.Windows.Forms.ComboBox();
            this.cbx_IdPago = new System.Windows.Forms.ComboBox();
            this.btn_LimpiarCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 253);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1045, 220);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(755, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID Cliente:";
            // 
            // tbx_IdCliente
            // 
            this.tbx_IdCliente.AutoSize = true;
            this.tbx_IdCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_IdCliente.Location = new System.Drawing.Point(893, 7);
            this.tbx_IdCliente.Name = "tbx_IdCliente";
            this.tbx_IdCliente.Size = new System.Drawing.Size(0, 19);
            this.tbx_IdCliente.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(755, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(755, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Celular Cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(755, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Direccion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(755, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Rut:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(755, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Alias:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(755, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Fuente:";
            // 
            // tbx_Direccion
            // 
            this.tbx_Direccion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Direccion.Location = new System.Drawing.Point(888, 141);
            this.tbx_Direccion.Name = "tbx_Direccion";
            this.tbx_Direccion.Size = new System.Drawing.Size(169, 26);
            this.tbx_Direccion.TabIndex = 11;
            // 
            // cbx_NombreCliente
            // 
            this.cbx_NombreCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_NombreCliente.FormattingEnabled = true;
            this.cbx_NombreCliente.Location = new System.Drawing.Point(888, 30);
            this.cbx_NombreCliente.Name = "cbx_NombreCliente";
            this.cbx_NombreCliente.Size = new System.Drawing.Size(169, 27);
            this.cbx_NombreCliente.TabIndex = 15;
            this.cbx_NombreCliente.SelectedIndexChanged += new System.EventHandler(this.cbx_NombreCliente_SelectedIndexChanged);
            // 
            // cbx_Alias
            // 
            this.cbx_Alias.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Alias.FormattingEnabled = true;
            this.cbx_Alias.Location = new System.Drawing.Point(888, 67);
            this.cbx_Alias.Name = "cbx_Alias";
            this.cbx_Alias.Size = new System.Drawing.Size(169, 27);
            this.cbx_Alias.TabIndex = 16;
            this.cbx_Alias.SelectedIndexChanged += new System.EventHandler(this.cbx_Alias_SelectedIndexChanged);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Agregar.Location = new System.Drawing.Point(340, 8);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(109, 32);
            this.btn_Agregar.TabIndex = 17;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar.Location = new System.Drawing.Point(578, 152);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(157, 32);
            this.btn_Buscar.TabIndex = 18;
            this.btn_Buscar.Text = "Buscar Cliente";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar.Location = new System.Drawing.Point(455, 8);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(109, 32);
            this.btn_Modificar.TabIndex = 19;
            this.btn_Modificar.Text = "Modificar";
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.Location = new System.Drawing.Point(245, 211);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(97, 32);
            this.btn_Eliminar.TabIndex = 20;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Actualizar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Actualizar.Location = new System.Drawing.Point(18, 211);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(97, 32);
            this.btn_Actualizar.TabIndex = 21;
            this.btn_Actualizar.Text = "Actualizar";
            this.btn_Actualizar.UseVisualStyleBackColor = true;
            this.btn_Actualizar.Click += new System.EventHandler(this.btn_Actualizar_Click);
            // 
            // btn_EliminarDeGrilla
            // 
            this.btn_EliminarDeGrilla.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarDeGrilla.Location = new System.Drawing.Point(578, 207);
            this.btn_EliminarDeGrilla.Name = "btn_EliminarDeGrilla";
            this.btn_EliminarDeGrilla.Size = new System.Drawing.Size(157, 32);
            this.btn_EliminarDeGrilla.TabIndex = 22;
            this.btn_EliminarDeGrilla.Text = "Eliminar de Grilla";
            this.btn_EliminarDeGrilla.UseVisualStyleBackColor = true;
            this.btn_EliminarDeGrilla.Click += new System.EventHandler(this.btn_EliminarDeGrilla_Click);
            // 
            // btn_AdminMoldesPedido
            // 
            this.btn_AdminMoldesPedido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AdminMoldesPedido.Location = new System.Drawing.Point(578, 7);
            this.btn_AdminMoldesPedido.Name = "btn_AdminMoldesPedido";
            this.btn_AdminMoldesPedido.Size = new System.Drawing.Size(157, 98);
            this.btn_AdminMoldesPedido.TabIndex = 23;
            this.btn_AdminMoldesPedido.Text = "Administar Moldes del Pedido";
            this.btn_AdminMoldesPedido.UseVisualStyleBackColor = true;
            this.btn_AdminMoldesPedido.Click += new System.EventHandler(this.btn_AdminMoldesPedido_Click);
            // 
            // tbx_IdPedido
            // 
            this.tbx_IdPedido.AutoSize = true;
            this.tbx_IdPedido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_IdPedido.Location = new System.Drawing.Point(134, 15);
            this.tbx_IdPedido.Name = "tbx_IdPedido";
            this.tbx_IdPedido.Size = new System.Drawing.Size(0, 19);
            this.tbx_IdPedido.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 19);
            this.label10.TabIndex = 24;
            this.label10.Text = "ID Pedido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(352, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "ID Estado:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 19);
            this.label9.TabIndex = 27;
            this.label9.Text = "Repartidor:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 19);
            this.label11.TabIndex = 28;
            this.label11.Text = "Distribucion:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 19);
            this.label12.TabIndex = 29;
            this.label12.Text = "Pago:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 19);
            this.label13.TabIndex = 30;
            this.label13.Text = "Boleta:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 19);
            this.label14.TabIndex = 31;
            this.label14.Text = "Fecha:";
            // 
            // tbx_NumeroBoleta
            // 
            this.tbx_NumeroBoleta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NumeroBoleta.Location = new System.Drawing.Point(128, 145);
            this.tbx_NumeroBoleta.Name = "tbx_NumeroBoleta";
            this.tbx_NumeroBoleta.Size = new System.Drawing.Size(214, 26);
            this.tbx_NumeroBoleta.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(352, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 19);
            this.label15.TabIndex = 38;
            this.label15.Text = "Total Moldes:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(352, 119);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(139, 19);
            this.label16.TabIndex = 39;
            this.label16.Text = "Valor del Pedido:";
            // 
            // tbx_TotalMoldes
            // 
            this.tbx_TotalMoldes.AutoSize = true;
            this.tbx_TotalMoldes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_TotalMoldes.Location = new System.Drawing.Point(506, 86);
            this.tbx_TotalMoldes.Name = "tbx_TotalMoldes";
            this.tbx_TotalMoldes.Size = new System.Drawing.Size(18, 19);
            this.tbx_TotalMoldes.TabIndex = 40;
            this.tbx_TotalMoldes.Text = "8";
            // 
            // tbx_ValorPedido
            // 
            this.tbx_ValorPedido.AutoSize = true;
            this.tbx_ValorPedido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_ValorPedido.Location = new System.Drawing.Point(497, 118);
            this.tbx_ValorPedido.Name = "tbx_ValorPedido";
            this.tbx_ValorPedido.Size = new System.Drawing.Size(67, 19);
            this.tbx_ValorPedido.TabIndex = 41;
            this.tbx_ValorPedido.Text = "$30.000";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(128, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(436, 26);
            this.dateTimePicker1.TabIndex = 42;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Chbx_Impreso
            // 
            this.Chbx_Impreso.AutoSize = true;
            this.Chbx_Impreso.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chbx_Impreso.Location = new System.Drawing.Point(444, 184);
            this.Chbx_Impreso.Name = "Chbx_Impreso";
            this.Chbx_Impreso.Size = new System.Drawing.Size(90, 23);
            this.Chbx_Impreso.TabIndex = 43;
            this.Chbx_Impreso.Text = "Impreso";
            this.Chbx_Impreso.UseVisualStyleBackColor = true;
            // 
            // Chbx_Pagado
            // 
            this.Chbx_Pagado.AutoSize = true;
            this.Chbx_Pagado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chbx_Pagado.Location = new System.Drawing.Point(352, 218);
            this.Chbx_Pagado.Name = "Chbx_Pagado";
            this.Chbx_Pagado.Size = new System.Drawing.Size(87, 23);
            this.Chbx_Pagado.TabIndex = 44;
            this.Chbx_Pagado.Text = "Pagado";
            this.Chbx_Pagado.UseVisualStyleBackColor = true;
            // 
            // Chbx_Boleta
            // 
            this.Chbx_Boleta.AutoSize = true;
            this.Chbx_Boleta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chbx_Boleta.Location = new System.Drawing.Point(352, 184);
            this.Chbx_Boleta.Name = "Chbx_Boleta";
            this.Chbx_Boleta.Size = new System.Drawing.Size(77, 23);
            this.Chbx_Boleta.TabIndex = 45;
            this.Chbx_Boleta.Text = "Boleta";
            this.Chbx_Boleta.UseVisualStyleBackColor = true;
            // 
            // Chbx_Entregado
            // 
            this.Chbx_Entregado.AutoSize = true;
            this.Chbx_Entregado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chbx_Entregado.Location = new System.Drawing.Point(444, 218);
            this.Chbx_Entregado.Name = "Chbx_Entregado";
            this.Chbx_Entregado.Size = new System.Drawing.Size(108, 23);
            this.Chbx_Entregado.TabIndex = 46;
            this.Chbx_Entregado.Text = "Entregado";
            this.Chbx_Entregado.UseVisualStyleBackColor = true;
            // 
            // tbx_IdEstados
            // 
            this.tbx_IdEstados.AutoSize = true;
            this.tbx_IdEstados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_IdEstados.Location = new System.Drawing.Point(506, 152);
            this.tbx_IdEstados.Name = "tbx_IdEstados";
            this.tbx_IdEstados.Size = new System.Drawing.Size(18, 19);
            this.tbx_IdEstados.TabIndex = 47;
            this.tbx_IdEstados.Text = "0";
            // 
            // cbx_CelularCliente
            // 
            this.cbx_CelularCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_CelularCliente.FormattingEnabled = true;
            this.cbx_CelularCliente.Location = new System.Drawing.Point(888, 103);
            this.cbx_CelularCliente.Name = "cbx_CelularCliente";
            this.cbx_CelularCliente.Size = new System.Drawing.Size(169, 27);
            this.cbx_CelularCliente.TabIndex = 48;
            this.cbx_CelularCliente.Text = "0";
            this.cbx_CelularCliente.SelectedIndexChanged += new System.EventHandler(this.cbx_CelularCliente_SelectedIndexChanged);
            // 
            // cbx_Rut
            // 
            this.cbx_Rut.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Rut.FormattingEnabled = true;
            this.cbx_Rut.Location = new System.Drawing.Point(888, 176);
            this.cbx_Rut.Name = "cbx_Rut";
            this.cbx_Rut.Size = new System.Drawing.Size(169, 27);
            this.cbx_Rut.TabIndex = 49;
            this.cbx_Rut.SelectedIndexChanged += new System.EventHandler(this.cbx_Rut_SelectedIndexChanged);
            this.cbx_Rut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbx_Rut_KeyPress);
            // 
            // tbx_Fuente
            // 
            this.tbx_Fuente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Fuente.FormattingEnabled = true;
            this.tbx_Fuente.Items.AddRange(new object[] {
            "Celular Unicose",
            "Celular Vero",
            "Messenger Unicose",
            "Messenger Vero",
            "Mary"});
            this.tbx_Fuente.Location = new System.Drawing.Point(888, 214);
            this.tbx_Fuente.Name = "tbx_Fuente";
            this.tbx_Fuente.Size = new System.Drawing.Size(169, 27);
            this.tbx_Fuente.TabIndex = 50;
            // 
            // cbx_IdRepartidor
            // 
            this.cbx_IdRepartidor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_IdRepartidor.FormattingEnabled = true;
            this.cbx_IdRepartidor.Location = new System.Drawing.Point(128, 177);
            this.cbx_IdRepartidor.Name = "cbx_IdRepartidor";
            this.cbx_IdRepartidor.Size = new System.Drawing.Size(214, 27);
            this.cbx_IdRepartidor.TabIndex = 51;
            this.cbx_IdRepartidor.SelectedIndexChanged += new System.EventHandler(this.cbx_IdRepartidor_SelectedIndexChanged);
            // 
            // cbx_IdDistribucion
            // 
            this.cbx_IdDistribucion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_IdDistribucion.FormattingEnabled = true;
            this.cbx_IdDistribucion.Location = new System.Drawing.Point(128, 78);
            this.cbx_IdDistribucion.Name = "cbx_IdDistribucion";
            this.cbx_IdDistribucion.Size = new System.Drawing.Size(214, 27);
            this.cbx_IdDistribucion.TabIndex = 52;
            this.cbx_IdDistribucion.SelectedIndexChanged += new System.EventHandler(this.cbx_IdDistribucion_SelectedIndexChanged);
            // 
            // cbx_IdPago
            // 
            this.cbx_IdPago.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_IdPago.FormattingEnabled = true;
            this.cbx_IdPago.Location = new System.Drawing.Point(128, 111);
            this.cbx_IdPago.Name = "cbx_IdPago";
            this.cbx_IdPago.Size = new System.Drawing.Size(214, 27);
            this.cbx_IdPago.TabIndex = 53;
            this.cbx_IdPago.SelectedIndexChanged += new System.EventHandler(this.cbx_IdPago_SelectedIndexChanged);
            // 
            // btn_LimpiarCliente
            // 
            this.btn_LimpiarCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LimpiarCliente.Location = new System.Drawing.Point(578, 111);
            this.btn_LimpiarCliente.Name = "btn_LimpiarCliente";
            this.btn_LimpiarCliente.Size = new System.Drawing.Size(157, 32);
            this.btn_LimpiarCliente.TabIndex = 54;
            this.btn_LimpiarCliente.Text = "Limpiar Cliente";
            this.btn_LimpiarCliente.UseVisualStyleBackColor = true;
            this.btn_LimpiarCliente.Click += new System.EventHandler(this.btn_LimpiarCliente_Click);
            // 
            // AdministarPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(1072, 485);
            this.Controls.Add(this.btn_LimpiarCliente);
            this.Controls.Add(this.cbx_IdPago);
            this.Controls.Add(this.cbx_IdDistribucion);
            this.Controls.Add(this.cbx_IdRepartidor);
            this.Controls.Add(this.tbx_Fuente);
            this.Controls.Add(this.cbx_Rut);
            this.Controls.Add(this.cbx_CelularCliente);
            this.Controls.Add(this.tbx_IdEstados);
            this.Controls.Add(this.Chbx_Entregado);
            this.Controls.Add(this.Chbx_Boleta);
            this.Controls.Add(this.Chbx_Pagado);
            this.Controls.Add(this.Chbx_Impreso);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tbx_ValorPedido);
            this.Controls.Add(this.tbx_TotalMoldes);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbx_NumeroBoleta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_IdPedido);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_AdminMoldesPedido);
            this.Controls.Add(this.btn_EliminarDeGrilla);
            this.Controls.Add(this.btn_Actualizar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.cbx_Alias);
            this.Controls.Add(this.cbx_NombreCliente);
            this.Controls.Add(this.tbx_Direccion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_IdCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdministarPedidos";
            this.Text = "AdministarPedidos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministarPedidos_FormClosing);
            this.Load += new System.EventHandler(this.AdministarPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tbx_IdCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_Direccion;
        private System.Windows.Forms.ComboBox cbx_NombreCliente;
        private System.Windows.Forms.ComboBox cbx_Alias;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.Button btn_EliminarDeGrilla;
        private System.Windows.Forms.Button btn_AdminMoldesPedido;
        private System.Windows.Forms.Label tbx_IdPedido;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbx_NumeroBoleta;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label tbx_TotalMoldes;
        private System.Windows.Forms.Label tbx_ValorPedido;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox Chbx_Impreso;
        private System.Windows.Forms.CheckBox Chbx_Pagado;
        private System.Windows.Forms.CheckBox Chbx_Boleta;
        private System.Windows.Forms.CheckBox Chbx_Entregado;
        private System.Windows.Forms.Label tbx_IdEstados;
        private System.Windows.Forms.ComboBox cbx_CelularCliente;
        private System.Windows.Forms.ComboBox cbx_Rut;
        private System.Windows.Forms.ComboBox tbx_Fuente;
        private System.Windows.Forms.ComboBox cbx_IdRepartidor;
        private System.Windows.Forms.ComboBox cbx_IdDistribucion;
        private System.Windows.Forms.ComboBox cbx_IdPago;
        private System.Windows.Forms.Button btn_LimpiarCliente;
    }
}