using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

    [OperationContract]
    Persona RetornarPersona(int cedula);

    // TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
//todos los metodos que van en la interfaz deben de ir acá 
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}

[DataContract]
public class Persona
{
    
    string Nombre;
    int cedula;
    string correo;
    string contraseña;
    bool tipo;

    [DataMember]
    public string Nombre1
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
            return cedula;
        }

        set
        {
            cedula = value;
        }
    }
    [DataMember]
    public int Correo
    {
        get
        {
            return Correo;
        }

        set
        {
            Correo = value;
        }
    }

    [DataMember]
    public int Contraseña
    {
        get
        {
            return Contraseña;
        }

        set
        {
            Contraseña = value;
        }
    }
}
