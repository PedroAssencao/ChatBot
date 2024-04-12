using Chatbot.API.DAL;
using Chatbot.API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Text;

namespace Chatbot.API.Repository
{
    public class LoginRepository : BaseRepository<Login>
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

        public async Task<dynamic?> Logar(Login? Model)
        {
            try
            {
                var usuarios = await GetAll();
                var usuarioSelecionado = usuarios.FirstOrDefault(x => x.LogEmail == Model?.LogEmail && Model?.DescriptografaSenha(x?.LogSenha) == Model?.LogSenha);
                if (usuarioSelecionado != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuarioSelecionado.LogId.ToString()),
                        new Claim(ClaimTypes.Role, "Logar"),
                        new Claim(ClaimTypes.NameIdentifier, usuarioSelecionado?.LogUser)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal); ;

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
                    await Adicionar(login);
                    return login;
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

    }
}
