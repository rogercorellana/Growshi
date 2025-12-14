using System;
using System.Collections.Generic;
using BE;
using DAL.Daos;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;

namespace BLL
{
    public class PlantaBLL
    {
        private PlantaDAO plantaDao = new PlantaDAO();
        private SlotDAO slotDao = new SlotDAO();

        private readonly ISessionService<Usuario> _sessionService = SessionService<Usuario>.GetInstance();
        private readonly IBitacoraService _bitacoraService = BitacoraService.GetInstance();
        private readonly BitacoraDAO _bitacoraDAO = new BitacoraDAO();



        public List<Planta> Listar()
        {
            return plantaDao.Listar();
        }

        public void GuardarNuevaSiembra(Planta planta, int slotId)
        {
            int nuevaPlantaId = plantaDao.Insertar(planta);

            if (nuevaPlantaId > 0)
            {
                slotDao.AsignarPlanta(slotId, nuevaPlantaId);

                #region Evento en bitácora - Planta Guardada y asignada correctamente



                IBitacora eventoLogout = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"Planta creada correctadamente por el usuario '{_sessionService.UsuarioLogueado.NombreUsuario}'.",
                    "Agricultura",
                    _sessionService.UsuarioLogueado.IdUsuario
                );
                var bitacoraParaGuardar = new Bitacora
                {
                    Nivel = eventoLogout.Nivel,
                    Mensaje = eventoLogout.Mensaje,
                    Modulo = eventoLogout.Modulo,
                    UsuarioID = eventoLogout.UsuarioID
                };


                _bitacoraDAO.Guardar(bitacoraParaGuardar);

                #endregion
            }

            else
            {
                #region Evento en bitácora - Planta Guardada y asignada INCORRECTAMENTE

                IBitacora eventoLogout = _bitacoraService.CrearEvento(
                    NivelCriticidad.Critico,
                    $"Intento INCORRECTO de creacion de planta por el usuario '{_sessionService.UsuarioLogueado.NombreUsuario}'.",
                    "Agricultura",
                    _sessionService.UsuarioLogueado.IdUsuario
                );
                var bitacoraParaGuardar = new Bitacora
                {
                    Nivel = eventoLogout.Nivel,
                    Mensaje = eventoLogout.Mensaje,
                    Modulo = eventoLogout.Modulo,
                    UsuarioID = eventoLogout.UsuarioID
                };


                _bitacoraDAO.Guardar(bitacoraParaGuardar);

                #endregion
            }
        }

        public Planta ObtenerPorSlot(int slotId)
        {
            return plantaDao.ObtenerPorSlot(slotId);
        }

        public void EliminarPlantaDelSlot(int slotId, int idPlanta)
        {
            slotDao.EliminarPlantaDelSlot(slotId, idPlanta);
        }




        // LÓGICA 1: Calcular fecha estimada
        public DateTime CalcularFechaCosecha(Planta planta)
        {
            if (planta == null) return DateTime.Now;
            double dias = planta.DiasTotalesPlan.GetValueOrDefault();
            return planta.FechaInicio.AddDays(dias);
        }

        // LÓGICA 2: Calcular días transcurridos
        public int CalcularDiasPasados(Planta planta)
        {
            if (planta == null) return 0;
            TimeSpan diff = DateTime.Now - planta.FechaInicio;
            int dias = diff.Days + 1; // +1 para contar el día de hoy
            return dias < 0 ? 0 : dias;
        }

        // LÓGICA 3: Calcular porcentaje (0 a 100)
        public int CalcularPorcentajeProgreso(Planta planta)
        {
            if (planta == null) return 0;
            double total = planta.DiasTotalesPlan.GetValueOrDefault();
            if (total <= 0) return 0;

            int pasados = CalcularDiasPasados(planta);
            int porcentaje = (int)((pasados * 100) / total);

            return porcentaje > 100 ? 100 : porcentaje;
        }

        // LÓGICA 4: Determinar el texto de la etapa (LO QUE PEDISTE)
        public string ObtenerEstadoEtapa(Planta planta)
        {
            if (planta == null) return "Sin Datos";

            int porcentaje = CalcularPorcentajeProgreso(planta);
            int diasPasados = CalcularDiasPasados(planta);
            double diasTotales = planta.DiasTotalesPlan.GetValueOrDefault();

            if (diasTotales <= 0) return "Etapa: Configuración Pendiente";

            if (porcentaje >= 100)
            {
                return "Etapa: ¡Lista para Cosecha!";
            }
            else if (porcentaje < 10)
            {
                return "Etapa: Germinación / Inicial";
            }
            else if (porcentaje < 50)
            {
                return "Etapa: Crecimiento Vegetativo";
            }
            else
            {
                return "Etapa: Floración / Maduración";
            }
        }


    }
}