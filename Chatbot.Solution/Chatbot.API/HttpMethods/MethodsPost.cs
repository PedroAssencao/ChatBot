using Chatbot.API.Models;
using Chatbot.API.Repository;
using Chatbot.API.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;

namespace Chatbot.API.HttpMethods
{
    public class MethodsPost
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient HttpClient;
        private readonly CadastroServies _cadastroRepository;
        private readonly BotRespostaServices _botrespostarepository;
        private readonly MensagemRepository _mensagemRepository;

        public MethodsPost(IConfiguration configuration, CadastroServies cadastroRepository, BotRespostaServices botrespostarepository, MensagemRepository mensagemRepository)
        {
            _configuration = configuration;
            HttpClient = new HttpClient();
            _cadastroRepository = cadastroRepository;
            _botrespostarepository = botrespostarepository;
            _mensagemRepository = mensagemRepository;
        }

        public async Task<string> MensagemDeMenu(string waId, string mensagem, string numeroDeEnvio)
        {
            var dadosJson = "";
            try
            {
                dadosJson = @"{
                                      ""messaging_product"": ""whatsapp"",
                                      ""recipient_type"": ""individual"",
                                      ""to"": ""5579988132044"",
                                      ""type"": ""interactive"",
                                      ""interactive"": {
                                        ""type"": ""list"",
                                        ""header"": {
                                          ""type"": ""text"",
                                          ""text"": ""Bem Vindo A Margi!""
                                        },
                                        ""body"": {
                                          ""text"": ""Selecione o Assunto a se tratar abaixo""
                                        },
                                        ""footer"": {
                                          ""text"": ""Obrigado Por Usar O Sistema Margi!""
                                        },
                                        ""action"": {
                                          ""button"": ""Menu de Opções"",
                                          ""sections"": [
                                            {  ""title"": ""Shorter Section Title""  ,
                                              ""rows"": [
                                                {
                                                  ""id"": ""unique-row-identifier"",
                                                  ""title"": ""Financeiro"",
                                                  ""description"": ""Tratar Assuntos Financeiros""
                                                },{
                                                  ""id"": ""unique-row-identifier2"",
                                                  ""title"": ""Ajuda"",
                                                  ""description"": ""Solicitar Ajuda Ao Atendente""
                                                },{
                                                  ""id"": ""unique-row-identifier3"",
                                                  ""title"": ""2 Via Boleto"",
                                                  ""description"": ""Solicitar 2 via para boleto""
                                                }
                                              ]
                                            }
                                          ]
                                        }
                                      }
                                    }";
                return await MetodoPostParaAsMensagens(dadosJson);

            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        public async Task<dynamic> MensagemParaOBotResponder(string waId, string descricaoDaMensagem)
        {

            var MensagensTemplates = await _mensagemRepository.GetAll();

            var dadosJson = "";
            try
            {

                if (descricaoDaMensagem != null && descricaoDaMensagem != "" && descricaoDaMensagem != " ")
                {

                    var ListaMensagem = MensagensTemplates.FirstOrDefault(x => x.MenDescricao == descricaoDaMensagem && x.LogId == 2);

                    if (ListaMensagem != null)
                    {
                        //apenas para testes isso aqui, pois o numero na lista da meta de teste esta com o 9 na frente

                        if (waId == "557988132044")
                        {
                            waId = "5579988132044";
                        }

                        dadosJson = $@"
                        {{
                            ""messaging_product"": ""whatsapp"",
                            ""recipient_type"": ""individual"",
                            ""to"": ""{waId}"",
                            ""type"": ""text"",
                            ""text"": {{
                                ""preview_url"": false,
                                ""body"": ""{ListaMensagem.MenResposta}""
                            }}
                        }}";


                    }
                }
                else
                {
                    dadosJson = @"{
                          ""messaging_product"": ""whatsapp"",
                          ""recipient_type"": ""individual"",
                          ""to"": ""5579988132044"",
                          ""type"": ""text"",
                          ""text"": {
                            ""preview_url"": false,
                            ""body"": ""Porfavor Escolha Uma Das Opções Acima""
                            }
                    }
                    ";
                }
                return await MetodoPostParaAsMensagens(dadosJson);
            }
            catch (Exception)
            {
                throw new Exception("Menssagem Vazia Ou Feita Por Bot");
            }
        }

