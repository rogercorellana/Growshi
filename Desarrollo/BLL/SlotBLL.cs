using System.Collections.Generic;
using BE;
using DAL.Daos;

namespace BLL
{
    public class SlotBLL
    {
        private SlotDAO dao = new SlotDAO();

        public List<Slot> ListarSlots(int usuarioId)
        {
            List<Slot> slots = dao.ObtenerSlotsPorUsuario(usuarioId);

            if (slots.Count == 0)
            {
                dao.AsignarPermisosHardware(usuarioId);

                slots = dao.ObtenerSlotsPorUsuario(usuarioId);
            }

            return slots;
        }


        public void ApagarSlot(int slotId)
        {
            
            dao.DeshabilitarSlot(slotId);
        }

        public void EncenderSlot(int slotId)
        {
            dao.HabilitarSlot(slotId);
        }

    }
}