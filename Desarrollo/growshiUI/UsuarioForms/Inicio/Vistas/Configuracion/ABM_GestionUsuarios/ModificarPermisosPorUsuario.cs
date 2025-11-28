using BLL;
using BLL.InicioUsuarioBLL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MetroFramework;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    public partial class ModificarPermisosPorUsuario : UserControl
    {
        RolesYPermisosPorUsuarioBLL RolesYPermisosPorUsuarioBLL = new RolesYPermisosPorUsuarioBLL();

        public ModificarPermisosPorUsuario()
        {
            InitializeComponent();
        }

        private void ModificarPermisosPorUsuario_Load(object sender, EventArgs e)
        {
            DarVidaAlGrid(metroGridUsuarios);
            DarVidaAlGrid(metroGridAsignados);
            DarVidaAlGrid(metroGridDisponibles);

            HacerBotonRedondo(btnAgregar);
            HacerBotonRedondo(btnQuitar);

            ListarFamiliaDeRoles();
        }

        private void DarVidaAlGrid(MetroFramework.Controls.MetroGrid grid)
        {
            grid.ReadOnly = true;                          
            grid.AllowUserToAddRows = false;                
            grid.AllowUserToDeleteRows = false;             
            grid.AllowUserToResizeRows = false;            
            grid.EditMode = DataGridViewEditMode.EditProgrammatically; 
            grid.MultiSelect = false;                      
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grid.BackgroundColor = Color.White;
            grid.Style = MetroColorStyle.Green;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(224, 224, 224);

            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 40;
            grid.EnableHeadersVisualStyles = false; 

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 250, 245);
            grid.RowsDefaultCellStyle.BackColor = Color.White;
            grid.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            grid.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201);
            grid.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            grid.RowTemplate.Height = 35;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false; 
        }

        private void HacerBotonRedondo(Button btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

        // --- LÓGICA DE NEGOCIO ---

        public void ListarFamiliaDeRoles()
        {
            DataTable dataTable = RolesYPermisosPorUsuarioBLL.ListarUsuarios();
            if (dataTable != null) metroGridUsuarios.DataSource = dataTable;
        }

        public void ListarRolesAsociadosAlUsuario(string idUsuarioSeleccionado)
        {
            DataTable dataTable = RolesYPermisosPorUsuarioBLL.ListarRolesAsociadosAlUsuario(idUsuarioSeleccionado);
            if (dataTable != null) metroGridAsignados.DataSource = dataTable;
        }

        public void ListarRolesDisponibles(string idUsuarioSeleccionado)
        {
            DataTable dataTable = RolesYPermisosPorUsuarioBLL.ListarRolesDelSistemaDisponibles(idUsuarioSeleccionado);
            if (dataTable != null) metroGridDisponibles.DataSource = dataTable;
        }

        private void metroGridUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (metroGridUsuarios.CurrentRow == null)
            {
                metroGridAsignados.DataSource = null;
                metroGridDisponibles.DataSource = null;
                return;
            }

            string idUsuarioSeleccionado = metroGridUsuarios.CurrentRow.Cells["UsuarioNombre"].Value.ToString();
            ListarRolesAsociadosAlUsuario(idUsuarioSeleccionado);
            ListarRolesDisponibles(idUsuarioSeleccionado);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (metroGridUsuarios.CurrentRow == null || metroGridDisponibles.CurrentRow == null) return;

            try
            {
                string idUsuario = metroGridUsuarios.CurrentRow.Cells["UsuarioNombre"].Value.ToString();
                string idPermiso = metroGridDisponibles.CurrentRow.Cells["PermisoID"].Value.ToString();

                RolesYPermisosPorUsuarioBLL.AgregarPermisoAUsuario(idPermiso, idUsuario);

                ListarRolesAsociadosAlUsuario(idUsuario);
                ListarRolesDisponibles(idUsuario);
            }
            catch (Exception ex) { MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (metroGridUsuarios.CurrentRow == null || metroGridAsignados.CurrentRow == null) return;

            try
            {
                string idUsuario = metroGridUsuarios.CurrentRow.Cells["UsuarioNombre"].Value.ToString();
                string idPermiso = metroGridAsignados.CurrentRow.Cells["PermisoID"].Value.ToString();

                RolesYPermisosPorUsuarioBLL.QuitarPermisoAUsuario(idPermiso, idUsuario);

                ListarRolesAsociadosAlUsuario(idUsuario);
                ListarRolesDisponibles(idUsuario);
            }
            catch (Exception ex) { MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}