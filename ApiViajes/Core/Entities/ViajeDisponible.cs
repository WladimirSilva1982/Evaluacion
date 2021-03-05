using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiViajes.Core.Entities
{
    public class ViajeDisponible
    {
        [Key]
        public string CodViaje { get; set; }

        public int NroPlazas { get; set; }

        public string LugarDestino { get; set; }

        public string LugarOrigen { get; set; }

        public decimal Precio { get; set; }
    }
}
