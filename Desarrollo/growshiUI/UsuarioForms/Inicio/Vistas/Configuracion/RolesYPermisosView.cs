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
    public partial class RolesYPermisosView : UserControl
    {
        public RolesYPermisosView()
        {
            InitializeComponent();
        }

        private void RolesYPermisosView_Load(object sender, EventArgs e)
        {
            // En una aplicación real, estos datos vendrían de la base de datos.
            // Para este ejemplo, los escribimos directamente.

            // Cargar la lista de Roles en el ListBox de la izquierda
            //lstRoles.Items.Add("Administrador");
            //lstRoles.Items.Add("Operador");
            //lstRoles.Items.Add("Invitado");

            //// Cargar TODOS los permisos posibles en la lista de la derecha
            //clbPermisos.Items.Add("Puede gestionar usuarios");
            //clbPermisos.Items.Add("Puede ver reportes");
            //clbPermisos.Items.Add("Puede editar cultivos");

            //// Al inicio, no hay nada seleccionado, así que desactivamos el panel derecho
            //clbPermisos.Enabled = false;
            //btnGuardarPermisos.Enabled = false;
        }

        private void listBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Si no hay ningún rol seleccionado, no hace nada.
            //if (lstRoles.SelectedItem == null) return;

            //// Reactivamos el panel derecho
            //clbPermisos.Enabled = true;
            //btnGuardarPermisos.Enabled = true;

            //// Obtenemos el nombre del rol y actualizamos el título
            //string rolSeleccionado = lstRoles.SelectedItem.ToString();
            //lblTituloPermisos.Text = "Permisos para el Rol: " + rolSeleccionado;

            //// --- Lógica para marcar/desmarcar los permisos ---
            //// 1. Primero, desmarcamos todo para limpiar la selección anterior.
            //for (int i = 0; i < clbPermisos.Items.Count; i++)
            //{
            //    clbPermisos.SetItemChecked(i, false);
            //}

            //// 2. Ahora, marcamos los permisos que correspondan a ese rol.
            //// (Esto también vendría de la base de datos).
            //if (rolSeleccionado == "Administrador")
            //{
            //    // El Admin puede todo, así que marcamos todas las casillas.
            //    for (int i = 0; i < clbPermisos.Items.Count; i++)
            //    {
            //        clbPermisos.SetItemChecked(i, true);
            //    }
            //}
            //else if (rolSeleccionado == "Operador")
            //{
            //    // El Operador solo puede ver reportes y editar cultivos.
            //    clbPermisos.SetItemChecked(clbPermisos.Items.IndexOf("Puede ver reportes"), true);
            //    clbPermisos.SetItemChecked(clbPermisos.Items.IndexOf("Puede editar cultivos"), true);
            //}
        }

        private void q(object sender, EventArgs e)
        {

        }
    }
}
