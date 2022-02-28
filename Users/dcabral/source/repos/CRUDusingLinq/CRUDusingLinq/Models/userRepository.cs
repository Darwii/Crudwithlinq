using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDusingLinq.Models
{
    public class userRepository : IUserRepository
    {
        private UsermodelsEntities _dataContext;
        public userRepository()
        {
            _dataContext = new UsermodelsEntities();
        }
        public void Deleteuser(int userid)
        {
            userdata userDetails = _dataContext.userdatas.Where(u => u.id == userid).SingleOrDefault();
            _dataContext.userdatas.Remove(userDetails);
            _dataContext.SaveChanges();

        }

        public userdata GetuserByID(int userid)
        {
            var query = from u in _dataContext.userdatas
                        where u.id == userid
                        select u;
            var user = query.FirstOrDefault();
            var model = new userdata()
            {
                id = userid,
                name = user.name,
                age = user.age,
                email = user.email
            };   

            return model;
        }

        public IEnumerable<userdata> GetUserDatas()
        {
            IList<userdata> userlist = new List<userdata>();
            var query = from user in _dataContext.userdatas
                        select user;
           
            var users = query.ToList();
            foreach(var userDetails in users)
            {
                userlist.Add(new userdata()
                {
                    id = userDetails.id,
                    name = userDetails.name,
                    age = userDetails.age,
                    email = userDetails.email,


                });

            }
                return userlist;

        }

        public void Insertuser(userdata user)
        {
            var userDetails = new userdata()
            {
                name = user.name,
                age = user.age,
                email = user.email
            };
            _dataContext.userdatas.Add(user);
            _dataContext.SaveChanges();
        }

        public void Updateuser(userdata user)
        {
            userdata userDetails = _dataContext.userdatas.Where(u => u.id == user.id).SingleOrDefault();
            userDetails.name = user.name;
            userDetails.age = user.age;
            userDetails.email = user.email;

            _dataContext.SaveChanges();
        }
    }
}