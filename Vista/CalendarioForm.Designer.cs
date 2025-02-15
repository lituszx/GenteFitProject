namespace GenteFit.Vista
{
    partial class CalendarioForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.VolverInicio = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelCalendar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SeleccionActividad = new System.Windows.Forms.ComboBox();
            this.genteFitCristinaDataSet = new GenteFit.GenteFitCristinaDataSet();
            this.actividadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.actividadTableAdapter = new GenteFit.GenteFitCristinaDataSetTableAdapters.ActividadTableAdapter();
            this.MostrarHorario = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitCristinaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 81);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GenteFit.Properties.Resources.Logo_GenteFit;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGreen;
            this.panel2.Controls.Add(this.VolverInicio);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 81);
            this.panel2.TabIndex = 8;
            // 
            // VolverInicio
            // 
            this.VolverInicio.Location = new System.Drawing.Point(539, 22);
            this.VolverInicio.Name = "VolverInicio";
            this.VolverInicio.Size = new System.Drawing.Size(100, 30);
            this.VolverInicio.TabIndex = 17;
            this.VolverInicio.Text = "Volver Atrás";
            this.VolverInicio.UseVisualStyleBackColor = true;
            this.VolverInicio.Click += new System.EventHandler(this.VolverInicio_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GenteFit.Properties.Resources.logodemo;
            this.pictureBox2.Location = new System.Drawing.Point(12, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // labelCalendar
            // 
            this.labelCalendar.AutoSize = true;
            this.labelCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelCalendar.Location = new System.Drawing.Point(162, 96);
            this.labelCalendar.Name = "labelCalendar";
            this.labelCalendar.Size = new System.Drawing.Size(329, 31);
            this.labelCalendar.TabIndex = 9;
            this.labelCalendar.Text = "Calendario de Actividades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Selecciona la actividad para ver su horario";
            // 
            // SeleccionActividad
            // 
            this.SeleccionActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeleccionActividad.FormattingEnabled = true;
            this.SeleccionActividad.Location = new System.Drawing.Point(386, 146);
            this.SeleccionActividad.Name = "SeleccionActividad";
            this.SeleccionActividad.Size = new System.Drawing.Size(211, 28);
            this.SeleccionActividad.TabIndex = 12;
            this.SeleccionActividad.SelectedIndexChanged += new System.EventHandler(this.SeleccionActividad_SelectedIndexChanged);
            // 
            // genteFitCristinaDataSet
            // 
            this.genteFitCristinaDataSet.DataSetName = "GenteFitCristinaDataSet";
            this.genteFitCristinaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // actividadBindingSource
            // 
            this.actividadBindingSource.DataMember = "Actividad";
            this.actividadBindingSource.DataSource = this.genteFitCristinaDataSet;
            // 
            // actividadTableAdapter
            // 
            this.actividadTableAdapter.ClearBeforeFill = true;
            // 
            // MostrarHorario
            // 
            this.MostrarHorario.FormattingEnabled = true;
            this.MostrarHorario.Location = new System.Drawing.Point(23, 201);
            this.MostrarHorario.Name = "MostrarHorario";
            this.MostrarHorario.Size = new System.Drawing.Size(613, 160);
            this.MostrarHorario.TabIndex = 13;
            this.MostrarHorario.SelectedIndexChanged += new System.EventHandler(this.MostrarHorario_SelectedIndexChanged);
            // 
            // CalendarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(652, 383);
            this.Controls.Add(this.MostrarHorario);
            this.Controls.Add(this.SeleccionActividad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCalendar);
            this.Controls.Add(this.panel1);
            this.Name = "CalendarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendario de Actividades";
            this.Load += new System.EventHandler(this.CalendarioForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitCristinaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCalendar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SeleccionActividad;
        private GenteFitCristinaDataSet genteFitCristinaDataSet;
        private System.Windows.Forms.BindingSource actividadBindingSource;
        private GenteFitCristinaDataSetTableAdapters.ActividadTableAdapter actividadTableAdapter;
        private System.Windows.Forms.ListBox MostrarHorario;
        private System.Windows.Forms.Button VolverInicio;
    }
}