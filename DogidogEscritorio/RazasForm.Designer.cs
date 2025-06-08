using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DogiDogEscritorio
{
    partial class RazasForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNombre = new TextBox();
            this.numEnergia = new NumericUpDown();
            this.numInteligencia = new NumericUpDown();
            this.numSocializacion = new NumericUpDown();
            this.numCuidado = new NumericUpDown();
            this.numPesoMinMacho = new NumericUpDown();
            this.numPesoMaxMacho = new NumericUpDown();
            this.numPesoMinHembra = new NumericUpDown();
            this.numPesoMaxHembra = new NumericUpDown();
            this.numEdadMaxima = new NumericUpDown();
            this.txtDescripcion = new TextBox();
            this.txtDatoCurioso = new TextBox();
            this.dgvRazas = new DataGridView();
            this.chartRazas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAgregar = new Button();
            this.btnEditar = new Button();
            this.btnEliminar = new Button();

            this.Size = new System.Drawing.Size(1200, 850);
            this.BackColor = System.Drawing.Color.White;

            string[] labels = {
        "Nombre", "Energía", "Inteligencia", "Socialización", "Cuidado",
        "Peso Min Macho", "Peso Max Macho", "Peso Min Hembra", "Peso Max Hembra", "Edad Máxima"
    };

            Control[] controls = {
        txtNombre, numEnergia, numInteligencia, numSocializacion, numCuidado,
        numPesoMinMacho, numPesoMaxMacho, numPesoMinHembra, numPesoMaxHembra, numEdadMaxima
    };

            for (int i = 0; i < labels.Length / 2; i++)
            {
                var lbl = new Label
                {
                    Text = labels[i],
                    Location = new System.Drawing.Point(30, 30 + i * 40),
                    AutoSize = true,
                    Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                };
                this.Controls.Add(lbl);

                controls[i].Location = new System.Drawing.Point(180, 25 + i * 40);
                controls[i].Size = new System.Drawing.Size(160, 25);
                this.Controls.Add(controls[i]);
            }

            for (int i = labels.Length / 2; i < labels.Length; i++)
            {
                var lbl = new Label
                {
                    Text = labels[i],
                    Location = new System.Drawing.Point(400, 30 + (i - labels.Length / 2) * 40),
                    AutoSize = true,
                    Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                };
                this.Controls.Add(lbl);

                controls[i].Location = new System.Drawing.Point(580, 25 + (i - labels.Length / 2) * 40);
                controls[i].Size = new System.Drawing.Size(160, 25);
                this.Controls.Add(controls[i]);
            }

            // Descripción
            var lblDescripcion = new Label
            {
                Text = "Descripción",
                Location = new System.Drawing.Point(30, 260),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
            };
            this.Controls.Add(lblDescripcion);

            txtDescripcion.Location = new System.Drawing.Point(30, 285);
            txtDescripcion.Size = new System.Drawing.Size(710, 60);
            txtDescripcion.Multiline = true;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            this.Controls.Add(txtDescripcion);

            // Dato curioso
            var lblDatoCurioso = new Label
            {
                Text = "Dato Curioso",
                Location = new System.Drawing.Point(30, 355),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
            };
            this.Controls.Add(lblDatoCurioso);

            txtDatoCurioso.Location = new System.Drawing.Point(30, 380);
            txtDatoCurioso.Size = new System.Drawing.Size(710, 60);
            txtDatoCurioso.Multiline = true;
            txtDatoCurioso.ScrollBars = ScrollBars.Vertical;
            this.Controls.Add(txtDatoCurioso);

            // Botones
            Button[] botones = { btnAgregar, btnEditar, btnEliminar };
            string[] textos = { "Agregar", "Editar", "Eliminar" };

            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].Text = textos[i];
                botones[i].Location = new System.Drawing.Point(30 + i * 120, 460);
                botones[i].Size = new System.Drawing.Size(100, 35);
                botones[i].BackColor = System.Drawing.Color.FromArgb(77, 208, 225); // azulito cute
                botones[i].Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
                this.Controls.Add(botones[i]);
            }

            // DataGridView
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).BeginInit();
            this.dgvRazas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRazas.Location = new System.Drawing.Point(30, 510);
            this.dgvRazas.Size = new System.Drawing.Size(710, 300);
            this.dgvRazas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            this.dgvRazas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRazas.RowHeadersVisible = false;
            this.dgvRazas.AllowUserToAddRows = false;
            this.dgvRazas.AllowUserToResizeRows = false;
            this.dgvRazas.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvRazas.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvRazas.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRazas.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvRazas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(77, 208, 225);
            this.dgvRazas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvRazas.EnableHeadersVisualStyles = false;
            this.Controls.Add(this.dgvRazas);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).EndInit();

            // Chart
            chartRazas.Location = new System.Drawing.Point(770, 30);
            chartRazas.Size = new System.Drawing.Size(400, 350);
            chartRazas.Titles.Add("Razas por nivel de energía");
            this.Controls.Add(chartRazas);

            this.numEnergia.Minimum = 1;
            this.numEnergia.Maximum = 5;

            this.numInteligencia.Minimum = 1;
            this.numInteligencia.Maximum = 5;

            this.numSocializacion.Minimum = 1;
            this.numSocializacion.Maximum = 5;

            this.numCuidado.Minimum = 1;
            this.numCuidado.Maximum = 5;

            // Eventos
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            this.dgvRazas.SelectionChanged += new System.EventHandler(this.dgvRazas_SelectionChanged);

            // ComboBox para elegir atributo de gráfica
            var lblGrafico = new Label
            {
                Text = "Mostrar en gráfica:",
                Location = new System.Drawing.Point(770, 400),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
            };
            this.Controls.Add(lblGrafico);

            cmbAtributoGrafico = new ComboBox
            {
                Location = new System.Drawing.Point(770, 340), // justo debajo del gráfico
            Size = new System.Drawing.Size(200, 30),
            DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                BackColor = System.Drawing.Color.White
            };
            cmbAtributoGrafico.Items.AddRange(new string[] { "Energía", "Inteligencia", "Socialización", "Cuidado" });
            cmbAtributoGrafico.SelectedIndex = 0;
            cmbAtributoGrafico.SelectedIndexChanged += cmbAtributoGrafico_SelectedIndexChanged;
            this.Controls.Add(cmbAtributoGrafico);


            // Configuración visual del gráfico
            chartRazas.ChartAreas.Clear();
            var chartArea = new ChartArea("MainArea");
            chartRazas.ChartAreas.Add(chartArea);

            cmbAtributoGrafico.Location = new System.Drawing.Point(770, 500);
            cmbAtributoGrafico.Size = new System.Drawing.Size(200, 30);

            // Configuración eje X
            chartArea.AxisX.Title = "Razas";
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Configuración eje Y
            chartArea.AxisY.Title = "Nivel";
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 5;
            chartArea.AxisY.Interval = 1;
            chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Limpiar series y agregar una nueva
            chartRazas.Series.Clear();
            var series = new Series("Nivel")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold),
                LabelForeColor = System.Drawing.Color.Black,
            };

            chartRazas.Series.Add(series);

            // Paleta de colores "cute" para barras
            var colors = new System.Drawing.Color[] {
    System.Drawing.Color.FromArgb(77, 208, 225),   // azul claro
    System.Drawing.Color.FromArgb(255, 179, 186), // rosa pastel
    System.Drawing.Color.FromArgb(255, 223, 186), // melocotón
    System.Drawing.Color.FromArgb(186, 255, 201), // verde claro
    System.Drawing.Color.FromArgb(186, 225, 255)  // azul pastel
};

            // Tamaño y posición mejorados para evitar corte
            chartRazas.Location = new System.Drawing.Point(770, 20);
            chartRazas.Size = new System.Drawing.Size(420, 400);

            // Al llenar datos después, asigna estos colores a cada punto para que quede visual:
            for (int i = 0; i < series.Points.Count; i++)
            {
                series.Points[i].Color = colors[i % colors.Length];
                series.Points[i].ToolTip = $"Nivel: {series.Points[i].YValues[0]}";
            }

            // Opcional: añadir leyenda
            chartRazas.Legends.Clear();
            var legend = new Legend()
            {
                Docking = Docking.Top,
                Alignment = StringAlignment.Center,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                LegendStyle = LegendStyle.Row,
            };
            chartRazas.Legends.Add(legend);

        }

        private ComboBox cmbAtributoGrafico;

        private TextBox txtNombre, txtDescripcion, txtDatoCurioso;
        private NumericUpDown numEnergia, numInteligencia, numSocializacion, numCuidado;
        private NumericUpDown numPesoMinMacho, numPesoMaxMacho, numPesoMinHembra, numPesoMaxHembra;
        private NumericUpDown numEdadMaxima;
        private Button btnAgregar, btnEditar, btnEliminar;
        private DataGridView dgvRazas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRazas;

    }
}
