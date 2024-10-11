using Api_Capacitacion.Model;
using API_Capacitacion.DTO.Tarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.Data.Interfaces
{
    public interface ITareaServices
    {
        public Task<TareaModel> Create(CreateTareaDTO createTareaDTO); 
    }
}
