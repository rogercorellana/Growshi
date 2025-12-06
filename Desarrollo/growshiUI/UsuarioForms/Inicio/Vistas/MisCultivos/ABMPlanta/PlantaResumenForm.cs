using BE;
using BLL;
using growshiUI.UsuarioForms.Inicio.Vistas.Menu;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanta
{
    public partial class PlantaResumenForm : MetroForm
    {
        // Variable privada para recordar qué slot estamos viendo
        private int _slotId;
        private string _nombrePlanta; // La guardamos para usarla en el mensaje de eliminar
        PlantaBLL plantaBLL = new PlantaBLL();

        // Constructor que recibe el ID del Slot
        public PlantaResumenForm(int slot)
        {
            InitializeComponent();

            // 1. Guardamos la referencia
            this._slotId = slot;

            // 2. Cargamos los datos específicos de este slot
            CargarDatosReales();
        }

        private void CargarDatosReales()
{
    // 1. Llamamos a la BLL
    Planta miPlanta = plantaBLL.ObtenerPorSlot(_slotId);

    if (miPlanta != null)
    {
        _nombrePlanta = miPlanta.Nombre;

        // --- A. TEXTOS BÁSICOS ---
        this.Text = $"Detalle del Slot #{_slotId}";
        lblPlanAsignado.Text = $"Slot {_slotId}: {miPlanta.NombrePlan}";
        lblTituloPlanta.Text = $"Slot {_slotId}: {miPlanta.Nombre}";
        lblFechaSiembra.Text = $"Fecha Siembra: {miPlanta.FechaInicio}";

        // --- B. CÁLCULOS MATEMÁTICOS (Corrección para double?) ---

        // PASO CLAVE:
        // Extraemos el valor. Si es null, usamos 0. 
        // Esto convierte el 'double?' a un 'double' normal.
        double totalDiasPlan = miPlanta.DiasTotalesPlan.GetValueOrDefault();

        // Cálculo 1: Fecha Estimada
        // Ahora sí funciona AddDays porque totalDiasPlan ya no es nullable
        DateTime fechaEstimada = miPlanta.FechaInicio.AddDays(totalDiasPlan);
        lblFechaCosecha.Text = $"Estimada Cosecha: {fechaEstimada}";

        // Cálculo 2: Días Transcurridos
        TimeSpan tiempoTranscurrido = DateTime.Now - miPlanta.FechaInicio;
        int diasPasados = tiempoTranscurrido.Days + 1;

        // Validación visual
        if (diasPasados < 0) diasPasados = 0;

        lblProgresoDia.Text = $"Día {diasPasados} de {totalDiasPlan}";

        // Cálculo 3: Porcentaje para la barra
        // Usamos la variable local 'totalDiasPlan' que ya es segura
        if (totalDiasPlan > 0)
        {
            // Casteamos a (int) porque la barra de progreso usa enteros
            int porcentaje = (int)((diasPasados * 100) / totalDiasPlan);
            
            // Tope visual 100%
            progresoEtapa.Value = porcentaje > 100 ? 100 : porcentaje;
        }
        else
        {
            progresoEtapa.Value = 0;
        }

        // --- C. ESTADO ---
        if (diasPasados >= totalDiasPlan && totalDiasPlan > 0)
            lblEtapaActual.Text = "Etapa: ¡Lista para Cosecha!";
        else
            lblEtapaActual.Text = "Etapa: En Progreso";
    }
    else
    {
        MetroMessageBox.Show(this, "No se encontró planta en este slot.");
        this.Close();
    }
}

        private void btnEliminarPlanta_Click(object sender, EventArgs e)
        {
            var result = MetroMessageBox.Show(this,
                $"¿Estás SEGURO de que deseas vaciar el Slot #{_slotId} y eliminar la planta '{_nombrePlanta}'?\n\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop);

            if (result == DialogResult.Yes)
            {
                // AQUI CONECTARÍAS CON LA BLL:
                // plantaBLL.EliminarPlantaDelSlot(_slotId);

                MetroMessageBox.Show(this, $"El Slot #{_slotId} ha sido vaciado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}