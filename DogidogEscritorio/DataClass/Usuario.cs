using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogidogEscritorio.DataClass
{
    public class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int contadorPreguntas { get; set; }
        public double? latitud { get; set; }
        public double? longitud { get; set; }
        public int? valoracion { get; set; }
        public int? foto { get; set; }
    }
}
