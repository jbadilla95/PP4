using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP4.DAL;

namespace PP4.BL
{
  public class Asientos_CRUD : IRepositorio<Asientos>
    {
        public void Delete(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    var toDelete = context.Asientos.Where(x => x.ID_Asientos == Id).SingleOrDefault();
                    if (toDelete != null) // si la tabla no está vacia entonces ingresará a eleiminar , de lo contrario no es necesario que vaya a consultar 
                    {
                        context.Asientos.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BORRANDO ASIENTO:  " + exp.Message);
                }
            }
        }

        public List<Asientos> Get()
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Asientos.ToList();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR :  " + exp.Message);
                }
            }
            return null;
        }

        public Asientos GetrByID(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Asientos.Where(x => x.ID_Asientos == Id).SingleOrDefault(); //me muestra el que es por defecto o el primero 
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO COMPRA:  " + exp.Message);
                }
            }
            return null;
        }

        public void Insert(Asientos item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    context.Asientos.Add(item);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR INGRESANDO ASIENTO:  " + exp.Message);
                }
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Asientos item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {

                    var updato = context.Asientos.Where(x => x.ID_Asientos == item.ID_Asientos).SingleOrDefault();  //first last or tolist
                    updato.ID_Asientos = item.ID_Asientos;
                    updato.Desc_Asientos = item.Desc_Asientos;
                  
                    //preguntar si hay forma de no hacerlo uno a uno 


                    //context.Entry(updato).State = System.Data.Entity.EntityState.Modified; // le estoy diciendo al entity que fue cambiado 

                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR ACTUALIZANDO ASIENTO:  " + exp.Message);
                }

            }

        }
    }
}

