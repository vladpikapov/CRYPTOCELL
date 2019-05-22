using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class CurreinciesRepository : IRepository<CURREINCIES>
    {
        private CryptoCellDB db;
        public CurreinciesRepository(CryptoCellDB context)
        {
            db = context;
        }
        public void Create(CURREINCIES item)
        {
            db.CURREINCIES.Add(item);
        }

        public CURREINCIES GetCur(string curname,string username)
        {
            return db.CURREINCIES.Where(x => x.UserName.Equals(username) && x.CurName.Equals(curname)).FirstOrDefault();
        }

        public CURREINCIES Get(string username)
        {
            return db.CURREINCIES.Where(x => x.UserName.Equals(username)).FirstOrDefault();
        }

        public IEnumerable<CURREINCIES> GetAll()
        {
            return db.CURREINCIES;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateAndSave(CURREINCIES item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();   
        }
    }
}
