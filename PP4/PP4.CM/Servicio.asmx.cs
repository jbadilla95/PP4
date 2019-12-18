using PP4.BL;
using PP4.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PP4.CM
{
    /// <summary>
    /// Summary description for Servicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicio : System.Web.Services.WebService
    {
        #region CRUD_Personas
        [WebMethod]
        public List<Persona> GetAllPersonas()
        {
            Persona_CRUD per = new Persona_CRUD();

            return per.Get();
        }

        [WebMethod]
        public void AgregaPersona(Persona item)
        {
            Persona_CRUD per = new Persona_CRUD();

            per.Insert(item);
        }

        [WebMethod]
        public void EliminarPersona(int id)
        {
            Persona_CRUD per = new Persona_CRUD();

            per.Delete(id);
        }

        [WebMethod]
        public Persona Getbyid(int id)
        {
            Persona_CRUD per = new Persona_CRUD();

            return per.GetrByID(id);
        }

        [WebMethod]
        public void ActualizarPersona(Persona item)
        {
            Persona_CRUD per = new Persona_CRUD();

            per.Update(item);
        }

        #endregion
        #region CRUD_PELICULAS

        [WebMethod]
        public void AgregaPelicula(Pelicula item)
        {
            Peliculas_CRUD per = new Peliculas_CRUD();
            
            
            per.Insert(item);
        }

        [WebMethod]
        public List<Pelicula> GetAllPeliculas()
        {
            Peliculas_CRUD per = new Peliculas_CRUD();

            return per.Get();
        }

        [WebMethod]
        public void EliminarPelicula(int id)
        {
            Peliculas_CRUD per = new Peliculas_CRUD();

            per.Delete(id);
        }

        [WebMethod]
        public Pelicula GetPeliculabyid(int id)
        {
            Peliculas_CRUD per = new Peliculas_CRUD();

            return per.GetrByID(id);
        }

        [WebMethod]
        public void ActualizarPelicula(Pelicula item)
        {
            Peliculas_CRUD per = new Peliculas_CRUD();

            per.Update(item);
        }
        #endregion
        #region CRUD SALAS
        [WebMethod]
        public void AgregaSala(Sala item)
        {
            Sala_CRUD per = new Sala_CRUD();

            per.Insert(item);
        }

        [WebMethod]
        public List<Sala> GetAllSalas()
        {
            Sala_CRUD per = new Sala_CRUD();

            return per.Get();
        }

        [WebMethod]
        public void EliminarSala(int id)
        {
            Sala_CRUD per = new Sala_CRUD();

            per.Delete(id);
        }

        [WebMethod]
        public Sala GetSalabyid(int id)
        {
            Sala_CRUD per = new Sala_CRUD();

            return per.GetrByID(id);
        }

        [WebMethod]
        public void ActualizarSala(Sala item)
        {
            Sala_CRUD per = new Sala_CRUD();

            per.Update(item);
        }
        #endregion
        #region CRUD Compras
        [WebMethod]
        public void AgregaCompra(Compra item)
        {
            Compra_CRUD per = new Compra_CRUD();

            per.Insert(item);
        }

        [WebMethod]
        public List<Compra> GetAllCompras()
        {
            Compra_CRUD per = new Compra_CRUD();

            return per.Get();
        }

        [WebMethod]
        public void EliminarCompra(int id)
        {
            Compra_CRUD per = new Compra_CRUD();

            per.Delete(id);
        }

        [WebMethod]
        public Compra GetComprabyid(int id)
        {
            Compra_CRUD per = new Compra_CRUD();

            return per.GetrByID(id);
        }

        [WebMethod]
        public void ActualizarCompra(Compra item)
        {
            Compra_CRUD per = new Compra_CRUD();

            per.Update(item);
        }
        #endregion
        #region CRUD Asientos
        [WebMethod]
        public void AgregaAsiento(Asientos item)
        {
             Asientos_CRUD per = new Asientos_CRUD();

            per.Insert(item);
        }

        [WebMethod]
        public List<Asientos> GetAllAsientos()
        {
            Asientos_CRUD per = new Asientos_CRUD();

            return per.Get();
        }

        [WebMethod]
        public void EliminarAsientos(int id)
        {
            Asientos_CRUD per = new Asientos_CRUD();

            per.Delete(id);
        }

        [WebMethod]
        public Asientos GetAsientosbyid(int id)
        {
            Asientos_CRUD per = new Asientos_CRUD();

            return per.GetrByID(id);
        }

        [WebMethod]
        public void ActualizarAsiento(Asientos item)
        {
            Asientos_CRUD per = new Asientos_CRUD();

            per.Update(item);
        }
        #endregion
        #region Tandas

        [WebMethod]
        public List<Tanda> GetAllTandas()
        {
            CRUD_Tanda per = new CRUD_Tanda();

            return per.Get();
        }

        [WebMethod]
        public void AgregaTanda(Tanda item)
        {
            CRUD_Tanda per = new CRUD_Tanda();

            per.Insert(item);
        }

        [WebMethod]
        public void EliminarTanda(int id)
        {
            CRUD_Tanda per = new CRUD_Tanda();

            per.Delete(id);
        }

        [WebMethod]
        public Tanda GetTandabyID(int id)
        {
            CRUD_Tanda per = new CRUD_Tanda();

            return per.GetrByID(id);
        }

        [WebMethod]
        public void ActualizarTanda(Tanda item)
        {
            CRUD_Tanda per = new CRUD_Tanda();

            per.Update(item);
        }
        #endregion

    }
}
