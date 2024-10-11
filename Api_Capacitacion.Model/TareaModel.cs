﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Capacitacion.Model
{
    public class TareaModel
    {
        public int IdTarea { get; set; }
        public string? Tarea { get; set; }
        public string? Descripcion { get; set; }
        public bool Completada { get; set; }
        //public int idUsuario { get; set; }
        public UserModel User { get; set; }
    }
}
