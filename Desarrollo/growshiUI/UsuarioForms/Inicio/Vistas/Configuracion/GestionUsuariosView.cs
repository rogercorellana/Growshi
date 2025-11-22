using BLL;
using BLL.InicioUsuarioBLL;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_RolesYPermisos;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // Necesario para bordes redondos
using System.Windows.Forms;
using MetroFramework;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class GestionUsuariosView : UserControl
    {
        GestionUsuariosBLL gestionUsuariosBLL = new GestionUsuariosBLL();

        public GestionUsuariosView()
        {
            InitializeComponent();
        }

        private void GestionUsuariosView_Load(object sender, EventArgs e)
        {
            // 1. Aplicar Estilo Premium a la Grilla
            DarVidaAlGrid(metroGridUsuarios);

            // 2. Redondear Botones (Estilo Píldora)
            // Radio 15 para altura 30 queda perfectamente redondo
            RedondearControl(btnAgregar, 15);
            RedondearControl(btnEditar, 15);
            RedondearControl(btnDesactivar, 15);
            RedondearControl(btnPermisos, 15);

            // 3. Cargar Datos
            ListarUsuarios();
        }

        // --- ESTILO VISUAL ---
        private void DarVidaAlGrid(MetroFramework.Controls.MetroGrid grid)
        {
            // Candados de seguridad
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically; // Sin doble click para editar

            // Estilo Visual
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None; // El borde lo da el panel contenedor
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(224, 224, 224);

            // Encabezados
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50); // Verde Oscuro
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 40;

            // Filas Zebra
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
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }

        public void ListarUsuarios()
        {
            DataTable dataTable = gestionUsuariosBLL.ListarUsuarios();
            if (dataTable != null) metroGridUsuarios.DataSource = dataTable;
        }

        private void buttonAgregarUsuario_Click(object sender, EventArgs e)
        {
            CargarVista(new AgregarUsuario());
        }

        private void buttonEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (metroGridUsuarios.CurrentRow == null) return;

            DialogResult resultado = MetroMessageBox.Show(this,
                "¿Está seguro de desactivar este usuario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(metroGridUsuarios.CurrentRow.Cells["UsuarioID"].Value);
                    gestionUsuariosBLL.DesactivarUsuario(id);
                    MetroMessageBox.Show(this, "Usuario desactivado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonEditarUsuario_Click(object sender, EventArgs e)
        {
            if (metroGridUsuarios.CurrentRow == null)
            {
                MetroMessageBox.Show(this, "Seleccione un usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombre = metroGridUsuarios.CurrentRow.Cells["UsuarioNombre"].Value.ToString();
                string pass = metroGridUsuarios.CurrentRow.Cells["UsuarioContraseña"].Value.ToString();
                string clave = metroGridUsuarios.CurrentRow.Cells["UsuarioClaveRecuperacion"].Value.ToString();
                int intentos = Convert.ToInt32(metroGridUsuarios.CurrentRow.Cells["UsuarioIntentos"].Value);
                int activo = Convert.ToInt32(metroGridUsuarios.CurrentRow.Cells["EstaActivo"].Value);

                CargarVista(new ModificarUsuario(nombre, pass, clave, intentos, activo));
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Error al leer datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificarPermisosUsuario_Click(object sender, EventArgs e)
        {
            CargarVista(new ModificarPermisosPorUsuario());
        }

        private void btnSuscripcion_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Módulo en mantenimiento.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}