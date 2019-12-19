using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP4.DAL;

namespace PP4.BL
{
    public class Peliculas_CRUD : IRepositorio<Pelicula>
    {
        public void Delete(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    var toDelete = context.Pelicula.Where(x => x.ID_Pelicula == Id).SingleOrDefault();
                    if (toDelete != null) // si la tabla no está vacia entonces ingresará a eleiminar , de lo contrario no es necesario que vaya a consultar 
                    {
                        context.Pelicula.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO PELICULA:  " + exp.Message);
                }
            }
        }

        public List<Pelicula> Get()
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Pelicula.ToList();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR :  " + exp.Message);
                }
            }
            return null;
        }

        public Pelicula GetrByID(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Pelicula.Where(x => x.ID_Pelicula == Id).SingleOrDefault(); //me muestra el que es por defecto o el primero 
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO PELICULA:  " + exp.Message);
                }
            }
            return null;
        }

        public List<Pelicula> Getsalas(int id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Pelicula.Where(x => x.ID_sala == id).ToList();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR :  " + exp.Message);
                }
            }
            return null;
        }

        public void Insert(Pelicula item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    context.Pelicula.Add(item);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR INGRESANDO PELICULA:  " + exp.Message);
                }
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Pelicula item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {

                    var updato = context.Pelicula.Where(x => x.ID_Pelicula == item.ID_Pelicula).SingleOrDefault();  //first last or tolist
                    updato.Descripcion_Pelicula = item.Descripcion_Pelicula;
                    updato.Duracion = item.Duracion;
                    updato.Estado = item.Estado;
                    updato.horario = item.horario;

                    //preguntar si hay forma de no hacerlo uno a uno 


                    //context.Entry(updato).State = System.Data.Entity.EntityState.Modified; // le estoy diciendo al entity que fue cambiado 

                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR ACTUALIZANDO PELICULA:  " + exp.Message);
                }

            }
        }
    }
}
