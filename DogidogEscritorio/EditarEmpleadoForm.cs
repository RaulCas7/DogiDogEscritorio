using System;
using System.Drawing;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DogiDogEscritorio
{
    public partial class EditarEmpleadoForm : Form
    {
        private int empleadoId;
        private int usuarioId;
        private bool esMismoUsuario;
        private bool esAdministradorLogueado;

        // Guarda datos originales para no sobrescribirlos
        private dynamic empleadoOriginal;

        public EditarEmpleadoForm(int empleadoId, int usuarioId, bool esMismoUsuario, bool esAdministradorLogueado)
        {
            InitializeComponent();

            this.empleadoId = empleadoId;
            this.usuarioId = usuarioId;
            this.esMismoUsuario = esMismoUsuario;
            this.esAdministradorLogueado = esAdministradorLogueado;

            // Aquí puedes habilitar/deshabilitar controles según esAdministradorLogueado, por ejemplo:
            btnResetPassword.Visible = esAdministradorLogueado;  // si agregas ese botón

            Load += EditarEmpleadoForm_Load;
        }

        private async void EditarEmpleadoForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"http://localhost:8080/dogidog/empleados/{empleadoId}");
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al cargar los datos del empleado.");
                        Close();
                        return;
                    }

                    var json = await response.Content.ReadAsStringAsync();
                    empleadoOriginal = JsonConvert.DeserializeObject<dynamic>(json);

                    txtPuesto.Text = empleadoOriginal.puesto;
                    chkAdmin.Checked = empleadoOriginal.esAdministrador;

                    if (esMismoUsuario)
                    {
                        lblPassword.Visible = true;
                        txtPassword.Visible = true;

                        // Placeholder simulado con asteriscos
                        txtPassword.ForeColor = Color.Gray;
                        txtPassword.Text = "Escribe tu nueva contraseña";
                        txtPassword.UseSystemPasswordChar = false;

                        // Suscribir eventos con métodos nombrados
                        txtPassword.GotFocus += TxtPassword_GotFocus;
                        txtPassword.LostFocus += TxtPassword_LostFocus;
                    }
                    else
                    {
                        lblPassword.Visible = false;
                        txtPassword.Visible = false;
                    }

                    btnResetPassword.Visible = esAdministradorLogueado && !esMismoUsuario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Close();
            }
        }

        private void TxtPassword_GotFocus(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Escribe tu nueva contraseña")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true; // Mostrar asteriscos
            }
        }

        private void TxtPassword_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false; // Mostrar texto placeholder sin asteriscos
                txtPassword.Text = "Escribe tu nueva contraseña";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Obtener usuario completo
                    var usuarioResponse = await client.GetAsync($"http://localhost:8080/dogidog/usuarios/{usuarioId}");
                    if (!usuarioResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al obtener datos del usuario.");
                        return;
                    }
                    var usuarioJson = await usuarioResponse.Content.ReadAsStringAsync();
                    dynamic usuarioActual = JsonConvert.DeserializeObject<dynamic>(usuarioJson);

                    // Actualizar empleado (solo puesto y admin, conservando resto)
                    var empleadoActualizado = new
                    {
                        id = empleadoOriginal.id,
                        usuario = empleadoOriginal.usuario,
                        puesto = txtPuesto.Text,
                        esAdministrador = chkAdmin.Checked,
                        fechaContratacion = empleadoOriginal.fechaContratacion
                    };

                    var jsonEmpleado = JsonConvert.SerializeObject(empleadoActualizado);
                    var contentEmpleado = new StringContent(jsonEmpleado, Encoding.UTF8, "application/json");

                    var responseEmpleado = await client.PutAsync($"http://localhost:8080/dogidog/empleados/{empleadoId}", contentEmpleado);
                    if (!responseEmpleado.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al actualizar el empleado.");
                        return;
                    }

                    // Actualizar contraseña si es el mismo usuario y la cambió
                    if (esMismoUsuario && !string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text != "Escribe tu nueva contraseña")
                    {
                        string passwordHasheada = CalcularMD5(txtPassword.Text);

                        // Para evitar el error de campos nulos, se obtiene el usuario completo y se actualiza la contraseña
                        usuarioActual.password = passwordHasheada;

                        var jsonPass = JsonConvert.SerializeObject(usuarioActual);
                        var contentPass = new StringContent(jsonPass, Encoding.UTF8, "application/json");

                        var resp = await client.PutAsync($"http://localhost:8080/dogidog/usuarios/{usuarioId}", contentPass);
                        if (!resp.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Empleado actualizado. Error al cambiar contraseña.");
                            return;
                        }
                    }

                    MessageBox.Show("Cambios guardados correctamente.");
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message);
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Seguro que quieres resetear la contraseña a '1234'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                using (var client = new HttpClient())
                {
                    // Obtener usuario completo
                    var usuarioResponse = await client.GetAsync($"http://localhost:8080/dogidog/usuarios/{usuarioId}");
                    if (!usuarioResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al obtener datos del usuario.");
                        return;
                    }
                    var usuarioJson = await usuarioResponse.Content.ReadAsStringAsync();
                    dynamic usuarioActual = JsonConvert.DeserializeObject<dynamic>(usuarioJson);

                    // Hashear "1234" con MD5 antes de asignar
                    usuarioActual.password = CalcularMD5("1234");

                    var jsonUsuario = JsonConvert.SerializeObject(usuarioActual);
                    var contentUsuario = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");

                    var resp = await client.PutAsync($"http://localhost:8080/dogidog/usuarios/{usuarioId}", contentUsuario);
                    if (!resp.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al resetear la contraseña.");
                        return;
                    }

                    MessageBox.Show("Contraseña reseteada a '1234'.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public static string CalcularMD5(string texto)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(texto);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convertir a cadena hex
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                    sb.Append(hashBytes[i].ToString("x2"));
                return sb.ToString();
            }
        }
    }
}

