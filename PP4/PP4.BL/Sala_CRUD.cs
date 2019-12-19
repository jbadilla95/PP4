using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP4.DAL;

namespace PP4.BL
{
    public class Sala_CRUD : IRepositorio<Sala_Cantidad>
    {
        public void Delete(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    var toDelete = context.Sala_Cantidad.Where(x => x.ID_SCantidad == Id).SingleOrDefault();
                    if (toDelete != null) // si la tabla no está vacia entonces ingresará a eleiminar , de lo contrario no es necesario que vaya a consultar 
                    {
                        context.Sala_Cantidad.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO SALA:  " + exp.Message);
                }
            }
        }

        public List<Sala_Cantidad> Get()
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Sala_Cantidad.ToList();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR :  " + exp.Message);
                }
            }
            return null;
        }

        public Sala_Cantidad GetrByID(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Sala_Cantidad.Where(x => x.ID_SCantidad == Id).SingleOrDefault(); //me muestra el que es por defecto o el primero 
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO SALA:  " + exp.Message);
                }
            }
            return null;
        }

        public void Insert(Sala_Cantidad item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    context.Sala_Cantidad.Add(item);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR INGRESANDO SALA:  " + exp.Message);
                }
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Sala_Cantidad item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {

                    var updato = context.Sala_Cantidad.Where(x => x.ID_SCantidad == item.ID_SCantidad).SingleOrDefault();  //first last or tolist
                    updato.ID_SCantidad = item.ID_SCantidad;
                    updato.ID_Asiento = item.ID_Asiento;
                    updato.Cantidad_total = item.Cantidad_total;
                    updato.Cantidad_disponible = item.Cantidad_disponible;


                    //preguntar si hay forma de no hacerlo uno a uno 


                    //context.Entry(updato).State = System.Data.Entity.EntityState.Modified; // le estoy diciendo al entity que fue cambiado 

                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR ACTUALIZANDO SALA:  " + exp.Message);
                }

            }
        }

           
            
        }
}
