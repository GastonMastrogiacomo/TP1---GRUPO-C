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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Label_CreditoUsuarioCargaFuncion = new Label();
            Label_CostoUnitarioFuncion = new Label();
            TB_CantidadEntradasFuncionUsuario = new TextBox();
            label5 = new Label();
            FL_FuncionesDisponiblesAdmin = new FlowLayoutPanel();
            FL_FuncionesUsuarioAdmin = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // Btn_SacarDeLista
            // 
            Btn_SacarDeLista.Location = new Point(372, 106);
            Btn_SacarDeLista.Name = "Btn_SacarDeLista";
            Btn_SacarDeLista.Size = new Size(53, 25);
            Btn_SacarDeLista.TabIndex = 1;
            Btn_SacarDeLista.Text = ">";
            Btn_SacarDeLista.UseVisualStyleBackColor = true;
            Btn_SacarDeLista.Click += Btn_SacarDeLista_Click;
            // 
            // Btn_AgregarALista
            // 
            Btn_AgregarALista.Location = new Point(372, 209);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 76);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 10;
            label1.Text = "Funciones del Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(435, 76);
            label2.Name = "label2";
            label2.Size = new Size(125, 15);
            label2.TabIndex = 11;
            label2.Text = "Funciones Disponibles";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 37);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 12;
            label3.Text = "Crédito Usuario: $";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(435, 37);
            label4.Name = "label4";
            label4.Size = new Size(138, 15);
            label4.TabIndex = 13;
            label4.Text = "Costo unitario funcion: $";
            // 
            // Label_CreditoUsuarioCargaFuncion
            // 
            Label_CreditoUsuarioCargaFuncion.AutoSize = true;
            Label_CreditoUsuarioCargaFuncion.Location = new Point(134, 37);
            Label_CreditoUsuarioCargaFuncion.Name = "Label_CreditoUsuarioCargaFuncion";
            Label_CreditoUsuarioCargaFuncion.Size = new Size(47, 15);
            Label_CreditoUsuarioCargaFuncion.TabIndex = 14;
            Label_CreditoUsuarioCargaFuncion.Text = "AAAAA";
            // 
            // Label_CostoUnitarioFuncion
            // 
            Label_CostoUnitarioFuncion.AutoSize = true;
            Label_CostoUnitarioFuncion.Location = new Point(591, 37);
            Label_CostoUnitarioFuncion.Name = "Label_CostoUnitarioFuncion";
            Label_CostoUnitarioFuncion.Size = new Size(47, 15);
            Label_CostoUnitarioFuncion.TabIndex = 15;
            Label_CostoUnitarioFuncion.Text = "AAAAA";
            // 
            // TB_CantidadEntradasFuncionUsuario
            // 
            TB_CantidadEntradasFuncionUsuario.Location = new Point(372, 165);
            TB_CantidadEntradasFuncionUsuario.Name = "TB_CantidadEntradasFuncionUsuario";
            TB_CantidadEntradasFuncionUsuario.Size = new Size(53, 23);
            TB_CantidadEntradasFuncionUsuario.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(364, 147);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 17;
            label5.Text = "Cant. Entradas";
            label5.Click += label5_Click;
            // 
            // FL_FuncionesDisponiblesAdmin
            // 
            FL_FuncionesDisponiblesAdmin.FlowDirection = FlowDirection.TopDown;
            FL_FuncionesDisponiblesAdmin.Location = new Point(453, 94);
            FL_FuncionesDisponiblesAdmin.Name = "FL_FuncionesDisponiblesAdmin";
            FL_FuncionesDisponiblesAdmin.Size = new Size(325, 328);
            FL_FuncionesDisponiblesAdmin.TabIndex = 18;
            FL_FuncionesDisponiblesAdmin.Paint += FL_FuncionesDisponiblesAdmin_Paint;
            // 
            // FL_FuncionesUsuarioAdmin
            // 
            FL_FuncionesUsuarioAdmin.FlowDirection = FlowDirection.TopDown;
            FL_FuncionesUsuarioAdmin.Location = new Point(27, 94);
            FL_FuncionesUsuarioAdmin.Name = "FL_FuncionesUsuarioAdmin";
            FL_FuncionesUsuarioAdmin.Size = new Size(321, 328);
            FL_FuncionesUsuarioAdmin.TabIndex = 19;
            // 
            // PantallaCargaFunciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FL_FuncionesUsuarioAdmin);
            Controls.Add(FL_FuncionesDisponiblesAdmin);
            Controls.Add(label5);
            Controls.Add(TB_CantidadEntradasFuncionUsuario);
            Controls.Add(Label_CostoUnitarioFuncion);
            Controls.Add(Label_CreditoUsuarioCargaFuncion);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Btn_SalirCargarLista);
            Controls.Add(Btn_AgregarALista);
            Controls.Add(Btn_SacarDeLista);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaCargaFunciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PantallaCargaListas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Btn_SacarDeLista;
        private Button Btn_AgregarALista;
        private Button Btn_SalirCargarLista;
        private CheckedListBox Clb_FuncionesCine;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label Label_CreditoUsuarioCargaFuncion;
        private Label Label_CostoUnitarioFuncion;
        private TextBox TB_CantidadEntradasFuncionUsuario;
        private Label label5;
        private FlowLayoutPanel FL_FuncionesDisponiblesAdmin;
        private FlowLayoutPanel FL_FuncionesUsuarioAdmin;
    }
}