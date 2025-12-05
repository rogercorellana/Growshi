using BE;
using DAL;
using DAL.Daos;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PlanCultivoBLL
    {
        PlanCultivoDAO planCultivoDAO = new PlanCultivoDAO();

        private readonly ISessionService<Usuario> _sessionService = SessionService<Usuario>.GetInstance();
        private readonly IBitacoraService _bitacoraService = BitacoraService.GetInstance();
        private readonly BitacoraDAO _bitacoraDAO = new BitacoraDAO();

        public List<PlanCultivo> Listar()
        {
            return planCultivoDAO.Listar();
        }

        public void GuardarPlan(PlanCultivo plan, int usuarioID)
        {
            if (string.IsNullOrWhiteSpace(plan.NombrePlan))
            {
                throw new Exception("El nombre del plan no puede estar vacío.");
            }

            if (plan.Etapas == null || plan.Etapas.Count < 3)
            {
                throw new Exception("El sistema requiere que se definan las 3 etapas (Germinación, Vegetación y Floración).");
            }

            bool resultado = planCultivoDAO.Alta(plan, usuarioID);

            if (!resultado)
            {
                #region Evento en bitácora - Plan de cultivo creado INCORRECTAMENTE

                IBitacora eventoLogout = _bitacoraService.CrearEvento(
                    NivelCriticidad.Error,
                    $"Intento de creacion de Plan de cultivo INCORRECTAMENTE por el usuario: '{_sessionService.UsuarioLogueado.NombreUsuario}'.",
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

                throw new Exception("No se pudo guardar el plan en la base de datos.");
            }
            else
            {
                #region Evento en bitácora - Plan de cultivo creado correctamente

                IBitacora eventoLogout = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"Plan de cultivo creado exitosamente por el usuario: '{_sessionService.UsuarioLogueado.NombreUsuario}'.",
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


        public void ModificarPlan(PlanCultivo planEditado)
        {
            // 1. Validaciones
            if (string.IsNullOrWhiteSpace(planEditado.NombrePlan))
            {
                throw new Exception("El nombre del plan no puede estar vacío.");
            }

            // 2. Intentar Modificar
            bool resultado = planCultivoDAO.modificarPlan(planEditado);

            if (!resultado)
            {
                #region Bitácora - Error al Modificar
                IBitacora eventoError = _bitacoraService.CrearEvento(
                    NivelCriticidad.Error,
                    $"Error al intentar modificar el Plan ID {planEditado.PlanCultivoID} por: '{_sessionService.UsuarioLogueado.NombreUsuario}'.",
                    "Agricultura",
                    _sessionService.UsuarioLogueado.IdUsuario
                );

                // Mapeo manual como lo tienes en tu código
                var logDb = new Bitacora
                {
                    Nivel = eventoError.Nivel,
                    Mensaje = eventoError.Mensaje,
                    Modulo = eventoError.Modulo,
                    UsuarioID = eventoError.UsuarioID
                };
                _bitacoraDAO.Guardar(logDb);
                #endregion

                throw new Exception("No se pudieron guardar los cambios en la base de datos.");
            }
            else
            {
                #region Bitácora - Éxito al Modificar
                IBitacora eventoExito = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"Plan de cultivo '{planEditado.NombrePlan}' (ID: {planEditado.PlanCultivoID}) modificado exitosamente.",
                    "Agricultura",
                    _sessionService.UsuarioLogueado.IdUsuario
                );

                var logDb = new Bitacora
                {
                    Nivel = eventoExito.Nivel,
                    Mensaje = eventoExito.Mensaje,
                    Modulo = eventoExito.Modulo,
                    UsuarioID = eventoExito.UsuarioID
                };
                _bitacoraDAO.Guardar(logDb);
                #endregion
            }
        }


        public void EliminarPlan(int idPlan, string nombrePlan)
        {
            // Intentamos eliminar
            bool resultado = planCultivoDAO.Eliminar(idPlan);

            if (!resultado)
            {
                #region Bitácora - Error al Eliminar
                IBitacora eventoError = _bitacoraService.CrearEvento(
                    NivelCriticidad.Error,
                    $"Error al intentar eliminar el Plan '{nombrePlan}' (ID: {idPlan}).",
                    "Agricultura",
                    _sessionService.UsuarioLogueado.IdUsuario
                );

                var logDb = new Bitacora
                {
                    Nivel = eventoError.Nivel,
                    Mensaje = eventoError.Mensaje,
                    Modulo = eventoError.Modulo,
                    UsuarioID = eventoError.UsuarioID
                };
                _bitacoraDAO.Guardar(logDb);
                #endregion

                throw new Exception("No se pudo eliminar el plan de la base de datos.");
            }
            else
            {
                #region Bitácora - Éxito al Eliminar
                IBitacora eventoExito = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"Plan de cultivo '{nombrePlan}' (ID: {idPlan}) eliminado correctamente.",
                    "Agricultura",
                    _sessionService.UsuarioLogueado.IdUsuario
                );

                var logDb = new Bitacora
                {
                    Nivel = eventoExito.Nivel,
                    Mensaje = eventoExito.Mensaje,
                    Modulo = eventoExito.Modulo,
                    UsuarioID = eventoExito.UsuarioID
                };
                _bitacoraDAO.Guardar(logDb);
                #endregion
            }
        }
    }
}