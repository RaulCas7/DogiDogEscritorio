using DogidogEscritorio.DataClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DogiDogEscritorio
{
    public partial class RazasForm : UserControl
    {
        private Raza razaSeleccionada = null;
        private readonly HttpClient httpClient = new HttpClient();
        private const string apiUrl = "http://localhost:8080/dogidog/razas";

        public RazasForm()
        {
            InitializeComponent();
            ConfigurarTabla();
            _ = CargarRazasDesdeAPI();
        }

        private async Task CargarRazasDesdeAPI()
        {
            try
            {
                var response = await httpClient.GetStringAsync(apiUrl);
                var razas = JsonConvert.DeserializeObject<List<Raza>>(response);

                dgvRazas.Rows.Clear();
                chartRazas.Series.Clear();
                chartRazas.Titles.Clear();
                chartRazas.ChartAreas.Clear();

                // Configurar el área del gráfico
                ChartArea chartArea = new ChartArea("AreaPrincipal");
                chartArea.AxisX.Title = "Raza";
                chartArea.AxisY.Title = "Nivel de Energía";
                chartArea.AxisX.LabelStyle.Angle = -45;
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.MajorGrid.Enabled = false;
                chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                chartRazas.ChartAreas.Add(chartArea);

                // Agregar título
                chartRazas.Titles.Add("Nivel de Energía por Raza");

                // Crear la serie
                var serie = new Series("Nivel de Energía")
                {
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.CornflowerBlue,
                    BorderWidth = 2,
                    IsValueShownAsLabel = true
                };

                foreach (var raza in razas)
                {
                    dgvRazas.Rows.Add(
                        raza.nombre,
                        raza.energia,
                        raza.inteligencia,
                        raza.socializacion,
                        raza.cuidado
                    );

                    serie.Points.AddXY(raza.nombre, raza.energia);
                }

                chartRazas.Series.Add(serie);
                await ActualizarGrafico();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar razas: " + ex.Message);
            }

        }


        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Complete los campos obligatorios.");
                return;
            }

            var nueva = ObtenerDatosFormulario();

            try
            {
                var json = JsonConvert.SerializeObject(nueva);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Raza agregada correctamente.");
                    LimpiarFormulario();
                    await CargarRazasDesdeAPI();
                }
                else
                {
                    MessageBox.Show("Error al agregar raza.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar raza: " + ex.Message);
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (razaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una raza para editar.");
                return;
            }

            var editada = ObtenerDatosFormulario();
            editada.id = razaSeleccionada.id;

            try
            {
                var json = JsonConvert.SerializeObject(editada);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{apiUrl}/{editada.id}", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Raza editada correctamente.");
                    LimpiarFormulario();
                    await CargarRazasDesdeAPI();
                }
                else
                {
                    MessageBox.Show("Error al editar raza.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar raza: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (razaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una raza para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de eliminar esta raza?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response = await httpClient.DeleteAsync($"{apiUrl}/{razaSeleccionada.id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Raza eliminada.");
                    LimpiarFormulario();
                    await CargarRazasDesdeAPI();
                }
                else
                {
                    MessageBox.Show("Error al eliminar raza.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar raza: " + ex.Message);
            }
        }

        private async void dgvRazas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRazas.SelectedRows.Count > 0)
            {
                var nombre = dgvRazas.SelectedRows[0].Cells[0].Value.ToString();

                try
                {
                    var response = await httpClient.GetStringAsync(apiUrl);
                    var razas = JsonConvert.DeserializeObject<List<Raza>>(response);
                    razaSeleccionada = razas.Find(r => r.nombre == nombre);

                    if (razaSeleccionada != null)
                    {
                        txtNombre.Text = razaSeleccionada.nombre;
                        numEnergia.Value = razaSeleccionada.energia;
                        numInteligencia.Value = razaSeleccionada.inteligencia;
                        numSocializacion.Value = razaSeleccionada.socializacion;
                        numCuidado.Value = razaSeleccionada.cuidado;
                        numPesoMinMacho.Value = razaSeleccionada.pesoMinMacho;
                        numPesoMaxMacho.Value = razaSeleccionada.pesoMaxMacho;
                        numPesoMinHembra.Value = razaSeleccionada.pesoMinHembra;
                        numPesoMaxHembra.Value = razaSeleccionada.pesoMaxHembra;
                        numEdadMaxima.Value = razaSeleccionada.edadMaxima;
                        txtDescripcion.Text = razaSeleccionada.descripcion;
                        txtDatoCurioso.Text = razaSeleccionada.datoCurioso;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar raza: " + ex.Message);
                }
            }
        }

        private void ConfigurarTabla()
        {
            dgvRazas.Columns.Clear();
            dgvRazas.AutoGenerateColumns = false;
            dgvRazas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRazas.MultiSelect = false;

            dgvRazas.Columns.Add("Nombre", "Nombre");
            dgvRazas.Columns.Add("Energia", "Energía");
            dgvRazas.Columns.Add("Inteligencia", "Inteligencia");
            dgvRazas.Columns.Add("Socializacion", "Socialización");
            dgvRazas.Columns.Add("Cuidado", "Cuidado");

            dgvRazas.Columns["Nombre"].Width = 150;
            dgvRazas.Columns["Energia"].Width = 80;
            dgvRazas.Columns["Inteligencia"].Width = 100;
            dgvRazas.Columns["Socializacion"].Width = 100;
            dgvRazas.Columns["Cuidado"].Width = 80;


        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            numEnergia.Value = 1;
            numInteligencia.Value = 1;
            numSocializacion.Value = 1;
            numCuidado.Value = 1;
            numPesoMinMacho.Value = 1;
            numPesoMaxMacho.Value = 1;
            numPesoMinHembra.Value = 1;
            numPesoMaxHembra.Value = 1;
            numEdadMaxima.Value = 1;
            txtDescripcion.Clear();
            txtDatoCurioso.Clear();
            razaSeleccionada = null;
        }

        private Raza ObtenerDatosFormulario()
        {
            return new Raza
            {
                nombre = txtNombre.Text,
                energia = (byte)numEnergia.Value,
                inteligencia = (byte)numInteligencia.Value,
                socializacion = (byte)numSocializacion.Value,
                cuidado = (byte)numCuidado.Value,
                pesoMinMacho = numPesoMinMacho.Value,
                pesoMaxMacho = numPesoMaxMacho.Value,
                pesoMinHembra = numPesoMinHembra.Value,
                pesoMaxHembra = numPesoMaxHembra.Value,
                edadMaxima = (int)numEdadMaxima.Value,
                descripcion = txtDescripcion.Text,
                datoCurioso = txtDatoCurioso.Text
            };
        }

        private async void cmbAtributoGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            await ActualizarGrafico();
        }

        private async Task ActualizarGrafico()
        {
            try
            {
                var response = await httpClient.GetStringAsync(apiUrl);
                var razas = JsonConvert.DeserializeObject<List<Raza>>(response);

                chartRazas.Series.Clear();
                chartRazas.Titles.Clear();
                chartRazas.ChartAreas.Clear();
                chartRazas.Legends.Clear();
                chartRazas.Width = 500;
                chartRazas.Height = 450;

                string atributo = cmbAtributoGrafico.SelectedItem?.ToString() ?? "Energía";

                // Configurar área del gráfico
                ChartArea chartArea = new ChartArea("AreaPrincipal");
                chartArea.AxisX.Title = "Raza";
                chartArea.AxisY.Title = atributo;
                chartArea.BackColor = System.Drawing.Color.WhiteSmoke;
                chartArea.AxisX.LabelStyle.Angle = -45;
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                chartArea.AxisY.Minimum = 0;
                chartArea.AxisY.Maximum = 5;
                chartArea.AxisY.Interval = 1;
                chartRazas.ChartAreas.Add(chartArea);

                // Título
                Title titulo = new Title($"{atributo} por Raza", Docking.Top, new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), System.Drawing.Color.DarkSlateBlue);
                chartRazas.Titles.Add(titulo);

                // Paleta pastel para las barras (colores cute)
                System.Drawing.Color[] coloresPastel = new System.Drawing.Color[]
                {
            System.Drawing.Color.FromArgb(255, 179, 186), // rosa pastel
            System.Drawing.Color.FromArgb(255, 223, 186), // melocotón
            System.Drawing.Color.FromArgb(186, 255, 201), // verde pastel
            System.Drawing.Color.FromArgb(186, 225, 255), // azul pastel
            System.Drawing.Color.FromArgb(238, 130, 238)  // violeta pastel
                };

                // Crear la serie
                var serie = new Series(atributo)
                {
                    ChartType = SeriesChartType.Column,
                    BorderWidth = 2,
                    IsValueShownAsLabel = true,
                    LabelForeColor = System.Drawing.Color.DarkSlateBlue,
                    Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                };

                // Añadir puntos con color individual y tooltip
                for (int i = 0; i < razas.Count; i++)
                {
                    double valor;
                    if (atributo == "Energía")
                        valor = razas[i].energia;
                    else if (atributo == "Inteligencia")
                        valor = razas[i].inteligencia;
                    else if (atributo == "Socialización")
                        valor = razas[i].socializacion;
                    else if (atributo == "Cuidado")
                        valor = razas[i].cuidado;
                    else
                        valor = razas[i].energia;

                    int index = serie.Points.AddXY(razas[i].nombre, valor);
                    serie.Points[index].Color = coloresPastel[i % coloresPastel.Length];
                    serie.Points[index].ToolTip = $"{razas[i].nombre}: {valor}";
                }

                chartRazas.Series.Add(serie);


                // Leyenda opcional, centrada y estilizada
                chartRazas.Legends.Add(new Legend
                {
                    Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold),
                    ForeColor = System.Drawing.Color.DarkSlateBlue,
                    Docking = Docking.Bottom,
                    Alignment = System.Drawing.StringAlignment.Center,
                    LegendStyle = LegendStyle.Table
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar gráfico: " + ex.Message);
            }
        }

    }
}

