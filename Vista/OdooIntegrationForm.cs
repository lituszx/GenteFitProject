using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace GenteFit.Vista
{
    public partial class OdooIntegrationForm : Form
    {
        private int usuarioID;
        private string rolUsuario;

        public OdooIntegrationForm(int usuarioId, string rolUsuario)
        {
            InitializeComponent();
            this.usuarioID = usuarioId;
            this.rolUsuario = rolUsuario;
        }

        private void OdooIntegrationForm_Load(object sender, EventArgs e)
        {
            // Poblar el combo con las tablas disponibles
            cbTablas.Items.AddRange(new string[] { "Cliente", "Actividad", "Usuario", "Reserva", "Monitor", "Sala" });
            cbTablas.SelectedIndex = 0;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string tablaSeleccionada = cbTablas.SelectedItem.ToString();

            string connectionString = "Data Source=.;Initial Catalog=GenteFitCristina;Integrated Security=True";
            string consulta = $"SELECT * FROM {tablaSeleccionada} FOR XML PATH('{tablaSeleccionada}'), ROOT('{tablaSeleccionada}s')";

            string xmlOutputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exportaciones", $"{tablaSeleccionada}.xml");
            Directory.CreateDirectory(Path.GetDirectoryName(xmlOutputPath));

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(consulta, conn))
            {
                conn.Open();
                string resultadoXml = cmd.ExecuteScalar() as string;

                if (!string.IsNullOrEmpty(resultadoXml))
                {
                    // Si el archivo existe, se sobrescribirá sin problemas.
                    bool existeArchivo = File.Exists(xmlOutputPath);

                    // Sobrescribimos el archivo
                    File.WriteAllText(xmlOutputPath, resultadoXml);

                    if (existeArchivo)
                    {
                        MessageBox.Show($"El archivo {xmlOutputPath} ya existía y ha sido sobrescrito con la nueva informacion de la tabla {tablaSeleccionada}.");
                    }
                    else
                    {
                        MessageBox.Show($"Se ha exportado la tabla {tablaSeleccionada} a {xmlOutputPath}.");
                    }
                }
                else
                {
                    MessageBox.Show("No se obtuvo ningún resultado.");
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (cbTablas.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una tabla a importar.");
                return;
            }

            string tablaSeleccionada = cbTablas.SelectedItem.ToString();
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exportaciones", $"{tablaSeleccionada}.xml");

            if (!File.Exists(xmlPath))
            {
                MessageBox.Show($"No se encontro el archivo {xmlPath} para importar.");
                return;
            }

            // Ruta al script Python
            string pythonScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "python", "importar_odoo.py");

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"\"{pythonScriptPath}\" \"{xmlPath}\" \"{tablaSeleccionada}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process p = new Process())
            {
                p.StartInfo = psi;
                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();

                p.WaitForExit();

                if (string.IsNullOrEmpty(error))
                {
                    MessageBox.Show($"Importacion de {tablaSeleccionada} a Odoo completada.\nOutput:\n{output}");
                }
                else
                {
                    MessageBox.Show($"Error al importar a Odoo:\n{error}");
                }
            }
        }

        private void OdooIntegrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Al cerrar este form, retornamos a AdministracionForm. Hay que cambiar esto para que se realice desde el boton de Volver atras.
            AdministracionForm adminForm = new AdministracionForm(rolUsuario, usuarioID);
            adminForm.Show();
        }
    }
}
