using BE;
using BLL;
using Interfaces.IBE;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class HistorialView : UserControl
    {
        private BitacoraBLL _bitacoraBLL;
        private List<Bitacora> _listaCompleta;

        public HistorialView()
        {
            InitializeComponent();
            _bitacoraBLL = new BitacoraBLL();

            this.Load += HistorialView_Load;
            this.Resize += HistorialView_Resize;

            // Eventos
            txtBuscar.TextChanged += Filtros_Changed;
            cmbNivel.SelectedIndexChanged += Filtros_Changed;
            dtpDesde.ValueChanged += Filtros_Changed;
            dtpHasta.ValueChanged += Filtros_Changed;
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private void HistorialView_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ResetearFiltros();
            CargarDatos();
        }

        private void CargarCombos()
        {
            cmbNivel.Items.Clear();
            cmbNivel.Items.Add("Todos");
            foreach (var item in Enum.GetValues(typeof(NivelCriticidad)))
            {
                cmbNivel.Items.Add(item);
            }
            cmbNivel.SelectedIndex = 0;
        }

        private void ResetearFiltros()
        {
            txtBuscar.Text = "";
            cmbNivel.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
        }

        public void CargarDatos()
        {
            try
            {
                _listaCompleta = _bitacoraBLL.Listar();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Error: " + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtros_Changed(object sender, EventArgs e)
        {
            if (_listaCompleta != null) AplicarFiltros();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            ResetearFiltros();
        }

        private void AplicarFiltros()
        {
            var consulta = _listaCompleta.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                string txt = txtBuscar.Text.ToLower();
                consulta = consulta.Where(x =>
                    (x.Mensaje != null && x.Mensaje.ToLower().Contains(txt)) ||
                    (x.Modulo != null && x.Modulo.ToLower().Contains(txt)));
            }

            if (cmbNivel.SelectedIndex > 0)
            {
                var nivelSel = (NivelCriticidad)cmbNivel.SelectedItem;
                consulta = consulta.Where(x => x.Nivel == nivelSel);
            }

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);
            consulta = consulta.Where(x => x.FechaHora >= desde && x.FechaHora <= hasta);

            var resultado = consulta.OrderByDescending(x => x.FechaHora).ToList();
            DibujarLista(resultado);
        }

        private void DibujarLista(List<Bitacora> lista)
        {
            flowLista.SuspendLayout();
            flowLista.Controls.Clear();

            var listaVisible = lista.Take(100).ToList(); // Paginación virtual

            if (listaVisible.Count == 0)
            {
                // Mostrar un Label Metro de "Sin resultados"
                MetroFramework.Controls.MetroLabel lblEmpty = new MetroFramework.Controls.MetroLabel();
                lblEmpty.Text = "No se encontraron eventos con los filtros actuales.";
                lblEmpty.AutoSize = true;
                lblEmpty.UseCustomBackColor = true;
                flowLista.Controls.Add(lblEmpty);
            }

            foreach (var item in listaVisible)
            {
                var card = new BitacoraItemView(item);
                // Ajustamos el ancho restando el scrollbar (aprox 25px)
                card.Width = flowLista.ClientSize.Width - 25;
                flowLista.Controls.Add(card);
            }

            flowLista.ResumeLayout();
        }

        private void HistorialView_Resize(object sender, EventArgs e)
        {
            flowLista.SuspendLayout();
            foreach (Control c in flowLista.Controls)
            {
                c.Width = flowLista.ClientSize.Width - 25;
            }
            flowLista.ResumeLayout();
        }
    }
}