        public async Task<dynamic> MetodoPostParaAsMensagens(string dadosJson)
        {
            if (dadosJson != "" || dadosJson != " ")
            {
                var conteudo = new StringContent(dadosJson, Encoding.UTF8, "application/json");

                var resposta = await HttpClient.PostAsync(_configuration.GetSection("security").GetSection("UrlAndAccessToken").Value, conteudo);


                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }

        public async Task<dynamic> VerificaTipoDeRetorno(dynamic Values)
        {

            try
            {
                return await TipoMensagem(Values);
            }
            catch (Exception)
            {

                try
                {
                    return await TipoMensagemBot(Values);
                }
                catch (Exception)
                {
                    try
                    {
                        return await TipoMensagemStatus(Values);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Metodo Não Identificado");
                    }
                }

            }
        }

        public async Task<dynamic> TipoMensagem(dynamic Values)
        {
            var mensagem = Values
             .GetProperty("entry")[0]
             .GetProperty("changes")[0]
             .GetProperty("value")
             .GetProperty("messages")[0]
             .GetProperty("text")
             .GetProperty("body").GetString();


            var numeroDeEnvio = Values
           .GetProperty("entry")[0]
           .GetProperty("changes")[0]
           .GetProperty("value")
           .GetProperty("messages")[0]
           .GetProperty("from")
           .GetString();

            var waId = Values
           .GetProperty("entry")[0]
           .GetProperty("changes")[0]
           .GetProperty("value")
           .GetProperty("contacts")[0]
           .GetProperty("wa_id")
           .GetString();


            if (mensagem == null)
            {
                throw new Exception();
            }

            var dados = await _cadastroRepository.GetAll();

            var Item = dados.FirstOrDefault(x => x.CatWaId == waId);

            if (Item == null)
            {
                Cadastro NovoCadastro = new Cadastro
                {
                    CatTimeStamp = mensagem,
                    CatWaId = waId,
                };
                await _cadastroRepository.Adicionar(NovoCadastro);
                return MensagemDeMenu(waId, mensagem, numeroDeEnvio);
            }
            else if (Item.CatTimeStamp == mensagem)
            {
                throw new Exception("Mensagem Repetida");
            }
            else
            {
                Item.CatTimeStamp = mensagem;
                Item.CatWaId = waId;
                await _cadastroRepository.Update(Item);
                return await MensagemDeMenu(waId, mensagem, numeroDeEnvio);
            }

        }

        public async Task<dynamic> TipoMensagemBot(dynamic Values)
        {

            var descricaoDaMensagem = Values
            .GetProperty("entry")[0]
            .GetProperty("changes")[0]
            .GetProperty("value")
            .GetProperty("messages")[0]
            .GetProperty("interactive")
            .GetProperty("list_reply")
            .GetProperty("description")
            .GetString();

            var waId = Values
             .GetProperty("entry")[0]
             .GetProperty("changes")[0]
             .GetProperty("value")
             .GetProperty("contacts")[0]
             .GetProperty("wa_id")
             .GetString();

            if (descricaoDaMensagem == null)
            {
                throw new Exception();
            }

            var dados = await _mensagemRepository.GetAll();

            var item = dados.FirstOrDefault(x => x.Con.ConWaId == waId && x.LogId == 2);

            if (item != null)
            {

                if (item?.MenDescricao == descricaoDaMensagem)
                {
                    throw new Exception("Mensagem Repetida");
                }
                else
                {
                    item.MenDescricao = descricaoDaMensagem;
                    item.Con.ConWaId = waId;
                    await _mensagemRepository.Update(item);
                    return await MensagemParaOBotResponder(waId, descricaoDaMensagem);
                }
            }
            else
            {
                BoTrespostum boTrespostum = new BoTrespostum
                {
                    BotTimeStamp = descricaoDaMensagem,
                    CatWaId = waId,
                };
                await _botrespostarepository.AdicionarBotResposta(boTrespostum);
                return await MensagemParaOBotResponder(waId, descricaoDaMensagem);
            }
        }

        public async Task<dynamic> TipoMensagemStatus(dynamic Values)
        {
            var sent = Values
                       .GetProperty("entry")[0]
                       .GetProperty("changes")[0]
                       .GetProperty("value")
                       .GetProperty("statuses")[0]
                       .GetProperty("status")
                       .GetString();

            if (sent == null)
            {
                throw new Exception();
            }
            return false;
        }
    }
}