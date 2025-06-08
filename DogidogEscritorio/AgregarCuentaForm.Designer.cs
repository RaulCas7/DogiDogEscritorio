namespace DogiDogEscritorio
{
    partial class AgregarCuentaForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPuesto;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.Button btnGuardar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "✨ Nueva Cuenta de Empleado";
            this.Size = new System.Drawing.Size(520, 650);
            this.MinimumSize = new System.Drawing.Size(520, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // Título centrado arriba
            System.Windows.Forms.Label lblTitulo = new System.Windows.Forms.Label();
            lblTitulo.Text = "🐶 Crear Nueva Cuenta";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.MediumOrchid;
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitulo.Height = 70;
            lblTitulo.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0); // Más espacio arriba
            this.Controls.Add(lblTitulo);

            // Panel con scroll para campos
            System.Windows.Forms.FlowLayoutPanel panel = new System.Windows.Forms.FlowLayoutPanel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            panel.WrapContents = false;
            panel.Padding = new System.Windows.Forms.Padding(30, 70, 30, 20); // Padding arriba aumentado
            panel.AutoScroll = true;
            panel.BackColor = System.Drawing.Color.White;
            this.Controls.Add(panel);

            // Campos con buen espacio
            panel.Controls.Add(CrearCampo("👤 Usuario", out txtUsuario));
            panel.Controls.Add(CrearCampo("📧 Email", out txtEmail));
            panel.Controls.Add(CrearCampo("🔒 Contraseña", out txtPassword, true));
            panel.Controls.Add(CrearCampo("💼 Puesto", out txtPuesto));
            panel.Controls.Add(CrearCampo("📅 Fecha Contratación", out dtpFecha));
            panel.Controls.Add(CrearCheckbox("Administrador", out chkAdmin));

            // Botón grande y con espacio
            btnGuardar = new System.Windows.Forms.Button();
            btnGuardar.Text = "✅ Crear Cuenta";
            btnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            btnGuardar.Width = 250;
            btnGuardar.Height = 45;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Margin = new System.Windows.Forms.Padding(0, 30, 0, 10);
            btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            panel.Controls.Add(btnGuardar);
        }

        private System.Windows.Forms.Panel CrearCampo(string label, out System.Windows.Forms.TextBox textbox, bool isPassword = false)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel() { Width = 450, Height = 75 };
            System.Windows.Forms.Label l = new System.Windows.Forms.Label()
            {
                Text = label,
                Width = 450,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.MediumOrchid
            };
            textbox = new System.Windows.Forms.TextBox()
            {
                Width = 420,
                UseSystemPasswordChar = isPassword,
                Font = new System.Drawing.Font("Segoe UI", 11),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.White
            };
            p.Controls.Add(l);
            p.Controls.Add(textbox);
            l.Top = 15;       // Bajado un poco el label
            textbox.Top = 45; // Bajado un poco el textbox
            return p;
        }

        private System.Windows.Forms.Panel CrearCampo(string label, out System.Windows.Forms.DateTimePicker picker)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel() { Width = 450, Height = 75 };
            System.Windows.Forms.Label l = new System.Windows.Forms.Label()
            {
                Text = label,
                Width = 450,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.MediumOrchid
            };
            picker = new System.Windows.Forms.DateTimePicker()
            {
                Width = 420,
                Format = System.Windows.Forms.DateTimePickerFormat.Short,
                Font = new System.Drawing.Font("Segoe UI", 11),
                CalendarForeColor = System.Drawing.Color.MediumOrchid,
                CalendarTitleBackColor = System.Drawing.Color.MediumOrchid,
                CalendarTitleForeColor = System.Drawing.Color.White
            };
            p.Controls.Add(l);
            p.Controls.Add(picker);
            l.Top = 15;       // Bajado un poco el label
            picker.Top = 45;  // Bajado un poco el picker
            return p;
        }

        private System.Windows.Forms.Panel CrearCheckbox(string label, out System.Windows.Forms.CheckBox chk)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel() { Width = 450, Height = 40 };
            chk = new System.Windows.Forms.CheckBox()
            {
                Text = label,
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.MediumOrchid,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            p.Controls.Add(chk);
            chk.Top = 8;
            chk.Left = 3;
            return p;
        }
    }
}

