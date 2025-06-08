using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DogidogEscritorio.DataClass
{
    public class Tarea
    {
        [JsonPropertyName("id")]
        public int Id_Tarea { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }
        public Prioridad Prioridad { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }

    public enum Estado
    {
        Pendiente, 
        Completada,
        Cancelada,
        Abierta,
        EnProgreso,
        Cerrada
    }

}
