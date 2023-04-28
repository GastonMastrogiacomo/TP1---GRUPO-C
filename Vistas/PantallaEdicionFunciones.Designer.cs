namespace TP1___GRUPO_C.Vistas
{
    partial class PantallaEdicionFunciones
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
            Label_CreditoDisponible = new Label();
            Label_Credito = new Label();
            Btn_Volver = new Button();
            SuspendLayout();
            // 
            // Label_CreditoDisponible
            // 
            Label_CreditoDisponible.AutoSize = true;
            Label_CreditoDisponible.Location = new Point(618, 9);
            Label_CreditoDisponible.Name = "Label_CreditoDisponible";
            Label_CreditoDisponible.Size = new Size(108, 15);
            Label_CreditoDisponible.TabIndex = 0;
            Label_CreditoDisponible.Text = "Crédito Disponible:";
            // 
            // Label_Credito
            // 
            Label_Credito.AutoSize = true;
            Label_Credito.Location = new Point(729, 9);
            Label_Credito.Name = "Label_Credito";
            Label_Credito.Size = new Size(0, 15);
            Label_Credito.TabIndex = 1;
            // 
            // Btn_Volver
            // 
            Btn_Volver.Location = new Point(12, 5);
            Btn_Volver.Name = "Btn_Volver";
            Btn_Volver.Size = new Size(105, 23);
            Btn_Volver.TabIndex = 2;
            Btn_Volver.Text = "Guardar y Salir";
            Btn_Volver.UseVisualStyleBackColor = true;
            Btn_Volver.Click += Btn_Volver_Click;
            // 
            // PantallaEdicionFunciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Btn_Volver);
            Controls.Add(Label_Credito);
            Controls.Add(Label_CreditoDisponible);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaEdicionFunciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PantallaEdicionFuncion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_CreditoDisponible;
        private Label Label_Credito;
        private Button Btn_Volver;
    }
}