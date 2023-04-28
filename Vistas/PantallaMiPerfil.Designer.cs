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
            MiSala = new DataGridViewTextBoxColumn();
            MiPelicula = new DataGridViewTextBoxColumn();
            Cant_Clientes = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            dataGridProximasFunciones = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label10 = new Label();
            label11 = new Label();
            label14 = new Label();
            label15 = new Label();
            Input_ = new Label();
            Label_UserDNI = new Label();
            Label_UserNombre = new Label();
            Label_UserApellido = new Label();
            Label_UserMail = new Label();
            Label_UserPassword = new Label();
            Label_UserFechaNac = new Label();
            Label_UserCredito = new Label();
            Input_NuevoCredito = new TextBox();
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
            Label_BienvenidaPerfil.Location = new Point(22, 15);
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
            label1.Location = new Point(605, 92);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 26;
            label1.Text = "Mi Credito: ";
            label1.UseWaitCursor = true;
            // 
            // Btn_ComprarCreditos
            // 
            Btn_ComprarCreditos.Location = new Point(605, 162);
            Btn_ComprarCreditos.Name = "Btn_ComprarCreditos";
            Btn_ComprarCreditos.Size = new Size(127, 23);
            Btn_ComprarCreditos.TabIndex = 28;
            Btn_ComprarCreditos.Text = "Comprar Creditos";
            Btn_ComprarCreditos.UseVisualStyleBackColor = true;
            Btn_ComprarCreditos.UseWaitCursor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(89, 337);
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
            dataGridPasadasFunciones.Columns.AddRange(new DataGridViewColumn[] { ID, MiSala, MiPelicula, Cant_Clientes, Costo, Fecha });
            dataGridPasadasFunciones.Location = new Point(89, 355);
            dataGridPasadasFunciones.Name = "dataGridPasadasFunciones";
            dataGridPasadasFunciones.RowTemplate.Height = 25;
            dataGridPasadasFunciones.Size = new Size(643, 93);
            dataGridPasadasFunciones.TabIndex = 32;
            // 
            // ID
            // 
            ID.Frozen = true;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // MiSala
            // 
            MiSala.Frozen = true;
            MiSala.HeaderText = "MiSala";
            MiSala.Name = "MiSala";
            MiSala.ReadOnly = true;
            // 
            // MiPelicula
            // 
            MiPelicula.Frozen = true;
            MiPelicula.HeaderText = "MiPelicula";
            MiPelicula.Name = "MiPelicula";
            MiPelicula.ReadOnly = true;
            // 
            // Cant_Clientes
            // 
            Cant_Clientes.Frozen = true;
            Cant_Clientes.HeaderText = "Cant_Clientes";
            Cant_Clientes.Name = "Cant_Clientes";
            Cant_Clientes.ReadOnly = true;
            // 
            // Costo
            // 
            Costo.Frozen = true;
            Costo.HeaderText = "Costo";
            Costo.Name = "Costo";
            Costo.ReadOnly = true;
            // 
            // Fecha
            // 
            Fecha.Frozen = true;
            Fecha.HeaderText = "Fecha";
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            // 
            // dataGridProximasFunciones
            // 
            dataGridProximasFunciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProximasFunciones.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGridProximasFunciones.Location = new Point(89, 226);
            dataGridProximasFunciones.Name = "dataGridProximasFunciones";
            dataGridProximasFunciones.RowTemplate.Height = 25;
            dataGridProximasFunciones.Size = new Size(643, 98);
            dataGridProximasFunciones.TabIndex = 35;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Frozen = true;
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Frozen = true;
            dataGridViewTextBoxColumn2.HeaderText = "MiSala";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.Frozen = true;
            dataGridViewTextBoxColumn3.HeaderText = "MiPelicula";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.Frozen = true;
            dataGridViewTextBoxColumn4.HeaderText = "Cant_Clientes";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.Frozen = true;
            dataGridViewTextBoxColumn5.HeaderText = "Costo";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.Frozen = true;
            dataGridViewTextBoxColumn6.HeaderText = "Fecha";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(146, 355);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 34;
            label4.UseWaitCursor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(89, 208);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 33;
            label5.Text = "Funciones Proximas: ";
            label5.UseWaitCursor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(89, 127);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 36;
            label7.Text = "Nombre: ";
            label7.UseWaitCursor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(89, 166);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 38;
            label8.Text = "Apellido";
            label8.UseWaitCursor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(347, 92);
            label10.Name = "label10";
            label10.Size = new Size(36, 15);
            label10.TabIndex = 42;
            label10.Text = "Mail: ";
            label10.UseWaitCursor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(89, 92);
            label11.Name = "label11";
            label11.Size = new Size(33, 15);
            label11.TabIndex = 41;
            label11.Text = "DNI: ";
            label11.UseWaitCursor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(347, 166);
            label14.Name = "label14";
            label14.Size = new Size(49, 15);
            label14.TabIndex = 46;
            label14.Text = "Fe. Nac.";
            label14.UseWaitCursor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(347, 127);
            label15.Name = "label15";
            label15.Size = new Size(63, 15);
            label15.TabIndex = 45;
            label15.Text = "Password: ";
            label15.UseWaitCursor = true;
            // 
            // Input_
            // 
            Input_.AutoSize = true;
            Input_.Location = new Point(605, 127);
            Input_.Name = "Input_";
            Input_.Size = new Size(55, 15);
            Input_.TabIndex = 50;
            Input_.Text = "Agregar: ";
            Input_.UseWaitCursor = true;
            // 
            // Label_UserDNI
            // 
            Label_UserDNI.AutoSize = true;
            Label_UserDNI.Location = new Point(149, 92);
            Label_UserDNI.Name = "Label_UserDNI";
            Label_UserDNI.Size = new Size(55, 15);
            Label_UserDNI.TabIndex = 52;
            Label_UserDNI.Text = "AAAAAA";
            Label_UserDNI.UseWaitCursor = true;
            // 
            // Label_UserNombre
            // 
            Label_UserNombre.AutoSize = true;
            Label_UserNombre.Location = new Point(149, 127);
            Label_UserNombre.Name = "Label_UserNombre";
            Label_UserNombre.Size = new Size(55, 15);
            Label_UserNombre.TabIndex = 53;
            Label_UserNombre.Text = "AAAAAA";
            Label_UserNombre.UseWaitCursor = true;
            // 
            // Label_UserApellido
            // 
            Label_UserApellido.AutoSize = true;
            Label_UserApellido.Location = new Point(149, 168);
            Label_UserApellido.Name = "Label_UserApellido";
            Label_UserApellido.Size = new Size(55, 15);
            Label_UserApellido.TabIndex = 54;
            Label_UserApellido.Text = "AAAAAA";
            Label_UserApellido.UseWaitCursor = true;
            // 
            // Label_UserMail
            // 
            Label_UserMail.AutoSize = true;
            Label_UserMail.Location = new Point(416, 92);
            Label_UserMail.Name = "Label_UserMail";
            Label_UserMail.Size = new Size(55, 15);
            Label_UserMail.TabIndex = 55;
            Label_UserMail.Text = "AAAAAA";
            Label_UserMail.UseWaitCursor = true;
            // 
            // Label_UserPassword
            // 
            Label_UserPassword.AutoSize = true;
            Label_UserPassword.Location = new Point(416, 127);
            Label_UserPassword.Name = "Label_UserPassword";
            Label_UserPassword.Size = new Size(55, 15);
            Label_UserPassword.TabIndex = 56;
            Label_UserPassword.Text = "AAAAAA";
            Label_UserPassword.UseWaitCursor = true;
            // 
            // Label_UserFechaNac
            // 
            Label_UserFechaNac.AutoSize = true;
            Label_UserFechaNac.Location = new Point(416, 166);
            Label_UserFechaNac.Name = "Label_UserFechaNac";
            Label_UserFechaNac.Size = new Size(55, 15);
            Label_UserFechaNac.TabIndex = 57;
            Label_UserFechaNac.Text = "AAAAAA";
            Label_UserFechaNac.UseWaitCursor = true;
            // 
            // Label_UserCredito
            // 
            Label_UserCredito.AutoSize = true;
            Label_UserCredito.Location = new Point(677, 92);
            Label_UserCredito.Name = "Label_UserCredito";
            Label_UserCredito.Size = new Size(55, 15);
            Label_UserCredito.TabIndex = 58;
            Label_UserCredito.Text = "AAAAAA";
            Label_UserCredito.UseWaitCursor = true;
            // 
            // Input_NuevoCredito
            // 
            Input_NuevoCredito.Location = new Point(667, 124);
            Input_NuevoCredito.Name = "Input_NuevoCredito";
            Input_NuevoCredito.Size = new Size(65, 23);
            Input_NuevoCredito.TabIndex = 59;
            // 
            // PantallaMiPerfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Input_NuevoCredito);
            Controls.Add(Label_UserCredito);
            Controls.Add(Label_UserFechaNac);
            Controls.Add(Label_UserPassword);
            Controls.Add(Label_UserMail);
            Controls.Add(Label_UserApellido);
            Controls.Add(Label_UserNombre);
            Controls.Add(Label_UserDNI);
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
            WindowState = FormWindowState.Minimized;
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
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn MiSala;
        private DataGridViewTextBoxColumn MiPelicula;
        private DataGridViewTextBoxColumn Cant_Clientes;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridView dataGridProximasFunciones;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label10;
        private Label label11;
        private Label label14;
        private Label label15;
        private Label Input_;
        private Label Label_UserDNI;
        private Label Label_UserNombre;
        private Label Label_UserApellido;
        private Label Label_UserMail;
        private Label Label_UserPassword;
        private Label Label_UserFechaNac;
        private Label Label_UserCredito;
        private TextBox Input_NuevoCredito;
    }
}