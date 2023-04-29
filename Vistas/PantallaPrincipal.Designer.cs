namespace TP1___GRUPO_C
{
    partial class PantallaPrincipal
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
            btnRegistrarse = new Button();
            button3 = new Button();
            Input_UbicacionPpal = new ComboBox();
            Input_FechaPpal = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            Input_PeliculaPpal = new TextBox();
            Btn_BuscarPpal = new Button();
            Btn_MiPerfil = new Button();
            Btn_CerrarSesion = new Button();
            tabControl1 = new TabControl();
            Peliculas = new TabPage();
            dataGridPeliculasPpal = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            Sinopsis = new DataGridViewTextBoxColumn();
            Poster = new DataGridViewTextBoxColumn();
            Duracion = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            Salas = new TabPage();
            dataGridSalasPpal = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Ubicacion = new DataGridViewTextBoxColumn();
            Capacidad = new DataGridViewTextBoxColumn();
            ID_Funciones_Arr = new DataGridViewTextBoxColumn();
            Funciones = new TabPage();
            dataGridFuncionesPpal = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Cant_Clientes = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Id_MiSala = new DataGridViewTextBoxColumn();
            Capacidad_MiSala = new DataGridViewTextBoxColumn();
            Id_Pelicula = new DataGridViewTextBoxColumn();
            Nombre_Pelicula = new DataGridViewTextBoxColumn();
            IDS_Clientes_Arr = new DataGridViewTextBoxColumn();
            Input_PrecioMinimoPpal = new NumericUpDown();
            Input_PrecioMaximoPpal = new NumericUpDown();
            label8 = new Label();
            Label_MiCredito_Principal = new Label();
            Btn_ComprarEntradas = new Button();
            label10 = new Label();
            Input_CantEntradas = new NumericUpDown();
            Btn_RefrescarPpal = new Button();
            tabControl1.SuspendLayout();
            Peliculas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPeliculasPpal).BeginInit();
            Salas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSalasPpal).BeginInit();
            Funciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridFuncionesPpal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Input_PrecioMinimoPpal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Input_PrecioMaximoPpal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Input_CantEntradas).BeginInit();
            SuspendLayout();
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrarse.Location = new Point(673, 15);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(112, 31);
            btnRegistrarse.TabIndex = 1;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(522, 15);
            button3.Name = "button3";
            button3.Size = new Size(145, 31);
            button3.TabIndex = 2;
            button3.Text = "Iniciar Sesion";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Input_UbicacionPpal
            // 
            Input_UbicacionPpal.FormattingEnabled = true;
            Input_UbicacionPpal.Location = new Point(14, 97);
            Input_UbicacionPpal.Name = "Input_UbicacionPpal";
            Input_UbicacionPpal.Size = new Size(163, 23);
            Input_UbicacionPpal.TabIndex = 3;
            Input_UbicacionPpal.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Input_FechaPpal
            // 
            Input_FechaPpal.Location = new Point(183, 97);
            Input_FechaPpal.Name = "Input_FechaPpal";
            Input_FechaPpal.Size = new Size(200, 23);
            Input_FechaPpal.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(183, 67);
            label1.Name = "label1";
            label1.Size = new Size(47, 19);
            label1.TabIndex = 7;
            label1.Text = "Fecha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(392, 60);
            label2.Name = "label2";
            label2.Size = new Size(120, 19);
            label2.TabIndex = 8;
            label2.Text = "Rango de Precio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(392, 79);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 9;
            label3.Text = "min";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(498, 79);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 10;
            label4.Text = "max";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(14, 67);
            label5.Name = "label5";
            label5.Size = new Size(75, 19);
            label5.TabIndex = 12;
            label5.Text = "Ubicacion";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(221, 28);
            label6.TabIndex = 13;
            label6.Text = "Busqueda de Peliculas";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(604, 67);
            label7.Name = "label7";
            label7.Size = new Size(61, 19);
            label7.TabIndex = 14;
            label7.Text = "Pelicula";
            label7.Click += label7_Click;
            // 
            // Input_PeliculaPpal
            // 
            Input_PeliculaPpal.Location = new Point(604, 97);
            Input_PeliculaPpal.Name = "Input_PeliculaPpal";
            Input_PeliculaPpal.Size = new Size(100, 23);
            Input_PeliculaPpal.TabIndex = 15;
            // 
            // Btn_BuscarPpal
            // 
            Btn_BuscarPpal.Location = new Point(710, 96);
            Btn_BuscarPpal.Name = "Btn_BuscarPpal";
            Btn_BuscarPpal.Size = new Size(75, 23);
            Btn_BuscarPpal.TabIndex = 16;
            Btn_BuscarPpal.Text = "Buscar";
            Btn_BuscarPpal.UseVisualStyleBackColor = true;
            Btn_BuscarPpal.Click += Btn_BuscarPpal_Click;
            // 
            // Btn_MiPerfil
            // 
            Btn_MiPerfil.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_MiPerfil.Location = new Point(522, 15);
            Btn_MiPerfil.Name = "Btn_MiPerfil";
            Btn_MiPerfil.Size = new Size(121, 31);
            Btn_MiPerfil.TabIndex = 18;
            Btn_MiPerfil.Text = "Mi Perfil";
            Btn_MiPerfil.UseVisualStyleBackColor = true;
            Btn_MiPerfil.Click += Btn_MiPerfil_Click;
            // 
            // Btn_CerrarSesion
            // 
            Btn_CerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_CerrarSesion.Location = new Point(664, 15);
            Btn_CerrarSesion.Name = "Btn_CerrarSesion";
            Btn_CerrarSesion.Size = new Size(121, 31);
            Btn_CerrarSesion.TabIndex = 19;
            Btn_CerrarSesion.Text = "Cerrar Sesión";
            Btn_CerrarSesion.UseVisualStyleBackColor = true;
            Btn_CerrarSesion.Click += Btn_CerrarSesion_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Peliculas);
            tabControl1.Controls.Add(Salas);
            tabControl1.Controls.Add(Funciones);
            tabControl1.Location = new Point(14, 194);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(771, 244);
            tabControl1.TabIndex = 20;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // Peliculas
            // 
            Peliculas.Controls.Add(dataGridPeliculasPpal);
            Peliculas.Location = new Point(4, 24);
            Peliculas.Name = "Peliculas";
            Peliculas.Padding = new Padding(3);
            Peliculas.Size = new Size(763, 216);
            Peliculas.TabIndex = 0;
            Peliculas.Text = "Peliculas";
            Peliculas.UseVisualStyleBackColor = true;
            // 
            // dataGridPeliculasPpal
            // 
            dataGridPeliculasPpal.AllowUserToOrderColumns = true;
            dataGridPeliculasPpal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPeliculasPpal.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, Descripcion, Sinopsis, Poster, Duracion, dataGridViewTextBoxColumn6 });
            dataGridPeliculasPpal.Dock = DockStyle.Fill;
            dataGridPeliculasPpal.Location = new Point(3, 3);
            dataGridPeliculasPpal.Name = "dataGridPeliculasPpal";
            dataGridPeliculasPpal.RowTemplate.Height = 25;
            dataGridPeliculasPpal.Size = new Size(757, 210);
            dataGridPeliculasPpal.TabIndex = 50;
            dataGridPeliculasPpal.CellDoubleClick += dataGridPeliculas_CellDoubleClick;
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
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "ID_Funciones_Arr";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Salas
            // 
            Salas.Controls.Add(dataGridSalasPpal);
            Salas.Location = new Point(4, 24);
            Salas.Name = "Salas";
            Salas.Padding = new Padding(3);
            Salas.Size = new Size(763, 216);
            Salas.TabIndex = 1;
            Salas.Text = "Salas";
            Salas.UseVisualStyleBackColor = true;
            // 
            // dataGridSalasPpal
            // 
            dataGridSalasPpal.AllowUserToOrderColumns = true;
            dataGridSalasPpal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSalasPpal.Columns.AddRange(new DataGridViewColumn[] { ID, Ubicacion, Capacidad, ID_Funciones_Arr });
            dataGridSalasPpal.Dock = DockStyle.Fill;
            dataGridSalasPpal.Location = new Point(3, 3);
            dataGridSalasPpal.Name = "dataGridSalasPpal";
            dataGridSalasPpal.RowTemplate.Height = 25;
            dataGridSalasPpal.Size = new Size(757, 210);
            dataGridSalasPpal.TabIndex = 1;
            dataGridSalasPpal.CellDoubleClick += dataGridSalasPpal_CellDoubleClick_1;
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
            // ID_Funciones_Arr
            // 
            ID_Funciones_Arr.HeaderText = "Funciones_Arr";
            ID_Funciones_Arr.Name = "ID_Funciones_Arr";
            ID_Funciones_Arr.ReadOnly = true;
            // 
            // Funciones
            // 
            Funciones.Controls.Add(dataGridFuncionesPpal);
            Funciones.Location = new Point(4, 24);
            Funciones.Name = "Funciones";
            Funciones.Size = new Size(763, 216);
            Funciones.TabIndex = 2;
            Funciones.Text = "Funciones";
            Funciones.UseVisualStyleBackColor = true;
            // 
            // dataGridFuncionesPpal
            // 
            dataGridFuncionesPpal.AllowUserToOrderColumns = true;
            dataGridFuncionesPpal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridFuncionesPpal.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, Fecha, Cant_Clientes, Costo, Id_MiSala, Capacidad_MiSala, Id_Pelicula, Nombre_Pelicula, IDS_Clientes_Arr });
            dataGridFuncionesPpal.Dock = DockStyle.Fill;
            dataGridFuncionesPpal.Location = new Point(0, 0);
            dataGridFuncionesPpal.Name = "dataGridFuncionesPpal";
            dataGridFuncionesPpal.RowTemplate.Height = 25;
            dataGridFuncionesPpal.Size = new Size(763, 216);
            dataGridFuncionesPpal.TabIndex = 34;
            dataGridFuncionesPpal.CellDoubleClick += dataGridFuncionesPpal_CellDoubleClick_1;
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
            // Id_MiSala
            // 
            Id_MiSala.HeaderText = "Id_MiSala";
            Id_MiSala.Name = "Id_MiSala";
            Id_MiSala.ReadOnly = true;
            // 
            // Capacidad_MiSala
            // 
            Capacidad_MiSala.HeaderText = "Capacidad_MiSala";
            Capacidad_MiSala.Name = "Capacidad_MiSala";
            Capacidad_MiSala.ReadOnly = true;
            // 
            // Id_Pelicula
            // 
            Id_Pelicula.HeaderText = "Id_Pelicula";
            Id_Pelicula.Name = "Id_Pelicula";
            Id_Pelicula.ReadOnly = true;
            // 
            // Nombre_Pelicula
            // 
            Nombre_Pelicula.HeaderText = "Nombre_Pelicula";
            Nombre_Pelicula.Name = "Nombre_Pelicula";
            Nombre_Pelicula.ReadOnly = true;
            // 
            // IDS_Clientes_Arr
            // 
            IDS_Clientes_Arr.HeaderText = "IDS_Clientes_Arr";
            IDS_Clientes_Arr.Name = "IDS_Clientes_Arr";
            IDS_Clientes_Arr.ReadOnly = true;
            // 
            // Input_PrecioMinimoPpal
            // 
            Input_PrecioMinimoPpal.Location = new Point(392, 98);
            Input_PrecioMinimoPpal.Name = "Input_PrecioMinimoPpal";
            Input_PrecioMinimoPpal.Size = new Size(100, 23);
            Input_PrecioMinimoPpal.TabIndex = 21;
            // 
            // Input_PrecioMaximoPpal
            // 
            Input_PrecioMaximoPpal.Location = new Point(498, 97);
            Input_PrecioMaximoPpal.Name = "Input_PrecioMaximoPpal";
            Input_PrecioMaximoPpal.Size = new Size(100, 23);
            Input_PrecioMaximoPpal.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(632, 148);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 23;
            label8.Text = "Mi Credito: ";
            // 
            // Label_MiCredito_Principal
            // 
            Label_MiCredito_Principal.AutoSize = true;
            Label_MiCredito_Principal.Location = new Point(707, 148);
            Label_MiCredito_Principal.Name = "Label_MiCredito_Principal";
            Label_MiCredito_Principal.Size = new Size(47, 15);
            Label_MiCredito_Principal.TabIndex = 24;
            Label_MiCredito_Principal.Text = "AAAAA";
            // 
            // Btn_ComprarEntradas
            // 
            Btn_ComprarEntradas.Location = new Point(621, 176);
            Btn_ComprarEntradas.Name = "Btn_ComprarEntradas";
            Btn_ComprarEntradas.Size = new Size(161, 23);
            Btn_ComprarEntradas.TabIndex = 25;
            Btn_ComprarEntradas.Text = "Comprar Entradas";
            Btn_ComprarEntradas.UseVisualStyleBackColor = true;
            Btn_ComprarEntradas.Click += Btn_ComprarEntradas_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(498, 148);
            label10.Name = "label10";
            label10.Size = new Size(83, 15);
            label10.TabIndex = 27;
            label10.Text = "Cant. Entradas";
            // 
            // Input_CantEntradas
            // 
            Input_CantEntradas.Location = new Point(498, 178);
            Input_CantEntradas.Name = "Input_CantEntradas";
            Input_CantEntradas.Size = new Size(100, 23);
            Input_CantEntradas.TabIndex = 28;
            // 
            // Btn_RefrescarPpal
            // 
            Btn_RefrescarPpal.Location = new Point(14, 148);
            Btn_RefrescarPpal.Name = "Btn_RefrescarPpal";
            Btn_RefrescarPpal.Size = new Size(83, 26);
            Btn_RefrescarPpal.TabIndex = 29;
            Btn_RefrescarPpal.Text = "Refrescar";
            Btn_RefrescarPpal.UseVisualStyleBackColor = true;
            Btn_RefrescarPpal.Click += Btn_RefrescarPpal_Click;
            // 
            // PantallaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Btn_RefrescarPpal);
            Controls.Add(Input_CantEntradas);
            Controls.Add(label10);
            Controls.Add(Btn_ComprarEntradas);
            Controls.Add(Label_MiCredito_Principal);
            Controls.Add(label8);
            Controls.Add(Input_PrecioMaximoPpal);
            Controls.Add(Input_PrecioMinimoPpal);
            Controls.Add(tabControl1);
            Controls.Add(Btn_CerrarSesion);
            Controls.Add(Btn_MiPerfil);
            Controls.Add(Btn_BuscarPpal);
            Controls.Add(Input_PeliculaPpal);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Input_FechaPpal);
            Controls.Add(Input_UbicacionPpal);
            Controls.Add(button3);
            Controls.Add(btnRegistrarse);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            tabControl1.ResumeLayout(false);
            Peliculas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridPeliculasPpal).EndInit();
            Salas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridSalasPpal).EndInit();
            Funciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridFuncionesPpal).EndInit();
            ((System.ComponentModel.ISupportInitialize)Input_PrecioMinimoPpal).EndInit();
            ((System.ComponentModel.ISupportInitialize)Input_PrecioMaximoPpal).EndInit();
            ((System.ComponentModel.ISupportInitialize)Input_CantEntradas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRegistrarse;
        private Button button3;
        private ComboBox Input_UbicacionPpal;
        private DateTimePicker Input_FechaPpal;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox Input_PeliculaPpal;
        private Button Btn_BuscarPpal;
        private Button Btn_MiPerfil;
        private Button Btn_CerrarSesion;
        private TabControl tabControl1;
        private TabPage Peliculas;
        private TabPage Salas;
        private TabPage Funciones;
        private DataGridView dataGridPeliculasPpal;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Sinopsis;
        private DataGridViewTextBoxColumn Poster;
        private DataGridViewTextBoxColumn Duracion;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private NumericUpDown Input_PrecioMinimoPpal;
        private NumericUpDown Input_PrecioMaximoPpal;
        private Label label8;
        private Label Label_MiCredito_Principal;
        private Button Btn_ComprarEntradas;
        private Label label10;
        private NumericUpDown Input_CantEntradas;
        private DataGridView dataGridSalasPpal;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Ubicacion;
        private DataGridViewTextBoxColumn Capacidad;
        private DataGridViewTextBoxColumn ID_Funciones_Arr;
        private DataGridView dataGridFuncionesPpal;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Cant_Clientes;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Id_MiSala;
        private DataGridViewTextBoxColumn Capacidad_MiSala;
        private DataGridViewTextBoxColumn Id_Pelicula;
        private DataGridViewTextBoxColumn Nombre_Pelicula;
        private DataGridViewTextBoxColumn IDS_Clientes_Arr;
        private Button Btn_RefrescarPpal;
    }
}