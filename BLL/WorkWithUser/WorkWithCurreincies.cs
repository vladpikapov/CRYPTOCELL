using BLL.DTO;
using BLL.Interfaces;
using System;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Entities;
using AutoMapper;
using System.Windows;

namespace BLL.WorkWithUser
{
   public class WorkWithCurreincies : CurWork
    {
       CurreinciesRepository db { get; set; } 

        public WorkWithCurreincies()
        {
            db = new CurreinciesRepository(new DAL.EF.CryptoCellDB());
        }

        public IEnumerable<CurreinciesDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CURREINCIES, CurreinciesDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CURREINCIES>, List<CurreinciesDTO>>(db.GetAll());
        }

        public void SaveInfo(CurreinciesDTO info)
        {
           var curren =  db.GetAll().Where(x=>x.UserName.Equals(info.UserName) && x.CurName.Equals(info.CurName)).FirstOrDefault();
            
            curren.CurCourseNow = info.CurCourseNow;
            curren.CurBalance = info.CurBalance;
                db.UpdateAndSave(curren);
        }

        public IEnumerable<CurreinciesDTO> GetUserCurrency(string username)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CURREINCIES, CurreinciesDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CURREINCIES>, List<CurreinciesDTO>>(db.GetAll()).Where(u=>u.UserName.Equals(username));
        }

        public CurreinciesDTO GetCur(string curName, string username)
        {
            var cur = db.GetCur(curName, username);
            return new CurreinciesDTO { CurName=cur.CurName,UserName = cur.UserName,CurBalance = cur.CurBalance,CurCourseNow = cur.CurCourseNow,CurCourseLast=cur.CurCourseLast};
        }
    }
}
