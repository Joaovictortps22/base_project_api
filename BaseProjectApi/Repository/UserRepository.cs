using BaseProjectApi.Data;
using BaseProjectApi.Models;
using BaseProjectApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProjectApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BaseProjectApiDbContext _dbContext;
        public UserRepository(BaseProjectApiDbContext baseProjectApiDbContext)
        {
            _dbContext = baseProjectApiDbContext;
        }

        public async Task<User> Get(int id)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Usuário não encontrado na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user, int id)
        {
            User userForId = await Get(id);

            if(userForId == null)
            {
                throw new Exception($"Usuário para o Id: {id}, não existe na base de dados");
            }

            userForId.Name = user.Name;
            userForId.Email = user.Email;
            userForId.Telephone = user.Telephone;
            userForId.Password = user.Password;
            userForId.Active = user.Active;
            userForId.Admin = user.Admin;

            _dbContext.Users.Update(userForId);
            await _dbContext.SaveChangesAsync();

            return userForId;
        }

        public async Task<bool> Delete(int id)
        {
            User userForId = await Get(id);

            if (userForId == null)
            {
                throw new Exception($"Usuário para o Id: {id}, não existe");
            }

            _dbContext.Users.Remove(userForId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> Login(Login userCredentials)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == userCredentials.Email &&
                                                                    x.Password == userCredentials.Password);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Login ou senha estão incorretos");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
