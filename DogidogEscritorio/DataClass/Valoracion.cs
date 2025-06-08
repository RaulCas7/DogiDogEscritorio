using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogidogEscritorio.DataClass
{
    public class Valoracion
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }         
        public Usuario valorado { get; set; }       
        public int puntuacion { get; set; }
        public string comentario { get; set; }
        public DateTime fechaValoracion { get; set; }
    }
}
