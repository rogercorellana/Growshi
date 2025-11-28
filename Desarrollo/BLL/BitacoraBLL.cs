using System.Collections.Generic;
using BE;
using DAL.Daos;

namespace BLL
{
    public class BitacoraBLL
    {
        private BitacoraDAO _dao;

        public BitacoraBLL()
        {
            _dao = new BitacoraDAO();
        }

        public List<Bitacora> Listar()
        {
            return _dao.ObtenerTodos();
        }

        public void Registrar(Bitacora evento)
        {
            _dao.Guardar(evento);
        }
    }
}