using System;

namespace GenteFit.Vista
{
    partial class AdministracionForm
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
            this.btnGestionClientes = new System.Windows.Forms.Button();
            this.btnGestionUsuario = new System.Windows.Forms.Button();
            this.btnGestionReservas = new System.Windows.Forms.Button();
            this.btnGestionActividades = new System.Windows.Forms.Button();
            this.btnCalendario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOdoo = new System.Windows.Forms.Button();
            this.Salir = new System.Windows.Forms.Button();
            this.labelAdm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGestionClientes
            // 
            this.btnGestionClientes.BackColor = System.Drawing.Color.White;
            this.btnGestionClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionClientes.Location = new System.Drawing.Point(231, 196);
            this.btnGestionClientes.Name = "btnGestionClientes";
            this.btnGestionClientes.Size = new System.Drawing.Size(182, 48);
            this.btnGestionClientes.TabIndex = 0;
            this.btnGestionClientes.Text = "Gestión de Clientes";
            this.btnGestionClientes.UseVisualStyleBackColor = false;
            this.btnGestionClientes.Click += new System.EventHandler(this.btnGestionClientes_Click);
            // 
            // btnGestionUsuario
            // 
            this.btnGestionUsuario.BackColor = System.Drawing.Color.White;
            this.btnGestionUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionUsuario.Location = new System.Drawing.Point(22, 196);
            this.btnGestionUsuario.Name = "btnGestionUsuario";
            this.btnGestionUsuario.Size = new System.Drawing.Size(182, 48);
            this.btnGestionUsuario.TabIndex = 1;
            this.btnGestionUsuario.Text = "Gestión de Usuarios";
            this.btnGestionUsuario.UseVisualStyleBackColor = false;
            this.btnGestionUsuario.Click += new System.EventHandler(this.btnGestionUsuario_Click);
            // 
            // btnGestionReservas
            // 
            this.btnGestionReservas.BackColor = System.Drawing.Color.White;
            this.btnGestionReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionReservas.Location = new System.Drawing.Point(330, 275);
            this.btnGestionReservas.Name = "btnGestionReservas";
            this.btnGestionReservas.Size = new System.Drawing.Size(182, 48);
            this.btnGestionReservas.TabIndex = 2;
            this.btnGestionReservas.Text = "Reservas y Lista de espera";
            this.btnGestionReservas.UseVisualStyleBackColor = false;
            this.btnGestionReservas.Click += new System.EventHandler(this.btnGestionReservas_Click);
            // 
            // btnGestionActividades
            // 
            this.btnGestionActividades.BackColor = System.Drawing.Color.White;
            this.btnGestionActividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionActividades.Location = new System.Drawing.Point(440, 196);
            this.btnGestionActividades.Name = "btnGestionActividades";
            this.btnGestionActividades.Size = new System.Drawing.Size(182, 48);
            this.btnGestionActividades.TabIndex = 3;
            this.btnGestionActividades.Text = "Gestión de Actividades";
            this.btnGestionActividades.UseVisualStyleBackColor = false;
            this.btnGestionActividades.Click += new System.EventHandler(this.btnGestionActividades_Click);
            // 
            // btnCalendario
            // 
            this.btnCalendario.BackColor = System.Drawing.Color.White;
            this.btnCalendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalendario.Location = new System.Drawing.Point(124, 275);
            this.btnCalendario.Name = "btnCalendario";
            this.btnCalendario.Size = new System.Drawing.Size(182, 48);
            this.btnCalendario.TabIndex = 4;
            this.btnCalendario.Text = "Calendario de Actividades";
            this.btnCalendario.UseVisualStyleBackColor = false;
            this.btnCalendario.Click += new System.EventHandler(this.btnCalendario_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GenteFit.Properties.Resources.Logo_GenteFit;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.btnOdoo);
            this.panel1.Controls.Add(this.Salir);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 81);
            this.panel1.TabIndex = 7;
            // 
            // btnOdoo
            // 
            this.btnOdoo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnOdoo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdoo.Location = new System.Drawing.Point(355, 21);
            this.btnOdoo.Name = "btnOdoo";
            this.btnOdoo.Size = new System.Drawing.Size(123, 41);
            this.btnOdoo.TabIndex = 10;
            this.btnOdoo.Text = "Odoo";
            this.btnOdoo.UseVisualStyleBackColor = false;
            this.btnOdoo.Click += new System.EventHandler(this.btnOdoo_Click);
            // 
            // Salir
            // 
            this.Salir.BackColor = System.Drawing.Color.White;
            this.Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir.Location = new System.Drawing.Point(506, 21);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(123, 41);
            this.Salir.TabIndex = 9;
            this.Salir.Text = "Salir";
            this.Salir.UseVisualStyleBackColor = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // labelAdm
            // 
            this.labelAdm.AutoSize = true;
            this.labelAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelAdm.Location = new System.Drawing.Point(173, 123);
            this.labelAdm.Name = "labelAdm";
            this.labelAdm.Size = new System.Drawing.Size(305, 31);
            this.labelAdm.TabIndex = 8;
            this.labelAdm.Text = "Panel de Administración";
            // 
            // AdministracionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(641, 404);
            this.Controls.Add(this.labelAdm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCalendario);
            this.Controls.Add(this.btnGestionActividades);
            this.Controls.Add(this.btnGestionReservas);
            this.Controls.Add(this.btnGestionUsuario);
            this.Controls.Add(this.btnGestionClientes);
            this.Name = "AdministracionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Principal";
            this.Load += new System.EventHandler(this.AdministracionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button btnGestionClientes;
        private System.Windows.Forms.Button btnGestionUsuario;
        private System.Windows.Forms.Button btnGestionReservas;
        private System.Windows.Forms.Button btnGestionActividades;
        private System.Windows.Forms.Button btnCalendario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelAdm;
        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.Button btnOdoo;
    }
}