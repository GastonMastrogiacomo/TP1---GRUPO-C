namespace TP1___GRUPO_C.Vistas
{
    partial class PantallaCargaFunciones
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
            Btn_SacarDeLista = new Button();
            Btn_AgregarALista = new Button();
            Btn_SalirCargarLista = new Button();
            Btn_GuardarYSalir = new Button();
            Clb_FuncionesCine = new CheckedListBox();
            Clb_FuncionesUsuario = new CheckedListBox();
            SuspendLayout();
            // 
            // Btn_SacarDeLista
            // 
            Btn_SacarDeLista.Location = new Point(376, 188);
            Btn_SacarDeLista.Name = "Btn_SacarDeLista";
            Btn_SacarDeLista.Size = new Size(53, 25);
            Btn_SacarDeLista.TabIndex = 1;
            Btn_SacarDeLista.Text = ">";
            Btn_SacarDeLista.UseVisualStyleBackColor = true;
            Btn_SacarDeLista.Click += Btn_SacarDeLista_Click;
            // 
            // Btn_AgregarALista
            // 
            Btn_AgregarALista.Location = new Point(376, 265);
            Btn_AgregarALista.Name = "Btn_AgregarALista";
            Btn_AgregarALista.Size = new Size(53, 26);
            Btn_AgregarALista.TabIndex = 2;
            Btn_AgregarALista.Text = "<";
            Btn_AgregarALista.UseVisualStyleBackColor = true;
            Btn_AgregarALista.Click += Btn_AgregarALista_Click;
            // 
            // Btn_SalirCargarLista
            // 
            Btn_SalirCargarLista.Location = new Point(703, 29);
            Btn_SalirCargarLista.Name = "Btn_SalirCargarLista";
            Btn_SalirCargarLista.Size = new Size(75, 23);
            Btn_SalirCargarLista.TabIndex = 4;
            Btn_SalirCargarLista.Text = "Salir";
            Btn_SalirCargarLista.UseVisualStyleBackColor = true;
            Btn_SalirCargarLista.Click += Btn_SalirCargarLista_Click;
            // 
            // Btn_GuardarYSalir
            // 
            Btn_GuardarYSalir.Location = new Point(27, 29);
            Btn_GuardarYSalir.Name = "Btn_GuardarYSalir";
            Btn_GuardarYSalir.Size = new Size(102, 23);
            Btn_GuardarYSalir.TabIndex = 7;
            Btn_GuardarYSalir.Text = "Guardar y Salir";
            Btn_GuardarYSalir.UseVisualStyleBackColor = true;
            Btn_GuardarYSalir.Click += Btn_GuardarYSalir_Click;
            // 
            // Clb_FuncionesCine
            // 
            Clb_FuncionesCine.FormattingEnabled = true;
            Clb_FuncionesCine.Location = new Point(435, 58);
            Clb_FuncionesCine.Name = "Clb_FuncionesCine";
            Clb_FuncionesCine.Size = new Size(343, 364);
            Clb_FuncionesCine.TabIndex = 8;
            // 
            // Clb_FuncionesUsuario
            // 
            Clb_FuncionesUsuario.FormattingEnabled = true;
            Clb_FuncionesUsuario.Location = new Point(27, 58);
            Clb_FuncionesUsuario.Name = "Clb_FuncionesUsuario";
            Clb_FuncionesUsuario.Size = new Size(343, 364);
            Clb_FuncionesUsuario.TabIndex = 9;
            // 
            // PantallaCargaFunciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Clb_FuncionesUsuario);
            Controls.Add(Clb_FuncionesCine);
            Controls.Add(Btn_GuardarYSalir);
            Controls.Add(Btn_SalirCargarLista);
            Controls.Add(Btn_AgregarALista);
            Controls.Add(Btn_SacarDeLista);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaCargaFunciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PantallaCargaListas";
            ResumeLayout(false);
        }

        #endregion
        private Button Btn_SacarDeLista;
        private Button Btn_AgregarALista;
        private Button Btn_SalirCargarLista;
        private Button Btn_GuardarYSalir;
        private CheckedListBox Clb_FuncionesCine;
        private CheckedListBox Clb_FuncionesUsuario;
    }
}