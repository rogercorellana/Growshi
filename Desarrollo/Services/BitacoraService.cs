using Interfaces.IBE;
using Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    // DTO interno para transportar los datos del evento.
    internal class BitacoraDTO : IBitacora
    {
        public int BitacoraID { get; set; }
        public int? UsuarioID { get; set; }
        public DateTime FechaHora { get; set; }
        public NivelCriticidad Nivel { get; set; }
        public string Modulo { get; set; }
        public string Mensaje { get; set; }
    }

    public sealed class BitacoraService : IBitacoraService
    {
        private static readonly IBitacoraService _instancia = new BitacoraService();

        private BitacoraService() { }

        public static IBitacoraService GetInstance() => _instancia;

        // El método ahora es mucho más simple: solo crea y devuelve.
        public IBitacora CrearEvento(NivelCriticidad nivel, string mensaje, string modulo = null, int? usuarioId = null)
        {
            return new BitacoraDTO
            {
                Nivel = nivel,
                Mensaje = mensaje,
                Modulo = modulo,
                UsuarioID = usuarioId,
                FechaHora = DateTime.Now
            };
        }
    }
}
