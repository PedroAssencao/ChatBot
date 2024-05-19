﻿using Chatbot.API.DAL;
using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text;

namespace Chatbot.API.Repository
{
    public class LoginRepository : BaseRepository<Login>, ILoginInterface
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginRepository(chatbotContext chatbotContext, IHttpContextAccessor content) : base(chatbotContext)
        {
            _httpContextAccessor = content;
        }

        public async Task<Login?> RetornarLogIdPorWaID(string waID)
        {
            try
            {
                if (waID == null)
                {
                    throw new Exception("Informe um Whatsapp Id");
                }
                else
                {
                    var dados = await GetAll();
                    var LoginEntity = dados.FirstOrDefault(x => x.LogWaid == waID);
                    return LoginEntity;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<dynamic?> Logar(Login? Model, bool IsCadastre)
        {
            try
            {
                var usuarios = await GetAll();
                var usuarioSelecionado = usuarios.FirstOrDefault(x => x.LogEmail == Model?.LogEmail && Model?.DescriptografaSenha(x?.LogSenha) == Model?.LogSenha || IsCadastre);
                if (usuarioSelecionado != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Model.LogId.ToString()),
                        new Claim(ClaimTypes.Role, "Logar"),
                        new Claim(ClaimTypes.NameIdentifier, Model?.LogUser)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return true;
                }
                else
                {
                    throw new Exception("Usuario Não Encontrado");

                }
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex);
            }
        }

        public async Task<Login> Cadastrar(Login? Model)
        {
            try
            {
                if (Model != null)
                {

                    Login login = new Login
                    {
                        LogId = Model.LogId,
                        LogEmail = Model.LogEmail,
                        LogImg = Model.LogImg,
                        LogPlano = Model.LogPlano,
                        LogSenha = Model.CriptografaSenha(Model?.LogSenha),
                        LogUser = Model.LogUser,
                        LogWaid = Model.LogWaid,
                    };
                    var dados = await GetAll();
                    var checkEmailAndUser = dados.Where(x => x.LogEmail == login.LogEmail || x.LogUser == login.LogUser).ToList();
                    if (checkEmailAndUser.Count == 0)
                    {
                        await Adicionar(login);
                        await Logar(login, true);
                        return login;
                    }
                    else
                    {
                        throw new Exception("Usuario ou Email Já Cadastrados");
                    }
                
                }
                else
                {
                    throw new Exception("Não foi Possivel Cadastrar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error " + ex);
            }
        }

        public async Task<Login> AtualizarCadastro(Login Model)
        {
            try
            {
                if (Model != null)
                {
                    Login login = new Login
                    {
                        LogId = Model.LogId,
                        LogEmail = Model.LogEmail,
                        LogImg = Model.LogImg,
                        LogPlano = Model.LogPlano,
                        LogSenha = Model.CriptografaSenha(Model?.LogSenha),
                        LogUser = Model.LogUser,
                        LogWaid = Model.LogWaid,
                    };
                    await Update(login);
                    return login;
                }
                else
                {
                    throw new Exception("Não foi Possivel Atualizar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error " + ex);
            }
        }

        public async Task<Login> RemoverLogin(int id)
        {
            try
            {
                if (id != 0)
                {
                    return await Delete(id);
                }
                else
                {
                    throw new Exception("Informe Um Codigo");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error " + ex);
            }
        }

        public async Task<List<Login>> GetALl() => await GetAll();
        public async Task<Login> GetPorId(int id) => await GetPorID(id);
        public async Task<Login> Create(Login Model) => await Create(Model);
        public async Task<Login> update(Login Model) => await Update(Model);
        public async Task<Login> delete(int id) => await Delete(id);
    }
}
