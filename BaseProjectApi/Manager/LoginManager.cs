using BaseProjectApi.Models;
using BaseProjectApi.Repository;
using BaseProjectApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProjectApi.Manager
{
    public class LoginManager
    {
        private readonly IUserRepository _userRepository;

        public LoginManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Jwt> Login(Login userCredentials)
        {
            JwtRepository _jwtRepository = new JwtRepository();

            User user = await _userRepository.Login(userCredentials);
            Jwt token = _jwtRepository.GerarToken(user);

            return token;
        }
    }
}
