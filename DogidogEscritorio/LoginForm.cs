
using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DogidogEscritorio.DataClass;
using Newtonsoft.Json;


namespace DogiDogEscritorio
{


    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent(); // Llama al método del Designer
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Lógica al cargar si quieres (por ahora, puede quedar vacía)
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingresa email y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string baseUrl = "http://localhost:8080/dogidog";

                    // 1. Validar usuario (login)
                    string loginUrl = $"{baseUrl}/usuarios/inicio?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}";
                    HttpResponseMessage loginResponse = await client.GetAsync(loginUrl);

                    if (!loginResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Login fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Leer datos usuario
                    string usuarioJson = await loginResponse.Content.ReadAsStringAsync();
                    var usuario = System.Text.Json.JsonSerializer.Deserialize<Usuario>(usuarioJson, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (usuario == null)
                    {
                        MessageBox.Show("Error al obtener datos del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Guardar usuario en sesión
                    Sesion.UsuarioActual = usuario;

                    // 2. Obtener empleado relacionado al usuario
                    string empleadoUrl = $"{baseUrl}/empleados/usuario/{usuario.id}";
                    HttpResponseMessage empleadoResponse = await client.GetAsync(empleadoUrl);

                    if (!empleadoResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("El usuario no tiene permisos para ingresar (no es empleado).", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string empleadoJson = await empleadoResponse.Content.ReadAsStringAsync();
                    var empleado = System.Text.Json.JsonSerializer.Deserialize<Empleado>(empleadoJson, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (empleado == null)
                    {
                        MessageBox.Show("Error al obtener datos del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Guardar empleado en sesión
                    Sesion.EmpleadoActual = empleado;

                    // Abrir formulario principal
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}

