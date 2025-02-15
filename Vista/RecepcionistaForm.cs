using GenteFit.Modelos;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GenteFit.Vista
{
    public partial class RecepcionistaForm : Form
    {
        private int idUsuario;
        private string rolUsuario;

        public RecepcionistaForm(int idUsuario, string rolUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;
        }
        private void RecepcionistaForm_Load(object sender, EventArgs e)
        {
            LoadClientes();
        }

        private void LoadClientes()
        {
            try
            {
                using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                {
                    var clientes = db.Cliente.Select(c => new
                    {
                        c.ClienteID,
                        c.Nombre,
                        c.Apellidos,
                        c.Correo,
                        c.Telefono,
                        c.FechaNacimiento,
                        c.Direccion,
                        c.UsuarioID
                    }).ToList();

                    dataGridViewClientes.DataSource = clientes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                {
                    string searchTerm = txtBuscar.Text.Trim();

                    var filteredClients = db.Cliente
                        .Where(c => c.Nombre.Contains(searchTerm) || c.Correo.Contains(searchTerm))
                        .Select(c => new
                        {
                            c.ClienteID,
                            c.Nombre,
                            c.Apellidos,
                            c.Correo,
                            c.Telefono,
                            c.FechaNacimiento,
                            c.Direccion,
                            c.UsuarioID
                        }).ToList();

                    dataGridViewClientes.DataSource = filteredClients;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}");
            }
        }

        // Evento para seleccionar una fila en el DataGridView
        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewClientes.Rows[e.RowIndex];
                // Cargar los valores de la fila seleccionada en los TextBox
                txtNombre.Text = selectedRow.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = selectedRow.Cells["Apellidos"].Value.ToString();
                txtCorreo.Text = selectedRow.Cells["Correo"].Value.ToString();
                txtTelefono.Text = selectedRow.Cells["Telefono"].Value.ToString();
                txtDireccion.Text = selectedRow.Cells["Direccion"].Value.ToString();
                dateTimePickerFechaNacimiento.Value = Convert.ToDateTime(selectedRow.Cells["FechaNacimiento"].Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewClientes.SelectedRows.Count > 0)
                {
                    int clienteID = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["ClienteID"].Value);

                    using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                    {
                        var cliente = db.Cliente.Find(clienteID);
                        if (cliente != null)
                        {
                            // Eliminamos primero el usuario asociado al cliente
                            var usuario = db.Usuario.Find(cliente.UsuarioID);
                            if (usuario != null)
                            {
                                db.Usuario.Remove(usuario);
                            }

                            db.Cliente.Remove(cliente);
                            db.SaveChanges();
                            MessageBox.Show("Cliente eliminado con éxito.");
                            LoadClientes();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar cliente: {ex.Message}");
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewClientes.SelectedRows.Count > 0)
                {
                    int clienteID = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["ClienteID"].Value);

                    using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                    {
                        var cliente = db.Cliente.Find(clienteID);
                        if (cliente != null)
                        {
                            cliente.Nombre = txtNombre.Text.Trim();
                            cliente.Apellidos = txtApellidos.Text.Trim();
                            cliente.Correo = txtCorreo.Text.Trim();
                            cliente.Telefono = txtTelefono.Text.Trim();
                            cliente.FechaNacimiento = dateTimePickerFechaNacimiento.Value;
                            cliente.Direccion = txtDireccion.Text.Trim();

                            // Actualizamos también el usuario asociado si es necesario
                            var usuario = db.Usuario.Find(cliente.UsuarioID);
                            if (usuario != null)
                            {
                                usuario.NombreUsuario = txtCorreo.Text.Trim();
                            }

                            db.SaveChanges();
                            MessageBox.Show("Cliente modificado con éxito.");
                            LoadClientes();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar cliente: {ex.Message}");
            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                {
                    // Si hay cliente seleccionado, modificarlo
                    if (dataGridViewClientes.SelectedRows.Count > 0)
                    {
                        int clienteID = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["ClienteID"].Value);
                        var cliente = db.Cliente.Find(clienteID);
                        if (cliente != null)
                        {
                            cliente.Nombre = txtNombre.Text.Trim();
                            cliente.Apellidos = txtApellidos.Text.Trim();
                            cliente.Correo = txtCorreo.Text.Trim();
                            cliente.Telefono = txtTelefono.Text.Trim();
                            cliente.FechaNacimiento = dateTimePickerFechaNacimiento.Value;
                            cliente.Direccion = txtDireccion.Text.Trim();

                            // Actualizamos también el usuario asociado si es necesario
                            var usuario = db.Usuario.Find(cliente.UsuarioID);
                            if (usuario != null)
                            {
                                usuario.NombreUsuario = txtCorreo.Text.Trim();
                            }

                            db.SaveChanges();
                            MessageBox.Show("Cliente modificado con éxito.");
                        }
                    }
                    else
                    {
                        // Si no hay cliente seleccionado, agregar uno nuevo

                        // Verificamos si el nombre de usuario ya existe
                        string nombreUsuario = txtCorreo.Text.Trim();
                        if (db.Usuario.Any(u => u.NombreUsuario == nombreUsuario))
                        {
                            MessageBox.Show("El nombre de usuario ya existe. Por favor, ingrese otro correo.");
                            return;
                        }

                        // Primero, creamos un nuevo usuario para el cliente
                        var nuevoUsuario = new Modelos.Usuario
                        {
                            NombreUsuario = nombreUsuario,    // Utilizamos el correo como nombre de usuario
                            Contraseña = "Contraseña123",     // Asigna una contraseña por defecto o genera una
                            Rol = "Cliente"
                        };

                        db.Usuario.Add(nuevoUsuario);
                        db.SaveChanges(); // Guardamos para obtener el UsuarioID

                        // Ahora, creamos el cliente asociado al nuevo usuario
                        var nuevoCliente = new Modelos.Cliente
                        {
                            Nombre = txtNombre.Text.Trim(),
                            Apellidos = txtApellidos.Text.Trim(),
                            Correo = txtCorreo.Text.Trim(),
                            Telefono = txtTelefono.Text.Trim(),
                            FechaNacimiento = dateTimePickerFechaNacimiento.Value,
                            Direccion = txtDireccion.Text.Trim(),
                            UsuarioID = nuevoUsuario.UsuarioID // Asignamos el ID del nuevo usuario
                        };

                        db.Cliente.Add(nuevoCliente);
                        db.SaveChanges();
                        MessageBox.Show("Cliente agregado con éxito.");
                    }

                    LoadClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar cliente: {ex.Message}");
            }
        }

        private void ValidarCampos()
        {
            bool correoValido = Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            btnAgregarUsuario.Enabled =
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellidos.Text) &&
                correoValido &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtDireccion.Text) &&
                dateTimePickerFechaNacimiento.Value <= DateTime.Now;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void txtApellidos_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void txtCorreo_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void txtTelefono_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void txtDireccion_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void dateTimePickerFechaNacimiento_ValueChanged(object sender, EventArgs e) => ValidarCampos();

        private void pictureBox2_Click(object sender, EventArgs e)
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
