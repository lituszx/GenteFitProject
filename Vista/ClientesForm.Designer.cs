namespace GenteFit.Vista
{
    partial class ClientesForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.VolverInicio = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelAdmClientes = new System.Windows.Forms.Label();
            this.btnConsultarPerfil = new System.Windows.Forms.Button();
            this.btnAccederReservas = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGreen;
            this.panel2.Controls.Add(this.VolverInicio);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 81);
            this.panel2.TabIndex = 9;
            // 
            // VolverInicio
            // 
            this.VolverInicio.Location = new System.Drawing.Point(535, 22);
            this.VolverInicio.Name = "VolverInicio";
            this.VolverInicio.Size = new System.Drawing.Size(100, 30);
            this.VolverInicio.TabIndex = 18;
            this.VolverInicio.Text = "Volver Atrás";
            this.VolverInicio.UseVisualStyleBackColor = true;
            this.VolverInicio.Click += new System.EventHandler(this.VolverInicio_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GenteFit.Properties.Resources.Logo_GenteFit;
            this.pictureBox2.Location = new System.Drawing.Point(12, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // labelAdmClientes
            // 
            this.labelAdmClientes.AutoSize = true;
            this.labelAdmClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelAdmClientes.Location = new System.Drawing.Point(232, 114);
            this.labelAdmClientes.Name = "labelAdmClientes";
            this.labelAdmClientes.Size = new System.Drawing.Size(189, 31);
            this.labelAdmClientes.TabIndex = 10;
            this.labelAdmClientes.Text = "Panel Clientes";
            // 
            // btnConsultarPerfil
            // 
            this.btnConsultarPerfil.Location = new System.Drawing.Point(126, 213);
            this.btnConsultarPerfil.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsultarPerfil.Name = "btnConsultarPerfil";
            this.btnConsultarPerfil.Size = new System.Drawing.Size(119, 58);
            this.btnConsultarPerfil.TabIndex = 11;
            this.btnConsultarPerfil.Text = "Ver Perfil";
            this.btnConsultarPerfil.UseVisualStyleBackColor = true;
            this.btnConsultarPerfil.Click += new System.EventHandler(this.btnConsultarPerfil_Click);
            // 
            // btnAccederReservas
            // 
            this.btnAccederReservas.Location = new System.Drawing.Point(376, 210);
            this.btnAccederReservas.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccederReservas.Name = "btnAccederReservas";
            this.btnAccederReservas.Size = new System.Drawing.Size(165, 61);
            this.btnAccederReservas.TabIndex = 13;
            this.btnAccederReservas.Text = "Acceder al Sistema de Reservas";
            this.btnAccederReservas.UseVisualStyleBackColor = true;
            this.btnAccederReservas.Click += new System.EventHandler(this.btnAccederReservas_Click);
            // 
            // ClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(647, 397);
            this.Controls.Add(this.btnAccederReservas);
            this.Controls.Add(this.btnConsultarPerfil);
            this.Controls.Add(this.labelAdmClientes);
            this.Controls.Add(this.panel2);
            this.Name = "ClientesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Cliente";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelAdmClientes;
        private System.Windows.Forms.Button btnConsultarPerfil; // Cambié el nombre aquí
        private System.Windows.Forms.Button btnAccederReservas;
        private System.Windows.Forms.Button VolverInicio;
    }
}
