using PP4.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.BL
{
    public class Persona_CRUD : IRepositorio<Persona>
    {
        public void Delete(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    var toDelete = context.Persona.Where(x => x.ID_Persona== Id).SingleOrDefault();
                    if (toDelete != null) // si la tabla no está vacia entonces ingresará a eleiminar , de lo contrario no es necesario que vaya a consultar 
                    {
                        context.Persona.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO PERSONA:  " + exp.Message);
                }
            }
        }

        public IEnumerable Get()
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Persona.ToList();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR :  " + exp.Message);
                }
            }
            return null;
        }

        public Persona GetrByID(int Id)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    return context.Persona.Where(x => x.ID_Persona == Id).SingleOrDefault(); //me muestra el que es por defecto o el primero 
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR BUSCANDO PERSONA:  " + exp.Message);
                }
            }
            return null;
        }

        public void Insert(Persona item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {
                    context.Persona.Add(item);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR INGRESANDO PERSONA:  " + exp.Message);
                }
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Persona item)
        {
            using (DBCPP4 context = new DBCPP4())
            {
                try
                {

                    var updato = context.Persona.Where(x => x.ID_Persona == item.ID_Persona).SingleOrDefault();  //first last or tolist
                    updato.Nombre = item.Nombre;
                    updato.Cedula = item.Cedula;
                    updato.correo = item.correo;
                    updato.contraseña = item.contraseña;
                    updato.tipo_perfil = item.tipo_perfil;

                    //preguntar si hay forma de no hacerlo uno a uno 


                    //context.Entry(updato).State = System.Data.Entity.EntityState.Modified; // le estoy diciendo al entity que fue cambiado 

                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("ERROR ACTUALIZANDO PERSONA:  " + exp.Message);
                }

            }
        }
}
