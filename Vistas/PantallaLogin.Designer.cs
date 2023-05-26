namespace TP1___GRUPO_C
{
    partial class PantallaLogin
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
            button1 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(362, 43);
            label1.Name = "label1";
            label1.Size = new Size(59, 28);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(330, 259);
            button1.Name = "button1";
            button1.Size = new Size(128, 40);
            button1.TabIndex = 1;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(339, 124);
            label2.Name = "label2";
            label2.Size = new Size(110, 28);
            label2.TabIndex = 2;
            label2.Text = "Contraseña";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(320, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(320, 155);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(152, 23);
            textBox2.TabIndex = 4;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(330, 316);
            button2.Name = "button2";
            button2.Size = new Size(128, 40);
            button2.TabIndex = 5;
            button2.Text = "Volver";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // PantallaLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
    }
}