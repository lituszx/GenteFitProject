using GenteFit.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFit.Vista
{
    public partial class CalendarioForm : Form
    {
        private string rolUsuario;
        private int idUsuario;

        public CalendarioForm(string rol, int id)
        {
            InitializeComponent();
            rolUsuario = rol;
            idUsuario = id;
        }
        private void CalendarioForm_Load(object sender, EventArgs e)
        {
            using (var db = new GenteFitCristinaEntities1())
            {
                // Obtengo todas las actividades desde la base de datos
                var actividades = db.Actividad.ToList();

                // Limpio el ComboBox 
                SeleccionActividad.Items.Clear();

                // Añado las actividades al ComboBox
                foreach (var actividad in actividades)
                {
                    SeleccionActividad.Items.Add(actividad); // Añadimos la actividad completa
                }

                // Establecer DisplayMember y ValueMember para asociar el texto visible y el valor interno
                SeleccionActividad.DisplayMember = "Nombre";  // Mostramos el nombre de la actividad
                SeleccionActividad.ValueMember = "ActividadID";  // Usamos el ID como valor interno
            }
        }




        private void SeleccionActividad_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SeleccionActividad.SelectedItem != null)
            {
                try
                {
                    // Obtengo el ID de la actividad seleccionada

                    int actividadId = Convert.ToInt32(((Actividad)SeleccionActividad.SelectedItem).ActividadID);

                    // Limpio de nuevo el ListBox antes de cargar nuevos datos
                    MostrarHorario.Items.Clear();

                    using (var db = new GenteFitCristinaEntities1())
                    {
                        // Obtengo la actividad seleccionada
                        var actividad = db.Actividad.FirstOrDefault(a => a.ActividadID == actividadId);

                        if (actividad != null && actividad.Horario != default(DateTime))
                        {
                            // Formateo y mostrar el horario como quiero que se muestre
                            string hora = actividad.Horario.ToString("dd-MM-yyyy HH:mm");
                            MostrarHorario.Items.Add(hora);
                        }
                        else
                        {
                            MostrarHorario.Items.Add("Esta actividad no tiene horarios disponibles actualmente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el horario: {ex.Message}");
                }
            }
            else
            {
                // Si no se selecciona nada
                MostrarHorario.Items.Clear();
                MostrarHorario.Items.Add("Por favor, seleccione una actividad.");
            }
        }


        private void MostrarHorario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VolverInicio_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Estás seguro de que quieres volver al panel de administración?",
                                         "Confirmar acción",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AdministracionForm adminForm = new AdministracionForm(rol: rolUsuario, id: idUsuario);
                adminForm.Show();
                this.Close();
            }
        }
    }
    
}

