using System.Collections.Generic;
using BE;
using DAL.Daos;

namespace BLL
{
    public class PlantaBLL
    {
        private PlantaDAO plantaDao = new PlantaDAO();
        private SlotDAO slotDao = new SlotDAO();
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
            }
        }
    }
}