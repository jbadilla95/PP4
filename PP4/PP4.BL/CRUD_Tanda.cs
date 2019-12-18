using PP4.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PP4.BL
{
    public class CRUD_Tanda : IRepositorio<Tanda>
    {
        public void Delete(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    var toDelete = context.Tandas.Where(x => x.ID_tanda == Id).SingleOrDefault();
                    if (toDelete != null) // si la tabla no está vacia entonces ingresará a eleiminar , de lo contrario no es necesario que vaya a consultar 
                    {
                        context.Tandas.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR ELIMINANDO TANDA:  " + exp.Message);
                }
            }
        }

        public List<Tanda> Get()
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Tandas.ToList();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR :  " + exp.Message);
                }
            }
            return null;
        }



        public Tanda GetrByID(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Tandas.Where(x => x.ID_tanda == Id).SingleOrDefault(); //me muestra el que es por defecto o el primero 
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO Tanda:  " + exp.Message);
                }
            }
            return null;
        }

        public void Insert(Tanda item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    context.Tandas.Add(item);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR INGRESANDO TANDA:  " + exp.Message);
                }
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Tanda item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {

                    var updato = context.Tandas.Where(x => x.ID_tanda == item.ID_tanda).SingleOrDefault();  //first last or tolist
                    updato.ID_pelicula = item.ID_pelicula;
                    updato.ID_sala = item.ID_sala;
                    updato.ID_tanda = item.ID_tanda;
                    

                    //preguntar si hay forma de no hacerlo uno a uno 


                    context.Entry(updato).State = System.Data.Entity.EntityState.Modified; // le estoy diciendo al entity que fue cambiado 

                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR ACTUALIZANDO Tanda:  " + exp.Message);
                }

            }
        }


    }
}
