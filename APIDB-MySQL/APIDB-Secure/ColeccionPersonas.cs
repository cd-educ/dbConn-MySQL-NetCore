using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using APIDB_Secure.Models;
using APIDB_Secure;

namespace APIDB_Secure
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

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();
            queryBuilder.setQuery("SELECT * FROM personas");

            var dataReader = DBConnection.getInstance().select(queryBuilder);
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

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();
            
            queryBuilder.setQuery("SELECT * FROM personas WHERE id=@id");
            queryBuilder.addParam("@id", id);

            var dataReader = DBConnection.getInstance().select(queryBuilder);
            Persona persona = null;
            while (dataReader.Read())
            {
                persona = new Persona(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
            }

            return persona;

        }

        public void agregarPersona(Persona persona)
        {

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("INSERT INTO personas (nombre,edad) VALUES (@nombre,@edad)");
            queryBuilder.addParam("@nombre", persona.nombre);
            queryBuilder.addParam("@edad", persona.edad);

            //this.personas.Add(persona)
            DBConnection.getInstance().abm(queryBuilder);

        }

        public void eliminarPersona(Persona persona)
        {
            //this.personas.Remove(persona)

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("DELETE FROM personas WHERE id=@id");
            queryBuilder.addParam("@id", persona.id);

            DBConnection.getInstance().abm(queryBuilder);

        }

        // SOBRECARGA
        public void eliminarPersona(int id)
        {
            //this.personas.Remove(persona)

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("DELETE FROM personas WHERE id=@id");
            queryBuilder.addParam("@id", id);

            DBConnection.getInstance().abm(queryBuilder);

        }

        public void actualizarPersona(Persona persona)
        {

            /*this.eliminarPersona(id);
            this.agregarPersona(persona);*/

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("UPDATE personas SET nombre=@nombre,edad=@edad WHERE id=@id");
            queryBuilder.addParam("@id", persona.id);
            queryBuilder.addParam("@nombre", persona.nombre);
            queryBuilder.addParam("@edad", persona.edad);

            DBConnection.getInstance().abm(queryBuilder);


        }

    }
}
