using Interfaces.IBE;
using Interfaces.IDAL;
using Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BitacoraService : IBitacoraService
    {
        public BitacoraService() { }



        public DataTable Registrar(string mensaje, int usuario)
        {

            // 1. Crea una instancia de DataTable (puedes darle un nombre)
            var tablaBitacora = new DataTable("Bitacora");

            // 2. Define las columnas que tendrá tu tabla
            //    addColumn(nombre_columna, tipo_de_dato)
            tablaBitacora.Columns.Add("Mensaje", typeof(string));
            tablaBitacora.Columns.Add("Usuario", typeof(string)); // Guardamos el nombre de usuario como string
            tablaBitacora.Columns.Add("Fecha", typeof(DateTime));

            // 3. Crea una nueva fila usando la estructura de la tabla
            DataRow nuevaFila = tablaBitacora.NewRow();

            // 4. Asigna los valores a cada columna de esa fila
            nuevaFila["Mensaje"] = mensaje;
            nuevaFila["Usuario"] = usuario; // Accedemos a la propiedad del usuario
            nuevaFila["Fecha"] = DateTime.Now;

            // 5. Agrega la fila completa a la tabla
            tablaBitacora.Rows.Add(nuevaFila);

            // 6. Retorna la tabla ya cargada
            return tablaBitacora;
        }
    }
}
