using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using GenteFit.Modelos;
using GenteFit.Controlador;

namespace GenteFit.Vista
{
    public partial class ReservasForm : Form
    {
        private GestionReservas gestionReservas = new GestionReservas();
        private string rolUsuario;
        private int clienteId;
        private int usuarioID;

        public ReservasForm(int usuarioId, string rolUsuario)
        {
            InitializeComponent();
            usuarioID = usuarioId;
            this.rolUsuario = rolUsuario;
        }

        private void ReservasForm_Load(object sender, EventArgs e)
        {
            // Obtenemos el ClienteID asociado al UsuarioID
            clienteId = ObtenerClienteID();

            if (clienteId == 0)
            {
                MessageBox.Show("No se encontró información del cliente.");
                return;
            }

            // Cargamos las actividades disponibles
            CargarActividades();

            // Cargamos las reservas del cliente
            CargarReservasCliente();
        }

        private int ObtenerClienteID()
        {
            using (var context = new GenteFitCristinaEntities1())
            {
                // Buscamos el ClienteID asociado al UsuarioID en la tabla Cliente
                var cliente = context.Cliente.FirstOrDefault(c => c.UsuarioID == usuarioID);
                return cliente?.ClienteID ?? 0;
            }
        }

        private void CargarActividades()
        {
            using (var context = new GenteFitCristinaEntities1())
            {
                var actividades = context.Actividad.Include(a => a.Reserva).ToList();
                dgvActividades.DataSource = actividades.Select(a => new
                {
                    a.ActividadID,
                    a.Nombre,
                    a.Descripcion,
                    a.Intensidad,
                    a.PlazasTotales,
                    a.Horario,
                    a.SalaID,
                    a.MonitorID,
                    PlazasDisponibles = a.PlazasTotales - a.Reserva.Count
                }).ToList();
            }

            // Configuración de encabezados
            dgvActividades.Columns["ActividadID"].HeaderText = "ID";
            dgvActividades.Columns["Nombre"].HeaderText = "Nombre";
            dgvActividades.Columns["Descripcion"].HeaderText = "Descripción";
            dgvActividades.Columns["Intensidad"].HeaderText = "Intensidad";
            dgvActividades.Columns["PlazasTotales"].HeaderText = "Plazas Totales";
            dgvActividades.Columns["Horario"].HeaderText = "Horario";
            dgvActividades.Columns["SalaID"].HeaderText = "Sala";
            dgvActividades.Columns["MonitorID"].HeaderText = "Monitor";
            dgvActividades.Columns["PlazasDisponibles"].HeaderText = "Plazas Disponibles";
        }

        private void CargarReservasCliente()
        {
            using (var context = new GenteFitCristinaEntities1())
            {
                var reservas = context.Reserva
                    .Include(r => r.Actividad)
                    .Where(r => r.ClienteID == clienteId)
                    .ToList();

                dgvReservas.DataSource = reservas.Select(r => new
                {
                    r.ReservaID,
                    Actividad = r.Actividad.Nombre,
                    r.Actividad.Horario,
                    r.EstadoReserva
                }).ToList();
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (clienteId == 0)
            {
                MessageBox.Show("No se puede realizar una reserva porque no está asociado a un cliente.");
                return;
            }

            if (dgvActividades.SelectedRows.Count > 0)
            {
                try
                {
                    int actividadId = Convert.ToInt32(dgvActividades.SelectedRows[0].Cells["ActividadID"].Value);

                    // Realizamos la reserva pasando el ClienteID obtenido
                    gestionReservas.ReservarActividad(clienteId, actividadId);
                    CargarActividades();
                    CargarReservasCliente();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al realizar la reserva: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una actividad.");
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                try
                {
                    int reservaId = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["ReservaID"].Value);
                    gestionReservas.CancelarReserva(reservaId);
                    CargarActividades();
                    CargarReservasCliente();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al cancelar la reserva: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una reserva para cancelar.");
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
                // Pasamos rolUsuario y usuarioID al crear AdministracionForm
                AdministracionForm administracionForm = new AdministracionForm(rolUsuario, usuarioID);
                administracionForm.Show();
                this.Hide();
            }
        }
    }
}
