using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioAlquiler.MODELS
{
    public class alquilerModels
    {
        public int ID_Alquiler { get; set; }
        public int ID_Coche { get; set; }
        public int ID_Cliente { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
    }
}
