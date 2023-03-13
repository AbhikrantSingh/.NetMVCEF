using NzWalk.Data;
using NzWalk.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Repositories
{
    public class UserRepoitories : IUserRepository
    {
        private readonly NZWalkDbContext dbContext;

        public UserRepoitories(NZWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user =  dbContext.Users.FirstOrDefault(user => user.userName == username && user.Password == password);


            if (user == null) return user;

            var userRole = dbContext.user_Roles.Where(x => x.UserId == user.Id).ToList();
            if (userRole.Any())
            {
                user.Roles = new List<string>();
                foreach (var u in userRole)
                {
                    var role = dbContext.Roles.FirstOrDefault(x => x.Id == u.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }
            user.Password = null;
            return user;
        }
    }
}
