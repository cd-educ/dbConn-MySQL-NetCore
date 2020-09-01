using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using APIDB_Insecure.Models;
using APIDB_Insecure;

namespace APIDB_Insecure
{
    public class ColeccionPersonas
    {

        public static ColeccionPersonas instance;
        /*public List<Persona> personas = new List<Persona>();
        private ColeccionPersonas()
        {
            personas.Add(new Persona(1, "Jorge", 23));
            personas.Add(new Persona(2, "Facundo", 12));
            personas.Add(new Persona(3, "Mariana", 37));
            personas.Add(new Persona(4, "Sofia", 18));
            personas.Add(new Persona(5, "Marcelo", 10));
        }*/

        public static ColeccionPersonas getInstance()
        {
            if (instance == null)
            {
                ColeccionPersonas.instance = new ColeccionPersonas();
            }

            return instance;

        }

        public List<Persona> verPersonas()
        {
            //return personas;

            var dataReader = DBConnection.getInstance().select("SELECT * FROM personas");
            var lista = new List<Persona>();
            while (dataReader.Read())
            {
                var persona = new Persona(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                lista.Add(persona);
            }

            return lista;

        }

        public Persona verPersona(int id)
        {

            var dataReader = DBConnection.getInstance().select("SELECT * FROM personas WHERE id=" + id);
            Persona persona = null;
            while (dataReader.Read())
            {
                persona = new Persona(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
            }

            return persona;

        }

        public void agregarPersona(Persona persona)
        {

            //this.personas.Add(persona)
            DBConnection.getInstance().insert("INSERT INTO personas (nombre,edad) VALUES ("+ persona.nombre + "," + persona.edad + ")");

        }

        public void eliminarPersona(Persona persona)
        {
            //this.personas.Remove(persona)
            DBConnection.getInstance().delete("DELETE FROM personas WHERE id=" + persona.id);
        }

        // SOBRECARGA
        public void eliminarPersona(int id)
        {
            //this.personas.Remove(persona)
            DBConnection.getInstance().delete("DELETE FROM personas WHERE id=" + id);
        }

        public void actualizarPersona(Persona persona)
        {

            /*this.eliminarPersona(id);
            this.agregarPersona(persona);*/

            DBConnection.getInstance().update("UPDATE personas SET nombre=" + persona.nombre + ",edad=" + persona.edad + " WHERE id=" + persona.id);

        }

    }
}
