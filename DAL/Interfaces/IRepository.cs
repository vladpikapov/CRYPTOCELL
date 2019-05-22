using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
   public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(string username); //т.к. осуществляю поиск по имени
        void UpdateAndSave(T item);
        void Create(T item);
        void Save();
    }
}
