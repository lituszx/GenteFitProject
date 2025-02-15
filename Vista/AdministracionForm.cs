using GenteFit.Modelos;
using System;
using System.Windows.Forms;

namespace GenteFit.Vista
{
    public partial class AdministracionForm : Form
    {
        private string rolUsuario;
        private int usuarioID;

        public AdministracionForm(string rol, int id)
        {
            InitializeComponent();
            rolUsuario = rol;
            usuarioID = id;
        }

        private void AdministracionForm_Load(object sender, EventArgs e)
        {
            // Configuramos la visibilidad de los botones según el rol del usuario
            switch (rolUsuario)
            {
                case "Administrador":
                    btnGestionClientes.Visible = true;
                    btnGestionReservas.Visible = true;
                    btnCalendario.Visible = true;
                    btnGestionUsuario.Visible = true;
                    btnGestionActividades.Visible = true;
                    btnOdoo.Visible = true;
                    break;

                case "Encargado":
                    btnGestionClientes.Visible = false;
                    btnGestionReservas.Visible = true;
                    btnCalendario.Visible = true;
                    btnGestionUsuario.Visible = false;
                    btnGestionActividades.Visible = true;
                    btnOdoo.Visible = false;
                    break;

                case "Recepcionista":
                    btnGestionClientes.Visible = true;
                    btnGestionReservas.Visible = false;
                    btnCalendario.Visible = false;
                    btnGestionUsuario.Visible = false;
                    btnGestionActividades.Visible = false;
                    btnOdoo.Visible = false;
                    break;

                case "Cliente":
                    btnGestionClientes.Visible = false;
                    btnGestionReservas.Visible = true;
                    btnCalendario.Visible = false;
                    btnGestionUsuario.Visible = true;
                    btnGestionActividades.Visible = false;
                    btnOdoo.Visible = false;
                    break;

                default:
                    MessageBox.Show("Rol no válido.");
                    this.Close();
                    break;
            }
        }

        private void btnGestionReservas_Click(object sender, EventArgs e)
        {
            // Pasamos el UsuarioID y rolUsuario a los diferentes Forms
            ReservasForm reservasForm = new ReservasForm(usuarioID, rolUsuario);
            reservasForm.Show();
            this.Hide();
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            RecepcionistaForm recepcionistaForm = new RecepcionistaForm(usuarioID, rolUsuario);
            recepcionistaForm.Show();
            this.Hide();
        }

        private void btnGestionUsuario_Click(object sender, EventArgs e)
        {
            ClientesForm clientesForm = new ClientesForm(usuarioID, rolUsuario);
            clientesForm.Show();
            this.Hide();
        }

        private void btnGestionActividades_Click(object sender, EventArgs e)
        {
            GestionarActividades gestionarActividadesForm = new GestionarActividades(usuarioID, rolUsuario);
            gestionarActividadesForm.Show();
            this.Hide();
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            CalendarioForm calendarioForm = new CalendarioForm(rol: rolUsuario, id: usuarioID);
            calendarioForm.Show();
            this.Hide();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Estás seguro de que quieres cerrar sesión y volver al inicio?",
                                "Confirmar acción",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                // Mostrar el formulario de Login
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Cerrar el formulario actual
                this.Close();
            }

        }

        private void btnOdoo_Click(object sender, EventArgs e)
        {
            // Al hacer clic, abrimos el nuevo formulario de integración con Odoo
            OdooIntegrationForm odooForm = new OdooIntegrationForm(usuarioID, rolUsuario);
            odooForm.Show();
            this.Hide();
        }
    }
}