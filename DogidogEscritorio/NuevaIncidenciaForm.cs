using DogidogEscritorio.DataClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DogidogEscritorio


{
    public partial class NuevaIncidenciaForm : Form
    {



        public string Titulo { get; private set; }
        public string Descripcion { get; private set; }
        public string Prioridad { get; private set; }
        public string Estado { get; private set; }
        public Empleado EmpleadoAsignado { get; private set; }

        public int AsignadoAId { get; private set; }

        private async Task CargarEmpleadosAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri("http://localhost:8080/dogidog/");

                var response = await client.GetAsync("empleados");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var empleados = System.Text.Json.JsonSerializer.Deserialize<List<Empleado>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    cmbAsignado.Items.Clear();
                    foreach (var emp in empleados)
                    {
                        cmbAsignado.Items.Add(new ComboBoxItem
                        {
                            Text = emp.usuario.usuario,
                            Value = emp.id
                        });
                    }

                    // Seleccionar el empleado correcto por id, si tienes ese dato
                    if (AsignadoAId != 0)
                    {
                        foreach (ComboBoxItem item in cmbAsignado.Items)
                        {
                            if (item.Value == AsignadoAId)
                            {
                                cmbAsignado.SelectedItem = item;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        public NuevaIncidenciaForm()
        {
            InitializeComponent();

            // Valores por defecto
            Prioridad = "Media";
            Estado = "Abierto";

            // Eventos de prioridad
            btnBaja.Click += (s, e) => SetPrioridad("Baja");
            btnMedia.Click += (s, e) => SetPrioridad("Media");
            btnAlta.Click += (s, e) => SetPrioridad("Alta");

            // Eventos de estado
            btnAbierto.Click += (s, e) => SetEstado("Abierta");
            btnEnProgreso.Click += (s, e) => SetEstado("EnProgreso");
            btnCerrado.Click += (s, e) => SetEstado("Cerrada");

            // Botones guardar y cancelar
            btnGuardar.Click += (s, e) => Guardar();
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Visualización inicial
            SetPrioridad(Prioridad);
            SetEstado(Estado);
        }

        private void SetPrioridad(string prioridad)
        {
            Prioridad = prioridad;
            btnBaja.BackColor = prioridad == "Baja" ? Color.LightBlue : SystemColors.Control;
            btnMedia.BackColor = prioridad == "Media" ? Color.LightBlue : SystemColors.Control;
            btnAlta.BackColor = prioridad == "Alta" ? Color.LightBlue : SystemColors.Control;
        }

        private void SetEstado(string estado)
        {
            Estado = estado;
            btnAbierto.BackColor = estado == "Abierta" ? Color.LightGreen : SystemColors.Control;
            btnEnProgreso.BackColor = estado == "EnProgreso" ? Color.LightGreen : SystemColors.Control;
            btnCerrado.BackColor = estado == "Cerrada" ? Color.LightGreen : SystemColors.Control;
        }
        private async void Guardar()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Titulo = txtTitulo.Text.Trim();
            Descripcion = txtDescripcion.Text.Trim();

            var itemSeleccionado = cmbAsignado.SelectedItem as ComboBoxItem;
            if (itemSeleccionado != null)
            {
                AsignadoAId = (int)itemSeleccionado.Value;
            }
            else
            {
                AsignadoAId = 0; // No se asignó ningún empleado
            }

            bool exito = await CrearTareaAsync();

            if (exito)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async void NuevaIncidenciaForm_Load(object sender, EventArgs e)
        {
            await CargarEmpleadosAsync();
        }

        public async Task<bool> CrearTareaAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var tarea = new
                    {
                        titulo = this.Titulo,
                        descripcion = this.Descripcion,
                        prioridad = this.Prioridad,  // o como espera la API
                        estado = this.Estado,
                        empleado = AsignadoAId != 0 ? new { id = AsignadoAId } : null
                    };

                    string json = System.Text.Json.JsonSerializer.Serialize(tarea);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    string url = "http://localhost:8080/dogidog/tareas";

                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Tarea creada correctamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Error al crear tarea: {(int)response.StatusCode} {response.ReasonPhrase}");
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

    }
}

