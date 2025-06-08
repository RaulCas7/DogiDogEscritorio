using DogidogEscritorio.DataClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DogidogEscritorio
{
    public partial class EditarIncidenciaForm : Form
    {


        // Propiedades públicas para leer al cerrar el formulario
        public string EstadoSeleccionado { get; private set; }
        public string PrioridadSeleccionada { get; private set; }
        public string AsignadoA { get; private set; }

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
                    var empleados = JsonSerializer.Deserialize<List<Empleado>>(json, new JsonSerializerOptions
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


        public EditarIncidenciaForm(Tarea tarea)
        {
            InitializeComponent();

            CargarEmpleadosAsync();


            // Inicializar valores con la tarea recibida (usar null checks por si acaso)
            AsignadoA = tarea?.Empleado?.usuario?.usuario ?? "";
            EstadoSeleccionado = tarea?.Estado.ToString() ?? "Abierto";
            PrioridadSeleccionada = tarea?.Prioridad.ToString() ?? "Media";

            // Mostrar en controles
            SetEstadoBoton(EstadoSeleccionado);
            SetPrioridadBoton(PrioridadSeleccionada);

            // Asociar eventos (si no lo hiciste en el diseñador)
            btnAbierto.Click += (s, e) => SetEstadoBoton("Abierto");
            btnEnProgreso.Click += (s, e) => SetEstadoBoton("En progreso");
            btnCerrado.Click += (s, e) => SetEstadoBoton("Cerrado");

            btnBaja.Click += (s, e) => SetPrioridadBoton("Baja");
            btnMedia.Click += (s, e) => SetPrioridadBoton("Media");
            btnAlta.Click += (s, e) => SetPrioridadBoton("Alta");

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void SetEstadoBoton(string estado)
        {
            EstadoSeleccionado = estado;

            btnAbierto.BackColor = estado == "Abierto" ? Color.LightBlue : SystemColors.Control;
            btnEnProgreso.BackColor = estado == "En progreso" ? Color.LightBlue : SystemColors.Control;
            btnCerrado.BackColor = estado == "Cerrado" ? Color.LightBlue : SystemColors.Control;
        }

        private void SetPrioridadBoton(string prioridad)
        {
            PrioridadSeleccionada = prioridad;

            btnBaja.BackColor = prioridad == "Baja" ? Color.LightGreen : SystemColors.Control;
            btnMedia.BackColor = prioridad == "Media" ? Color.Khaki : SystemColors.Control;
            btnAlta.BackColor = prioridad == "Alta" ? Color.LightCoral : SystemColors.Control;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var seleccionado = cmbAsignado.SelectedItem as ComboBoxItem;
            if (seleccionado == null)
            {
                MessageBox.Show("Debe asignar un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AsignadoAId = seleccionado.Value;
            AsignadoA = seleccionado.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Actualiza la tarea recibida con los valores editados y la devuelve
        /// </summary>
        public Tarea GetTareaActualizada(Tarea tareaOriginal)
        {
            tareaOriginal.Estado = ParseEstado(EstadoSeleccionado);
            tareaOriginal.Prioridad = ParsePrioridad(PrioridadSeleccionada);

            if (tareaOriginal.Empleado == null)
                tareaOriginal.Empleado = new Empleado();

            // Aquí asignamos el ID real
            tareaOriginal.Empleado.id = AsignadoAId;

            // Puedes asignar también el nombre si quieres (pero lo esencial es el id)
            if (tareaOriginal.Empleado.usuario == null)
                tareaOriginal.Empleado.usuario = new Usuario();

            tareaOriginal.Empleado.usuario.usuario = AsignadoA;

            return tareaOriginal;
        }

        private Estado ParseEstado(string estado)
        {
            estado = estado.ToLower();

            if (estado == "abierta")
                return Estado.Abierta;
            else if (estado == "en progreso")
                return Estado.EnProgreso;
            else if (estado == "cerrada")
                return Estado.Cerrada;
            else
                return Estado.Abierta;
        }

        private Prioridad ParsePrioridad(string prioridad)
        {
    prioridad = prioridad.ToLower();

    if (prioridad == "baja")
        return Prioridad.Baja;
    else if (prioridad == "media")
        return Prioridad.Media;
    else if (prioridad == "alta")
        return Prioridad.Alta;
    else
        return Prioridad.Media;
        }

        private void cmbAsignado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

public class ComboBoxItem
{
    public string Text { get; set; }
    public int Value { get; set; }
    public override string ToString() => Text;
}
