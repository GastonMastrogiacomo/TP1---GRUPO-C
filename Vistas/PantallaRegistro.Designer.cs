namespace TP1___GRUPO_C
{
    partial class PantallaRegistro
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBoxNombres = new TextBox();
            textBoxApellidos = new TextBox();
            textBoxDNI = new TextBox();
            textBoxMail = new TextBox();
            textBoxPass = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(286, 33);
            label1.Name = "label1";
            label1.Size = new Size(206, 25);
            label1.TabIndex = 0;
            label1.Text = "Formulario de Registro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 74);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombres";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(298, 74);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 2;
            label3.Text = "Apellidos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 129);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 3;
            label4.Text = "DNI";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 238);
            label5.Name = "label5";
            label5.Size = new Size(117, 15);
            label5.TabIndex = 4;
            label5.Text = "Fecha de nacimiento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(178, 184);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 5;
            label6.Text = "Password";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(51, 184);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 6;
            label7.Text = "Mail";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(51, 256);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // textBoxNombres
            // 
            textBoxNombres.Location = new Point(51, 92);
            textBoxNombres.Name = "textBoxNombres";
            textBoxNombres.Size = new Size(227, 23);
            textBoxNombres.TabIndex = 11;
            textBoxNombres.TextChanged += textBox1_TextChanged;
            // 
            // textBoxApellidos
            // 
            textBoxApellidos.Location = new Point(298, 92);
            textBoxApellidos.Name = "textBoxApellidos";
            textBoxApellidos.Size = new Size(227, 23);
            textBoxApellidos.TabIndex = 12;
            textBoxApellidos.TextChanged += textBoxApellidos_TextChanged;
            // 
            // textBoxDNI
            // 
            textBoxDNI.Location = new Point(51, 147);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.Size = new Size(100, 23);
            textBoxDNI.TabIndex = 13;
            textBoxDNI.TextChanged += textBoxDNI_TextChanged;
            // 
            // textBoxMail
            // 
            textBoxMail.Location = new Point(51, 202);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(100, 23);
            textBoxMail.TabIndex = 14;
            textBoxMail.TextChanged += textBox4_TextChanged;
            // 
            // textBoxPass
            // 
            textBoxPass.Location = new Point(178, 202);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.Size = new Size(100, 23);
            textBoxPass.TabIndex = 15;
            textBoxPass.TextChanged += textBoxPass_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(51, 302);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "Registrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(143, 302);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 17;
            button2.Text = "Volver";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // PantallaRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBoxPass);
            Controls.Add(textBoxMail);
            Controls.Add(textBoxDNI);
            Controls.Add(textBoxApellidos);
            Controls.Add(textBoxNombres);
            Controls.Add(dateTimePicker1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DateTimePicker dateTimePicker1;
        private TextBox textBoxNombres;
        private TextBox textBoxApellidos;
        private TextBox textBoxDNI;
        private TextBox textBoxMail;
        private TextBox textBoxPass;
        private Button button1;
        private Button button2;
    }
}