using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.BL
{
   public  interface IRepositorio<T>
    {
        List<T> Get();
        T GetrByID(int Id);
        void Insert(T item);
        void Delete(int Id);
        void Update(T item);
        void Save();
    }
}
