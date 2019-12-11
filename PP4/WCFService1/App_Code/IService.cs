using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Security;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    [OperationContract]
    void NuevaPersona(Persona_Service persona_);

    [OperationContract]
    int EditarPersona(Persona_Service persona_);

    [OperationContract]
    int EliminarPersona(int ID_Persona);

    [OperationContract]
    Persona_Service BuscarPersona(int ID_Persona);

    [OperationContract]
    List<Persona_Service> MostrarPersona();

    // TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class Persona_Service
{
    
    [DataMember]
    public string Nombre
    {
        get
        {
            return Nombre;
        }

        set
        {
            Nombre = value;
        }
    }
    [DataMember]
    public int Cedula
    {
        get
        {
            return Cedula;
        }

        set
        {
            Cedula = value;
        }
    }
    [DataMember]
    public string correo
    {
        get
        {
            return correo;
        }

        set
        {
            correo = value;
        }
    }
    [DataMember]
    public string contraseña
    {
        get
        {
            return contraseña;
        }

        set
        {
            contraseña = value;
        }
    }
    [DataMember]
    public Boolean tipo_perfil
    {
        get
        {
            return tipo_perfil;
        }

        set
        {
            tipo_perfil = value;
        }

    }
}

