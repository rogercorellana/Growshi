using growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class MisCultivosView : UserControl
    {
        public MisCultivosView()
        {
            InitializeComponent();
            CargarSlots();
        }

        private void CargarSlots()
        {
            this.gridLayout.Controls.Clear();

            for (int i = 1; i <= 4; i++)
            {
                CultivoSlotView slot = new CultivoSlotView();
                slot.Dock = DockStyle.Fill; 
                slot.Margin = new Padding(10); 

                slot.Inicializar(i);

                slot.Click += Slot_Click;

                
                this.gridLayout.Controls.Add(slot);
            }
        }

        private void Slot_Click(object sender, EventArgs e)
        {
            var slot = (CultivoSlotView)sender;

            MessageBox.Show($"Hiciste clic en el Slot #{slot.SlotId}.\nAquí abriremos el formulario para agregar/ver planta.");

       
        }
    }
}