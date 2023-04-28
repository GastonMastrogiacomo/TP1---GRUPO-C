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
            ubicacionBox = new ComboBox();
            FechaPicker = new DateTimePicker();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox3 = new TextBox();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            Btn_MiPerfil = new Button();
            Btn_CerrarSesion = new Button();
            ID = new DataGridViewTextBoxColumn();
            Imagen = new DataGridViewImageColumn();
            Pelicula = new DataGridViewTextBoxColumn();
            Comprar = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // ubicacionBox
            // 
            ubicacionBox.FormattingEnabled = true;
            ubicacionBox.Location = new Point(14, 97);
            ubicacionBox.Name = "ubicacionBox";
            ubicacionBox.Size = new Size(163, 23);
            ubicacionBox.TabIndex = 3;
            ubicacionBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // FechaPicker
            // 
            FechaPicker.Location = new Point(183, 97);
            FechaPicker.Name = "FechaPicker";
            FechaPicker.Size = new Size(200, 23);
            FechaPicker.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(392, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(498, 97);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 6;
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
            // textBox3
            // 
            textBox3.Location = new Point(604, 97);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 15;
            // 
            // button4
            // 
            button4.Location = new Point(710, 93);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 16;
            button4.Text = "Buscar";
            button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Imagen, Pelicula, Comprar });
            dataGridView1.Location = new Point(14, 140);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(771, 272);
            dataGridView1.TabIndex = 17;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.Visible = false;
            // 
            // Imagen
            // 
            Imagen.HeaderText = "Imagen";
            Imagen.Name = "Imagen";
            Imagen.ReadOnly = true;
            // 
            // Pelicula
            // 
            Pelicula.HeaderText = "Pelicula";
            Pelicula.Name = "Pelicula";
            Pelicula.ReadOnly = true;
            Pelicula.Resizable = DataGridViewTriState.True;
            Pelicula.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Comprar
            // 
            Comprar.HeaderText = "Comprar";
            Comprar.Name = "Comprar";
            // 
            // PantallaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Btn_CerrarSesion);
            Controls.Add(Btn_MiPerfil);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            Controls.Add(textBox3);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(FechaPicker);
            Controls.Add(ubicacionBox);
            Controls.Add(button3);
            Controls.Add(btnRegistrarse);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRegistrarse;
        private Button button3;
        private ComboBox ubicacionBox;
        private DateTimePicker FechaPicker;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox3;
        private Button button4;
        private DataGridView dataGridView1;
        private Button Btn_MiPerfil;
        private Button Btn_CerrarSesion;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewImageColumn Imagen;
        private DataGridViewTextBoxColumn Pelicula;
        private DataGridViewButtonColumn Comprar;
    }
}