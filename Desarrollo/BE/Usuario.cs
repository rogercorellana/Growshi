using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.IBE;

namespace BE
{

    public class Usuario : IUsuarioLogueado
    {

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public List<string> Permisos { get; set; }
        public int IdiomaPreferidoID { get; set; }
        public Usuario()
        {
            this.Permisos = new List<string>();
        }


        public override string ToString()
        {
            
            return this.NombreUsuario;
        }


    }
}
