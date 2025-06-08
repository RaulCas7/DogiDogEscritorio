﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogidogEscritorio.DataClass
{
    public class Empleado
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public string puesto { get; set; }
        public DateTime fechaContratacion { get; set; }
        public bool esAdministrador { get; set; }
    }
}
