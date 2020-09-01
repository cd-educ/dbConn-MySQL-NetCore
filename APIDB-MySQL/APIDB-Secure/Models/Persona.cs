using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDB_Secure.Models
{
    public class Persona
    {

        public Persona()
        {

        }

        public Persona(int id, string nombre, int edad)
        {
            this.id = id;
            this.nombre = nombre;
            this.edad = edad;
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }

    }

}
