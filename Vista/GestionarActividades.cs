using GenteFit.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFit.Vista
{
    public partial class GestionarActividades : Form
    {
        SqlConnection conex = new SqlConnection("Data Source=DESKTOP-8CJA7DG;Initial Catalog=GenteFitCristina;Integrated Security=True");
        SqlDataAdapter adpt;
        private string rolUsuario;
        private int idUsuario;

        public GestionarActividades(int idUsuario, string rolUsuario)
        {
            InitializeComponent();
            Content();
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;
        }

        private void GestionarActividades_Load(object sender, EventArgs e)
        {
            CargarSalas();
            CargarMonitores();
            CargarHorarios();
        }

        private void CargarSalas()
        {
            using (var db = new Modelos.GenteFitCristinaEntities1())
            {
                var salas = db.Sala.Select(s => new { s.SalaID, s.Nombre }).ToList();
                Salas.DataSource = salas;
                Salas.DisplayMember = "Nombre";
                Salas.ValueMember = "SalaID";
            }
        }

        private void CargarMonitores()
        {
            using (var db = new Modelos.GenteFitCristinaEntities1())
            {
                var monitores = db.Monitor.Select(m => new { m.MonitorID, m.Nombre }).ToList();
                Monitores.DataSource = monitores;
                Monitores.DisplayMember = "Nombre";
                Monitores.ValueMember = "MonitorID";
            }
        }
        private void CargarHorarios()
        {
            using (var db = new Modelos.GenteFitCristinaEntities1())
            {
                // Asumiendo que tienes una tabla de horarios o una lista de horarios disponibles en otra tabla
                var horarios = db.Actividad.Select(h => new { h.ActividadID, h.Horario }).ToList(); // Ajusta según el esquema de tu base de datos
                Horarios.DataSource = horarios;
                Horarios.DisplayMember = "Horario"; // Campo que representa el horario en texto
                Horarios.ValueMember = "ActividadID"; // Campo de ID de horario
            }
        }
        private void Content()
        {
            conex.Open();
            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter("SELECT * FROM Actividad", conex);
            adpt.Fill(dt);
            dataGridViewActividades.DataSource = dt;
            conex.Close();
        }
        private void dataGridViewActividades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewActividades.Rows[e.RowIndex];
                // Cargar los valores de la fila seleccionada en los TextBox
                textBoxAct.Text = selectedRow.Cells["Nombre"].Value.ToString();
                textBoxDesc.Text = selectedRow.Cells["Descripcion"].Value.ToString();
                textBoxPlz.Text = selectedRow.Cells["PlazasTotales"].Value.ToString();
                Instensidades.SelectedItem = selectedRow.Cells["Intensidad"].Value.ToString();
                Horarios.SelectedItem = selectedRow.Cells["Horario"].Value.ToString();
                Salas.SelectedValue = Convert.ToInt32(selectedRow.Cells["SalaID"].Value);
                Monitores.SelectedValue = Convert.ToInt32(selectedRow.Cells["MonitorID"].Value);
            }

        }

        private void BtnAgregarAct_Click(object sender, EventArgs e)
        {
            try
            {
                using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                {

                    if (dataGridViewActividades.SelectedRows.Count > 0)
                    {
                        int actividadID = Convert.ToInt32(dataGridViewActividades.SelectedRows[0].Cells["ActividadID"].Value);
                        var actividad = db.Actividad.Find(actividadID);
                        if (actividad != null)
                        {
                            actividad.Nombre = textBoxAct.Text.Trim();
                            actividad.Descripcion = textBoxDesc.Text.Trim();
                            actividad.Intensidad = Instensidades.SelectedItem.ToString();
                            actividad.PlazasTotales = Int32.Parse(textBoxPlz.Text.ToString());
                            var seleccionado = (dynamic)Horarios.SelectedItem;  // Convertimos a tipo dinámico para acceder a la propiedad
                            DateTime horarioSeleccionado;
                            DateTime.TryParse(seleccionado.Horario.ToString(), out horarioSeleccionado);
                            actividad.Horario = horarioSeleccionado;
                            actividad.SalaID = ((dynamic)Salas.SelectedItem).SalaID;
                            actividad.MonitorID = ((dynamic)Monitores.SelectedItem).MonitorID;

                            db.SaveChanges();
                            MessageBox.Show("Actividad modificada con éxito.");
                        }
                    }
                    else
                    {

                        var seleccionado = (dynamic)Horarios.SelectedItem;  // Convertimos a tipo dinámico para acceder a la propiedad
                        DateTime horarioSeleccionado;

                        if (DateTime.TryParse(seleccionado.Horario.ToString(), out horarioSeleccionado))
                        {

                            var nuevaActividad = new GenteFit.Modelos.Actividad
                            {
                                Nombre = textBoxAct.Text.Trim(),
                                Descripcion = textBoxDesc.Text.Trim(),
                                Intensidad = Instensidades.SelectedItem.ToString(),
                                PlazasTotales = Int32.Parse(textBoxPlz.Text.ToString()),
                                Horario = horarioSeleccionado,  // Asignamos el DateTime
                                SalaID = ((dynamic)Salas.SelectedItem).SalaID,
                                MonitorID = ((dynamic)Monitores.SelectedItem).MonitorID,
                            };

                            db.Actividad.Add(nuevaActividad);
                        }
                        else
                        {
                            MessageBox.Show("El formato del horario seleccionado no es válido.");
                        }



                        db.SaveChanges();
                        MessageBox.Show("Actividad agregada con éxito.");
                    }

                    LoadAct();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al agregar actividad: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadAct()
        {
            try
            {
                using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                {
                    var actividad = db.Actividad.Select(c => new
                    {
                        c.ActividadID,
                        c.Nombre,
                        c.Descripcion,
                        c.Intensidad,
                        c.PlazasTotales,
                        c.Horario,
                        c.SalaID,
                        c.MonitorID
                    }).ToList();

                    dataGridViewActividades.DataSource = actividad;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar actividades: {ex.Message}");
            }
        }
        private void txtBuscarAct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                {
                    string searchTerm = txtBuscarAct.Text.Trim();

                    var filteredAct = db.Actividad
                        .Where(c => c.Nombre.Contains(searchTerm))
                        .Select(c => new
                        {
                            c.ActividadID,
                            c.Nombre,
                            c.Descripcion,
                            c.Intensidad,
                            c.PlazasTotales,
                            c.Horario,
                            c.SalaID,
                            c.MonitorID
                        }).ToList();

                    dataGridViewActividades.DataSource = filteredAct;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar actividad: {ex.Message}");
            }
        }

        private void btnEliminarAct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewActividades.SelectedRows.Count > 0)
                {
                    int actividadID = Convert.ToInt32(dataGridViewActividades.SelectedRows[0].Cells["ActividadID"].Value);

                    using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                    {
                        var actividad = db.Actividad.Find(actividadID);
                        if (actividad != null)
                        {
                            db.Actividad.Remove(actividad);
                            db.SaveChanges();
                            MessageBox.Show("Actividad eliminada con éxito.");
                            LoadAct();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una actividad para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar actividad: {ex.Message}");
            }
        }

        private void textBoxAct_TextChanged(object sender, EventArgs e)
        {

        }

        private void Instensidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Salas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Monitores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewActividades.SelectedRows.Count > 0)
                {
                    int actividadID = Convert.ToInt32(dataGridViewActividades.SelectedRows[0].Cells["ActividadID"].Value);

                    using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                    {
                        var actividad = db.Actividad.Find(actividadID);
                        if (actividad != null)
                        {
                            actividad.Nombre = textBoxAct.Text.Trim();
                            actividad.Descripcion = textBoxDesc.Text.Trim();
                            actividad.Intensidad = Instensidades.SelectedItem.ToString();
                            actividad.PlazasTotales = Int32.Parse(textBoxPlz.Text.ToString());
                            var seleccionado = (dynamic)Horarios.SelectedItem;  // Convertimos a tipo dinámico para acceder a la propiedad
                            DateTime horarioSeleccionado;
                            DateTime.TryParse(seleccionado.Horario.ToString(), out horarioSeleccionado);
                            actividad.Horario = horarioSeleccionado;
                            actividad.SalaID = ((dynamic)Salas.SelectedItem).SalaID;
                            actividad.MonitorID = ((dynamic)Monitores.SelectedItem).MonitorID;

                            db.SaveChanges();
                            MessageBox.Show("Actividad modificada con éxito.");
                            LoadAct();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una actividad para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar actividad: {ex.Message}");
            }
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
