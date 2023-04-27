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
            button4 = new Button();
            button3 = new Button();
            label10 = new Label();
            comboBox2 = new ComboBox();
            Cb_EsAdmin = new CheckBox();
            label9 = new Label();
            Cb_Bloqueado = new CheckBox();
            Selecc_FechaDeNacimiento = new DateTimePicker();
            label5 = new Label();
            Input_Credito = new TextBox();
            label6 = new Label();
            Input_IntentosFallidos = new TextBox();
            label7 = new Label();
            label8 = new Label();
            Input_DNI = new TextBox();
            button2 = new Button();
            label3 = new Label();
            Input_Password = new TextBox();
            label4 = new Label();
            Input_Mail = new TextBox();
            label2 = new Label();
            Input_Apellido = new TextBox();
            label1 = new Label();
            Input_Nombre = new TextBox();
            button1 = new Button();
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
            Btn_VerFunciones = new Button();
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
            Pestañas.Location = new Point(16, 80);
            Pestañas.Multiline = true;
            Pestañas.Name = "Pestañas";
            Pestañas.SelectedIndex = 0;
            Pestañas.Size = new Size(782, 354);
            Pestañas.TabIndex = 0;
            Pestañas.Selected += Pestañas_Selected;
            // 
            // Salas
            // 
            Salas.Controls.Add(dataGridSalas);
            Salas.Location = new Point(4, 24);
            Salas.Name = "Salas";
            Salas.Padding = new Padding(3);
            Salas.Size = new Size(774, 326);
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
            dataGridSalas.Size = new Size(768, 320);
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
            Funciones.Size = new Size(774, 326);
            Funciones.TabIndex = 1;
            Funciones.Text = "Funciones";
            Funciones.UseVisualStyleBackColor = true;
            // 
            // Películas
            // 
            Películas.Location = new Point(4, 24);
            Películas.Name = "Películas";
            Películas.Padding = new Padding(3);
            Películas.Size = new Size(774, 326);
            Películas.TabIndex = 2;
            Películas.Text = "Películas";
            Películas.UseVisualStyleBackColor = true;
            // 
            // Usuarios
            // 
            Usuarios.Controls.Add(Btn_VerFunciones);
            Usuarios.Controls.Add(button4);
            Usuarios.Controls.Add(button3);
            Usuarios.Controls.Add(label10);
            Usuarios.Controls.Add(comboBox2);
            Usuarios.Controls.Add(Cb_EsAdmin);
            Usuarios.Controls.Add(label9);
            Usuarios.Controls.Add(Cb_Bloqueado);
            Usuarios.Controls.Add(Selecc_FechaDeNacimiento);
            Usuarios.Controls.Add(label5);
            Usuarios.Controls.Add(Input_Credito);
            Usuarios.Controls.Add(label6);
            Usuarios.Controls.Add(Input_IntentosFallidos);
            Usuarios.Controls.Add(label7);
            Usuarios.Controls.Add(label8);
            Usuarios.Controls.Add(Input_DNI);
            Usuarios.Controls.Add(button2);
            Usuarios.Controls.Add(label3);
            Usuarios.Controls.Add(Input_Password);
            Usuarios.Controls.Add(label4);
            Usuarios.Controls.Add(Input_Mail);
            Usuarios.Controls.Add(label2);
            Usuarios.Controls.Add(Input_Apellido);
            Usuarios.Controls.Add(label1);
            Usuarios.Controls.Add(Input_Nombre);
            Usuarios.Controls.Add(button1);
            Usuarios.Controls.Add(dataGridUsuarios);
            Usuarios.Location = new Point(4, 24);
            Usuarios.Name = "Usuarios";
            Usuarios.Size = new Size(774, 326);
            Usuarios.TabIndex = 3;
            Usuarios.Text = "Usuarios";
            Usuarios.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(683, 12);
            button4.Name = "button4";
            button4.Size = new Size(72, 23);
            button4.TabIndex = 28;
            button4.Text = "Eliminar";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(605, 12);
            button3.Name = "button3";
            button3.Size = new Size(72, 23);
            button3.TabIndex = 27;
            button3.Text = "Modificar";
            button3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(583, 116);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 25;
            label10.Text = "Reservas:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(653, 111);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(102, 23);
            comboBox2.TabIndex = 24;
            // 
            // Cb_EsAdmin
            // 
            Cb_EsAdmin.AutoSize = true;
            Cb_EsAdmin.CheckAlign = ContentAlignment.MiddleRight;
            Cb_EsAdmin.Location = new Point(583, 84);
            Cb_EsAdmin.Name = "Cb_EsAdmin";
            Cb_EsAdmin.Size = new Size(62, 19);
            Cb_EsAdmin.TabIndex = 23;
            Cb_EsAdmin.Text = "Admin";
            Cb_EsAdmin.UseMnemonic = false;
            Cb_EsAdmin.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(394, 89);
            label9.Name = "label9";
            label9.Size = new Size(64, 15);
            label9.TabIndex = 22;
            label9.Text = "Funciones:";
            // 
            // Cb_Bloqueado
            // 
            Cb_Bloqueado.AutoSize = true;
            Cb_Bloqueado.CheckAlign = ContentAlignment.MiddleRight;
            Cb_Bloqueado.Location = new Point(394, 57);
            Cb_Bloqueado.Name = "Cb_Bloqueado";
            Cb_Bloqueado.Size = new Size(83, 19);
            Cb_Bloqueado.TabIndex = 20;
            Cb_Bloqueado.Text = "Bloqueado";
            Cb_Bloqueado.UseVisualStyleBackColor = true;
            // 
            // Selecc_FechaDeNacimiento
            // 
            Selecc_FechaDeNacimiento.Location = new Point(653, 55);
            Selecc_FechaDeNacimiento.Name = "Selecc_FechaDeNacimiento";
            Selecc_FechaDeNacimiento.Size = new Size(102, 23);
            Selecc_FechaDeNacimiento.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(396, 121);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 18;
            label5.Text = "Crédito: ";
            // 
            // Input_Credito
            // 
            Input_Credito.Location = new Point(464, 118);
            Input_Credito.Name = "Input_Credito";
            Input_Credito.Size = new Size(102, 23);
            Input_Credito.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(197, 118);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 16;
            label6.Text = "Intentos Fall.";
            // 
            // Input_IntentosFallidos
            // 
            Input_IntentosFallidos.Location = new Point(271, 115);
            Input_IntentosFallidos.Name = "Input_IntentosFallidos";
            Input_IntentosFallidos.Size = new Size(102, 23);
            Input_IntentosFallidos.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(583, 58);
            label7.Name = "label7";
            label7.Size = new Size(68, 15);
            label7.TabIndex = 14;
            label7.Text = "Fecha Nac.:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(4, 58);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 12;
            label8.Text = "DNI: ";
            // 
            // Input_DNI
            // 
            Input_DNI.Location = new Point(78, 55);
            Input_DNI.Name = "Input_DNI";
            Input_DNI.Size = new Size(102, 23);
            Input_DNI.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(4, 12);
            button2.Name = "button2";
            button2.Size = new Size(67, 23);
            button2.TabIndex = 10;
            button2.Text = "Refrescar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Btn_RefrescarUsuarios;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(197, 89);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 9;
            label3.Text = "Password:";
            // 
            // Input_Password
            // 
            Input_Password.Location = new Point(271, 86);
            Input_Password.Name = "Input_Password";
            Input_Password.Size = new Size(102, 23);
            Input_Password.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(197, 60);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 7;
            label4.Text = "Mail:";
            // 
            // Input_Mail
            // 
            Input_Mail.Location = new Point(271, 57);
            Input_Mail.Name = "Input_Mail";
            Input_Mail.Size = new Size(102, 23);
            Input_Mail.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 118);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 5;
            label2.Text = "Apellido:";
            // 
            // Input_Apellido
            // 
            Input_Apellido.Location = new Point(77, 115);
            Input_Apellido.Name = "Input_Apellido";
            Input_Apellido.Size = new Size(102, 23);
            Input_Apellido.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 89);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 3;
            label1.Text = "Nombre:";
            // 
            // Input_Nombre
            // 
            Input_Nombre.Location = new Point(77, 86);
            Input_Nombre.Name = "Input_Nombre";
            Input_Nombre.Size = new Size(102, 23);
            Input_Nombre.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(527, 12);
            button1.Name = "button1";
            button1.Size = new Size(72, 23);
            button1.TabIndex = 1;
            button1.Text = "Nuevo";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridUsuarios
            // 
            dataGridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUsuarios.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, DNI, Nombre, Apellido, Mail, Password, IntentosFallidos, Bloquedo, dataGridViewTextBoxColumn2, Credito, FechaNacimiento, EsAdmin, Reservas });
            dataGridUsuarios.Location = new Point(4, 152);
            dataGridUsuarios.Name = "dataGridUsuarios";
            dataGridUsuarios.RowTemplate.Height = 25;
            dataGridUsuarios.Size = new Size(859, 171);
            dataGridUsuarios.TabIndex = 0;
            dataGridUsuarios.CellDoubleClick += dataGridUsuarios_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // DNI
            // 
            DNI.HeaderText = "DNI";
            DNI.Name = "DNI";
            DNI.ReadOnly = true;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            // 
            // Mail
            // 
            Mail.HeaderText = "Mail";
            Mail.Name = "Mail";
            Mail.ReadOnly = true;
            // 
            // Password
            // 
            Password.HeaderText = "Password";
            Password.Name = "Password";
            Password.ReadOnly = true;
            // 
            // IntentosFallidos
            // 
            IntentosFallidos.HeaderText = "Intentos_Fallidos";
            IntentosFallidos.Name = "IntentosFallidos";
            IntentosFallidos.ReadOnly = true;
            // 
            // Bloquedo
            // 
            Bloquedo.HeaderText = "Bloqueado";
            Bloquedo.Name = "Bloquedo";
            Bloquedo.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Funciones";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Credito
            // 
            Credito.HeaderText = "Credito";
            Credito.Name = "Credito";
            Credito.ReadOnly = true;
            // 
            // FechaNacimiento
            // 
            FechaNacimiento.HeaderText = "Fecha_Nacimiento";
            FechaNacimiento.Name = "FechaNacimiento";
            FechaNacimiento.ReadOnly = true;
            // 
            // EsAdmin
            // 
            EsAdmin.HeaderText = "Es_Admin";
            EsAdmin.Name = "EsAdmin";
            EsAdmin.ReadOnly = true;
            // 
            // Reservas
            // 
            Reservas.HeaderText = "Reservas";
            Reservas.Name = "Reservas";
            Reservas.ReadOnly = true;
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
            CerrarSesion.Location = new Point(627, 32);
            CerrarSesion.Name = "CerrarSesion";
            CerrarSesion.Size = new Size(145, 31);
            CerrarSesion.TabIndex = 18;
            CerrarSesion.Tag = "btn";
            CerrarSesion.Text = "Cerrar Sesión";
            CerrarSesion.UseVisualStyleBackColor = true;
            CerrarSesion.Click += Btn_CerrarSesion;
            // 
            // Btn_VerFunciones
            // 
            Btn_VerFunciones.BackColor = Color.White;
            Btn_VerFunciones.Location = new Point(464, 86);
            Btn_VerFunciones.Name = "Btn_VerFunciones";
            Btn_VerFunciones.Size = new Size(102, 23);
            Btn_VerFunciones.TabIndex = 29;
            Btn_VerFunciones.Text = "Ver Funciones";
            Btn_VerFunciones.UseVisualStyleBackColor = false;
            Btn_VerFunciones.Click += Btn_VerFunciones_Click;
            // 
            // PantallaABMAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 480);
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
            Usuarios.PerformLayout();
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
        private TextBox Input_Nombre;
        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox Input_Apellido;
        private Button button2;
        private Label label3;
        private TextBox Input_Password;
        private Label label4;
        private TextBox Input_Mail;
        private Label label7;
        private TextBox Input_FechaNacimiento;
        private Label label8;
        private TextBox Input_DNI;
        private Label label5;
        private TextBox Input_Credito;
        private Label label6;
        private TextBox Input_IntentosFallidos;
        private DateTimePicker Selecc_FechaDeNacimiento;
        private CheckBox Cb_Bloqueado;
        private Label label9;
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
        private Label label10;
        private ComboBox comboBox2;
        private CheckBox Cb_EsAdmin;
        private Button button4;
        private Button button3;
        private Button Btn_VerFunciones;
    }
}