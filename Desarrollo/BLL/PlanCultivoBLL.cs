using BE;
using DAL;
using DAL.Daos;
using Interfaces.IServices;
using Services;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PlanCultivoBLL
    {
        PlanCultivoDAO planCultivoDAO = new PlanCultivoDAO();


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
                throw new Exception("No se pudo guardar el plan en la base de datos.");
            }
        }
    }
}