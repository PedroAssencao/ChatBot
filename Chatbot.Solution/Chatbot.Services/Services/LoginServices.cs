using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Repository.Interfaces;
using Chatbot.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Chatbot.Services.Services
{
    public class LoginServices : ILoginInterfaceServices
    {
        protected readonly ILoginInterface _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginServices(ILoginInterface repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<LoginDttoGet>> GetALl()
        {
            try
            {
                var dados = await _repository.GetALl();
                List<LoginDttoGet> List = new List<LoginDttoGet>();
                foreach (var item in dados)
                {
                    LoginDttoGet NewModel = new LoginDttoGet
                    {
                        Codigo = item.LogId,
                        CodigoWhatsap = item.LogWaid,
                        Usuario = item.LogUser,
                        Email = item.LogEmail,
                        Senha = item.LogSenha,
                        Imagem = item.LogImg,
                        Plano = item.LogPlano,
                    };
                    List.Add(NewModel);
                }
                return List;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<LoginDttoGet> GetPorId(int id)
        {
            try
            {
                var dados = await _repository.GetPorId(id);
                LoginDttoGet NewModel = new LoginDttoGet
                {
                    Codigo = dados.LogId,
                    CodigoWhatsap = dados.LogWaid,
                    Usuario = dados.LogUser,
                    Email = dados.LogEmail,
                    Senha = dados.LogSenha,
                    Imagem = dados.LogImg,
                    Plano = dados.LogPlano,
                };
                return NewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<LoginDttoGet> RetornarLogIdPorWaID(string waID)
        {
            try
            {
                if (waID == null)
                {
                    throw new Exception("Informe um Whatsapp Id");
                }
                else
                {
                    var dados = await _repository.GetALl();
                    var LoginEntity = dados.First(x => x.LogWaid == waID);
                    if (LoginEntity != null)
                    {
                        LoginDttoGet NewModel = new LoginDttoGet
                        {
                            Codigo = LoginEntity.LogId,
                            CodigoWhatsap = LoginEntity.LogWaid,
                            Usuario = LoginEntity.LogUser,
                            Email = LoginEntity.LogEmail,
                            Senha = LoginEntity.LogSenha,
                            Imagem = LoginEntity.LogImg,
                            Plano = LoginEntity.LogPlano,
                        };
                        return NewModel;
                    }
                    else
                    {
                        throw new Exception("Login não Encontrado");
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<LoginDttoGet> Create(LoginDttoGet Model)
        {
            try
            {
                Login NewModel = new Login
                {
                    LogWaid = Model.CodigoWhatsap,
                    LogUser = Model.Usuario,
                    LogEmail = Model.Email,
                    LogSenha = Model.Senha,
                    LogImg = Model.Imagem,
                    LogPlano = Model.Plano
                };
                await _repository.Adicionar(NewModel);
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<LoginDttoGet> Update(LoginDttoGet Model)
        {
            try
            {
                Login NewModel = new Login
                {
                    LogId = Model.Codigo,
                    LogWaid = Model.CodigoWhatsap,
                    LogUser = Model.Usuario,
                    LogEmail = Model.Email,
                    LogSenha = Model.Senha,
                    LogImg = Model.Imagem,
                    LogPlano = Model.Plano
                };
                await _repository.update(NewModel);
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<LoginDttoGet> Delete(int id)
        {
            try
            {
                var item = await _repository.delete(id);
                LoginDttoGet NewModel = new LoginDttoGet
                {
                    Codigo = item.LogId,
                    CodigoWhatsap = item.LogWaid,
                    Usuario = item.LogUser,
                    Email = item.LogEmail,
                    Senha = item.LogSenha,
                    Imagem = item.LogImg,
                    Plano = item.LogPlano,
                };
                return NewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Logar(LoginDttoPost Model, bool IsCadastre)
        {
            try
            {
                var usuarios = await _repository.GetALl();
                var usuarioSelecionado = usuarios.FirstOrDefault(x => x.LogEmail == Model?.Email && Model?.DescriptografaSenha(x?.LogSenha) == Model?.Senha || IsCadastre);
                if (usuarioSelecionado != null)
                {
                    var claims = new List<Claim>
                    {
                     new Claim(ClaimTypes.Name, usuarioSelecionado.LogId.ToString()),
                     new Claim(ClaimTypes.Role, "Logar"),
                     new Claim(ClaimTypes.NameIdentifier, usuarioSelecionado.LogUser)
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
                throw new Exception("error: " + ex.Message);
            }
        }
        public async Task<LoginDttoGet> Cadastrar(LoginDttoGet Model)
        {
            try
            {
                if (Model != null)
                {

                    Login login = new Login
                    {
                        LogId = Model.Codigo,
                        LogEmail = Model.Email,
                        LogImg = Model.Imagem,
                        LogPlano = Model.Plano,
                        LogSenha = Model.CriptografaSenha(Model?.Senha),
                        LogUser = Model.Usuario,
                        LogWaid = Model.CodigoWhatsap,
                    };

                    Model.CriptografaSenha(Model.Senha);

                    var dados = await _repository.GetALl();
                    var checkEmailAndUser = dados.Where(x => x.LogEmail == login.LogEmail || x.LogUser == login.LogUser).ToList();
                    if (checkEmailAndUser.Count == 0)
                    {
                        LoginDttoPost NewModel = new LoginDttoPost
                        {
                            Email = Model.Email,
                            Senha = Model.Senha,
                        };
                        await _repository.Adicionar(login);
                        await Logar(NewModel, true);
                        return Model;
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

        public async Task<HttpStatusCode> Logout()
        {
            try
            {
                await _httpContextAccessor.HttpContext.SignOutAsync();
                return HttpStatusCode.OK;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LoginDttoGetForView> GetPorIdLoginView(int id)
        {
            try
            {
                var dados = await _repository.GetPorId(id);
                LoginDttoGetForView NewModel = new LoginDttoGetForView
                {
                    Codigo = dados.LogId,
                    CodigoWhatsapp = dados.LogWaid,
                    Usuario = dados.LogUser,
                };
                return NewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
