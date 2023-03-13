using NzWalk.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Repositories
{
    public class StaticUserRepository 
    {
        //List<User> Users = new List<User>()
        //{
        //    new User(){ 
        //        FirstName="Abhikrant",LastName="Singh",Email="abhi@soni.com",
        //        Id = Guid.NewGuid(),Password="123321",userName="AbhikrantSingh",
        //        Roles=new List<string>{ "reader","writer"}
        //    },
        //    new User(){
        //        FirstName="Soni",LastName="Singh",Email="soni@abhi.com",
        //        Id = Guid.NewGuid(),Password="123321",userName="soniSingh",
        //        Roles=new List<string>{ "reader"}
        //    }
        //};
        public async Task<User> AuthenticateAsync(string username, string password)
        {
          //var user=  Users.Find(x => (x.userName == username)
          //              && (x.Password == password));
          //  if (user == null) return null;
            return null;
        }
    }
}
