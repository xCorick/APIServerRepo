using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.Data
{
    public class PostgresSQLConfiguration
    {
        public string? connection {  get; set; }
        public PostgresSQLConfiguration(string Connection) => this.connection = Connection;
    }
}
