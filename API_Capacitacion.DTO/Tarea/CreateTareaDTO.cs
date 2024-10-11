using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.DTO.Tarea
{
    public class CreateTareaDTO
    {
        public string? Tarea { get; set; }
        public string? Descripcion { get; set; }
        public int idUsuario { get; set; }
    }
}
