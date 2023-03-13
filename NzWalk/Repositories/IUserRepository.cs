using NzWalk.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);

    }
}
