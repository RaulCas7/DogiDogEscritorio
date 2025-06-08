
using System;
using System.Windows.Forms;

using System;
using System.Windows.Forms;

namespace DogiDogEscritorio
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadSection(new IncidenciasForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Lógica al cargar el form, si hace falta
        }

        private void btnIncidencias_Click(object sender, EventArgs e)
        {
            LoadSection(new IncidenciasForm());
        }

        private void btnDogiBot_Click(object sender, EventArgs e)
        {
            LoadSection(new DogiBotForm());
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            LoadSection(new NotificacionesForm());
        }

        private void btnRazas_Click(object sender, EventArgs e)
        {
            LoadSection(new RazasForm());
        }

        private void btnValoraciones_Click(object sender, EventArgs e)
        {
            LoadSection(new ValoracionesForm());
        }


        private void btnAdministrarCuentas_Click(object sender, EventArgs e)
        {
           LoadSection(new CuentasForm());
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {
            // Puedes eliminar si no usas este evento
        }

        private void LoadSection(Control control)
        {
            contentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

