using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DogiDogEscritorio
{
    public partial class DogiBotForm
    {
        private Label lblTitulo;
        private Label lblPregunta;
        private Label lblRespuesta;
        private TextBox txtPregunta;
        private TextBox txtRespuesta;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnToggleModo;
        private DataGridView dgvDialogos;

        private async void AnimateButton(Button boton)
        {
            Color original = boton.BackColor;
            for (int i = 0; i < 2; i++)
            {
                boton.BackColor = ControlPaint.Light(original);
                await Task.Delay(100);
                boton.BackColor = original;
                await Task.Delay(100);
            }
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.lblPregunta = new Label();
            this.lblRespuesta = new Label();
            this.txtPregunta = new TextBox();
            this.txtRespuesta = new TextBox();
            this.btnAgregar = new Button();
            this.btnEditar = new Button();
            this.btnEliminar = new Button();
            this.btnToggleModo = new Button();
            this.dgvDialogos = new DataGridView();

            DataGridViewTextBoxColumn colPregunta = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colRespuesta = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDialogos)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Text = "💬 Gestor de Frases de DogiBot";
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(77, 208, 225);
            this.lblTitulo.Location = new Point(20, 20);
            this.lblTitulo.AutoSize = true;

            // lblPregunta
            this.lblPregunta.Text = "🐶 Pregunta";
            this.lblPregunta.Location = new Point(20, 65);
            this.lblPregunta.Font = new Font("Segoe UI", 10F);
            this.lblPregunta.ForeColor = Color.FromArgb(70, 70, 70);

            // txtPregunta
            this.txtPregunta.Location = new Point(20, 85);
            this.txtPregunta.Width = 300;

            // lblRespuesta
            this.lblRespuesta.Text = "💡 Respuesta";
            this.lblRespuesta.Location = new Point(340, 65);
            this.lblRespuesta.Font = new Font("Segoe UI", 10F);
            this.lblRespuesta.ForeColor = Color.FromArgb(70, 70, 70);

            // txtRespuesta
            this.txtRespuesta.Location = new Point(340, 85);
            this.txtRespuesta.Width = 300;

            int botonTop = 130;
            int botonWidth = 120;
            Size botonSize = new Size(botonWidth, 30);

            // btnAgregar
            this.btnAgregar.Text = "➕ Agregar";
            this.btnAgregar.Location = new Point(20, botonTop);
            this.btnAgregar.Size = botonSize;
            this.EstilarBoton(this.btnAgregar, Color.FromArgb(77, 208, 225));
            this.btnAgregar.Click += async (s, e) => { AnimateButton(this.btnAgregar); btnAgregar_Click(s, e); };

            // btnEditar
            this.btnEditar.Text = "✏️ Editar";
            this.btnEditar.Location = new Point(160, botonTop);
            this.btnEditar.Size = botonSize;
            this.EstilarBoton(this.btnEditar, Color.LightSkyBlue);
            this.btnEditar.Enabled = false;
            this.btnEditar.Click += async (s, e) => { AnimateButton(this.btnEditar); btnEditar_Click(s, e); };

            // btnEliminar
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.Location = new Point(300, botonTop);
            this.btnEliminar.Size = botonSize;
            this.EstilarBoton(this.btnEliminar, Color.LightCoral);
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Click += async (s, e) => { AnimateButton(this.btnEliminar); btnEliminar_Click(s, e); };

            // btnToggleModo
            this.btnToggleModo.Text = "🔄 Cambiar Modo";
            this.btnToggleModo.Location = new Point(440, botonTop);
            this.btnToggleModo.Size = new Size(botonWidth + 20, 30);
            this.EstilarBoton(this.btnToggleModo, Color.MediumPurple);
            this.btnToggleModo.Click += async (s, e) => { AnimateButton(this.btnToggleModo); btnToggleModo_Click(s, e); };

            // dgvDialogos
            this.dgvDialogos.Location = new Point(20, botonTop + 50);
            this.dgvDialogos.Size = new Size(740, 260);
            this.dgvDialogos.AllowUserToAddRows = false;
            this.dgvDialogos.AllowUserToDeleteRows = true;
            this.dgvDialogos.ReadOnly = true;
            this.dgvDialogos.BackgroundColor = Color.White;
            this.dgvDialogos.BorderStyle = BorderStyle.Fixed3D;
            this.dgvDialogos.MultiSelect = false;
            this.dgvDialogos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            colPregunta.HeaderText = "Pregunta";
            colPregunta.Width = 350;

            colRespuesta.HeaderText = "Respuesta";
            colRespuesta.Width = 350;

            this.dgvDialogos.Columns.Add(colPregunta);
            this.dgvDialogos.Columns.Add(colRespuesta);

            // DogiBotForm
            this.ClientSize = new Size(800, 550);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblPregunta);
            this.Controls.Add(this.txtPregunta);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnToggleModo);
            this.Controls.Add(this.dgvDialogos);
            this.Name = "DogiBotForm";
            this.Text = "🐾 DogiBot - Editor de Respuestas";
            this.Load += new System.EventHandler(this.DogiBotForm_LoadAsync);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDialogos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void EstilarBoton(Button boton, Color colorFondo)
        {
            boton.BackColor = colorFondo;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;
        }
    }
}
