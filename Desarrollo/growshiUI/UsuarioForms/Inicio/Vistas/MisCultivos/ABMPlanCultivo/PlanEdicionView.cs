using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using MetroFramework;
using MetroFramework.Controls;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo
{
    public partial class PlanEdicionView : UserControl
    {
        #region Propiedades y Servicios

        private readonly PlanCultivoBLL _planBLL;
        private readonly EtapaCultivoBLL _etapaBLL;
        private readonly IdiomaBLL _idiomaBLL;
        private readonly BitacoraBLL _bitacoraBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IBitacoraService _bitacoraService;
        private readonly Usuario _usuarioActual;

        private int _idPlan;

        public event EventHandler OnCancelar;
        public event EventHandler OnGuardar;

        #endregion

        #region Constructor e Inicialización

        public PlanEdicionView()
        {
            InitializeComponent();

            // 1. Instancias
            _planBLL = new PlanCultivoBLL();
            _etapaBLL = new EtapaCultivoBLL();
            _idiomaBLL = new IdiomaBLL();
            _bitacoraBLL = new BitacoraBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _bitacoraService = BitacoraService.GetInstance();

            _usuarioActual = _sessionService.UsuarioLogueado;

            // 2. Eventos UI
            btnCancelar.Click += (s, e) => OnCancelar?.Invoke(this, EventArgs.Empty);
            btnGuardar.Click += btnGuardar_Click;

            // 3. Suscripción a Idioma
            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;

            // Carga inicial de textos
            ActualizarTraducciones();
        }

        #endregion

        #region Gestión de Idioma

        public void ActualizarTraducciones()
        {
            // Títulos y Etiquetas
            lblTitulo.Text = _idiomaBLL.Traducir("PlanEdicion_Lbl_Titulo");
            lblNombrePlan.Text = _idiomaBLL.Traducir("PlanEdicion_Lbl_NombrePlan");
            grpEtapas.Text = _idiomaBLL.Traducir("PlanEdicion_Grp_Configuracion");

            // Botones
            btnGuardar.Text = _idiomaBLL.Traducir("PlanEdicion_Btn_Guardar");
            btnCancelar.Text = _idiomaBLL.Traducir("PlanEdicion_Btn_Cancelar");

            // Encabezados de Grilla
            colEtapa.HeaderText = _idiomaBLL.Traducir("PlanEdicion_Col_Etapa");
            colDuracion.HeaderText = _idiomaBLL.Traducir("PlanEdicion_Col_Duracion");
            colTempMin.HeaderText = _idiomaBLL.Traducir("PlanEdicion_Col_TempMin");
            colTempMax.HeaderText = _idiomaBLL.Traducir("PlanEdicion_Col_TempMax");
            colPhMin.HeaderText = _idiomaBLL.Traducir("PlanEdicion_Col_PhMin");
            colPhMax.HeaderText = _idiomaBLL.Traducir("PlanEdicion_Col_PhMax");

            // --- NUEVO ---
            colHorasLuz.HeaderText = _idiomaBLL.Traducir("PlanEdicion_Col_HorasLuz");
        }

        #endregion

        #region Lógica de Negocio (Carga y Guardado)

        public void CargarDatos(PlanCultivo plan)
        {
            _idPlan = plan.PlanCultivoID;
            txtNombrePlan.Text = plan.NombrePlan;
            CargarEtapas();
        }

        private void CargarEtapas()
        {
            try
            {
                var etapas = _etapaBLL.ListarPorPlan(_idPlan);

                // Evitamos la autogeneración para usar nuestras columnas diseñadas
                gridEtapasEdicion.AutoGenerateColumns = false;
                gridEtapasEdicion.DataSource = null;
                gridEtapasEdicion.DataSource = etapas;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, _idiomaBLL.Traducir("Global_Titulo_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones
            if (string.IsNullOrWhiteSpace(txtNombrePlan.Text))
            {
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("Global_Msg_CamposObligatorios"),
                    _idiomaBLL.Traducir("Global_Titulo_Atencion"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Preparar Objeto
                PlanCultivo planEditado = new PlanCultivo();
                planEditado.PlanCultivoID = _idPlan;
                planEditado.NombrePlan = txtNombrePlan.Text;

                // Forzamos commit en la grilla para asegurar que tome el último valor editado
                gridEtapasEdicion.EndEdit();

                // Recuperamos la lista (Binding directo)
                if (gridEtapasEdicion.DataSource is List<EtapaCultivo> etapasModificadas)
                {
                    planEditado.Etapas = etapasModificadas;
                }
                else
                {
                    // Fallback de seguridad
                    planEditado.Etapas = new List<EtapaCultivo>();
                }

                // 3. Guardar en BD
                _planBLL.ModificarPlan(planEditado);

                // 4. Bitácora (Importante: Modificar un plan es crítico)
                IBitacora evento = _bitacoraService.CrearEvento(
                    NivelCriticidad.Advertencia, // Advertencia porque altera parámetros
                    $"Plan Modificado: {planEditado.NombrePlan} (ID: {_idPlan})",
                    "Gestión Cultivos",
                    _usuarioActual.IdUsuario
                );

                var bitacora = new Bitacora
                {
                    FechaHora = evento.FechaHora,
                    Nivel = evento.Nivel,
                    Mensaje = evento.Mensaje,
                    Modulo = evento.Modulo,
                    UsuarioID = evento.UsuarioID
                };

                _bitacoraBLL.Registrar(bitacora);

                // 5. Feedback
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("PlanEdicion_Msg_Exito"),
                    _idiomaBLL.Traducir("Global_Titulo_Exito"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnGuardar?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, _idiomaBLL.Traducir("Global_Titulo_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}