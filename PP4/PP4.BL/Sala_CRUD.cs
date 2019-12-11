using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP4.DAL;

namespace PP4.BL
{
    public class Sala_CRUD : IRepositorio<Sala>
    {
        public void Delete(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    var toDelete = context.Sala.Where(x => x.ID_Sala == Id).SingleOrDefault();
                    if (toDelete != null) // si la tabla no está vacia entonces ingresará a eleiminar , de lo contrario no es necesario que vaya a consultar 
                    {
                        context.Sala.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO SALA:  " + exp.Message);
                }
            }
        }

        public List<Sala> Get()
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Sala.ToList();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR :  " + exp.Message);
                }
            }
            return null;
        }

        public Sala GetrByID(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Sala.Where(x => x.ID_Sala == Id).SingleOrDefault(); //me muestra el que es por defecto o el primero 
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO SALA:  " + exp.Message);
                }
            }
            return null;
        }

        public void Insert(Sala item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    context.Sala.Add(item);
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

        public void Update(Sala item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {

                    var updato = context.Sala.Where(x => x.ID_Sala == item.ID_Sala).SingleOrDefault();  //first last or tolist
                    updato.Desc_sala = item.Desc_sala;

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
