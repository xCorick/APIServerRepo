using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Capacitacion.Model
{
    public class UserModel
    {
        public int idUsuario { get; set; }
        public string? nombres { get; set; }
        public string? usuario { get; set; }
        public string? contrasena { get; set; }
    }
}
