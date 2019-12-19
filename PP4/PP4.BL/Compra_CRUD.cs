using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP4.DAL;

namespace PP4.BL
{
    public class Compra_CRUD : IRepositorio<Compra>
    {
        public void Delete(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    var toDelete = context.Compra.Where(x => x.ID_Compra == Id).SingleOrDefault();
                    if (toDelete != null) // si la tabla no está vacia entonces ingresará a eleiminar , de lo contrario no es necesario que vaya a consultar 
                    {
                        context.Compra.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO COMPRA:  " + exp.Message);
                }
            }
        }

        public List<Compra> Get()
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Compra.ToList();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR :  " + exp.Message);
                }
            }
            return null;
        }

        public Compra GetrByID(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Compra.Where(x => x.ID_Compra == Id).SingleOrDefault(); //me muestra el que es por defecto o el primero 
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO COMPRA:  " + exp.Message);
                }
            }
            return null;
        }

        public void Insert(Compra item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    context.Compra.Add(item);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR EJECUTANDO COMPRA:  " + exp.Message);
                }
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Compra item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {

                    var updato = context.Compra.Where(x => x.ID_Compra == item.ID_Compra).SingleOrDefault();  //first last or tolist
                    updato.Fecha = item.Fecha;
                    
                    updato.Total_Pagar = item.Total_Pagar;
                    updato.ID_persona = item.ID_persona;
                    //preguntar si hay forma de no hacerlo uno a uno 


                    //context.Entry(updato).State = System.Data.Entity.EntityState.Modified; // le estoy diciendo al entity que fue cambiado 

                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR ACTUALIZANDO COMPRA:  " + exp.Message);
                }

            }
        
    }
    }
}
