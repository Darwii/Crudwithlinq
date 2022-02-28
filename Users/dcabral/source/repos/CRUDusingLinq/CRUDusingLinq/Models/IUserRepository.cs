using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDusingLinq.Models
{
     public interface IUserRepository
    {
        IEnumerable<userdata> GetUserDatas();
        userdata GetuserByID(int userid);
        void Insertuser(userdata user);
        void Deleteuser(int userid);

        void Updateuser(userdata user);
    }
}
