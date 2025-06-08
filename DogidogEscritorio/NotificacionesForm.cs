using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DogiDogEscritorio
{
    public partial class NotificacionesForm : UserControl
    {
        private class UsuarioDTO
        {
            public int id { get; set; }
            public string usuario { get; set; }
            public string email { get; set; }
            public int? valoracion { get; set; }
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:8080/dogidog/")
        };

        private List<UsuarioDTO> listaUsuarios = new List<UsuarioDTO>();

        public NotificacionesForm()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private async void CargarUsuarios()
        {
            try
            {
                var respuesta = await httpClient.GetAsync("usuarios");
                if (respuesta.IsSuccessStatusCode)
                {
                    var json = await respuesta.Content.ReadAsStringAsync();
                    listaUsuarios = JsonConvert.DeserializeObject<List<UsuarioDTO>>(json);

                    dgvUsuarios.Rows.Clear();
                    foreach (var u in listaUsuarios)
                    {
                        dgvUsuarios.Rows.Add(false, u.usuario, u.email);
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener los usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string mensaje = txtMensaje.Text.Trim();

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(mensaje))
            {
                MessageBox.Show("Por favor completa el título y el mensaje.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuariosSeleccionados = new List<UsuarioDTO>();

            for (int i = 0; i < dgvUsuarios.Rows.Count; i++)
            {
                bool seleccionado = Convert.ToBoolean(dgvUsuarios.Rows[i].Cells["chkSeleccionar"].Value);
                if (seleccionado)
                {
                    usuariosSeleccionados.Add(listaUsuarios[i]);
                }
            }

            if (usuariosSeleccionados.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un usuario para enviar la notificación.", "Ningún usuario seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí agregamos la confirmación:
            var confirmResult = MessageBox.Show(
                $"¿Está seguro que desea enviar la notificación a {usuariosSeleccionados.Count} usuarios?\n\nTítulo: {titulo}\nDescripción: {mensaje}",
                "Confirmar envío",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
            {
                // Si no confirma, sale del método sin enviar nada
                return;
            }

            try
            {
                foreach (var u in usuariosSeleccionados)
                {
                    var notificacion = new
                    {
                        titulo = titulo,
                        mensaje = mensaje,
                        usuario = new
                        {
                            id = u.id,
                            usuario = u.usuario,
                            email = u.email,
                            password = "",  // o null si no lo necesitas enviar
                            contadorPreguntas = 0,
                            latitud = (double?)null,
                            longitud = (double?)null,
                            valoracion = u.valoracion,
                            foto = (int?)null
                        }
                    };

                    var json = JsonConvert.SerializeObject(notificacion);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("notificaciones", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Error al enviar notificación a {u.usuario}");
                    }
                }

                MessageBox.Show("Notificaciones enviadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitulo.Clear();
                txtMensaje.Clear();

                foreach (DataGridViewRow row in dgvUsuarios.Rows)
                {
                    row.Cells["chkSeleccionar"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar notificaciones: " + ex.Message);
            }
        }


        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                row.Cells["chkSeleccionar"].Value = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // UserControl no tiene Close(). Aquí podrías:
            // - Limpiar los campos
            // - O notificar al form padre para ocultar este control
            txtTitulo.Clear();
            txtMensaje.Clear();
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                row.Cells["chkSeleccionar"].Value = false;
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

