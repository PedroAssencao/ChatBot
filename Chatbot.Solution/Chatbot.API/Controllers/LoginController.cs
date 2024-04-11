﻿using Chatbot.API.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Chatbot.API.Repository;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        protected readonly LoginRepository _loginepository;

        public LoginController(LoginRepository loginepository)
        {
            _loginepository = loginepository;
        }

        [HttpPost("/login/logar")]
        public async Task<IActionResult?> Logar(Login? Model) => Ok(await _loginepository.Logar(Model));
        [HttpPost("/login/Cadastrar")]
        public async Task<IActionResult> Cadastrar(Login? model) => await _loginepository.Cadastrar(model) ? Ok() : BadRequest();

        [HttpGet("/login")]
        public async Task<IActionResult> get() => Ok(await _loginepository.GetAll());


    }
}