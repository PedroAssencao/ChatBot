using Chatbot.API.DAL;
using Chatbot.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace Chatbot.Test.Chatbot.Infrastructure.Mock
{
    public class ChatbotMockDate
    {
        public static async Task CreateDates(ChatbotConnection application, bool create)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var catalogDbContext = provider.GetRequiredService<chatbotContext>())
                {
                    await catalogDbContext.Database.EnsureCreatedAsync();

                    if (create)
                    {
                        //Criação Modelos Login
                        await catalogDbContext.Logins.AddAsync(new Login
                        {
                            LogId = 1,
                            LogEmail = "master.123@123",
                            LogSenha = "c2VuYWkuMTIz",
                            LogImg = "img-placeholder",
                            LogUser = "master",
                            LogPlano = "Master",
                            LogWaid = "15550882003"
                        });

                        //Criação Modelos Departamentos
                        await catalogDbContext.Departamentos.AddAsync(new Departamento
                        {
                            DepId = 1,
                            DepDescricao = "Suporte",
                            LogId = 1
                        });

                        //Criação Modelos Atendentes
                        await catalogDbContext.Atendentes.AddAsync(new Atendente
                        {
                            AteId = 1,
                            AteEmail = "emailTeste@gmail.com",
                            AteNome = "AtendenteTeste",
                            AteImg = "placeholder.img",
                            AteSenha = "atendente@123",
                            LogId = 1,
                            DepId = 1
                        });

                        //Criação Modelos Contatos
                        await catalogDbContext.Contatos.AddRangeAsync(new List<Contato>
                        {
                            new Contato {
                                ConId = 1,
                                ConWaId = "557988132044",
                                ConNome = "Pedro Assenção",
                                ConDataCadastro = Convert.ToDateTime("2024-07-24 16:27:14.220"),
                                ConBloqueadoStatus = false,
                                LogId = 1
                            }
                        });

                        //Criação Modelos Mensagens
                        await catalogDbContext.Menus.AddRangeAsync(new List<Menu>
                        {
                            new Domain.Models.Menu
                            {
                                MenId = 1,
                                MenHeader = "Empresas Senai",
                                MenFooter = "Todos direitos reservados",
                                MenBody = "Seja Bem Vindo ao Nosso Robo de Atendimento, Antes de Falar Com Nossos Atendentes Por Favor Resposnda as Perguntas Abaixo Para Sabermos o Seu Problema, Tentaremos Resolver Sem Intervenção Humana Se Possivel!",
                                MenTipo = "PrimeiraMensagem",
                                MenTitle = "Menu Inicial",
                                LogId = 1
                            },
                            new Domain.Models.Menu
                            {
                                MenId = 2,
                                MenHeader = "Empresas Senai",
                                MenFooter = "Todos direitos reservados",
                                MenBody = "Por Favor Escolha Qual Parte das Finança Voce Esta Tendo Problemas",
                                MenTipo = "MenuBot",
                                MenTitle = "Finanças",
                                LogId = 1
                            },
                            new Domain.Models.Menu
                            {
                                MenId = 3,
                                MenHeader = "Empresas Senai",
                                MenFooter = "Todos direitos reservados",
                                MenBody = "Por Favor Escolha Qual Setor de Suporte Que Voce Deseja Ser Atendido",
                                MenTipo = "MenuBot",
                                MenTitle = "Suporte",
                                LogId = 1
                            },
                            new Domain.Models.Menu
                            {
                                MenId = 4,
                                MenHeader = "Empresas Senai",
                                MenFooter = "Todos direitos reservados",
                                MenBody = "Escolha Quais Das Opções Abaixo Descreve Melhor o Seu Problema",
                                MenTipo = "MenuBot",
                                MenTitle = "Menu de Dificuldades ao Acessar o Sistema",
                                LogId = 1
                            },
                            new Domain.Models.Menu
                            {
                                MenId = 5,
                                MenHeader = "Empresas Senai",
                                MenFooter = "Todos direitos reservados",
                                MenBody = "Escolha Quais Das Opções Abaixo Descreve Melhor o Seu Problema de Pagamento",
                                MenTipo = "MenuBot",
                                MenTitle = "DificuldadePagar",
                                LogId = 1
                            },
                            new Domain.Models.Menu
                            {
                                MenId = 6,
                                MenHeader = "Empresas Senai",
                                MenFooter = "Todos direitos reservados",
                                MenBody = "Escolha Quais Das Opções Abaixo e a Sua Vontade Se Tiver Mais Alguma Pergunta Apenas Pergunte!",
                                MenTipo = "MenuDaIA",
                                MenTitle = "Menu IA",
                                LogId = 1
                            }
                        });

                        //Criação Modelos Options
                        await catalogDbContext.Options.AddRangeAsync(new List<Option>
                        {
                            new Domain.Models.Option
                            {
                                OptId = 1,
                                MenId = 1,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Referente a Financeiro",
                                OptFinalizar = false,
                                OptResposta = "2",
                                OptTipo = "MensagemDeRespostaInterativa",
                                OptTitle = "Financeiro"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 2,
                                MenId = 1,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Referente a Suporte",
                                OptFinalizar = false,
                                OptResposta = "3",
                                OptTipo = "MensagemDeRespostaInterativa",
                                OptTitle = "Suporte"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 3,
                                MenId = 1,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "História do Senai Contada Pela IA e Interação Geral Com IA",
                                OptFinalizar = false,
                                OptResposta = null,
                                OptTipo = "MensagemPorIA",
                                OptTitle = "História Senai"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 4,
                                MenId = 5,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Pagamento Não Disponível",
                                OptFinalizar = true,
                                OptResposta = "Sua Forma de Pagamento não está disponível no sistema? Use esse QR code para pagar diretamente: (exemploQRCode)",
                                OptTipo = "MensagemDeResposta",
                                OptTitle = "Pagamento Indisponível"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 5,
                                MenId = 5,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Pagamento Não Autorizado",
                                OptFinalizar = true,
                                OptResposta = "Sinto Muito Pelo Transtorno, se possível, tente checar seu saldo para verificar se houve uma transação errônea.",
                                OptTipo = "MensagemDeResposta",
                                OptTitle = "Pagamento Não Autorizado"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 6,
                                MenId = 5,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Finalizar Atendimento",
                                OptFinalizar = true,
                                OptResposta = "Muito Obrigado Por Interagir.",
                                OptTipo = "MensagemDeResposta",
                                OptTitle = "Finalizar"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 7,
                                MenId = 4,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Esqueci Minha Senha",
                                OptFinalizar = true,
                                OptResposta = "Aqui está um link para preencher as informações para o reset da sua senha: (linkExemplo), espero que fique bem.",
                                OptTipo = "MensagemDeResposta",
                                OptTitle = "Esquecimento da Senha"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 8,
                                MenId = 4,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Instabilidade No Geral",
                                OptFinalizar = true,
                                OptResposta = "Lamentamos se o sistema está lento hoje, estamos em período de manutenção e voltaremos ao normal em breve.",
                                OptTipo = "MensagemDeResposta",
                                OptTitle = "Dificuldades Sistemas"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 9,
                                MenId = 4,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Finalizar Atendimento",
                                OptFinalizar = true,
                                OptResposta = "Obrigado por interagir, volte sempre.",
                                OptTipo = "MensagemDeResposta",
                                OptTitle = "Finalizar"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 10,
                                MenId = 2,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Dificuldades no Pagamento",
                                OptFinalizar = false,
                                OptResposta = "5",
                                OptTipo = "MensagemDeRespostaInterativa",
                                OptTitle = "Pagamento"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 11,
                                MenId = 2,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Finalizar Atendimento",
                                OptFinalizar = true,
                                OptResposta = "Obrigado por interagir, espero que tenha conseguido resolver seu problema.",
                                OptTipo = "MensagemDeResposta",
                                OptTitle = "Finalizar"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 12,
                                MenId = 3,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Dificuldades com o Sistema",
                                OptFinalizar = false,
                                OptResposta = "4",
                                OptTipo = "MensagemDeRespostaInterativa",
                                OptTitle = "Sistema"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 13,
                                MenId = 3,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Falar com Atendente do Setor de Suporte",
                                OptFinalizar = false,
                                OptResposta = "1",
                                OptTipo = "RedirecionamentoHumano",
                                OptTitle = "Suporte Humano"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 14,
                                MenId = 3,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Finalizar Atendimento",
                                OptFinalizar = true,
                                OptResposta = "Obrigado por interagir, espero que tenha conseguido resolver seu problema.",
                                OptTipo = "MensagemDeResposta",
                                OptTitle = "Finalizar"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 15,
                                MenId = 6,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Voltar ao Fluxo de Atendimento Normal",
                                OptFinalizar = false,
                                OptResposta = "Sim",
                                OptTipo = "MensagemPorIA",
                                OptTitle = "Sim"
                            },
                            new Domain.Models.Option
                            {
                                OptId = 16,
                                MenId = 6,
                                LogId = 1,
                                OptData = Convert.ToDateTime("2024-07-23T22:31:35.673"),
                                OptDescricao = "Finalizar o Atendimento",
                                OptFinalizar = true,
                                OptResposta = "Obrigado por interagir com o sistema!",
                                OptTipo = "MensagemPorIA",
                                OptTitle = "Finalizar"
                            }
                        });

                        //Criação Modelos Atendimento
                        await catalogDbContext.Atendimentos.AddRangeAsync(new List<Atendimento>
                        {
                            new Atendimento
                            {
                                AtenId = 1,
                                AtenEstado = "Finalizado",
                                AtenData = Convert.ToDateTime("2024-10-16 16:15:07.987"),
                                AteId = 1,
                                DepId = 1,
                                ConId = 1,
                                LogId = 1
                            },
                        });

                        //Criação Modelos Chats
                        await catalogDbContext.Chats.AddRangeAsync(new List<Chat>
                        {
                            new Chat
                            {
                                ChaId = 1,
                                AtenId = 1,
                                AteId = 1,
                                ConId = 1,
                                LogId = 1,
                            },
                        });

                        //Criação Modelos Mensagens
                        await catalogDbContext.Mensagens.AddRangeAsync(new List<Mensagen>
                        {
                            new Mensagen
                            {
                                MensId = 1,
                                MensData = Convert.ToDateTime("2024-10-16 16:15:08.453"),
                                MensDescricao = "Finalizar Atendimento",
                                MenTipo = "MensagemEnviada",
                                mensWaId = "wamid.HBgMNTU3OTg4MTMyMDQ0FQIAEhgWM0VCMDBFMzlGQzREMzZFQjUwQzkyMgA=",
                                mensStatus = "read",
                                ChaId = 1,
                                ConId = 1,
                                LogId = 1,
                            },
                        });

                        await catalogDbContext.SaveChangesAsync(); //Salvando esse modelo
                    }
                }
            }
        }
    }
}
