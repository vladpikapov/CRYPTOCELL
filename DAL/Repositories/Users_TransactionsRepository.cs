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
   public class Users_TransactionsRepository : IRepository<USERS_TRANSACTIONS>
    {
        CryptoCellDB db;
        public Users_TransactionsRepository(CryptoCellDB context)
        {
            db = context;
        }

        public void Create(USERS_TRANSACTIONS item)
        {
            db.USERS_TRANSACTIONS.Add(item);
        }

        public USERS_TRANSACTIONS Get(string name)
        {
          return  db.USERS_TRANSACTIONS.Where(x => x.FromUserName.Equals(name) || x.ToUserName.Equals(name)).LastOrDefault();
        }

        public IEnumerable<USERS_TRANSACTIONS> GetAll()
        {
            return db.USERS_TRANSACTIONS;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateAndSave(USERS_TRANSACTIONS item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
