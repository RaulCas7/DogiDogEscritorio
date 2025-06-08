using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace DogiDogEscritorio
{
    public partial class AgregarCuentaForm : Form
    {
        public AgregarCuentaForm()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoUsuario = new
                {
                    usuario = txtUsuario.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    password = txtPassword.Text,
                    contadorPreguntas = 0,
                    latitud = 0.0,
                    longitud = 0.0,
                    valoracion = 0,
                    foto = 0
                };

                var client = new HttpClient();
                var jsonUsuario = JsonConvert.SerializeObject(nuevoUsuario);
                var contentUsuario = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");

                var responseUsuario = await client.PostAsync("http://localhost:8080/dogidog/usuarios", contentUsuario);

                if (responseUsuario.StatusCode == HttpStatusCode.Conflict)
                {
                    MessageBox.Show("Ese correo electrónico o usuario ya está registrado. Intenta con otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!responseUsuario.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear el usuario.");
                    return;
                }

                // Obtener el ID buscando por email
                var buscarUsuarioResponse = await client.GetAsync($"http://localhost:8080/dogidog/usuarios/email/{nuevoUsuario.email}");
                if (!buscarUsuarioResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario creado, pero no se pudo obtener su ID.");
                    return;
                }

                var jsonUsuarioEncontrado = await buscarUsuarioResponse.Content.ReadAsStringAsync();
                var creado = JsonConvert.DeserializeObject<Usuario>(jsonUsuarioEncontrado);

                var nuevoEmpleado = new
                {
                    usuario = new { id = creado.id },
                    puesto = txtPuesto.Text,
                    fechaContratacion = dtpFecha.Value.ToString("yyyy-MM-dd"),
                    esAdministrador = chkAdmin.Checked
                };

                var jsonEmpleado = JsonConvert.SerializeObject(nuevoEmpleado);
                var contentEmpleado = new StringContent(jsonEmpleado, Encoding.UTF8, "application/json");

                var responseEmpleado = await client.PostAsync("http://localhost:8080/dogidog/empleados", contentEmpleado);

                if (responseEmpleado.IsSuccessStatusCode)
                {
                    MessageBox.Show("🎉 Cuenta creada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario creado, pero error al crear el empleado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }


        private class Usuario
        {
            public int id { get; set; }
        }
    }
}

