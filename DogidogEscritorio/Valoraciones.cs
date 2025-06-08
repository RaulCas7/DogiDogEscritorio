using DogidogEscritorio.DataClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace DogiDogEscritorio
{
    public partial class ValoracionesForm : UserControl
    {
        public ValoracionesForm()
        {
            InitializeComponent();
            CargarValoraciones(); // Esto luego se conectará con la API
        }

        private async void CargarValoraciones()
        {
            try
            {
                string apiUrl = "http://localhost:8080/dogidog/valoraciones"; // base
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync($"{apiUrl}");

                var valoraciones = JsonConvert.DeserializeObject<List<Valoracion>>(response);

                dgvValoraciones.Rows.Clear();
                foreach (var v in valoraciones)
                {
                    int rowIndex = dgvValoraciones.Rows.Add(
                        v.usuario?.email ?? "Desconocido",
                        v.valorado?.email ?? "Desconocido",
                        v.puntuacion,
                        v.comentario
                    );

                    dgvValoraciones.Rows[rowIndex].Tag = v;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar valoraciones: " + ex.Message);
            }
        }

        private async void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            if (dgvValoraciones.SelectedRows.Count > 0)
            {
                var fila = dgvValoraciones.SelectedRows[0];
                var valoracion = fila.Tag as Valoracion;

                if (valoracion == null || valoracion.valorado == null)
                {
                    MessageBox.Show("No se puede obtener el ID del usuario valorado.");
                    return;
                }

                int idValorado = valoracion.valorado.id;
                string email = valoracion.valorado.email;

                var confirm = MessageBox.Show($"¿Eliminar la cuenta de {email}?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        HttpClient client = new HttpClient();
                        var response = await client.DeleteAsync($"http://localhost:8080/dogidog/usuarios/{idValorado}");

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Cuenta eliminada correctamente.");
                            CargarValoraciones();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar la cuenta.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de red: " + ex.Message);
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvValoraciones.Rows)
            {
                row.Visible = row.Cells["colUsuarioValorado"].Value.ToString().ToLower().Contains(filtro)
                           || row.Cells["colUsuarioValora"].Value.ToString().ToLower().Contains(filtro);
            }
        }

        private void dgvValoraciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

