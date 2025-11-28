using BLL;
using BLL.InicioUsuarioBLL;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_RolesYPermisos;
using Services; 
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MetroFramework;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class RolesYPermisosView : UserControl
    {
        private RolesYPermisosBLL rolesYPermisosBLL = new RolesYPermisosBLL();
        private IdiomaBLL _idiomaBLL = new IdiomaBLL();

        public RolesYPermisosView()
        {
            InitializeComponent();
        }

        private void RolesYPermisosView_Load(object sender, EventArgs e)
        {
            DarVidaAlGrid(metroGridFamilia);
            DarVidaAlGrid(metroGridAsociados);
            DarVidaAlGrid(metroGridSistema);
            RedondearControl(btnAgregarPermiso, 20);
            RedondearControl(btnQuitarPermiso, 20);
            TraducirInterfaz();

            IdiomaService.GetInstance().IdiomaCambiado += () => {
                TraducirInterfaz();
                ListarFamiliaDeRoles();

                if (metroGridFamilia.CurrentRow != null)
                {
                    string id = metroGridFamilia.CurrentRow.Cells["PermisoID"].Value.ToString();
                    ListarRolesAsociadosAUnaFamilia(id);
                    ListarRolesDelSistemaDisponibles(id);
                }
            };

            ListarFamiliaDeRoles();
        }

        private void TraducirInterfaz()
        {
           
            if (btnNuevaFamilia != null) btnNuevaFamilia.Text = _idiomaBLL.Traducir("btn_nueva_familia");
            if (btnRenombrarFamilia != null) btnRenombrarFamilia.Text = _idiomaBLL.Traducir("btn_renombrar_familia");
            if (btnEliminarFamilia != null) btnEliminarFamilia.Text = _idiomaBLL.Traducir("btn_eliminar_familia");
            if (lblFamilia != null) lblFamilia.Text = _idiomaBLL.Traducir("lbl_familiaDeRoles");
            if (lblAsignados != null) lblAsignados.Text = _idiomaBLL.Traducir("lbl_permisosAsignados");
            if (lblDisponibles != null) lblDisponibles.Text = _idiomaBLL.Traducir("lbl_permisosDisponibles");


        }

        // --- ESTILOS VISUALES ---
        private void DarVidaAlGrid(MetroFramework.Controls.MetroGrid grid)
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

        private void CargarVista(UserControl vista)
        {
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }

        // --- LÓGICA DE DATOS Y TRADUCCIÓN DE COLUMNAS ---

        private void TraducirColumnas(MetroFramework.Controls.MetroGrid grid)
        {
            if (grid.DataSource == null) return;

            if (grid.Columns.Contains("NombreDescriptivo"))
            {
                grid.Columns["NombreDescriptivo"].HeaderText = _idiomaBLL.Traducir("col_nombre_permiso");
            }
            else if (grid.Columns.Contains("Nombre")) 
            {
                grid.Columns["Nombre"].HeaderText = _idiomaBLL.Traducir("col_nombre_permiso");
            }

            // Ocultar ID
            if (grid.Columns.Contains("PermisoID"))
                grid.Columns["PermisoID"].Visible = false;

            if (grid.Columns.Contains("Permiso")) 
                grid.Columns["Permiso"].Visible = false;
        }

        public void ListarFamiliaDeRoles()
        {
            DataTable dataTable = rolesYPermisosBLL.ListarFamiliaDeRoles();
            if (dataTable != null)
            {
                metroGridFamilia.DataSource = dataTable;
                TraducirColumnas(metroGridFamilia);
            }
        }

        public void ListarRolesAsociadosAUnaFamilia(string idFamilia)
        {
            DataTable dataTable = rolesYPermisosBLL.ListarRolesAsociadosAfamilia(idFamilia);
            if (dataTable != null)
            {
                metroGridAsociados.DataSource = dataTable;
                TraducirColumnas(metroGridAsociados);
            }
        }

        public void ListarRolesDelSistemaDisponibles(string idFamilia)
        {
            DataTable dataTable = rolesYPermisosBLL.ListarRolesDelSistemaDisponibles(idFamilia);
            if (dataTable != null)
            {
                metroGridSistema.DataSource = dataTable;
                TraducirColumnas(metroGridSistema);
            }
        }

        private void metroGridFamilia_SelectionChanged(object sender, EventArgs e)
        {
            if (metroGridFamilia.CurrentRow == null)
            {
                metroGridAsociados.DataSource = null;
                metroGridSistema.DataSource = null;
                return;
            }

            string idFamilia = metroGridFamilia.CurrentRow.Cells["PermisoID"].Value.ToString();
            ListarRolesAsociadosAUnaFamilia(idFamilia);
            ListarRolesDelSistemaDisponibles(idFamilia);
        }

        // --- BOTONES GESTIÓN FAMILIA (Izquierda) ---

        private void btnNuevaFamilia_Click(object sender, EventArgs e)
        {
            CargarVista(new AgregarFamilia());
        }

        private void btnRenombrarFamilia_Click(object sender, EventArgs e)
        {
            if (metroGridFamilia.CurrentRow == null)
            {
                string msg = _idiomaBLL.Traducir("msg_seleccione_familia");
                string titulo = _idiomaBLL.Traducir("titulo_atencion");
                MetroMessageBox.Show(this, msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = metroGridFamilia.CurrentRow.Cells["PermisoID"].Value.ToString();
            string nombre = metroGridFamilia.CurrentRow.Cells["NombreDescriptivo"].Value.ToString();

            CargarVista(new ModificarFamilia(id, nombre));
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            if (metroGridFamilia.CurrentRow == null) return;

            string mensaje = _idiomaBLL.Traducir("msg_confirmar_borrar_familia");
            string titulo = _idiomaBLL.Traducir("titulo_confirmar");

            if (MetroMessageBox.Show(this, mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string id = metroGridFamilia.CurrentRow.Cells["PermisoID"].Value.ToString();
                    rolesYPermisosBLL.EliminarFamiliaDeRoles(id);

                    string msgExito = _idiomaBLL.Traducir("msg_familia_eliminada");
                    string tituloExito = _idiomaBLL.Traducir("titulo_exito");

                    MetroMessageBox.Show(this, msgExito, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarFamiliaDeRoles();
                }
                catch (Exception ex)
                {
                    string tituloError = _idiomaBLL.Traducir("titulo_error");
                    MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- BOTONES ASIGNACIÓN (Flechas Centro) ---

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            if (metroGridFamilia.CurrentRow == null || metroGridSistema.CurrentRow == null)
            {
                string msg = _idiomaBLL.Traducir("msg_seleccione_familia_permiso");
                string titulo = _idiomaBLL.Traducir("titulo_atencion");
                MetroMessageBox.Show(this, msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idFamilia = metroGridFamilia.CurrentRow.Cells["PermisoID"].Value.ToString();
                string idPermiso = metroGridSistema.CurrentRow.Cells["PermisoID"].Value.ToString();

                rolesYPermisosBLL.AgregarPermisoComponenteAFamilia(idPermiso, idFamilia);

                ListarRolesAsociadosAUnaFamilia(idFamilia);
                ListarRolesDelSistemaDisponibles(idFamilia);
            }
            catch (Exception ex)
            {
                string tituloError = _idiomaBLL.Traducir("titulo_error");
                MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarPermiso_Click(object sender, EventArgs e)
        {
            if (metroGridFamilia.CurrentRow == null || metroGridAsociados.CurrentRow == null)
            {
                string msg = _idiomaBLL.Traducir("msg_seleccione_permiso_quitar");
                string titulo = _idiomaBLL.Traducir("titulo_atencion");
                MetroMessageBox.Show(this, msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idFamilia = metroGridFamilia.CurrentRow.Cells["PermisoID"].Value.ToString();
                string idPermiso = metroGridAsociados.CurrentRow.Cells["PermisoID"].Value.ToString();

                rolesYPermisosBLL.QuitarPermisoComponenteDeFamilia(idPermiso, idFamilia);

                ListarRolesAsociadosAUnaFamilia(idFamilia);
                ListarRolesDelSistemaDisponibles(idFamilia);
            }
            catch (Exception ex)
            {
                string tituloError = _idiomaBLL.Traducir("titulo_error");
                MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}