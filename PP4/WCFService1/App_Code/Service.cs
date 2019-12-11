using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient; //Representa una coneccion a SQL server , basicamente me permite usar el dataset con la ayuda de mi connection string
using PP4.DAL;
using PP4.BL;
using System.Security;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public Persona_Service BuscarPersona(int ID_Persona)
    {
        throw new NotImplementedException();
    }

    public int EditarPersona(Persona_Service persona_)
    {
        throw new NotImplementedException();
    }

    public int EliminarPersona(int ID_Persona)
    {
        throw new NotImplementedException();
    }

    public List<Persona_Service> MostrarPersona()
    {
        throw new NotImplementedException();
    }

    public void NuevaPersona(Persona_Service persona_)
    {
        Persona_CRUD per = new Persona_CRUD();
        Persona nuevo = new Persona();
        persona_.Nombre = nuevo.Nombre;
        persona_.correo = nuevo.correo;
        persona_.contraseña = nuevo.contraseña;
        persona_.tipo_perfil = nuevo.tipo_perfil;

        per.Insert(nuevo);
        

    
    }
}
