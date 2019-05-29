using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface CurWork
    {
        IEnumerable<CurreinciesDTO> GetAll();
        IEnumerable<CurreinciesDTO> GetUserCurrency(string username);
        CurreinciesDTO GetCur(string curName,string username);
        void SaveInfo(CurreinciesDTO info);
       
    }
}
