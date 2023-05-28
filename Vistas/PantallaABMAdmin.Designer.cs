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
            Label_SalaId = new Label();
            Btn_EliminarSala = new Button();
            Btn_ModificarSala = new Button();
            Btn_RefrescarSalas = new Button();
            Btn_NuevoSala = new Button();
            label11 = new Label();
            Input_Capacidad = new TextBox();
            Label_UbicacionSala = new Label();
            Input_Ubicacion = new TextBox();
            dataGridSalas = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Ubicacion = new DataGridViewTextBoxColumn();
            Capacidad = new DataGridViewTextBoxColumn();
            Funciones = new TabPage();
            Label_FuncionId = new Label();
            Input_Costo = new TextBox();
            label14 = new Label();
            Input_CantidadClientes = new TextBox();
            Selec_Fecha = new DateTimePicker();
            Cb_Peliculas = new ComboBox();
            label13 = new Label();
            Cb_Salas = new ComboBox();
            Btn_EliminarFuncion = new Button();
            Btn_ModificarFuncion = new Button();
            Btn_RefrescarFunciones = new Button();
            Btn_NuevoFuncion = new Button();
            Label_Fecha = new Label();
            label12 = new Label();
            Input_MiSala = new Label();
            dataGridFunciones = new DataGridView();
            Películas = new TabPage();
            CLB_Funciones = new CheckedListBox();
            Label_PeliculaId = new Label();
            Input_Sinopsis = new TextBox();
            Input_Descripcion = new TextBox();
            label19 = new Label();
            Input_Nombre_Pelicula = new TextBox();
            Input_Duracion = new TextBox();
            label10 = new Label();
            Input_Poster = new TextBox();
            label15 = new Label();
            Btn_EliminarPelicula = new Button();
            Btn_ModificarPelicula = new Button();
            button4 = new Button();
            Btn_NuevoPelicula = new Button();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            dataGridPeliculas = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            Sinopsis = new DataGridViewTextBoxColumn();
            Poster = new DataGridViewTextBoxColumn();
            Duracion = new DataGridViewTextBoxColumn();
            Usuarios = new TabPage();
            Label_IdUsuario = new Label();
            Btn_VerFunciones = new Button();
            Btn_EliminarUsuario = new Button();
            Btn_ModificarUsuario = new Button();
            Cb_EsAdmin = new CheckBox();
            label9 = new Label();
            Cb_Bloqueado = new CheckBox();
            Selec_FechaDeNacimiento = new DateTimePicker();
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
            Btn_NuevoUsuario = new Button();
            dataGridUsuarios = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            DNI = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Mail = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            IntentosFallidos = new DataGridViewTextBoxColumn();
            Bloquedo = new DataGridViewTextBoxColumn();
            Credito = new DataGridViewTextBoxColumn();
            FechaNacimiento = new DataGridViewTextBoxColumn();
            EsAdmin = new DataGridViewTextBoxColumn();
            LabelBienvenida = new Label();
            Btn_CerrarSesionAdmin = new Button();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Cant_Clientes = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Id_MiSala = new DataGridViewTextBoxColumn();
            Id_Pelicula = new DataGridViewTextBoxColumn();
            Pestañas.SuspendLayout();
            Salas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSalas).BeginInit();
            Funciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridFunciones).BeginInit();
            Películas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPeliculas).BeginInit();
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
            Pestañas.Size = new Size(1064, 375);
            Pestañas.TabIndex = 0;
            Pestañas.SelectedIndexChanged += Pestañas_SelectedIndexChanged;
            Pestañas.Selected += Pestañas_Selected;
            // 
            // Salas
            // 
            Salas.Controls.Add(Label_SalaId);
            Salas.Controls.Add(Btn_EliminarSala);
            Salas.Controls.Add(Btn_ModificarSala);
            Salas.Controls.Add(Btn_RefrescarSalas);
            Salas.Controls.Add(Btn_NuevoSala);
            Salas.Controls.Add(label11);
            Salas.Controls.Add(Input_Capacidad);
            Salas.Controls.Add(Label_UbicacionSala);
            Salas.Controls.Add(Input_Ubicacion);
            Salas.Controls.Add(dataGridSalas);
            Salas.Location = new Point(4, 24);
            Salas.Name = "Salas";
            Salas.Padding = new Padding(3);
            Salas.Size = new Size(1056, 347);
            Salas.TabIndex = 0;
            Salas.Text = "Salas";
            Salas.UseVisualStyleBackColor = true;
            // 
            // Label_SalaId
            // 
            Label_SalaId.AutoSize = true;
            Label_SalaId.Location = new Point(81, 10);
            Label_SalaId.Name = "Label_SalaId";
            Label_SalaId.Size = new Size(0, 15);
            Label_SalaId.TabIndex = 33;
            Label_SalaId.Visible = false;
            // 
            // Btn_EliminarSala
            // 
            Btn_EliminarSala.Location = new Point(687, 6);
            Btn_EliminarSala.Name = "Btn_EliminarSala";
            Btn_EliminarSala.Size = new Size(72, 23);
            Btn_EliminarSala.TabIndex = 32;
            Btn_EliminarSala.Text = "Eliminar";
            Btn_EliminarSala.UseVisualStyleBackColor = true;
            Btn_EliminarSala.Click += Btn_EliminarSala_Click;
            // 
            // Btn_ModificarSala
            // 
            Btn_ModificarSala.Location = new Point(609, 6);
            Btn_ModificarSala.Name = "Btn_ModificarSala";
            Btn_ModificarSala.Size = new Size(72, 23);
            Btn_ModificarSala.TabIndex = 31;
            Btn_ModificarSala.Text = "Modificar";
            Btn_ModificarSala.UseVisualStyleBackColor = true;
            Btn_ModificarSala.Click += Btn_ModificarSala_Click;
            // 
            // Btn_RefrescarSalas
            // 
            Btn_RefrescarSalas.Location = new Point(8, 6);
            Btn_RefrescarSalas.Name = "Btn_RefrescarSalas";
            Btn_RefrescarSalas.Size = new Size(67, 23);
            Btn_RefrescarSalas.TabIndex = 30;
            Btn_RefrescarSalas.Text = "Refrescar";
            Btn_RefrescarSalas.UseVisualStyleBackColor = true;
            Btn_RefrescarSalas.Click += Btn_RefrescarSalas_Click;
            // 
            // Btn_NuevoSala
            // 
            Btn_NuevoSala.Location = new Point(531, 6);
            Btn_NuevoSala.Name = "Btn_NuevoSala";
            Btn_NuevoSala.Size = new Size(72, 23);
            Btn_NuevoSala.TabIndex = 29;
            Btn_NuevoSala.Text = "Nuevo";
            Btn_NuevoSala.UseVisualStyleBackColor = true;
            Btn_NuevoSala.Click += Btn_NuevoSala_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 92);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 4;
            label11.Text = "Capacidad: ";
            // 
            // Input_Capacidad
            // 
            Input_Capacidad.Location = new Point(96, 89);
            Input_Capacidad.Name = "Input_Capacidad";
            Input_Capacidad.Size = new Size(100, 23);
            Input_Capacidad.TabIndex = 3;
            // 
            // Label_UbicacionSala
            // 
            Label_UbicacionSala.AutoSize = true;
            Label_UbicacionSala.Location = new Point(6, 50);
            Label_UbicacionSala.Name = "Label_UbicacionSala";
            Label_UbicacionSala.Size = new Size(90, 15);
            Label_UbicacionSala.TabIndex = 2;
            Label_UbicacionSala.Text = "Ubicacion Sala: ";
            // 
            // Input_Ubicacion
            // 
            Input_Ubicacion.Location = new Point(96, 47);
            Input_Ubicacion.Name = "Input_Ubicacion";
            Input_Ubicacion.Size = new Size(100, 23);
            Input_Ubicacion.TabIndex = 1;
            // 
            // dataGridSalas
            // 
            dataGridSalas.AllowUserToOrderColumns = true;
            dataGridSalas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSalas.Columns.AddRange(new DataGridViewColumn[] { ID, Ubicacion, Capacidad });
            dataGridSalas.Location = new Point(3, 129);
            dataGridSalas.Name = "dataGridSalas";
            dataGridSalas.RowTemplate.Height = 25;
            dataGridSalas.Size = new Size(768, 194);
            dataGridSalas.TabIndex = 0;
            dataGridSalas.CellDoubleClick += DataGridSalas_CellDoubleClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Ubicacion
            // 
            Ubicacion.HeaderText = "Ubicacion";
            Ubicacion.Name = "Ubicacion";
            Ubicacion.ReadOnly = true;
            // 
            // Capacidad
            // 
            Capacidad.HeaderText = "Capacidad";
            Capacidad.Name = "Capacidad";
            Capacidad.ReadOnly = true;
            // 
            // Funciones
            // 
            Funciones.Controls.Add(Label_FuncionId);
            Funciones.Controls.Add(Input_Costo);
            Funciones.Controls.Add(label14);
            Funciones.Controls.Add(Input_CantidadClientes);
            Funciones.Controls.Add(Selec_Fecha);
            Funciones.Controls.Add(Cb_Peliculas);
            Funciones.Controls.Add(label13);
            Funciones.Controls.Add(Cb_Salas);
            Funciones.Controls.Add(Btn_EliminarFuncion);
            Funciones.Controls.Add(Btn_ModificarFuncion);
            Funciones.Controls.Add(Btn_RefrescarFunciones);
            Funciones.Controls.Add(Btn_NuevoFuncion);
            Funciones.Controls.Add(Label_Fecha);
            Funciones.Controls.Add(label12);
            Funciones.Controls.Add(Input_MiSala);
            Funciones.Controls.Add(dataGridFunciones);
            Funciones.Location = new Point(4, 24);
            Funciones.Name = "Funciones";
            Funciones.Padding = new Padding(3);
            Funciones.Size = new Size(1056, 347);
            Funciones.TabIndex = 1;
            Funciones.Text = "Funciones";
            Funciones.UseVisualStyleBackColor = true;
            // 
            // Label_FuncionId
            // 
            Label_FuncionId.AutoSize = true;
            Label_FuncionId.Location = new Point(81, 9);
            Label_FuncionId.Name = "Label_FuncionId";
            Label_FuncionId.Size = new Size(0, 15);
            Label_FuncionId.TabIndex = 49;
            Label_FuncionId.Visible = false;
            // 
            // Input_Costo
            // 
            Input_Costo.Location = new Point(516, 46);
            Input_Costo.Name = "Input_Costo";
            Input_Costo.Size = new Size(100, 23);
            Input_Costo.TabIndex = 48;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(466, 52);
            label14.Name = "label14";
            label14.Size = new Size(44, 15);
            label14.TabIndex = 47;
            label14.Text = "Costo: ";
            // 
            // Input_CantidadClientes
            // 
            Input_CantidadClientes.Location = new Point(333, 78);
            Input_CantidadClientes.Name = "Input_CantidadClientes";
            Input_CantidadClientes.ReadOnly = true;
            Input_CantidadClientes.Size = new Size(100, 23);
            Input_CantidadClientes.TabIndex = 46;
            // 
            // Selec_Fecha
            // 
            Selec_Fecha.Location = new Point(333, 49);
            Selec_Fecha.Name = "Selec_Fecha";
            Selec_Fecha.Size = new Size(100, 23);
            Selec_Fecha.TabIndex = 45;
            // 
            // Cb_Peliculas
            // 
            Cb_Peliculas.FormattingEnabled = true;
            Cb_Peliculas.Location = new Point(96, 78);
            Cb_Peliculas.Name = "Cb_Peliculas";
            Cb_Peliculas.Size = new Size(100, 23);
            Cb_Peliculas.TabIndex = 44;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(8, 78);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 43;
            label13.Text = "Pelicula:";
            // 
            // Cb_Salas
            // 
            Cb_Salas.FormattingEnabled = true;
            Cb_Salas.Location = new Point(96, 49);
            Cb_Salas.Name = "Cb_Salas";
            Cb_Salas.Size = new Size(100, 23);
            Cb_Salas.TabIndex = 42;
            // 
            // Btn_EliminarFuncion
            // 
            Btn_EliminarFuncion.Location = new Point(687, 5);
            Btn_EliminarFuncion.Name = "Btn_EliminarFuncion";
            Btn_EliminarFuncion.Size = new Size(72, 23);
            Btn_EliminarFuncion.TabIndex = 41;
            Btn_EliminarFuncion.Text = "Eliminar";
            Btn_EliminarFuncion.UseVisualStyleBackColor = true;
            Btn_EliminarFuncion.Click += Btn_EliminarFuncion_Click;
            // 
            // Btn_ModificarFuncion
            // 
            Btn_ModificarFuncion.Location = new Point(609, 5);
            Btn_ModificarFuncion.Name = "Btn_ModificarFuncion";
            Btn_ModificarFuncion.Size = new Size(72, 23);
            Btn_ModificarFuncion.TabIndex = 40;
            Btn_ModificarFuncion.Text = "Modificar";
            Btn_ModificarFuncion.UseVisualStyleBackColor = true;
            Btn_ModificarFuncion.Click += Btn_ModificarFuncion_Click;
            // 
            // Btn_RefrescarFunciones
            // 
            Btn_RefrescarFunciones.Location = new Point(8, 5);
            Btn_RefrescarFunciones.Name = "Btn_RefrescarFunciones";
            Btn_RefrescarFunciones.Size = new Size(67, 23);
            Btn_RefrescarFunciones.TabIndex = 39;
            Btn_RefrescarFunciones.Text = "Refrescar";
            Btn_RefrescarFunciones.UseVisualStyleBackColor = true;
            Btn_RefrescarFunciones.Click += Btn_RefrescarFunciones_Click;
            // 
            // Btn_NuevoFuncion
            // 
            Btn_NuevoFuncion.Location = new Point(531, 5);
            Btn_NuevoFuncion.Name = "Btn_NuevoFuncion";
            Btn_NuevoFuncion.Size = new Size(72, 23);
            Btn_NuevoFuncion.TabIndex = 38;
            Btn_NuevoFuncion.Text = "Nuevo";
            Btn_NuevoFuncion.UseVisualStyleBackColor = true;
            Btn_NuevoFuncion.Click += Btn_NuevaFuncion_Click;
            // 
            // Label_Fecha
            // 
            Label_Fecha.AutoSize = true;
            Label_Fecha.Location = new Point(244, 52);
            Label_Fecha.Name = "Label_Fecha";
            Label_Fecha.Size = new Size(44, 15);
            Label_Fecha.TabIndex = 37;
            Label_Fecha.Text = "Fecha: ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(244, 81);
            label12.Name = "label12";
            label12.Size = new Size(83, 15);
            label12.TabIndex = 37;
            label12.Text = "Cant. Clientes ";
            // 
            // Input_MiSala
            // 
            Input_MiSala.AutoSize = true;
            Input_MiSala.Location = new Point(8, 49);
            Input_MiSala.Name = "Input_MiSala";
            Input_MiSala.Size = new Size(34, 15);
            Input_MiSala.TabIndex = 35;
            Input_MiSala.Text = "Sala: ";
            // 
            // dataGridFunciones
            // 
            dataGridFunciones.AllowUserToOrderColumns = true;
            dataGridFunciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridFunciones.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, Fecha, Cant_Clientes, Costo, Id_MiSala, Id_Pelicula });
            dataGridFunciones.Location = new Point(8, 126);
            dataGridFunciones.Name = "dataGridFunciones";
            dataGridFunciones.RowTemplate.Height = 25;
            dataGridFunciones.Size = new Size(770, 202);
            dataGridFunciones.TabIndex = 33;
            dataGridFunciones.CellDoubleClick += DataGridFunciones_CellDoubleClick;
            // 
            // Películas
            // 
            Películas.Controls.Add(CLB_Funciones);
            Películas.Controls.Add(Label_PeliculaId);
            Películas.Controls.Add(Input_Sinopsis);
            Películas.Controls.Add(Input_Descripcion);
            Películas.Controls.Add(label19);
            Películas.Controls.Add(Input_Nombre_Pelicula);
            Películas.Controls.Add(Input_Duracion);
            Películas.Controls.Add(label10);
            Películas.Controls.Add(Input_Poster);
            Películas.Controls.Add(label15);
            Películas.Controls.Add(Btn_EliminarPelicula);
            Películas.Controls.Add(Btn_ModificarPelicula);
            Películas.Controls.Add(button4);
            Películas.Controls.Add(Btn_NuevoPelicula);
            Películas.Controls.Add(label16);
            Películas.Controls.Add(label17);
            Películas.Controls.Add(label18);
            Películas.Controls.Add(dataGridPeliculas);
            Películas.Location = new Point(4, 24);
            Películas.Name = "Películas";
            Películas.Padding = new Padding(3);
            Películas.Size = new Size(1056, 347);
            Películas.TabIndex = 2;
            Películas.Text = "Películas";
            Películas.UseVisualStyleBackColor = true;
            // 
            // CLB_Funciones
            // 
            CLB_Funciones.FormattingEnabled = true;
            CLB_Funciones.Location = new Point(493, 78);
            CLB_Funciones.Name = "CLB_Funciones";
            CLB_Funciones.Size = new Size(188, 40);
            CLB_Funciones.TabIndex = 69;
            // 
            // Label_PeliculaId
            // 
            Label_PeliculaId.AutoSize = true;
            Label_PeliculaId.Location = new Point(95, 10);
            Label_PeliculaId.Name = "Label_PeliculaId";
            Label_PeliculaId.Size = new Size(0, 15);
            Label_PeliculaId.TabIndex = 68;
            Label_PeliculaId.Visible = false;
            // 
            // Input_Sinopsis
            // 
            Input_Sinopsis.Location = new Point(296, 46);
            Input_Sinopsis.Name = "Input_Sinopsis";
            Input_Sinopsis.Size = new Size(100, 23);
            Input_Sinopsis.TabIndex = 67;
            // 
            // Input_Descripcion
            // 
            Input_Descripcion.Location = new Point(96, 81);
            Input_Descripcion.Name = "Input_Descripcion";
            Input_Descripcion.Size = new Size(100, 23);
            Input_Descripcion.TabIndex = 66;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(8, 86);
            label19.Name = "label19";
            label19.Size = new Size(75, 15);
            label19.TabIndex = 65;
            label19.Text = "Descripcion: ";
            // 
            // Input_Nombre_Pelicula
            // 
            Input_Nombre_Pelicula.Location = new Point(96, 44);
            Input_Nombre_Pelicula.Name = "Input_Nombre_Pelicula";
            Input_Nombre_Pelicula.Size = new Size(100, 23);
            Input_Nombre_Pelicula.TabIndex = 64;
            // 
            // Input_Duracion
            // 
            Input_Duracion.Location = new Point(493, 46);
            Input_Duracion.Name = "Input_Duracion";
            Input_Duracion.Size = new Size(188, 23);
            Input_Duracion.TabIndex = 63;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(420, 52);
            label10.Name = "label10";
            label10.Size = new Size(61, 15);
            label10.TabIndex = 62;
            label10.Text = "Duracion: ";
            // 
            // Input_Poster
            // 
            Input_Poster.Location = new Point(296, 75);
            Input_Poster.Name = "Input_Poster";
            Input_Poster.Size = new Size(100, 23);
            Input_Poster.TabIndex = 61;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(420, 78);
            label15.Name = "label15";
            label15.Size = new Size(67, 15);
            label15.TabIndex = 58;
            label15.Text = "Funciones: ";
            // 
            // Btn_EliminarPelicula
            // 
            Btn_EliminarPelicula.Location = new Point(687, 5);
            Btn_EliminarPelicula.Name = "Btn_EliminarPelicula";
            Btn_EliminarPelicula.Size = new Size(72, 23);
            Btn_EliminarPelicula.TabIndex = 56;
            Btn_EliminarPelicula.Text = "Eliminar";
            Btn_EliminarPelicula.UseVisualStyleBackColor = true;
            Btn_EliminarPelicula.Click += Btn_EliminarPelicula_Click;
            // 
            // Btn_ModificarPelicula
            // 
            Btn_ModificarPelicula.Location = new Point(609, 5);
            Btn_ModificarPelicula.Name = "Btn_ModificarPelicula";
            Btn_ModificarPelicula.Size = new Size(72, 23);
            Btn_ModificarPelicula.TabIndex = 55;
            Btn_ModificarPelicula.Text = "Modificar";
            Btn_ModificarPelicula.UseVisualStyleBackColor = true;
            Btn_ModificarPelicula.Click += Btn_ModificarPelicula_Click;
            // 
            // button4
            // 
            button4.Location = new Point(8, 5);
            button4.Name = "button4";
            button4.Size = new Size(67, 23);
            button4.TabIndex = 54;
            button4.Text = "Refrescar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Btn_RefrescarPeliculas;
            // 
            // Btn_NuevoPelicula
            // 
            Btn_NuevoPelicula.Location = new Point(531, 5);
            Btn_NuevoPelicula.Name = "Btn_NuevoPelicula";
            Btn_NuevoPelicula.Size = new Size(72, 23);
            Btn_NuevoPelicula.TabIndex = 53;
            Btn_NuevoPelicula.Text = "Nuevo";
            Btn_NuevoPelicula.UseVisualStyleBackColor = true;
            Btn_NuevoPelicula.Click += Btn_NuevoPelicula_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(244, 52);
            label16.Name = "label16";
            label16.Size = new Size(56, 15);
            label16.TabIndex = 51;
            label16.Text = "Sinopsis: ";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(244, 81);
            label17.Name = "label17";
            label17.Size = new Size(46, 15);
            label17.TabIndex = 52;
            label17.Text = "Poster: ";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(8, 49);
            label18.Name = "label18";
            label18.Size = new Size(57, 15);
            label18.TabIndex = 50;
            label18.Text = "Nombre: ";
            // 
            // dataGridPeliculas
            // 
            dataGridPeliculas.AllowUserToOrderColumns = true;
            dataGridPeliculas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPeliculas.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, Descripcion, Sinopsis, Poster, Duracion });
            dataGridPeliculas.Location = new Point(3, 128);
            dataGridPeliculas.Name = "dataGridPeliculas";
            dataGridPeliculas.RowTemplate.Height = 25;
            dataGridPeliculas.Size = new Size(768, 194);
            dataGridPeliculas.TabIndex = 49;
            dataGridPeliculas.CellDoubleClick += DataGridPeliculas_CellDoubleClick_2;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "ID";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Nombre";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // Sinopsis
            // 
            Sinopsis.HeaderText = "Sinopsis";
            Sinopsis.Name = "Sinopsis";
            Sinopsis.ReadOnly = true;
            // 
            // Poster
            // 
            Poster.HeaderText = "Poster";
            Poster.Name = "Poster";
            Poster.ReadOnly = true;
            // 
            // Duracion
            // 
            Duracion.HeaderText = "Duracion";
            Duracion.Name = "Duracion";
            Duracion.ReadOnly = true;
            // 
            // Usuarios
            // 
            Usuarios.Controls.Add(Label_IdUsuario);
            Usuarios.Controls.Add(Btn_VerFunciones);
            Usuarios.Controls.Add(Btn_EliminarUsuario);
            Usuarios.Controls.Add(Btn_ModificarUsuario);
            Usuarios.Controls.Add(Cb_EsAdmin);
            Usuarios.Controls.Add(label9);
            Usuarios.Controls.Add(Cb_Bloqueado);
            Usuarios.Controls.Add(Selec_FechaDeNacimiento);
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
            Usuarios.Controls.Add(Btn_NuevoUsuario);
            Usuarios.Controls.Add(dataGridUsuarios);
            Usuarios.Location = new Point(4, 24);
            Usuarios.Name = "Usuarios";
            Usuarios.Size = new Size(1056, 347);
            Usuarios.TabIndex = 3;
            Usuarios.Text = "Usuarios";
            Usuarios.UseVisualStyleBackColor = true;
            // 
            // Label_IdUsuario
            // 
            Label_IdUsuario.AutoSize = true;
            Label_IdUsuario.Location = new Point(78, 16);
            Label_IdUsuario.Name = "Label_IdUsuario";
            Label_IdUsuario.Size = new Size(0, 15);
            Label_IdUsuario.TabIndex = 30;
            Label_IdUsuario.Visible = false;
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
            // Btn_EliminarUsuario
            // 
            Btn_EliminarUsuario.Location = new Point(683, 12);
            Btn_EliminarUsuario.Name = "Btn_EliminarUsuario";
            Btn_EliminarUsuario.Size = new Size(72, 23);
            Btn_EliminarUsuario.TabIndex = 28;
            Btn_EliminarUsuario.Text = "Eliminar";
            Btn_EliminarUsuario.UseVisualStyleBackColor = true;
            Btn_EliminarUsuario.Click += Btn_EliminarUsuario_Click;
            // 
            // Btn_ModificarUsuario
            // 
            Btn_ModificarUsuario.Location = new Point(605, 12);
            Btn_ModificarUsuario.Name = "Btn_ModificarUsuario";
            Btn_ModificarUsuario.Size = new Size(72, 23);
            Btn_ModificarUsuario.TabIndex = 27;
            Btn_ModificarUsuario.Text = "Modificar";
            Btn_ModificarUsuario.UseVisualStyleBackColor = true;
            Btn_ModificarUsuario.Click += Btn_ModificarUsuario_Click;
            // 
            // Cb_EsAdmin
            // 
            Cb_EsAdmin.AutoSize = true;
            Cb_EsAdmin.CheckAlign = ContentAlignment.MiddleRight;
            Cb_EsAdmin.Location = new Point(582, 115);
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
            // Selec_FechaDeNacimiento
            // 
            Selec_FechaDeNacimiento.Location = new Point(652, 86);
            Selec_FechaDeNacimiento.Name = "Selec_FechaDeNacimiento";
            Selec_FechaDeNacimiento.Size = new Size(102, 23);
            Selec_FechaDeNacimiento.TabIndex = 19;
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
            label7.Location = new Point(582, 89);
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
            // Btn_NuevoUsuario
            // 
            Btn_NuevoUsuario.Location = new Point(527, 12);
            Btn_NuevoUsuario.Name = "Btn_NuevoUsuario";
            Btn_NuevoUsuario.Size = new Size(72, 23);
            Btn_NuevoUsuario.TabIndex = 1;
            Btn_NuevoUsuario.Text = "Nuevo";
            Btn_NuevoUsuario.UseVisualStyleBackColor = true;
            Btn_NuevoUsuario.Click += Btn_NuevoUsuario_Click;
            // 
            // dataGridUsuarios
            // 
            dataGridUsuarios.AllowUserToOrderColumns = true;
            dataGridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUsuarios.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, DNI, Nombre, Apellido, Mail, Password, IntentosFallidos, Bloquedo, Credito, FechaNacimiento, EsAdmin });
            dataGridUsuarios.Location = new Point(4, 152);
            dataGridUsuarios.Name = "dataGridUsuarios";
            dataGridUsuarios.RowTemplate.Height = 25;
            dataGridUsuarios.Size = new Size(765, 171);
            dataGridUsuarios.TabIndex = 0;
            dataGridUsuarios.CellDoubleClick += DataGridUsuarios_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
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
            // Btn_CerrarSesionAdmin
            // 
            Btn_CerrarSesionAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_CerrarSesionAdmin.Location = new Point(627, 32);
            Btn_CerrarSesionAdmin.Name = "Btn_CerrarSesionAdmin";
            Btn_CerrarSesionAdmin.Size = new Size(145, 31);
            Btn_CerrarSesionAdmin.TabIndex = 18;
            Btn_CerrarSesionAdmin.Tag = "btn";
            Btn_CerrarSesionAdmin.Text = "Cerrar Sesión";
            Btn_CerrarSesionAdmin.UseVisualStyleBackColor = true;
            Btn_CerrarSesionAdmin.Click += Btn_CerrarSesion;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "ID";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Fecha
            // 
            Fecha.HeaderText = "Fecha";
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            // 
            // Cant_Clientes
            // 
            Cant_Clientes.HeaderText = "Asientos_Disponibles";
            Cant_Clientes.Name = "Cant_Clientes";
            Cant_Clientes.ReadOnly = true;
            // 
            // Costo
            // 
            Costo.HeaderText = "Costo";
            Costo.Name = "Costo";
            Costo.ReadOnly = true;
            // 
            // Id_MiSala
            // 
            Id_MiSala.HeaderText = "Id_MiSala";
            Id_MiSala.Name = "Id_MiSala";
            Id_MiSala.ReadOnly = true;
            // 
            // Id_Pelicula
            // 
            Id_Pelicula.HeaderText = "Id_Pelicula";
            Id_Pelicula.Name = "Id_Pelicula";
            Id_Pelicula.ReadOnly = true;
            // 
            // PantallaABMAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 480);
            Controls.Add(LabelBienvenida);
            Controls.Add(Btn_CerrarSesionAdmin);
            Controls.Add(Pestañas);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaABMAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form6";
            Load += PantallaABMAdmin_Load;
            Pestañas.ResumeLayout(false);
            Salas.ResumeLayout(false);
            Salas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSalas).EndInit();
            Funciones.ResumeLayout(false);
            Funciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridFunciones).EndInit();
            Películas.ResumeLayout(false);
            Películas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPeliculas).EndInit();
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
        private Button Btn_CerrarSesionAdmin;
        private DataGridView dataGridSalas;
        private DataGridView dataGridUsuarios;
        private TextBox Input_Nombre;
        private Button Btn_NuevoUsuario;
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
        private DateTimePicker Selec_FechaDeNacimiento;
        private CheckBox Cb_Bloqueado;
        private Label label9;
        private CheckBox Cb_EsAdmin;
        private Button Btn_EliminarUsuario;
        private Button Btn_ModificarUsuario;
        private Button Btn_VerFunciones;
        private Label label11;
        private TextBox Input_Capacidad;
        private Label Label_UbicacionSala;
        private TextBox Input_Ubicacion;
        private Button Btn_EliminarSala;
        private Button Btn_ModificarSala;
        private Button Btn_RefrescarSalas;
        private Button Btn_NuevoSala;
        private Button Btn_ModificarFuncion;
        private Button Btn_RefrescarFunciones;
        private Button Btn_NuevoFuncion;
        private Label label12;
        private Label Input_MiSala;
        private DataGridView dataGridFunciones;
        private ComboBox Cb_Salas;
        private Label label13;
        private ComboBox Cb_Pelicula;
        private ComboBox Cb_Peliculas;
        private Label Label_Fecha;
        private DateTimePicker Selec_Fecha;
        private TextBox Input_CantidadClientes;
        private TextBox Input_Costo;
        private Label label14;
        private Label Label_IdUsuario;
        private TextBox Input_Duracion;
        private Label label10;
        private TextBox Input_Poster;
        private ComboBox Cb_Funciones;
        private Label label15;
        private Button Btn_EliminarPelicula;
        private Button Btn_ModificarPelicula;
        private Button button4;
        private Button Btn_NuevoPelicula;
        private Label label16;
        private Label label17;
        private Label label18;
        private DataGridView dataGridPeliculas;
        private TextBox Input_Sinopsis;
        private TextBox Input_Descripcion;
        private Label label19;
        private TextBox Input_Nombre_Pelicula;
        private Label Label_SalaId;
        private Label Label_FuncionId;
        private Label Label_PeliculaId;
        private Button Btn_EliminarFuncion;
        private CheckedListBox CLB_Funciones;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn DNI;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Mail;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn IntentosFallidos;
        private DataGridViewTextBoxColumn Bloquedo;
        private DataGridViewTextBoxColumn Credito;
        private DataGridViewTextBoxColumn FechaNacimiento;
        private DataGridViewTextBoxColumn EsAdmin;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Ubicacion;
        private DataGridViewTextBoxColumn Capacidad;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Sinopsis;
        private DataGridViewTextBoxColumn Poster;
        private DataGridViewTextBoxColumn Duracion;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Cant_Clientes;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Id_MiSala;
        private DataGridViewTextBoxColumn Id_Pelicula;
    }
}