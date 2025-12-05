using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class EtapaCultivoBLL
    {
        private EtapaCultivoDAO dao = new EtapaCultivoDAO();

        public List<EtapaCultivo> ListarPorPlan(int idPlan)
        {
            return dao.ListarPorPlan(idPlan);
        }

       

        public void ModificarEtapaPlan(EtapaCultivo etapa)
        {
            throw new NotImplementedException();
        }
    }
}