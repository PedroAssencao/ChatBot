﻿using Chatbot.API.DAL;

using Chatbot.API.Repository;
using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Services
{
    public class ChatsServices : IChatsInterfaceServices
    {
        protected readonly IChatsInterface _repository;
        protected readonly IAtendenteInterfaceServices _atendente;
        protected readonly IAtendimentoInterfaceServices _atendimento;
        protected readonly IContatoInterfaceServices _contato;
        protected readonly ILoginInterfaceServices _login;
        protected readonly IMensagemInterfaceServices _mensagem;

        public ChatsServices(IChatsInterface repository, IAtendenteInterfaceServices atendente, IAtendimentoInterfaceServices atendimento, IContatoInterfaceServices contato, ILoginInterfaceServices login, IMensagemInterfaceServices mensagem)
        {
            _repository = repository;
            _atendente = atendente;
            _atendimento = atendimento;
            _contato = contato;
            _login = login;
            _mensagem = mensagem;
        }

        public async Task<List<ChatsDttoGet>> GetALl()
        {
            try
            {
                var dados = await _repository.GetALl();
                List<ChatsDttoGet> Lista = new List<ChatsDttoGet>();
                foreach (var item in dados)
                {
                    ChatsDttoGet ViewModel = new ChatsDttoGet
                    {
                        Codigo = item.ChaId,
                        Atendente = item.AteId == null ? null : await _atendente.GetPorId(Convert.ToInt32(item.AteId)),
                        Atendimento = item.AtenId == null ? null : await _atendimento.GetPorId(Convert.ToInt32(item.AtenId)),
                        Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                        Mensagens = item?.ChaId == null && item?.LogId == null ? null : await _mensagem.BuscarMensagensDeUmChat(Convert.ToInt32(item.ChaId), Convert.ToInt32(item.LogId))
                    };
                    Lista.Add(ViewModel);
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ChatsDttoGetForMensagens> BuscarChatParaMensagen(int id)
        {
            try
            {
                var item = await _repository.GetPorId(id);
                ChatsDttoGetForMensagens NewModel = new ChatsDttoGetForMensagens
                {
                    Codigo = item.ChaId,
                    Atendente = await _atendente.GetPorId(Convert.ToInt32(item.AteId)),
                    Atendimento = await _atendimento.GetPorId(Convert.ToInt32(item.AtenId)),
                    Contato = await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                };
                return NewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ChatsDttoGet> GetPorId(int id)
        {
            try
            {
                var item = await _repository.GetPorId(id);
                ChatsDttoGet ViewModel = new ChatsDttoGet
                {
                    Codigo = item.ChaId,
                    Atendente = item.AteId == null ? null : await _atendente.GetPorId(Convert.ToInt32(item.AteId)),
                    Atendimento = item.AtenId == null ? null : await _atendimento.GetPorId(Convert.ToInt32(item.AtenId)),
                    Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Mensagens = item?.ChaId == null && item?.LogId == null ? null : await _mensagem.BuscarMensagensDeUmChat(Convert.ToInt32(item.ChaId), Convert.ToInt32(item.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ChatsDttoGet> AdicionarPost(ChatsDttoPost Model)
        {
            try
            {
                Chat NewModel = new Chat
                {
                    AteId = Model.CodigoAtendente,
                    AtenId = Model.CodigoAtendimento,
                    ConId = Model.CodigoContato,
                    LogId = Model.CodigoLogin
                };
                var item = await _repository.Adicionar(NewModel);
                ChatsDttoGet ViewModel = new ChatsDttoGet
                {
                    Codigo = item.ChaId,
                    Atendente = item.AteId == null ? null : await _atendente.GetPorId(Convert.ToInt32(item.AteId)),
                    Atendimento = item.AtenId == null ? null : await _atendimento.GetPorId(Convert.ToInt32(item.AtenId)),
                    Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Mensagens = item?.ChaId == null && item?.LogId == null ? null : await _mensagem.BuscarMensagensDeUmChat(Convert.ToInt32(item.ChaId), Convert.ToInt32(item.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ChatsDttoGet> AtualziarPut(ChatsDttoPut Model)
        {
            try
            {
                Chat NewModel = new Chat
                {
                    ChaId = Model.Codigo,
                    AteId = Model.CodigoAtendente,
                    AtenId = Model.CodigoAtendimento,
                    ConId = Model.CodigoContato,
                    LogId = Model.CodigoLogin
                };
                var item = await _repository.update(NewModel);
                ChatsDttoGet ViewModel = new ChatsDttoGet
                {
                    Codigo = item.ChaId,
                    Atendente = item.AteId == null ? null : await _atendente.GetPorId(Convert.ToInt32(item.AteId)),
                    Atendimento = item.AtenId == null ? null : await _atendimento.GetPorId(Convert.ToInt32(item.AtenId)),
                    Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Mensagens = item?.ChaId == null && item?.LogId == null ? null : await _mensagem.BuscarMensagensDeUmChat(Convert.ToInt32(item.ChaId), Convert.ToInt32(item.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ChatsDttoGet> Delete(int id)
        {
            try
            {
                var item = await _repository.delete(id);
                ChatsDttoGet ViewModel = new ChatsDttoGet
                {
                    Codigo = item.ChaId,
                    Atendente = item.AteId == null ? null : await _atendente.GetPorId(Convert.ToInt32(item.AteId)),
                    Atendimento = item.AtenId == null ? null : await _atendimento.GetPorId(Convert.ToInt32(item.AtenId)),
                    Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Mensagens = item?.ChaId == null && item?.LogId == null ? null : await _mensagem.BuscarMensagensDeUmChat(Convert.ToInt32(item.ChaId), Convert.ToInt32(item.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Metodos Não Utilizados
        public Task<ChatsDttoGet> Create(ChatsDttoGet Model)
        {
            throw new NotImplementedException();
        }

        public Task<ChatsDttoGet> Update(ChatsDttoGet Model)
        {
            throw new NotImplementedException();
        }
    }
}
