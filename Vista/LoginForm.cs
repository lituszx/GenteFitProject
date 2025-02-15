using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFit.Vista
{
    public partial class LoginForm : Form
    {
        // Agregamos una variable para almacenar el UsuarioID obtenido de la tabla Cliente
        private int usuarioID;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Por favor, ingrese usuario y contraseña.");
                    return;
                }

                string sPass = txtPassword.Text.Trim();
                buttonEntrar.Enabled = false;

                using (Modelos.GenteFitCristinaEntities1 db = new Modelos.GenteFitCristinaEntities1())
                {
                    // Verificamos el usuario en la tabla Usuario
                    var usuario = db.Usuario.FirstOrDefault(d => d.NombreUsuario == txtUser.Text && d.Contraseña == sPass);

                    if (usuario != null)
                    {
                        // Almacenamos el UsuarioID obtenido de la tabla Usuario
                        usuarioID = usuario.UsuarioID;

                        MessageBox.Show($"Bienvenido, {usuario.NombreUsuario}. Rol: {usuario.Rol}");

                        // Pasamos el UsuarioID y el Rol al AdministracionForm
                        AdministracionForm administracionForm = new AdministracionForm(usuario.Rol, usuarioID);
                        administracionForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}");
            }
            finally
            {
                buttonEntrar.Enabled = true;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void checkDB_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
