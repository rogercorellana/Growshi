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
    }
}