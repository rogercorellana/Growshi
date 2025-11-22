using BLL.InicioUsuarioBLL;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_RolesYPermisos;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MetroFramework; // Importante

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class RolesYPermisosView : UserControl
    {
        RolesYPermisosBLL rolesYPermisosBLL = new RolesYPermisosBLL();

        public RolesYPermisosView()
        {
            InitializeComponent();
        }

        private void RolesYPermisosView_Load(object sender, EventArgs e)
        {
            // 1. Estilizar las 3 Grillas
            DarVidaAlGrid(metroGridFamilia);
            DarVidaAlGrid(metroGridAsociados);
            DarVidaAlGrid(metroGridSistema);

            // 2. Redondear Botones de Flechas (Centrales)
            RedondearControl(btnAgregarPermiso, 20); // Radio 20 para 40x40
            RedondearControl(btnQuitarPermiso, 20);

            // 3. Estilizar Botones de Gestión (Abajo Izquierda)
            // Los dejamos rectangulares con borde suave o MetroButton estándar

            // 4. Cargar Datos Iniciales
            ListarFamiliaDeRoles();
        }

        // --- ESTILOS VISUALES ---
        private void DarVidaAlGrid(MetroFramework.Controls.MetroGrid grid)
        {
            // Candados
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Visual
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(224, 224, 224);

            // Encabezados
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 40;

            // Filas
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

        // --- LÓGICA DE DATOS ---

        public void ListarFamiliaDeRoles()
        {
            DataTable dataTable = rolesYPermisosBLL.ListarFamiliaDeRoles();
            if (dataTable != null) metroGridFamilia.DataSource = dataTable;
        }

        public void ListarRolesAsociadosAUnaFamilia(string idFamilia)
        {
            DataTable dataTable = rolesYPermisosBLL.ListarRolesAsociadosAfamilia(idFamilia);
            if (dataTable != null) metroGridAsociados.DataSource = dataTable;
        }

        public void ListarRolesDelSistemaDisponibles(string idFamilia)
        {
            DataTable dataTable = rolesYPermisosBLL.ListarRolesDelSistemaDisponibles(idFamilia);
            if (dataTable != null) metroGridSistema.DataSource = dataTable;
        }

        private void metroGridFamilia_SelectionChanged(object sender, EventArgs e)
        {
            if (metroGridFamilia.CurrentRow == null)
            {
                metroGridAsociados.DataSource = null;
                metroGridSistema.DataSource = null;
                return;
            }

            // Asumo que la columna ID se llama "PermisoID", verifica tu BD
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
                MetroMessageBox.Show(this, "Seleccione una familia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = metroGridFamilia.CurrentRow.Cells["PermisoID"].Value.ToString();
            string nombre = metroGridFamilia.CurrentRow.Cells["NombreDescriptivo"].Value.ToString(); // Ajustar nombre col

            CargarVista(new ModificarFamilia(id, nombre));
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            if (metroGridFamilia.CurrentRow == null) return;

            string mensaje = "¡Acción IRREVERSIBLE!\n¿Desea borrar esta familia de permisos?";
            if (MetroMessageBox.Show(this, mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string id = metroGridFamilia.CurrentRow.Cells["PermisoID"].Value.ToString();
                    rolesYPermisosBLL.EliminarFamiliaDeRoles(id);
                    MetroMessageBox.Show(this, "Familia eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarFamiliaDeRoles();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- BOTONES ASIGNACIÓN (Flechas Centro) ---

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            if (metroGridFamilia.CurrentRow == null || metroGridSistema.CurrentRow == null)
            {
                MetroMessageBox.Show(this, "Seleccione una Familia y un Permiso Disponible.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception ex) { MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnQuitarPermiso_Click(object sender, EventArgs e)
        {
            if (metroGridFamilia.CurrentRow == null || metroGridAsociados.CurrentRow == null)
            {
                MetroMessageBox.Show(this, "Seleccione un Permiso Asignado para quitar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception ex) { MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}