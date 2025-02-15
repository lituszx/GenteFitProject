
namespace GenteFit.Vista
{
    partial class GestionarActividades
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
            this.dataGridViewActividades = new System.Windows.Forms.DataGridView();
            this.BtnAgregarAct = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.txtBuscarAct = new System.Windows.Forms.TextBox();
            this.btnEliminarAct = new System.Windows.Forms.Button();
            this.textBoxAct = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.textBoxPlz = new System.Windows.Forms.TextBox();
            this.Instensidades = new System.Windows.Forms.ComboBox();
            this.labelIntensidad = new System.Windows.Forms.Label();
            this.labelHorario = new System.Windows.Forms.Label();
            this.Horarios = new System.Windows.Forms.ComboBox();
            this.labelSala = new System.Windows.Forms.Label();
            this.Salas = new System.Windows.Forms.ComboBox();
            this.labelMonitor = new System.Windows.Forms.Label();
            this.Monitores = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.VolverInicio = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActividades)).BeginInit();
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
            this.panel2.TabIndex = 10;
            // 
            // dataGridViewActividades
            // 
            this.dataGridViewActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActividades.Location = new System.Drawing.Point(12, 190);
            this.dataGridViewActividades.Name = "dataGridViewActividades";
            this.dataGridViewActividades.Size = new System.Drawing.Size(627, 237);
            this.dataGridViewActividades.TabIndex = 11;
            this.dataGridViewActividades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewActividades_CellContentClick);
            // 
            // BtnAgregarAct
            // 
            this.BtnAgregarAct.Location = new System.Drawing.Point(81, 603);
            this.BtnAgregarAct.Name = "BtnAgregarAct";
            this.BtnAgregarAct.Size = new System.Drawing.Size(146, 46);
            this.BtnAgregarAct.TabIndex = 12;
            this.BtnAgregarAct.Text = "Agregar Actividad";
            this.BtnAgregarAct.UseVisualStyleBackColor = true;
            this.BtnAgregarAct.Click += new System.EventHandler(this.BtnAgregarAct_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(365, 603);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(146, 46);
            this.BtnModificar.TabIndex = 13;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // txtBuscarAct
            // 
            this.txtBuscarAct.Location = new System.Drawing.Point(12, 154);
            this.txtBuscarAct.Name = "txtBuscarAct";
            this.txtBuscarAct.Size = new System.Drawing.Size(159, 20);
            this.txtBuscarAct.TabIndex = 14;
            this.txtBuscarAct.TextChanged += new System.EventHandler(this.txtBuscarAct_TextChanged);
            // 
            // btnEliminarAct
            // 
            this.btnEliminarAct.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarAct.Location = new System.Drawing.Point(549, 151);
            this.btnEliminarAct.Name = "btnEliminarAct";
            this.btnEliminarAct.Size = new System.Drawing.Size(90, 23);
            this.btnEliminarAct.TabIndex = 15;
            this.btnEliminarAct.Text = "Eliminar";
            this.btnEliminarAct.UseVisualStyleBackColor = false;
            this.btnEliminarAct.Click += new System.EventHandler(this.btnEliminarAct_Click);
            // 
            // textBoxAct
            // 
            this.textBoxAct.Location = new System.Drawing.Point(36, 444);
            this.textBoxAct.Name = "textBoxAct";
            this.textBoxAct.Size = new System.Drawing.Size(125, 20);
            this.textBoxAct.TabIndex = 16;
            this.textBoxAct.Text = "Nombre";
            this.textBoxAct.TextChanged += new System.EventHandler(this.textBoxAct_TextChanged);
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Location = new System.Drawing.Point(206, 444);
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(234, 20);
            this.textBoxDesc.TabIndex = 17;
            this.textBoxDesc.Text = "Descripcion";
            // 
            // textBoxPlz
            // 
            this.textBoxPlz.Location = new System.Drawing.Point(494, 444);
            this.textBoxPlz.Name = "textBoxPlz";
            this.textBoxPlz.Size = new System.Drawing.Size(94, 20);
            this.textBoxPlz.TabIndex = 18;
            this.textBoxPlz.Text = "Plazas Totales";
            // 
            // Instensidades
            // 
            this.Instensidades.FormattingEnabled = true;
            this.Instensidades.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.Instensidades.Location = new System.Drawing.Point(177, 497);
            this.Instensidades.Name = "Instensidades";
            this.Instensidades.Size = new System.Drawing.Size(121, 21);
            this.Instensidades.TabIndex = 19;
            this.Instensidades.SelectedIndexChanged += new System.EventHandler(this.Instensidades_SelectedIndexChanged);
            // 
            // labelIntensidad
            // 
            this.labelIntensidad.AutoSize = true;
            this.labelIntensidad.Location = new System.Drawing.Point(106, 500);
            this.labelIntensidad.Name = "labelIntensidad";
            this.labelIntensidad.Size = new System.Drawing.Size(65, 13);
            this.labelIntensidad.TabIndex = 20;
            this.labelIntensidad.Text = "Intensidad : ";
            // 
            // labelHorario
            // 
            this.labelHorario.AutoSize = true;
            this.labelHorario.Location = new System.Drawing.Point(304, 500);
            this.labelHorario.Name = "labelHorario";
            this.labelHorario.Size = new System.Drawing.Size(47, 13);
            this.labelHorario.TabIndex = 22;
            this.labelHorario.Text = "Horario :";
            this.labelHorario.Click += new System.EventHandler(this.label1_Click);
            // 
            // Horarios
            // 
            this.Horarios.FormattingEnabled = true;
            this.Horarios.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.Horarios.Location = new System.Drawing.Point(357, 497);
            this.Horarios.Name = "Horarios";
            this.Horarios.Size = new System.Drawing.Size(121, 21);
            this.Horarios.TabIndex = 21;
            this.Horarios.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // labelSala
            // 
            this.labelSala.AutoSize = true;
            this.labelSala.Location = new System.Drawing.Point(124, 550);
            this.labelSala.Name = "labelSala";
            this.labelSala.Size = new System.Drawing.Size(37, 13);
            this.labelSala.TabIndex = 24;
            this.labelSala.Text = "Sala : ";
            // 
            // Salas
            // 
            this.Salas.FormattingEnabled = true;
            this.Salas.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.Salas.Location = new System.Drawing.Point(177, 547);
            this.Salas.Name = "Salas";
            this.Salas.Size = new System.Drawing.Size(121, 21);
            this.Salas.TabIndex = 23;
            this.Salas.SelectedIndexChanged += new System.EventHandler(this.Salas_SelectedIndexChanged);
            // 
            // labelMonitor
            // 
            this.labelMonitor.AutoSize = true;
            this.labelMonitor.Location = new System.Drawing.Point(304, 550);
            this.labelMonitor.Name = "labelMonitor";
            this.labelMonitor.Size = new System.Drawing.Size(48, 13);
            this.labelMonitor.TabIndex = 26;
            this.labelMonitor.Text = "Monitor :";
            // 
            // Monitores
            // 
            this.Monitores.FormattingEnabled = true;
            this.Monitores.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.Monitores.Location = new System.Drawing.Point(357, 547);
            this.Monitores.Name = "Monitores";
            this.Monitores.Size = new System.Drawing.Size(121, 21);
            this.Monitores.TabIndex = 25;
            this.Monitores.SelectedIndexChanged += new System.EventHandler(this.Monitores_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GenteFit.Properties.Resources.Logo_GenteFit;
            this.pictureBox2.Location = new System.Drawing.Point(12, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // VolverInicio
            // 
            this.VolverInicio.Location = new System.Drawing.Point(539, 12);
            this.VolverInicio.Name = "VolverInicio";
            this.VolverInicio.Size = new System.Drawing.Size(100, 30);
            this.VolverInicio.TabIndex = 27;
            this.VolverInicio.Text = "Volver Atrás";
            this.VolverInicio.UseVisualStyleBackColor = true;
            this.VolverInicio.Click += new System.EventHandler(this.VolverInicio_Click);
            // 
            // GestionarActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(651, 687);
            this.Controls.Add(this.labelMonitor);
            this.Controls.Add(this.Monitores);
            this.Controls.Add(this.labelSala);
            this.Controls.Add(this.Salas);
            this.Controls.Add(this.labelHorario);
            this.Controls.Add(this.Horarios);
            this.Controls.Add(this.labelIntensidad);
            this.Controls.Add(this.Instensidades);
            this.Controls.Add(this.textBoxPlz);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.textBoxAct);
            this.Controls.Add(this.btnEliminarAct);
            this.Controls.Add(this.txtBuscarAct);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnAgregarAct);
            this.Controls.Add(this.dataGridViewActividades);
            this.Controls.Add(this.panel2);
            this.Name = "GestionarActividades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionar Actividades";
            this.Load += new System.EventHandler(this.GestionarActividades_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridViewActividades;
        private System.Windows.Forms.Button BtnAgregarAct;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.TextBox txtBuscarAct;
        private System.Windows.Forms.Button btnEliminarAct;
        private System.Windows.Forms.TextBox textBoxAct;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.TextBox textBoxPlz;
        private System.Windows.Forms.ComboBox Instensidades;
        private System.Windows.Forms.Label labelIntensidad;
        private System.Windows.Forms.Label labelHorario;
        private System.Windows.Forms.ComboBox Horarios;
        private System.Windows.Forms.Label labelSala;
        private System.Windows.Forms.ComboBox Salas;
        private System.Windows.Forms.Label labelMonitor;
        private System.Windows.Forms.ComboBox Monitores;
        private System.Windows.Forms.Button VolverInicio;
    }
}