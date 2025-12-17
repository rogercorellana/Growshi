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
using growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo;
using growshiUI.Reportes;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class PlanesDeCultivoView : UserControl
    {
        #region Propiedades y Servicios

        private readonly PlanCultivoBLL _planCultivoBLL;
        private readonly EtapaCultivoBLL _etapaCultivoBLL;
        private readonly IdiomaBLL _idiomaBLL;
        private readonly BitacoraBLL _bitacoraBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IBitacoraService _bitacoraService;
        private readonly Usuario _usuarioActual;

        // Evento para comunicar con el formulario principal si es necesario
        public event Action<PlanCultivo> OnSolicitarEdicion;

        // Variables para textos dinámicos (Ficha técnica)
        private string _fmtTemperatura = "Temperatura: {0}°C - {1}°C";
        private string _fmtHumedad = "Humedad: {0}% - {1}%";
        private string _fmtPh = "pH: {0} - {1}";
        private string _fmtLuz = "Horas Luz: {0}";
        private string _txtSeleccioneEtapa = "Seleccione una etapa...";

        #endregion

        #region Constructor e Inicialización

        public PlanesDeCultivoView()
        {
            InitializeComponent();

            // 1. Instancias
            _planCultivoBLL = new PlanCultivoBLL();
            _etapaCultivoBLL = new EtapaCultivoBLL();
            _idiomaBLL = new IdiomaBLL();
            _bitacoraBLL = new BitacoraBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _bitacoraService = BitacoraService.GetInstance();

            _usuarioActual = _sessionService.UsuarioLogueado;

            // 2. Suscripciones
            this.Load += PlanesDeCultivoView_Load;
            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;
        }

        private void PlanesDeCultivoView_Load(object sender, EventArgs e)
        {
            ConfigurarGrillas();
            ActualizarTraducciones();
            CargarPlanes();

            // Eventos de grilla
            gridPlanes.SelectionChanged += GridPlanes_SelectionChanged;
            gridEtapas.SelectionChanged += GridEtapas_SelectionChanged;
        }

        #endregion

        #region Gestión de Idioma

        public void ActualizarTraducciones()
        {
            // Títulos
            lblTituloPlanes.Text = _idiomaBLL.Traducir("Planes_Lbl_TituloPrincipal");
            lblTituloDetalle.Text = _idiomaBLL.Traducir("Planes_Lbl_TituloDetalle");
            lblTituloFicha.Text = _idiomaBLL.Traducir("Planes_Lbl_TituloFicha");

            // Botones
            btnNuevo.Text = _idiomaBLL.Traducir("Planes_Btn_Nuevo");
            btnEditar.Text = _idiomaBLL.Traducir("Planes_Btn_Editar");
            btnExportar.Text = _idiomaBLL.Traducir("Planes_Btn_Exportar");
            btnEliminar.Text = _idiomaBLL.Traducir("Planes_Btn_Eliminar");

            // Columnas Grilla (Solo si existen)
            if (gridPlanes.Columns.Contains("colPlanNombre"))
                gridPlanes.Columns["colPlanNombre"].HeaderText = _idiomaBLL.Traducir("Planes_Col_NombrePlan");

            // Textos Dinámicos (Formatos)
            _fmtTemperatura = _idiomaBLL.Traducir("Planes_Fmt_Temperatura");
            _fmtHumedad = _idiomaBLL.Traducir("Planes_Fmt_Humedad");
            _fmtPh = _idiomaBLL.Traducir("Planes_Fmt_Ph");
            _fmtLuz = _idiomaBLL.Traducir("Planes_Fmt_Luz");
            _txtSeleccioneEtapa = _idiomaBLL.Traducir("Planes_Txt_SeleccioneEtapa");

            // Refrescar ficha si hay algo seleccionado
            if (gridEtapas.SelectedRows.Count > 0)
            {
                var etapa = (EtapaCultivo)gridEtapas.SelectedRows[0].DataBoundItem;
                MostrarFichaTecnica(etapa);
            }
            else
            {
                LimpiarDetalleFicha();
            }
        }

        #endregion

        #region Lógica de Grillas y Carga

        private void ConfigurarGrillas()
        {
            if (gridPlanes != null)
            {
                gridPlanes.AutoGenerateColumns = false;
                gridPlanes.MultiSelect = false;
                gridPlanes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Aseguramos que la columna tenga el DataPropertyName correcto
                if (gridPlanes.Columns.Contains("colPlanNombre"))
                    gridPlanes.Columns["colPlanNombre"].DataPropertyName = "NombrePlan";
            }

            if (gridEtapas != null)
            {
                gridEtapas.AutoGenerateColumns = true;
                gridEtapas.MultiSelect = false;
                gridEtapas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void CargarPlanes()
        {
            try
            {
                var lista = _planCultivoBLL.Listar();
                gridPlanes.DataSource = null;
                gridPlanes.DataSource = lista;
                gridPlanes.ClearSelection();

                // Limpiamos la parte derecha
                gridEtapas.DataSource = null;
                LimpiarDetalleFicha();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void GridPlanes_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPlanes.SelectedRows.Count > 0)
            {
                PlanCultivo planSeleccionado = (PlanCultivo)gridPlanes.SelectedRows[0].DataBoundItem;
                if (planSeleccionado != null)
                {
                    CargarEtapasDelPlan(planSeleccionado);
                }
            }
            else
            {
                gridEtapas.DataSource = null;
                LimpiarDetalleFicha();
            }
        }

        private void CargarEtapasDelPlan(PlanCultivo plan)
        {
            try
            {
                List<EtapaCultivo> listaEtapas = _etapaCultivoBLL.ListarPorPlan(plan.PlanCultivoID);

                gridEtapas.DataSource = null;
                gridEtapas.DataSource = listaEtapas;

                OcultarColumnasTecnicas();

                if (gridEtapas.Rows.Count > 0)
                    gridEtapas.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void OcultarColumnasTecnicas()
        {
            // 1. Ocultar columnas que no queremos ver
            string[] columnasOcultar = {
        "EtapaCultivoID", "PlanCultivoID",
        "TempMin", "TempMax",
        "HumMin", "HumMax",
        "PhMin", "PhMax",
        "EcMin", "EcMax",
        "HorasLuz"
    };

            foreach (string col in columnasOcultar)
            {
                if (gridEtapas.Columns[col] != null)
                    gridEtapas.Columns[col].Visible = false;
            }

            // 2. Aplicar TRADUCCIONES a los encabezados visibles
            // Asegúrate de que los nombres "DataPropertyName" coincidan con tu BE
            if (gridEtapas.Columns["NombreEtapa"] != null)
                gridEtapas.Columns["NombreEtapa"].HeaderText = _idiomaBLL.Traducir("Planes_Col_Etapa");

            if (gridEtapas.Columns["Duracion"] != null)
                gridEtapas.Columns["Duracion"].HeaderText = _idiomaBLL.Traducir("Planes_Col_Duracion");

            if (gridEtapas.Columns["Orden"] != null)
                gridEtapas.Columns["Orden"].HeaderText = _idiomaBLL.Traducir("Planes_Col_Orden");
        }

        private void GridEtapas_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEtapas.SelectedRows.Count > 0)
            {
                EtapaCultivo etapa = (EtapaCultivo)gridEtapas.SelectedRows[0].DataBoundItem;
                MostrarFichaTecnica(etapa);
            }
            else
            {
                LimpiarDetalleFicha();
            }
        }

        private void MostrarFichaTecnica(EtapaCultivo etapa)
        {
            lblTituloFicha.Text = $"{_idiomaBLL.Traducir("Planes_Lbl_TituloFicha")}: {etapa.NombreEtapa}";

            // Usamos las variables de formato cargadas por el idioma
            lblInfoTemp.Text = string.Format(_fmtTemperatura, etapa.TempMin, etapa.TempMax);
            lblInfoHum.Text = string.Format(_fmtHumedad, etapa.HumMin, etapa.HumMax);
            lblInfoPh.Text = string.Format(_fmtPh, etapa.PhMin, etapa.PhMax);
            lblInfoHorasLuz.Text = string.Format(_fmtLuz, etapa.HorasLuz);
        }

        private void LimpiarDetalleFicha()
        {
            lblTituloFicha.Text = _txtSeleccioneEtapa;
            lblInfoTemp.Text = "Temperature: --";
            lblInfoHum.Text = "Humedad: --";
            lblInfoPh.Text = "pH: --";
            lblInfoHorasLuz.Text = "Light: --";
        }

        #endregion

        #region Acciones (Botones)

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarPlanCultivoForm planCultivoForm = new AgregarPlanCultivoForm();
            this.Hide(); // Opcional: Ocultar padre

            if (planCultivoForm.ShowDialog() == DialogResult.OK)
            {
                // Bitácora
                RegistrarBitacora("Nuevo Plan creado", NivelCriticidad.Info);
            }

            CargarPlanes();
            this.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridPlanes.SelectedRows.Count > 0)
            {
                var plan = (PlanCultivo)gridPlanes.SelectedRows[0].DataBoundItem;
                OnSolicitarEdicion?.Invoke(plan);
            }
            else
            {
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("Planes_Msg_SeleccionarEditar"),
                    _idiomaBLL.Traducir("Global_Titulo_Atencion"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridPlanes.SelectedRows.Count > 0)
            {
                var plan = (PlanCultivo)gridPlanes.SelectedRows[0].DataBoundItem;

                var confirmacion = MetroMessageBox.Show(this,
                    string.Format(_idiomaBLL.Traducir("Planes_Msg_ConfirmarEliminar"), plan.NombrePlan),
                    _idiomaBLL.Traducir("Global_Titulo_Atencion"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        _planCultivoBLL.EliminarPlan(plan.PlanCultivoID, plan.NombrePlan);

                        RegistrarBitacora($"Plan eliminado: {plan.NombrePlan}", NivelCriticidad.Advertencia);

                        MetroMessageBox.Show(this,
                            _idiomaBLL.Traducir("Planes_Msg_EliminadoExito"),
                            _idiomaBLL.Traducir("Global_Titulo_Exito"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarPlanes();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("FK_Planta_PlanCultivo"))
                        {
                            MetroMessageBox.Show(this,
                                _idiomaBLL.Traducir("Planes_Err_PlanEnUso"),
                                _idiomaBLL.Traducir("Global_Titulo_Error"),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MostrarError(ex.Message);
                        }
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("Planes_Msg_SeleccionarEliminar"),
                    _idiomaBLL.Traducir("Global_Titulo_Atencion"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (gridPlanes.SelectedRows.Count > 0)
            {
                var plan = (PlanCultivo)gridPlanes.SelectedRows[0].DataBoundItem;
                var etapas = _etapaCultivoBLL.ListarPorPlan(plan.PlanCultivoID);

                string nombreSeguro = string.Join("_", plan.NombrePlan.Split(System.IO.Path.GetInvalidFileNameChars()));

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF Files|*.pdf";
                saveFile.Title = _idiomaBLL.Traducir("Planes_Dialog_GuardarPDF");
                saveFile.FileName = $"Plan_{nombreSeguro}.pdf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GeneradorReportePlan generador = new GeneradorReportePlan();
                        generador.ExportarPdf(plan, etapas, saveFile.FileName);

                        // Bitácora
                        RegistrarBitacora($"Plan exportado a PDF: {plan.NombrePlan}", NivelCriticidad.Info);

                        var abrir = MetroMessageBox.Show(this,
                            _idiomaBLL.Traducir("Planes_Msg_ExportarExito"),
                            _idiomaBLL.Traducir("Global_Titulo_Exito"),
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (abrir == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveFile.FileName);
                        }
                    }
                    catch (System.IO.IOException)
                    {
                        MetroMessageBox.Show(this,
                            _idiomaBLL.Traducir("Planes_Err_ArchivoEnUso"),
                            _idiomaBLL.Traducir("Global_Titulo_Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        string mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                        MostrarError(mensaje);
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("Planes_Msg_SeleccionarExportar"),
                    _idiomaBLL.Traducir("Global_Titulo_Atencion"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Helpers

        private void RegistrarBitacora(string mensaje, NivelCriticidad nivel)
        {
            var evento = _bitacoraService.CrearEvento(nivel, mensaje, "Gestión Cultivos", _usuarioActual.IdUsuario);
            var bitacora = new Bitacora
            {
                FechaHora = evento.FechaHora,
                Nivel = evento.Nivel,
                Mensaje = evento.Mensaje,
                Modulo = evento.Modulo,
                UsuarioID = evento.UsuarioID
            };
            _bitacoraBLL.Registrar(bitacora);
        }

        private void MostrarError(string mensaje)
        {
            MetroMessageBox.Show(this, mensaje, _idiomaBLL.Traducir("Global_Titulo_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}