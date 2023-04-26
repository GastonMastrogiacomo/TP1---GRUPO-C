namespace TP1___GRUPO_C.Vistas
{
    partial class PantallaABMAdmin : Form
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
            Pestañas = new TabControl();
            Salas = new TabPage();
            dataGridSalas = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Ubicacion = new DataGridViewTextBoxColumn();
            Capacidad = new DataGridViewTextBoxColumn();
            Funciones = new TabPage();
            Películas = new TabPage();
            Usuarios = new TabPage();
            dataGridUsuarios = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            DNI = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Mail = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            IntentosFallidos = new DataGridViewTextBoxColumn();
            Bloquedo = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Credito = new DataGridViewTextBoxColumn();
            FechaNacimiento = new DataGridViewTextBoxColumn();
            EsAdmin = new DataGridViewTextBoxColumn();
            Reservas = new DataGridViewTextBoxColumn();
            LabelBienvenida = new Label();
            CerrarSesion = new Button();
            Pestañas.SuspendLayout();
            Salas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSalas).BeginInit();
            Usuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).BeginInit();
            SuspendLayout();
            // 
            // Pestañas
            // 
            Pestañas.Controls.Add(Salas);
            Pestañas.Controls.Add(Funciones);
            Pestañas.Controls.Add(Películas);
            Pestañas.Controls.Add(Usuarios);
            Pestañas.Location = new Point(16, 87);
            Pestañas.Multiline = true;
            Pestañas.Name = "Pestañas";
            Pestañas.SelectedIndex = 0;
            Pestañas.Size = new Size(771, 347);
            Pestañas.TabIndex = 0;
            Pestañas.Selected += Pestañas_Selected;
            // 
            // Salas
            // 
            Salas.Controls.Add(dataGridSalas);
            Salas.Location = new Point(4, 24);
            Salas.Name = "Salas";
            Salas.Padding = new Padding(3);
            Salas.Size = new Size(763, 319);
            Salas.TabIndex = 0;
            Salas.Text = "Salas";
            Salas.UseVisualStyleBackColor = true;
            Salas.Click += Salas_Click;
            // 
            // dataGridSalas
            // 
            dataGridSalas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSalas.Columns.AddRange(new DataGridViewColumn[] { ID, Ubicacion, Capacidad });
            dataGridSalas.Dock = DockStyle.Fill;
            dataGridSalas.Location = new Point(3, 3);
            dataGridSalas.Name = "dataGridSalas";
            dataGridSalas.RowTemplate.Height = 25;
            dataGridSalas.Size = new Size(757, 313);
            dataGridSalas.TabIndex = 0;
            dataGridSalas.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // Ubicacion
            // 
            Ubicacion.HeaderText = "Ubicacion";
            Ubicacion.Name = "Ubicacion";
            // 
            // Capacidad
            // 
            Capacidad.HeaderText = "Capacidad";
            Capacidad.Name = "Capacidad";
            // 
            // Funciones
            // 
            Funciones.Location = new Point(4, 24);
            Funciones.Name = "Funciones";
            Funciones.Padding = new Padding(3);
            Funciones.Size = new Size(763, 319);
            Funciones.TabIndex = 1;
            Funciones.Text = "Funciones";
            Funciones.UseVisualStyleBackColor = true;
            // 
            // Películas
            // 
            Películas.Location = new Point(4, 24);
            Películas.Name = "Películas";
            Películas.Padding = new Padding(3);
            Películas.Size = new Size(763, 319);
            Películas.TabIndex = 2;
            Películas.Text = "Películas";
            Películas.UseVisualStyleBackColor = true;
            // 
            // Usuarios
            // 
            Usuarios.Controls.Add(dataGridUsuarios);
            Usuarios.Location = new Point(4, 24);
            Usuarios.Name = "Usuarios";
            Usuarios.Size = new Size(763, 319);
            Usuarios.TabIndex = 3;
            Usuarios.Text = "Usuarios";
            Usuarios.UseVisualStyleBackColor = true;
            // 
            // dataGridUsuarios
            // 
            dataGridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUsuarios.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, DNI, Nombre, Apellido, Mail, Password, IntentosFallidos, Bloquedo, dataGridViewTextBoxColumn2, Credito, FechaNacimiento, EsAdmin, Reservas });
            dataGridUsuarios.Dock = DockStyle.Fill;
            dataGridUsuarios.Location = new Point(0, 0);
            dataGridUsuarios.Name = "dataGridUsuarios";
            dataGridUsuarios.RowTemplate.Height = 25;
            dataGridUsuarios.Size = new Size(763, 319);
            dataGridUsuarios.TabIndex = 0;
            dataGridUsuarios.CellContentClick += dataGridUsuarios_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // DNI
            // 
            DNI.HeaderText = "DNI";
            DNI.Name = "DNI";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            // 
            // Mail
            // 
            Mail.HeaderText = "Mail";
            Mail.Name = "Mail";
            // 
            // Password
            // 
            Password.HeaderText = "Password";
            Password.Name = "Password";
            // 
            // IntentosFallidos
            // 
            IntentosFallidos.HeaderText = "Intentos_Fallidos";
            IntentosFallidos.Name = "IntentosFallidos";
            // 
            // Bloquedo
            // 
            Bloquedo.HeaderText = "Bloqueado";
            Bloquedo.Name = "Bloquedo";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Funciones";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Credito
            // 
            Credito.HeaderText = "Credito";
            Credito.Name = "Credito";
            // 
            // FechaNacimiento
            // 
            FechaNacimiento.HeaderText = "Fecha_Nacimiento";
            FechaNacimiento.Name = "FechaNacimiento";
            // 
            // EsAdmin
            // 
            EsAdmin.HeaderText = "Es_Admin";
            EsAdmin.Name = "EsAdmin";
            // 
            // Reservas
            // 
            Reservas.HeaderText = "Reservas";
            Reservas.Name = "Reservas";
            // 
            // LabelBienvenida
            // 
            LabelBienvenida.AutoSize = true;
            LabelBienvenida.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            LabelBienvenida.Location = new Point(12, 30);
            LabelBienvenida.Name = "LabelBienvenida";
            LabelBienvenida.Size = new Size(129, 28);
            LabelBienvenida.TabIndex = 28;
            LabelBienvenida.Text = "Bienvenido, ";
            // 
            // CerrarSesion
            // 
            CerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            CerrarSesion.Location = new Point(642, 32);
            CerrarSesion.Name = "CerrarSesion";
            CerrarSesion.Size = new Size(145, 31);
            CerrarSesion.TabIndex = 18;
            CerrarSesion.Tag = "btn";
            CerrarSesion.Text = "Cerrar Sesión";
            CerrarSesion.UseVisualStyleBackColor = true;
            CerrarSesion.Click += Btn_CerrarSesion;
            // 
            // PantallaABMAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 462);
            Controls.Add(LabelBienvenida);
            Controls.Add(CerrarSesion);
            Controls.Add(Pestañas);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaABMAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form6";
            Load += PantallaABMAdmin_Load;
            Pestañas.ResumeLayout(false);
            Salas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridSalas).EndInit();
            Usuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl Pestañas;
        private TabPage Salas;
        private TabPage Funciones;
        private TabPage Películas;
        private TabPage Usuarios;
        private Label LabelBienvenida;
        private Button CerrarSesion;
        private DataGridView dataGridSalas;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Ubicacion;
        private DataGridViewTextBoxColumn Capacidad;
        private DataGridView dataGridUsuarios;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn DNI;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Mail;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn IntentosFallidos;
        private DataGridViewTextBoxColumn Bloquedo;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Credito;
        private DataGridViewTextBoxColumn FechaNacimiento;
        private DataGridViewTextBoxColumn EsAdmin;
        private DataGridViewTextBoxColumn Reservas;
    }
}