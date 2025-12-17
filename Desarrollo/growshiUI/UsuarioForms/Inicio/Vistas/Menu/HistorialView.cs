using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL;
using Interfaces.IBE;
using Services; // Para IdiomaService
using MetroFramework;
using MetroFramework.Controls;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class HistorialView : UserControl
    {
        #region Propiedades y Servicios

        private readonly BitacoraBLL _bitacoraBLL;
        private readonly IdiomaBLL _idiomaBLL;
        private List<Bitacora> _listaCompleta;

        #endregion

        #region Constructor e Inicialización

        public HistorialView()
        {
            InitializeComponent();

            // 1. Instancias
            _bitacoraBLL = new BitacoraBLL();
            _idiomaBLL = new IdiomaBLL();

            // 2. Suscripciones
            this.Load += HistorialView_Load;
            this.Resize += HistorialView_Resize;

            // Suscripción a cambio de idioma
            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;

            // Eventos de Filtros
            txtBuscar.TextChanged += Filtros_Changed;
            cmbNivel.SelectedIndexChanged += Filtros_Changed;
            dtpDesde.ValueChanged += Filtros_Changed;
            dtpHasta.ValueChanged += Filtros_Changed;
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private void HistorialView_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            CargarCombos();
            ResetearFiltros();
            CargarDatos();
        }

        #endregion

        #region Gestión de Idioma

        public void ActualizarTraducciones()
        {
            // Títulos y Etiquetas
            lblTitulo.Text = _idiomaBLL.Traducir("Historial_Lbl_TituloPrincipal");
            lblDesde.Text = _idiomaBLL.Traducir("Historial_Lbl_Desde");
            lblHasta.Text = _idiomaBLL.Traducir("Historial_Lbl_Hasta");

            // Botones y Placeholders
            btnLimpiar.Text = _idiomaBLL.Traducir("Historial_Btn_Limpiar");
            txtBuscar.PromptText = _idiomaBLL.Traducir("Historial_Txt_BuscarPlaceholder");
            cmbNivel.PromptText = _idiomaBLL.Traducir("Historial_Cmb_NivelPlaceholder");

            // Recargar combos para traducir "Todos"
            CargarCombos();
        }

        #endregion

        #region Lógica de Datos y Filtros

        private void CargarCombos()
        {
            // Guardamos la selección actual para restaurarla después de recargar
            int index = cmbNivel.SelectedIndex;

            cmbNivel.Items.Clear();
            cmbNivel.Items.Add(_idiomaBLL.Traducir("Historial_Cmb_Todos")); // "Todos" traducido

            foreach (var item in Enum.GetValues(typeof(NivelCriticidad)))
            {
                cmbNivel.Items.Add(item);
            }

            // Restaurar selección o default
            if (index >= 0 && index < cmbNivel.Items.Count)
                cmbNivel.SelectedIndex = index;
            else
                cmbNivel.SelectedIndex = 0;
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
                MetroMessageBox.Show(this,
                    string.Format(_idiomaBLL.Traducir("Historial_Msg_ErrorCarga"), ex.Message),
                    _idiomaBLL.Traducir("Global_Titulo_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            if (_listaCompleta == null) return;

            var consulta = _listaCompleta.AsEnumerable();

            // Filtro Texto
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                string txt = txtBuscar.Text.ToLower();
                consulta = consulta.Where(x =>
                    (x.Mensaje != null && x.Mensaje.ToLower().Contains(txt)) ||
                    (x.Modulo != null && x.Modulo.ToLower().Contains(txt)));
            }

            // Filtro Nivel (Index 0 es "Todos")
            if (cmbNivel.SelectedIndex > 0)
            {
                var nivelSel = (NivelCriticidad)cmbNivel.SelectedItem;
                consulta = consulta.Where(x => x.Nivel == nivelSel);
            }

            // Filtro Fechas
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1); // Fin del día
            consulta = consulta.Where(x => x.FechaHora >= desde && x.FechaHora <= hasta);

            var resultado = consulta.OrderByDescending(x => x.FechaHora).ToList();
            DibujarLista(resultado);
        }

        private void DibujarLista(List<Bitacora> lista)
        {
            flowLista.SuspendLayout();
            flowLista.Controls.Clear();

            // Límite visual para rendimiento
            var listaVisible = lista.Take(100).ToList();

            if (listaVisible.Count == 0)
            {
                MetroLabel lblEmpty = new MetroLabel();
                lblEmpty.Text = _idiomaBLL.Traducir("Historial_Lbl_SinResultados");
                lblEmpty.AutoSize = true;
                lblEmpty.UseCustomBackColor = true;
                flowLista.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var item in listaVisible)
                {
                    var card = new BitacoraItemView(item);
                    // Ajuste responsive
                    card.Width = flowLista.ClientSize.Width - 25;
                    flowLista.Controls.Add(card);
                }
            }

            flowLista.ResumeLayout();
        }

        private void ResetearFiltros()
        {
            txtBuscar.Text = "";
            cmbNivel.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
        }

        #endregion

        #region Eventos UI

        private void Filtros_Changed(object sender, EventArgs e)
        {
            if (_listaCompleta != null) AplicarFiltros();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            ResetearFiltros();
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

        #endregion
    }
}