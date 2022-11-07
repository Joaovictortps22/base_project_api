using BaseProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProjectApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> Get(int id);
        Task<User> Add(User user);
        Task<User> Update(User user, int id);
        Task<bool> Delete(int id);
    }
}
