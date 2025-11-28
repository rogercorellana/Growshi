using BLL.InicioUsuarioBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_RolesYPermisos
{
    public partial class AgregarFamilia : UserControl
    {

        RolesYPermisosBLL rolesYPermisosBLL = new RolesYPermisosBLL();
        public AgregarFamilia()
        {
            InitializeComponent();
        }

        private void CargarVista(UserControl vista)
        {
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }


        #region AGREGAR FAMILIA
        private void buttonAgregarFamilia_Click(object sender, EventArgs e)
        {
            string permisoID = textBoxPermisoID.Text.Trim();
            string nombreDescriptivo = textBoxNombreDescriptivo.Text.Trim();

            if (string.IsNullOrWhiteSpace(permisoID) || string.IsNullOrWhiteSpace(nombreDescriptivo))
            {
                MessageBox.Show("Debe completar todos los campos (Permiso ID y Nombre).",
                                "Campos Vacíos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; 
            }

            try
            {
                rolesYPermisosBLL.CrearFamiliaDeRoles(permisoID, nombreDescriptivo);

                string mensaje = "¡Familia de rol creada correctamente!\n\n" +
                                 "¿Desea seguir creando familias?";

                DialogResult resultado = MessageBox.Show(
                    mensaje,
                    "Éxito",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question 
                );

                if (resultado == DialogResult.Yes)
                {
                    textBoxPermisoID.Text = "";
                    textBoxNombreDescriptivo.Text = "";
                    textBoxPermisoID.Focus(); 
                }
                else
                {

                    CargarVista(new RolesYPermisosView());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al crear la familia: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
