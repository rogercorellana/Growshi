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

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class CopiasSeguridadView : UserControl
    {

        private readonly BackupBLL _backupBLL;
        private List<Backup> _listaBackups;
        public CopiasSeguridadView()
        {
            InitializeComponent();
            _backupBLL = new BackupBLL();

        }

        private void CopiasSeguridadView_Load(object sender, EventArgs e)
        {
            CargarBackups();

        }

        private void CargarBackups()
        {
            try
            {
                // Limpiamos la grilla antes de cargar nuevos datos.

                dataGridViewHistorial.DataSource = null;

                // Obtenemos la lista completa de backups desde la BLL.
                _listaBackups = _backupBLL.ObtenerCatalogoCompleto();
                dataGridViewHistorial.DataSource = _listaBackups;

                // Ocultamos columnas que no son amigables para el usuario.
                if (dataGridViewHistorial.Columns["Id"] != null) dataGridViewHistorial.Columns["Id"].Visible = false;
                if (dataGridViewHistorial.Columns["RutaArchivo"] != null) dataGridViewHistorial.Columns["RutaArchivo"].Visible = false;

                // Renombramos las cabeceras para que se vean mejor.
                if (dataGridViewHistorial.Columns["FechaHora"] != null) dataGridViewHistorial.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                if (dataGridViewHistorial.Columns["NombreArchivo"] != null) dataGridViewHistorial.Columns["NombreArchivo"].HeaderText = "Nombre del Archivo";
                if (dataGridViewHistorial.Columns["Usuario"] != null) dataGridViewHistorial.Columns["Usuario"].HeaderText = "Realizado Por";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el catálogo de backups: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
