using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Users_InfoRepository : IRepository<USERS_INFO>
    {
        CryptoCellDB db;
        public Users_InfoRepository(CryptoCellDB context)
        {
            db = context;
        }
        public void Create(USERS_INFO item)
        {
            db.USERS_INFO.Add(item);
        }

        public USERS_INFO Get(string Name)
        {
           return db.USERS_INFO.Where(x => x.UserName.Equals(Name)).FirstOrDefault();
        }

        public IEnumerable<USERS_INFO> GetAll()
        {
            return db.USERS_INFO;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateAndSave(USERS_INFO item)
        {

            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
