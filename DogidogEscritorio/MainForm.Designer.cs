using System;
using System.Drawing;
using System.Windows.Forms;

namespace DogiDogEscritorio
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button btnIncidencias;
        private System.Windows.Forms.Button btnDogiBot;
        private System.Windows.Forms.Button btnNotificaciones;
        private System.Windows.Forms.Button btnRazas;
        private System.Windows.Forms.Button btnValoraciones;
        private System.Windows.Forms.Button btnAdministrarCuentas;
        private System.Windows.Forms.Panel contentPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdministrarCuentas = new System.Windows.Forms.Button();
            this.btnValoraciones = new System.Windows.Forms.Button();
            this.btnRazas = new System.Windows.Forms.Button();
            this.btnNotificaciones = new System.Windows.Forms.Button();
            this.btnDogiBot = new System.Windows.Forms.Button();
            this.btnIncidencias = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(208)))), ((int)(((byte)(225)))));
            this.sidebarPanel.Controls.Add(this.pictureBox1);
            this.sidebarPanel.Controls.Add(this.btnAdministrarCuentas);
            this.sidebarPanel.Controls.Add(this.btnValoraciones);
            this.sidebarPanel.Controls.Add(this.btnRazas);
            this.sidebarPanel.Controls.Add(this.btnNotificaciones);
            this.sidebarPanel.Controls.Add(this.btnDogiBot);
            this.sidebarPanel.Controls.Add(this.btnIncidencias);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(183, 703);
            this.sidebarPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DogidogEscritorio.Properties.Resources.bordercollie;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnAdministrarCuentas
            // 
            this.btnAdministrarCuentas.FlatAppearance.BorderSize = 0;
            this.btnAdministrarCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrarCuentas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdministrarCuentas.ForeColor = System.Drawing.Color.White;
            this.btnAdministrarCuentas.Location = new System.Drawing.Point(0, 390);
            this.btnAdministrarCuentas.Name = "btnAdministrarCuentas";
            this.btnAdministrarCuentas.Size = new System.Drawing.Size(183, 43);
            this.btnAdministrarCuentas.TabIndex = 5;
            this.btnAdministrarCuentas.Text = "👤 Cuentas";
            this.btnAdministrarCuentas.UseVisualStyleBackColor = true;
            this.btnAdministrarCuentas.Click += new System.EventHandler(this.btnAdministrarCuentas_Click);
            // 
            // btnValoraciones
            // 
            this.btnValoraciones.FlatAppearance.BorderSize = 0;
            this.btnValoraciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValoraciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnValoraciones.ForeColor = System.Drawing.Color.White;
            this.btnValoraciones.Location = new System.Drawing.Point(0, 341);
            this.btnValoraciones.Name = "btnValoraciones";
            this.btnValoraciones.Size = new System.Drawing.Size(183, 43);
            this.btnValoraciones.TabIndex = 4;
            this.btnValoraciones.Text = "⭐ Valoraciones";
            this.btnValoraciones.UseVisualStyleBackColor = true;
            this.btnValoraciones.Click += new System.EventHandler(this.btnValoraciones_Click);
            // 
            // btnRazas
            // 
            this.btnRazas.FlatAppearance.BorderSize = 0;
            this.btnRazas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRazas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRazas.ForeColor = System.Drawing.Color.White;
            this.btnRazas.Location = new System.Drawing.Point(0, 288);
            this.btnRazas.Name = "btnRazas";
            this.btnRazas.Size = new System.Drawing.Size(183, 43);
            this.btnRazas.TabIndex = 3;
            this.btnRazas.Text = "🐕 Razas";
            this.btnRazas.UseVisualStyleBackColor = true;
            this.btnRazas.Click += new System.EventHandler(this.btnRazas_Click);
            // 
            // btnNotificaciones
            // 
            this.btnNotificaciones.FlatAppearance.BorderSize = 0;
            this.btnNotificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotificaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNotificaciones.ForeColor = System.Drawing.Color.White;
            this.btnNotificaciones.Location = new System.Drawing.Point(0, 235);
            this.btnNotificaciones.Name = "btnNotificaciones";
            this.btnNotificaciones.Size = new System.Drawing.Size(183, 43);
            this.btnNotificaciones.TabIndex = 2;
            this.btnNotificaciones.Text = "🔔 Notificaciones";
            this.btnNotificaciones.UseVisualStyleBackColor = true;
            this.btnNotificaciones.Click += new System.EventHandler(this.btnNotificaciones_Click);
            // 
            // btnDogiBot
            // 
            this.btnDogiBot.FlatAppearance.BorderSize = 0;
            this.btnDogiBot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDogiBot.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDogiBot.ForeColor = System.Drawing.Color.White;
            this.btnDogiBot.Location = new System.Drawing.Point(0, 181);
            this.btnDogiBot.Name = "btnDogiBot";
            this.btnDogiBot.Size = new System.Drawing.Size(183, 43);
            this.btnDogiBot.TabIndex = 1;
            this.btnDogiBot.Text = "🤖 DogiBot";
            this.btnDogiBot.UseVisualStyleBackColor = true;
            this.btnDogiBot.Click += new System.EventHandler(this.btnDogiBot_Click);
            // 
            // btnIncidencias
            // 
            this.btnIncidencias.FlatAppearance.BorderSize = 0;
            this.btnIncidencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncidencias.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIncidencias.ForeColor = System.Drawing.Color.White;
            this.btnIncidencias.Location = new System.Drawing.Point(0, 128);
            this.btnIncidencias.Name = "btnIncidencias";
            this.btnIncidencias.Size = new System.Drawing.Size(183, 43);
            this.btnIncidencias.TabIndex = 0;
            this.btnIncidencias.Text = "⚠️ Incidencias";
            this.btnIncidencias.UseVisualStyleBackColor = true;
            this.btnIncidencias.Click += new System.EventHandler(this.btnIncidencias_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(183, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1099, 703);
            this.contentPanel.TabIndex = 1;
            this.contentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.contentPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1282, 703);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DogiDog Escritorio";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sidebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private PictureBox pictureBox1;
    }
}
