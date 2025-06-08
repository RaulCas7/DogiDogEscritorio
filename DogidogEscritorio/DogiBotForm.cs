using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DogidogEscritorio.DataClass;
using System.Net.Http;
using System.Text.Json;

namespace DogiDogEscritorio
{
    public partial class DogiBotForm : UserControl
    {
        private bool isHandlingClick = false;

        private bool isUpdatingSelection = false;
        private int? editingRowIndex = null;
        private List<Pregunta> preguntas = new List<Pregunta>();
        private readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:8080/dogidog/") };

        public DogiBotForm()
        {
            InitializeComponent();
            dgvDialogos.SelectionChanged += dgvDialogos_SelectionChanged;
        }

        private async void DogiBotForm_LoadAsync(object sender, EventArgs e)
        {
            dgvDialogos.SelectionChanged += new EventHandler(dgvDialogos_SelectionChanged);

            // Quitar selección inicial para que no quede fila seleccionada
            dgvDialogos.ClearSelection();

            await CargarPreguntasAsync();

            // Forzar modo de botones en "agregar"
            editingRowIndex = null;
            btnAgregar.Text = "➕ Agregar";
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private async Task CargarPreguntasAsync()
        {
            try
            {
                var response = await client.GetAsync("preguntas");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    preguntas = JsonSerializer.Deserialize<List<Pregunta>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    dgvDialogos.Rows.Clear();
                    foreach (var p in preguntas)
                    {
                        dgvDialogos.Rows.Add(p.pregunta, p.respuesta); // Usa las propiedades correctas según tu clase Pregunta
                    }
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar las preguntas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando preguntas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            string preguntaTexto = txtPregunta.Text.Trim();
            string respuestaTexto = txtRespuesta.Text.Trim();

            if (string.IsNullOrWhiteSpace(preguntaTexto))
            {
                MessageBox.Show("¡Ups! 🐶 La pregunta no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (editingRowIndex == null)
            {
                await CrearPreguntaAsync(new Pregunta { pregunta = preguntaTexto, respuesta = respuestaTexto });
            }
            else
            {
                int id = preguntas[editingRowIndex.Value].id;
                await ActualizarPreguntaAsync(new Pregunta { id = id, pregunta = preguntaTexto, respuesta = respuestaTexto });
                editingRowIndex = null;
                btnAgregar.Text = "➕ Agregar";
            }

            txtPregunta.Clear();
            txtRespuesta.Clear();
            await CargarPreguntasAsync();
        }

        private async Task CrearPreguntaAsync(Pregunta nueva)
        {
            var json = JsonSerializer.Serialize(nueva);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("preguntas", content);

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("No se pudo crear la pregunta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ActualizarPreguntaAsync(Pregunta actualizada)
        {
            var json = JsonSerializer.Serialize(actualizada);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"preguntas/{actualizada.id}", content);

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("No se pudo actualizar la pregunta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDialogos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para editar 🐶", "Nada seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvDialogos.SelectedRows[0];
            txtPregunta.Text = row.Cells[0].Value?.ToString();
            txtRespuesta.Text = row.Cells[1].Value?.ToString();
            editingRowIndex = row.Index;
            btnAgregar.Text = "✏️ Guardar Cambios";
        }


        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDialogos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para eliminar 🗑️", "Nada seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvDialogos.SelectedRows[0].Index;
            int id = preguntas[index].id;

            var confirm = MessageBox.Show("¿Estás segur@ de que deseas eliminar esta pregunta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                var response = await client.DeleteAsync($"preguntas/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar la pregunta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                await CargarPreguntasAsync();
            }
        }


        private int? lastSelectedRowIndex = null;
        private bool internalSelectionChange = false;


        private void btnToggleModo_Click(object sender, EventArgs e)
        {
            if (editingRowIndex != null && editingRowIndex >= 0)
            {
                // Actualmente en modo edición, cambiar a modo agregar
                dgvDialogos.ClearSelection();
                txtPregunta.Clear();
                txtRespuesta.Clear();
                editingRowIndex = null;

                btnAgregar.Text = "➕ Agregar";
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;

                btnToggleModo.Text = "Cambiar a Editar";
            }
            else
            {
                // Actualmente en modo agregar, intentar cambiar a modo editar
                if (dgvDialogos.SelectedRows.Count > 0)
                {
                    var row = dgvDialogos.SelectedRows[0];
                    editingRowIndex = row.Index;
                    txtPregunta.Text = row.Cells[0].Value?.ToString();
                    txtRespuesta.Text = row.Cells[1].Value?.ToString();

                    btnAgregar.Text = "✏️ Guardar Cambios";
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;

                    btnToggleModo.Text = "Cambiar a Agregar";
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fila para cambiar a modo edición.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void dgvDialogos_SelectionChanged(object sender, EventArgs e)
        {
            if (editingRowIndex == null) return;

            if (dgvDialogos.SelectedRows.Count == 0)
            {
                ClearForm();
                editingRowIndex = null;
                btnToggleModo.Text = "Cambiar a Editar";
                return;
            }

            editingRowIndex = dgvDialogos.SelectedRows[0].Index;
            var row = dgvDialogos.Rows[editingRowIndex.Value];

            txtPregunta.Text = row.Cells[0].Value?.ToString();
            txtRespuesta.Text = row.Cells[1].Value?.ToString();

            btnAgregar.Text = "✏️ Guardar Cambios";
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnToggleModo.Text = "Cambiar a Agregar";
        }

        private void ClearForm()
        {
            txtPregunta.Clear();
            txtRespuesta.Clear();
            btnAgregar.Text = "➕ Agregar";
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnToggleModo.Text = "Cambiar a Editar";
        }


        private void txtPregunta_Enter(object sender, EventArgs e)
        {
            if (txtPregunta.Text == "Escribe una pregunta 🐶")
            {
                txtPregunta.Text = "";
                txtPregunta.ForeColor = Color.Black;
            }
        }

        private void txtPregunta_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPregunta.Text))
            {
                txtPregunta.Text = "Escribe una pregunta 🐶";
                txtPregunta.ForeColor = Color.Gray;
            }
        }


      
    }

}


