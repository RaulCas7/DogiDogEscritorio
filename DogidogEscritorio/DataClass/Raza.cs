using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogidogEscritorio.DataClass
{
    public class Raza
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public byte energia { get; set; }
        public byte inteligencia { get; set; }
        public byte socializacion { get; set; }
        public byte cuidado { get; set; }
        public decimal pesoMinMacho { get; set; }
        public decimal pesoMaxMacho { get; set; }
        public decimal pesoMinHembra { get; set; }
        public decimal pesoMaxHembra { get; set; }
        public int edadMaxima { get; set; }
        public string descripcion { get; set; }
        public string datoCurioso { get; set; }
    }
}
