using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BLL;
using BLL.InicioUsuarioBLL;
using Services;
using MetroFramework;
using MetroFramework.Controls;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_RolesYPermisos;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class GestionUsuariosView : UserControl
    {
        private GestionUsuariosBLL gestionUsuariosBLL = new GestionUsuariosBLL();
        private IdiomaBLL _idiomaBLL = new IdiomaBLL();

        public GestionUsuariosView()
        {
            InitializeComponent();
        }

        private void GestionUsuariosView_Load(object sender, EventArgs e)
        {
            DarVidaAlGrid(metroGridUsuarios);
            metroGridUsuarios.CellFormatting += metroGridUsuarios_CellFormatting;

            RedondearControl(btnAgregar, 15);
            RedondearControl(btnEditar, 15);
            RedondearControl(btnDesactivar, 15);
            RedondearControl(btnActivar, 15);
            RedondearControl(btnPermisos, 15);

            // Carga inicial de traducciones
            TraducirInterfaz();

            // Suscripción al evento de cambio de idioma
            IdiomaService.GetInstance().IdiomaCambiado += () => {
                TraducirInterfaz();
                ListarUsuarios(); // Recargamos para aplicar headers traducidos
            };

            ListarUsuarios();
        }

        private void TraducirInterfaz()
        {
            // Títulos y Textos Fijos
            lblTitulo.Text = _idiomaBLL.Traducir("GestionUsuarios_Lbl_Titulo");
            txtBuscar.PromptText = _idiomaBLL.Traducir("GestionUsuarios_Txt_Buscar");

            // Botones
            btnAgregar.Text = _idiomaBLL.Traducir("GestionUsuarios_Btn_Agregar");
            btnEditar.Text = _idiomaBLL.Traducir("GestionUsuarios_Btn_Editar");
            btnDesactivar.Text = _idiomaBLL.Traducir("GestionUsuarios_Btn_Desactivar");
            btnActivar.Text = _idiomaBLL.Traducir("GestionUsuarios_Btn_Activar");
            btnPermisos.Text = _idiomaBLL.Traducir("GestionUsuarios_Btn_Permisos");
        }

        // --- MÉTODOS DE GRILLA Y ESTILOS (Sin cambios lógicos) ---

        private void DarVidaAlGrid(MetroGrid grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;

            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(224, 224, 224);

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 40;

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 252, 245);
            grid.RowsDefaultCellStyle.BackColor = Color.White;
            grid.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            grid.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201);
            grid.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            grid.RowTemplate.Height = 35;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
        }

        private void RedondearControl(Control control, int radio)
        {
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radio, radio, 180, 90);
            path.AddArc(bounds.X + bounds.Width - radio, bounds.Y, radio, radio, 270, 90);
            path.AddArc(bounds.X + bounds.Width - radio, bounds.Y + bounds.Height - radio, radio, radio, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        // --- LÓGICA DE NEGOCIO ---

        private void CargarVista(UserControl vista)
        {
            // Mantenemos tu método original aunque tenga limitaciones con Forms, 
            // ya que pediste solo enfocarnos en el idioma.
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }

        public void ListarUsuarios()
        {
            DataTable dataTable = gestionUsuariosBLL.ListarUsuarios();
            if (dataTable != null)
            {
                metroGridUsuarios.DataSource = dataTable;

                // Aplicar traducciones a los encabezados
                if (metroGridUsuarios.Columns.Contains("UsuarioNombre"))
                    metroGridUsuarios.Columns["UsuarioNombre"].HeaderText = _idiomaBLL.Traducir("GestionUsuarios_Col_Usuario");

                if (metroGridUsuarios.Columns.Contains("UsuarioIntentos"))
                    metroGridUsuarios.Columns["UsuarioIntentos"].HeaderText = _idiomaBLL.Traducir("GestionUsuarios_Col_Intentos");

                if (metroGridUsuarios.Columns.Contains("EstaActivo"))
                    metroGridUsuarios.Columns["EstaActivo"].HeaderText = _idiomaBLL.Traducir("GestionUsuarios_Col_Activo");

                // Ocultar columnas
                if (metroGridUsuarios.Columns.Contains("UsuarioContraseña"))
                    metroGridUsuarios.Columns["UsuarioContraseña"].Visible = false;

                if (metroGridUsuarios.Columns.Contains("UsuarioClaveRecuperacion"))
                    metroGridUsuarios.Columns["UsuarioClaveRecuperacion"].Visible = false;

                if (metroGridUsuarios.Columns.Contains("UsuarioID"))
                    metroGridUsuarios.Columns["UsuarioID"].Visible = false;

                if (metroGridUsuarios.Columns.Contains("IdiomaPreferidoID"))
                    metroGridUsuarios.Columns["IdiomaPreferidoID"].Visible = false;
            }
        }

        private void buttonAgregarUsuario_Click(object sender, EventArgs e)
        {
            // Usamos tu método original
            CargarVista(new AgregarUsuario());
        }

        private void buttonEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (metroGridUsuarios.CurrentRow == null) return;

            string mensaje = _idiomaBLL.Traducir("GestionUsuarios_Msg_ConfirmarDesactivar");
            string titulo = _idiomaBLL.Traducir("Global_Titulo_Confirmar");

            DialogResult resultado = MetroMessageBox.Show(this, mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(metroGridUsuarios.CurrentRow.Cells["UsuarioID"].Value);
                    gestionUsuariosBLL.DesactivarUsuario(id);

                    string msgExito = _idiomaBLL.Traducir("GestionUsuarios_Msg_DesactivadoExito");
                    string tituloExito = _idiomaBLL.Traducir("Global_Titulo_Exito");

                    MetroMessageBox.Show(this, msgExito, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                }
                catch (Exception ex)
                {
                    string tituloError = _idiomaBLL.Traducir("Global_Titulo_Error");
                    MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (metroGridUsuarios.CurrentRow == null) return;

            string mensaje = _idiomaBLL.Traducir("GestionUsuarios_Msg_ConfirmarActivar");
            string titulo = _idiomaBLL.Traducir("Global_Titulo_Confirmar");

            DialogResult resultado = MetroMessageBox.Show(this, mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(metroGridUsuarios.CurrentRow.Cells["UsuarioID"].Value);
                    gestionUsuariosBLL.ActivarUsuario(id);

                    string msgExito = _idiomaBLL.Traducir("GestionUsuarios_Msg_ActivadoExito");
                    string tituloExito = _idiomaBLL.Traducir("Global_Titulo_Exito");

                    MetroMessageBox.Show(this, msgExito, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                }
                catch (Exception ex)
                {
                    string tituloError = _idiomaBLL.Traducir("Global_Titulo_Error");
                    MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonEditarUsuario_Click(object sender, EventArgs e)
        {
            if (metroGridUsuarios.CurrentRow == null)
            {
                string msg = _idiomaBLL.Traducir("GestionUsuarios_Msg_SeleccionarEditar");
                string titulo = _idiomaBLL.Traducir("Global_Titulo_Atencion");
                MetroMessageBox.Show(this, msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(metroGridUsuarios.CurrentRow.Cells["UsuarioID"].Value);
                string nombre = metroGridUsuarios.CurrentRow.Cells["UsuarioNombre"].Value.ToString();
                string pass = metroGridUsuarios.CurrentRow.Cells["UsuarioContraseña"].Value.ToString();
                string clave = metroGridUsuarios.CurrentRow.Cells["UsuarioClaveRecuperacion"].Value.ToString();
                int intentos = Convert.ToInt32(metroGridUsuarios.CurrentRow.Cells["UsuarioIntentos"].Value);
                int activo = Convert.ToInt32(metroGridUsuarios.CurrentRow.Cells["EstaActivo"].Value);

                CargarVista(new ModificarUsuario(id, nombre, pass, clave, intentos, activo));
            }
            catch (Exception ex)
            {
                string tituloError = _idiomaBLL.Traducir("Global_Titulo_Error");
                MetroMessageBox.Show(this, "Error: " + ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificarPermisosUsuario_Click(object sender, EventArgs e)
        {
            CargarVista(new ModificarPermisosPorUsuario());



        }

        private void metroGridUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (metroGridUsuarios.Columns[e.ColumnIndex].Name == "UsuarioContraseña" && e.Value != null)
            {
                e.Value = "●●●●●●●●";
                e.FormattingApplied = true;
            }

            if (metroGridUsuarios.Columns[e.ColumnIndex].Name == "UsuarioClaveRecuperacion" && e.Value != null)
            {
                e.Value = "(Oculto)";
                e.FormattingApplied = true;
            }
        }
    }
}