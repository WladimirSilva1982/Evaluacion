using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiViajes.Core.Entities
{
    public class ViajeDispoViajero
    {
        [Key]
        public string Cedula { get; set; }

        public string CodViaje { get; set; }
    }
}
