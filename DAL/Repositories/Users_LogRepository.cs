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
   public class Users_LogRepository:IRepository<USERS_LOG>
    {
        CryptoCellDB db;
        public Users_LogRepository(CryptoCellDB context)
        {
            db = context;
        }

        public void Create(USERS_LOG item)
        {
            db.USERS_LOG.Add(item);
        }

        public USERS_LOG Get(string name)
        {
            return db.USERS_LOG.Where(x =>x.UserLogName.Equals(name)).FirstOrDefault();
        }

        public IEnumerable<USERS_LOG> GetAll()
        {
            return db.USERS_LOG;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateAndSave(USERS_LOG item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
