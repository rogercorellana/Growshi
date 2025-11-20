using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class HistorialView : UserControl
    {
        private BitacoraBLL _bitacoraBLL;

        public HistorialView()
        {
            InitializeComponent();
            _bitacoraBLL = new BitacoraBLL();

            this.Load += HistorialView_Load;

            this.Resize += HistorialView_Resize;
        }

        private void HistorialView_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        public void CargarHistorial()
        {
            panelLista.Controls.Clear();

            try
            {
                List<Bitacora> listaLogs = _bitacoraBLL.Listar();

                if (listaLogs.Count == 0)
                {
                    Label lblVacio = new Label();
                    lblVacio.Text = "No se encontraron registros en la bitácora.";
                    lblVacio.AutoSize = true;
                    lblVacio.ForeColor = System.Drawing.Color.Gray;
                    lblVacio.Font = new System.Drawing.Font("Segoe UI", 10);
                    panelLista.Controls.Add(lblVacio);
                    return;
                }

                panelLista.SuspendLayout();

                foreach (var log in listaLogs)
                {
                    BitacoraItemView tarjeta = new BitacoraItemView(log);

                    tarjeta.Width = panelLista.ClientSize.Width - 25;
                    tarjeta.Margin = new Padding(0, 0, 0, 5); 

                    panelLista.Controls.Add(tarjeta);
                }

                panelLista.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message);
            }
        }

        private void HistorialView_Resize(object sender, EventArgs e)
        {
            if (panelLista.Controls.Count > 0)
            {
                panelLista.SuspendLayout();
                foreach (Control c in panelLista.Controls)
                {
                    c.Width = panelLista.ClientSize.Width - 25;
                }
                panelLista.ResumeLayout();
            }
        }
    }
}