using GenteFit.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFit.Vista
{
    public partial class ClientesForm : Form
    {
        private string rolUsuario;
        private int idUsuario;

        public ClientesForm(int idUsuario, string rolUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;
        }

        private void btnConsultarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                {
                    var clientes = db.Cliente.ToList();

                    if (clientes.Any())
                    {
                        // Construimos un mensaje con la informacion de todos los clientes
                        StringBuilder sb = new StringBuilder();
                        foreach (var cliente in clientes)
                        {
                            sb.AppendLine($"Nombre: {cliente.Nombre}");
                            sb.AppendLine($"Apellidos: {cliente.Apellidos}");
                            sb.AppendLine($"Correo: {cliente.Correo}");
                            sb.AppendLine($"Teléfono: {cliente.Telefono}");
                            sb.AppendLine($"Fecha de Nacimiento: {cliente.FechaNacimiento:yyyy-MM-dd}");
                            sb.AppendLine($"Dirección: {cliente.Direccion}");
                            sb.AppendLine(new string('-', 40));
                        }
                        MessageBox.Show(sb.ToString(), "Listado de Clientes");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información de clientes.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar el perfil: {ex.Message}");
            }
        }

        private void btnAccederReservas_Click(object sender, EventArgs e)
        {
           ReservasForm reservasForm = new ReservasForm(idUsuario, rolUsuario);
           reservasForm.Show();
           this.Hide();
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
