// (cabezera sin cambios)
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using DogidogEscritorio;
using DogidogEscritorio.DataClass;

namespace DogiDogEscritorio
{
    public partial class IncidenciasForm : UserControl
    {
        private List<Tarea> tareas = new List<Tarea>();

        private async Task<bool> ActualizarTareaAsync(Tarea tarea)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"http://localhost:8080/dogidog/tareas/{tarea.Id_Tarea}";

                    var opciones = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        Converters = { new JsonStringEnumConverter() }
                    };

                    // Agrego el converter para formatear DateTime
                    opciones.Converters.Add(new DateTimeConverterSinZona());

                    string json = JsonSerializer.Serialize(tarea, opciones);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                    {
                        MessageBox.Show("Error al actualizar tarea: " + response.ReasonPhrase);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
                return false;
            }
        }

        // Converter personalizado para DateTime sin zona horaria ni decimales extras
        public class DateTimeConverterSinZona : JsonConverter<DateTime>
        {
            private const string Formato = "yyyy-MM-dd'T'HH:mm:ss.fff";

            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateTime.Parse(reader.GetString() ?? string.Empty);
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString(Formato));
            }
        }

        public IncidenciasForm()
        {
            InitializeComponent();

            cmbEstadoFiltro.SelectedIndex = 0;

            cmbPrioridadFiltro.SelectedIndex = 0;

            cmbEstadoFiltro.SelectedIndexChanged += (s, e) => LoadIncidencias();
            cmbPrioridadFiltro.SelectedIndexChanged += (s, e) => LoadIncidencias();
            txtBuscar.TextChanged += (s, e) => LoadIncidencias();

            _ = CargarTareasAsync();
        }

        private async Task CargarTareasAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:8080/dogidog/tareas";
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        var opciones = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters = { new JsonStringEnumConverter() }
                        };

                        tareas = JsonSerializer.Deserialize<List<Tarea>>(json, opciones) ?? new List<Tarea>();

                        // Asegurar valores por defecto para fechas nulas
                        foreach (var tarea in tareas)
                        {
                            if (tarea.FechaCreacion == null)
                                tarea.FechaCreacion = DateTime.Now;

                            if (tarea.FechaVencimiento == null)
                                tarea.FechaVencimiento = DateTime.Now.AddDays(7);
                        }

                        LoadIncidencias();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        tareas.Clear();
                        LoadIncidencias();
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener tareas: " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }


        private void LoadIncidencias()
        {
            flowPanel.Controls.Clear();

            string estadoFiltro = cmbEstadoFiltro.SelectedItem?.ToString() ?? "Todos";
            string prioridadFiltro = cmbPrioridadFiltro.SelectedItem?.ToString() ?? "Todas";
            string textoBusqueda = txtBuscar.Text.Trim();

            var filtradas = tareas
                .Where(t =>
                    (string.IsNullOrEmpty(textoBusqueda) ||
                     (t.Titulo != null && t.Titulo.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)) &&
                    (estadoFiltro == "Todos" || t.Estado.ToString() == estadoFiltro) &&
                    (prioridadFiltro == "Todas" || t.Prioridad.ToString() == prioridadFiltro)
                )
                .ToList();

            foreach (var tarea in filtradas)
            {
                AddTarjeta(tarea);
            }
        }

        private void AddTarjeta(Tarea tarea)
        {
            Panel tarjeta = new Panel
            {
                Width = flowPanel.ClientSize.Width - 25,
                Height = 140,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
            };

            Label lblTitulo = new Label { Text = tarea.Titulo, Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(10, 10), AutoSize = true };

            Label lblDescripcion = new Label
            {
                Text = tarea.Descripcion,
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 40),
                AutoSize = true,
                MaximumSize = new Size(tarjeta.Width - 20, 40)
            };

            Label lblEstado = new Label
            {
                Text = $"Estado: {tarea.Estado}",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                Location = new Point(10, 90),
                AutoSize = true
            };

            Label lblPrioridad = new Label
            {
                Text = $"Prioridad: {tarea.Prioridad}",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                Location = new Point(200, 90),
                AutoSize = true
            };

            string asignadoA = tarea.Empleado != null ? tarea.Empleado.usuario.usuario : "Sin asignar";
            Label lblAsignado = new Label
            {
                Text = $"Asignado a: {asignadoA}",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 110),
                AutoSize = true
            };

            string fechaTexto = tarea.FechaVencimiento.HasValue
                ? tarea.FechaVencimiento.Value.ToShortDateString()
                : (tarea.FechaCreacion.HasValue
                    ? tarea.FechaCreacion.Value.ToShortDateString()
                    : "Sin fecha");
            Label lblFecha = new Label
            {
                Text = fechaTexto,
                Location = new Point(tarjeta.Width - 110, 110),
                AutoSize = true
            };

            // Colores por estado (versión compatible)
            Color color;
            switch (tarea.Estado)
            {
                case Estado.Abierta:
                    color = Color.OrangeRed;
                    break;
                case Estado.EnProgreso:
                    color = Color.MediumBlue;
                    break;
                case Estado.Cerrada:
                    color = Color.ForestGreen;
                    break;
                default:
                    color = Color.Gray;
                    break;
            }
            lblEstado.ForeColor = color;

            Button btnEditar = new Button
            {
                Text = "✏️",
                Size = new Size(30, 30),
                Location = new Point(tarjeta.Width - 80, 10),
                BackColor = Color.LightSkyBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.Click += (s, e) => EditarTarea(tarea);

            Button btnEliminar = new Button
            {
                Text = "🗑️",
                Size = new Size(30, 30),
                Location = new Point(tarjeta.Width - 40, 10),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat
            };
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Click += (s, e) =>
            {
                var res = MessageBox.Show($"¿Eliminar '{tarea.Titulo}'?", "Eliminar", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    EliminarTarea(tarea);
                }
            };

            tarjeta.Controls.AddRange(new Control[] { lblTitulo, lblDescripcion, lblEstado, lblPrioridad, lblAsignado, lblFecha, btnEditar, btnEliminar });
            flowPanel.Controls.Add(tarjeta);
        }

        private async void EliminarTarea(Tarea tarea)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"http://localhost:8080/dogidog/tareas/{tarea.Id_Tarea}";
                    var response = await client.DeleteAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        tareas.Remove(tarea);
                        LoadIncidencias();
                        MessageBox.Show("Tarea eliminada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar tarea: " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        private async void EditarTarea(Tarea tarea)
        {
            var form = new EditarIncidenciaForm(tarea);
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Obtener la tarea actualizada del formulario
                Tarea tareaActualizada = form.GetTareaActualizada(tarea);

                // Llamar a la API para actualizar
                bool exito = await ActualizarTareaAsync(tareaActualizada);

                if (exito)
                {
                    // Recargar lista de tareas si todo fue bien
                    await CargarTareasAsync();
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var form = new NuevaIncidenciaForm(); // Debes crear este formulario acorde a la entidad Tarea
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = CargarTareasAsync();
            }
        }

        private void IncidenciasForm_Load(object sender, EventArgs e)
        {

        }
    }

}
