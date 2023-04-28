namespace TP1___GRUPO_C.Vistas
{
    partial class PantallaMiPerfil
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
            Btn_CerrarSesionPerfil = new Button();
            Label_BienvenidaPerfil = new Label();
            label1 = new Label();
            Btn_ComprarCreditos = new Button();
            label3 = new Label();
            dataGridPasadasFunciones = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Cant_Clientes = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            ID_MiSala = new DataGridViewTextBoxColumn();
            Capacidad_Sala = new DataGridViewTextBoxColumn();
            Id_Pelicula = new DataGridViewTextBoxColumn();
            Pelicula_Nombre = new DataGridViewTextBoxColumn();
            IDS_Clientes = new DataGridViewTextBoxColumn();
            dataGridProximasFunciones = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label10 = new Label();
            label11 = new Label();
            label14 = new Label();
            label15 = new Label();
            Input_ = new Label();
            Input_NuevoCreditoPerfil = new TextBox();
            Btn_ModificarPerfil = new Button();
            Input_DNIPerfil = new TextBox();
            Input_NombrePerfil = new TextBox();
            Input_ApellidoPerfil = new TextBox();
            Input_PasswordPerfil = new TextBox();
            Input_MailPerfil = new TextBox();
            Label_MiCredito = new Label();
            Label_IDPerfil = new Label();
            DateTime_MiPerfil = new DateTimePicker();
            Btn_VolverAtrasPerfil = new Button();
            Btn_DevolverEntradas = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridPasadasFunciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProximasFunciones).BeginInit();
            SuspendLayout();
            // 
            // Btn_CerrarSesionPerfil
            // 
            Btn_CerrarSesionPerfil.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_CerrarSesionPerfil.Location = new Point(639, 17);
            Btn_CerrarSesionPerfil.Name = "Btn_CerrarSesionPerfil";
            Btn_CerrarSesionPerfil.Size = new Size(121, 31);
            Btn_CerrarSesionPerfil.TabIndex = 25;
            Btn_CerrarSesionPerfil.Text = "Cerrar Sesión";
            Btn_CerrarSesionPerfil.UseVisualStyleBackColor = true;
            Btn_CerrarSesionPerfil.UseWaitCursor = true;
            Btn_CerrarSesionPerfil.Click += Btn_CerrarSesionPerfil_Click;
            // 
            // Label_BienvenidaPerfil
            // 
            Label_BienvenidaPerfil.AutoSize = true;
            Label_BienvenidaPerfil.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            Label_BienvenidaPerfil.Location = new Point(12, 9);
            Label_BienvenidaPerfil.Name = "Label_BienvenidaPerfil";
            Label_BienvenidaPerfil.Size = new Size(118, 28);
            Label_BienvenidaPerfil.TabIndex = 23;
            Label_BienvenidaPerfil.Text = "Bienvenido";
            Label_BienvenidaPerfil.UseWaitCursor = true;
            Label_BienvenidaPerfil.Click += label6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(494, 93);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 26;
            label1.Text = "Mi Credito: ";
            label1.UseWaitCursor = true;
            // 
            // Btn_ComprarCreditos
            // 
            Btn_ComprarCreditos.Location = new Point(493, 162);
            Btn_ComprarCreditos.Name = "Btn_ComprarCreditos";
            Btn_ComprarCreditos.Size = new Size(127, 23);
            Btn_ComprarCreditos.TabIndex = 28;
            Btn_ComprarCreditos.Text = "Comprar Creditos";
            Btn_ComprarCreditos.UseVisualStyleBackColor = true;
            Btn_ComprarCreditos.UseWaitCursor = true;
            Btn_ComprarCreditos.Click += Btn_ComprarCreditos_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 341);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 29;
            label3.Text = "Funciones Pasadas: ";
            label3.UseWaitCursor = true;
            label3.Click += label3_Click;
            // 
            // dataGridPasadasFunciones
            // 
            dataGridPasadasFunciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPasadasFunciones.Columns.AddRange(new DataGridViewColumn[] { ID, Fecha, Cant_Clientes, Costo, ID_MiSala, Capacidad_Sala, Id_Pelicula, Pelicula_Nombre, IDS_Clientes });
            dataGridPasadasFunciones.Location = new Point(32, 359);
            dataGridPasadasFunciones.Name = "dataGridPasadasFunciones";
            dataGridPasadasFunciones.RowTemplate.Height = 25;
            dataGridPasadasFunciones.Size = new Size(728, 93);
            dataGridPasadasFunciones.TabIndex = 32;
            dataGridPasadasFunciones.UseWaitCursor = true;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Fecha
            // 
            Fecha.HeaderText = "Fecha";
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            // 
            // Cant_Clientes
            // 
            Cant_Clientes.HeaderText = "Cant_Clientes";
            Cant_Clientes.Name = "Cant_Clientes";
            Cant_Clientes.ReadOnly = true;
            // 
            // Costo
            // 
            Costo.HeaderText = "Costo";
            Costo.Name = "Costo";
            Costo.ReadOnly = true;
            // 
            // ID_MiSala
            // 
            ID_MiSala.HeaderText = "ID_MiSala";
            ID_MiSala.Name = "ID_MiSala";
            ID_MiSala.ReadOnly = true;
            // 
            // Capacidad_Sala
            // 
            Capacidad_Sala.HeaderText = "Capacidad_Sala";
            Capacidad_Sala.Name = "Capacidad_Sala";
            // 
            // Id_Pelicula
            // 
            Id_Pelicula.HeaderText = "ID_Pelicula";
            Id_Pelicula.Name = "Id_Pelicula";
            Id_Pelicula.ReadOnly = true;
            // 
            // Pelicula_Nombre
            // 
            Pelicula_Nombre.HeaderText = "Pelicula_Nombre";
            Pelicula_Nombre.Name = "Pelicula_Nombre";
            // 
            // IDS_Clientes
            // 
            IDS_Clientes.HeaderText = "IDS_Clientes";
            IDS_Clientes.Name = "IDS_Clientes";
            // 
            // dataGridProximasFunciones
            // 
            dataGridProximasFunciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProximasFunciones.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
            dataGridProximasFunciones.Location = new Point(32, 226);
            dataGridProximasFunciones.Name = "dataGridProximasFunciones";
            dataGridProximasFunciones.RowTemplate.Height = 25;
            dataGridProximasFunciones.Size = new Size(728, 98);
            dataGridProximasFunciones.TabIndex = 35;
            dataGridProximasFunciones.UseWaitCursor = true;
            dataGridProximasFunciones.CellDoubleClick += dataGridProximasFunciones_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Fecha";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Cant_Clientes";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Costo";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "ID_Misala";
            dataGridViewTextBoxColumn2.HeaderText = "ID_Misala";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Capacidad_Sala";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "ID_Pelicula";
            dataGridViewTextBoxColumn7.HeaderText = "ID_Pelicula";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Pelicula_Nombre";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "IDS_Clientes";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 359);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 34;
            label4.UseWaitCursor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 208);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 33;
            label5.Text = "Funciones Proximas: ";
            label5.UseWaitCursor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 128);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 36;
            label7.Text = "Nombre: ";
            label7.UseWaitCursor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(32, 167);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 38;
            label8.Text = "Apellido";
            label8.UseWaitCursor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(265, 93);
            label10.Name = "label10";
            label10.Size = new Size(36, 15);
            label10.TabIndex = 42;
            label10.Text = "Mail: ";
            label10.UseWaitCursor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(32, 93);
            label11.Name = "label11";
            label11.Size = new Size(33, 15);
            label11.TabIndex = 41;
            label11.Text = "DNI: ";
            label11.UseWaitCursor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(265, 167);
            label14.Name = "label14";
            label14.Size = new Size(49, 15);
            label14.TabIndex = 46;
            label14.Text = "Fe. Nac.";
            label14.UseWaitCursor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(265, 128);
            label15.Name = "label15";
            label15.Size = new Size(63, 15);
            label15.TabIndex = 45;
            label15.Text = "Password: ";
            label15.UseWaitCursor = true;
            // 
            // Input_
            // 
            Input_.AutoSize = true;
            Input_.Location = new Point(494, 128);
            Input_.Name = "Input_";
            Input_.Size = new Size(55, 15);
            Input_.TabIndex = 50;
            Input_.Text = "Agregar: ";
            Input_.UseWaitCursor = true;
            // 
            // Input_NuevoCreditoPerfil
            // 
            Input_NuevoCreditoPerfil.Location = new Point(555, 125);
            Input_NuevoCreditoPerfil.Name = "Input_NuevoCreditoPerfil";
            Input_NuevoCreditoPerfil.Size = new Size(65, 23);
            Input_NuevoCreditoPerfil.TabIndex = 59;
            Input_NuevoCreditoPerfil.UseWaitCursor = true;
            // 
            // Btn_ModificarPerfil
            // 
            Btn_ModificarPerfil.Location = new Point(32, 51);
            Btn_ModificarPerfil.Name = "Btn_ModificarPerfil";
            Btn_ModificarPerfil.Size = new Size(112, 23);
            Btn_ModificarPerfil.TabIndex = 60;
            Btn_ModificarPerfil.Text = "Modificar Datos";
            Btn_ModificarPerfil.UseVisualStyleBackColor = true;
            Btn_ModificarPerfil.UseWaitCursor = true;
            Btn_ModificarPerfil.Click += Btn_ModificarPerfil_Click;
            // 
            // Input_DNIPerfil
            // 
            Input_DNIPerfil.Location = new Point(89, 90);
            Input_DNIPerfil.Name = "Input_DNIPerfil";
            Input_DNIPerfil.Size = new Size(100, 23);
            Input_DNIPerfil.TabIndex = 61;
            Input_DNIPerfil.UseWaitCursor = true;
            // 
            // Input_NombrePerfil
            // 
            Input_NombrePerfil.Location = new Point(89, 128);
            Input_NombrePerfil.Name = "Input_NombrePerfil";
            Input_NombrePerfil.Size = new Size(100, 23);
            Input_NombrePerfil.TabIndex = 62;
            Input_NombrePerfil.UseWaitCursor = true;
            // 
            // Input_ApellidoPerfil
            // 
            Input_ApellidoPerfil.Location = new Point(89, 163);
            Input_ApellidoPerfil.Name = "Input_ApellidoPerfil";
            Input_ApellidoPerfil.Size = new Size(100, 23);
            Input_ApellidoPerfil.TabIndex = 63;
            Input_ApellidoPerfil.UseWaitCursor = true;
            // 
            // Input_PasswordPerfil
            // 
            Input_PasswordPerfil.Location = new Point(332, 128);
            Input_PasswordPerfil.Name = "Input_PasswordPerfil";
            Input_PasswordPerfil.Size = new Size(100, 23);
            Input_PasswordPerfil.TabIndex = 65;
            Input_PasswordPerfil.UseWaitCursor = true;
            // 
            // Input_MailPerfil
            // 
            Input_MailPerfil.Location = new Point(332, 90);
            Input_MailPerfil.Name = "Input_MailPerfil";
            Input_MailPerfil.Size = new Size(100, 23);
            Input_MailPerfil.TabIndex = 64;
            Input_MailPerfil.UseWaitCursor = true;
            // 
            // Label_MiCredito
            // 
            Label_MiCredito.AutoSize = true;
            Label_MiCredito.Location = new Point(569, 93);
            Label_MiCredito.Name = "Label_MiCredito";
            Label_MiCredito.Size = new Size(47, 15);
            Label_MiCredito.TabIndex = 67;
            Label_MiCredito.Text = "AAAAA";
            Label_MiCredito.UseWaitCursor = true;
            // 
            // Label_IDPerfil
            // 
            Label_IDPerfil.AutoSize = true;
            Label_IDPerfil.Location = new Point(165, 55);
            Label_IDPerfil.Name = "Label_IDPerfil";
            Label_IDPerfil.Size = new Size(47, 15);
            Label_IDPerfil.TabIndex = 68;
            Label_IDPerfil.Text = "AAAAA";
            Label_IDPerfil.UseWaitCursor = true;
            Label_IDPerfil.Visible = false;
            // 
            // DateTime_MiPerfil
            // 
            DateTime_MiPerfil.Location = new Point(332, 167);
            DateTime_MiPerfil.Name = "DateTime_MiPerfil";
            DateTime_MiPerfil.Size = new Size(100, 23);
            DateTime_MiPerfil.TabIndex = 69;
            DateTime_MiPerfil.UseWaitCursor = true;
            // 
            // Btn_VolverAtrasPerfil
            // 
            Btn_VolverAtrasPerfil.Location = new Point(512, 16);
            Btn_VolverAtrasPerfil.Name = "Btn_VolverAtrasPerfil";
            Btn_VolverAtrasPerfil.Size = new Size(121, 32);
            Btn_VolverAtrasPerfil.TabIndex = 70;
            Btn_VolverAtrasPerfil.Text = "Volver";
            Btn_VolverAtrasPerfil.UseVisualStyleBackColor = true;
            Btn_VolverAtrasPerfil.UseWaitCursor = true;
            Btn_VolverAtrasPerfil.Click += Btn_VolverAtrasPerfil_Click;
            // 
            // Btn_DevolverEntradas
            // 
            Btn_DevolverEntradas.Location = new Point(625, 197);
            Btn_DevolverEntradas.Name = "Btn_DevolverEntradas";
            Btn_DevolverEntradas.Size = new Size(107, 23);
            Btn_DevolverEntradas.TabIndex = 71;
            Btn_DevolverEntradas.Text = "Devolver Entrada";
            Btn_DevolverEntradas.UseVisualStyleBackColor = true;
            Btn_DevolverEntradas.UseWaitCursor = true;
            Btn_DevolverEntradas.Click += Btn_DevolverEntradas_Click;
            // 
            // PantallaMiPerfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Btn_DevolverEntradas);
            Controls.Add(Btn_VolverAtrasPerfil);
            Controls.Add(DateTime_MiPerfil);
            Controls.Add(Label_IDPerfil);
            Controls.Add(Label_MiCredito);
            Controls.Add(Input_PasswordPerfil);
            Controls.Add(Input_MailPerfil);
            Controls.Add(Input_ApellidoPerfil);
            Controls.Add(Input_NombrePerfil);
            Controls.Add(Input_DNIPerfil);
            Controls.Add(Btn_ModificarPerfil);
            Controls.Add(Input_NuevoCreditoPerfil);
            Controls.Add(Input_);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dataGridProximasFunciones);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(dataGridPasadasFunciones);
            Controls.Add(label3);
            Controls.Add(Btn_ComprarCreditos);
            Controls.Add(label1);
            Controls.Add(Btn_CerrarSesionPerfil);
            Controls.Add(Label_BienvenidaPerfil);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaMiPerfil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiPerfil";
            UseWaitCursor = true;
            Load += PantallaMiPerfil_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridPasadasFunciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProximasFunciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_CerrarSesionPerfil;
        private Label Label_BienvenidaPerfil;
        private Label label1;
        private Button Btn_ComprarCreditos;
        private Label label3;
        private DataGridView dataGridPasadasFunciones;
        private DataGridView dataGridProximasFunciones;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label10;
        private Label label11;
        private Label label14;
        private Label label15;
        private Label Input_;
        private TextBox Input_NuevoCreditoPerfil;
        private Button Btn_ModificarPerfil;
        private TextBox Input_DNIPerfil;
        private TextBox Input_NombrePerfil;
        private TextBox Input_ApellidoPerfil;
        private TextBox Input_PasswordPerfil;
        private TextBox Input_MailPerfil;
        private Label Label_MiCredito;
        private Label Label_IDPerfil;
        private DateTimePicker DateTime_MiPerfil;
        private Button Btn_VolverAtrasPerfil;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Cant_Clientes;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn ID_MiSala;
        private DataGridViewTextBoxColumn Capacidad_Sala;
        private DataGridViewTextBoxColumn Id_Pelicula;
        private DataGridViewTextBoxColumn Pelicula_Nombre;
        private DataGridViewTextBoxColumn IDS_Clientes;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Button Btn_DevolverEntradas;
    }
}