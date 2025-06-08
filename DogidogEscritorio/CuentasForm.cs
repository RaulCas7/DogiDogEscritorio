using DogidogEscritorio.DataClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace DogiDogEscritorio
{

    public partial class CuentasForm : UserControl
    {

        public Usuario usuarioActual { get; set; }
        public CuentasForm()
        {
            InitializeComponent();
            // Configurar columnas del DataGridView una sola vez
            dgvCuentas.Columns.Add("Email", "Email");
            dgvCuentas.Columns.Add("Puesto", "Puesto");
            dgvCuentas.Columns.Add("EsAdmin", "¿Admin?");
            dgvCuentas.Columns.Add("EmpleadoId", "EmpleadoId");
            dgvCuentas.Columns.Add("UsuarioId", "UsuarioId");

            // Ocultar las columnas técnicas
            dgvCuentas.Columns["EmpleadoId"].Visible = false;
            dgvCuentas.Columns["UsuarioId"].Visible = false;

            // (Opcional) Ajustar estilos
            dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCuentas.MultiSelect = false;
            CargarCuentas();
        }

        private async void CargarCuentas()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:8080/dogidog/empleados");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al cargar cuentas.");
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                var empleados = JsonConvert.DeserializeObject<List<dynamic>>(json);

                dgvCuentas.Rows.Clear();
                foreach (var emp in empleados)
                {
                    dgvCuentas.Rows.Add(
                        emp.usuario.email,
                        emp.puesto,
                        Convert.ToBoolean(emp.esAdministrador) ? "Sí" : "No",
                        emp.id,              // EmpleadoId
                        emp.usuario.id       // UsuarioId
                    );
                }
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var form = new AgregarCuentaForm())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Si el formulario devolvió OK, puedes recargar los datos
                    CargarCuentas(); // Este método deberías implementarlo para refrescar el dgvCuentas
                }
            }
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count > 0)
            {
                var fila = dgvCuentas.SelectedRows[0];

                if (fila.Cells["EmpleadoId"].Value == null || fila.Cells["UsuarioId"].Value == null)
                {
                    MessageBox.Show("Los datos de la fila seleccionada no son válidos.");
                    return;
                }

                if (!int.TryParse(fila.Cells["EmpleadoId"].Value.ToString(), out int empleadoId))
                {
                    MessageBox.Show("El ID del empleado no es válido.");
                    return;
                }

                if (!int.TryParse(fila.Cells["UsuarioId"].Value.ToString(), out int usuarioId))
                {
                    MessageBox.Show("El ID del usuario no es válido.");
                    return;
                }

                bool esMismoUsuario = false;
                bool esAdministradorLogueado = false;

                if (Sesion.UsuarioActual != null && Sesion.EmpleadoActual != null)
                {
                    esMismoUsuario = usuarioId == Sesion.UsuarioActual.id;
                    esAdministradorLogueado = Sesion.EmpleadoActual.esAdministrador;
                }
                else
                {
                    MessageBox.Show("No hay un usuario o empleado logueado.");
                    return;
                }

                var editarForm = new EditarEmpleadoForm(empleadoId, usuarioId, esMismoUsuario, esAdministradorLogueado);
                if (editarForm.ShowDialog() == DialogResult.OK)
                {
                    CargarCuentas();
                }
            }
            else
            {
                MessageBox.Show("Selecciona una cuenta para editar.");
            }
        }


        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("¿Deseas eliminar esta cuenta?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        // Obtener el empleadoId y usuarioId de la fila seleccionada
                        var fila = dgvCuentas.SelectedRows[0];

                        // Cambia los nombres de las columnas por las que tengas en tu DataGridView
                        int empleadoId = Convert.ToInt32(fila.Cells["EmpleadoId"].Value);
                        int usuarioId = Convert.ToInt32(fila.Cells["UsuarioId"].Value);

                        using (var client = new HttpClient())
                        {
                            // Primero eliminar empleado
                            var responseEmpleado = await client.DeleteAsync($"http://localhost:8080/dogidog/empleados/{empleadoId}");
                            if (!responseEmpleado.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Error al eliminar el empleado.");
                                return;
                            }

                            // Luego eliminar usuario
                            var responseUsuario = await client.DeleteAsync($"http://localhost:8080/dogidog/usuarios/{usuarioId}");
                            if (!responseUsuario.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Error al eliminar el usuario.");
                                return;
                            }

                            MessageBox.Show("Cuenta eliminada correctamente.");
                            CargarCuentas(); // Refrescar la lista después de eliminar
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la cuenta: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una cuenta para eliminar.");
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void dgvCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

