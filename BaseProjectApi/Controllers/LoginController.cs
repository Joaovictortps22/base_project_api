using BaseProjectApi.Data;
using BaseProjectApi.Manager;
using BaseProjectApi.Models;
using BaseProjectApi.Repository;
using BaseProjectApi.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginManager _loginManager;

        public LoginController(LoginManager loginManager)
        {
            _loginManager = loginManager;
        }

        [HttpPost]
        public async Task<ActionResult<Jwt>> Login([FromBody] Login loginUsuario)
        {

            try
            {
                Jwt tokenAndExp = await _loginManager.Login(loginUsuario);
                return Ok(tokenAndExp);
            }
            catch (Exception ex)
            {
                return StatusCode(401, new { message = ex.Message });
            }
        }
    }
}
