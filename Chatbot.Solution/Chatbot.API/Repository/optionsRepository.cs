﻿using Chatbot.API.DAL;
using Chatbot.API.Models;
using System.Linq;

namespace Chatbot.API.Repository
{
    public class optionsRepository : BaseRepository<Option>
    {
        protected readonly menuRepository _menuRepository;
        protected readonly MensagemRepository _mensagenRepository;
        protected readonly LoginRepository _loginRepository;
        public optionsRepository(chatbotContext chatbotContext, menuRepository menuRepository, MensagemRepository mensagenRepository, LoginRepository loginRepository) : base(chatbotContext)
        {
            _menuRepository = menuRepository;
            _mensagenRepository = mensagenRepository;
            _loginRepository = loginRepository;
        }


        /*Arrumar o Repositorio de Options*/
        public async Task<List<Option>> RetonarOptionComMenu()
        {
            try
            {
                var dados = await GetAll();
                List<Option> ListaComObjetos = new List<Option>();
                foreach (var item in dados)
                {
                    Option option = new Option
                    {
                        OptId = item.OptId,
                        MenId = item.MenId,
                        LogId = item.LogId,
                        OptTitle = item.OptTitle,
                        OptDescricao = item.OptDescricao,
                        OptData = item.OptData,
                        OptFinalizar = item.OptFinalizar,
                        OptResposta = item.OptResposta,
                        OptTipo = item.OptTipo,
                        Men = await _menuRepository.GetPorID(Convert.ToInt32(item.MenId)),
                        Log = await _loginRepository.GetPorID(Convert.ToInt32(item.LogId)),
                    };
                    ListaComObjetos.Add(option);
                }

                return ListaComObjetos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um error ao tentar formar lista error: " + ex);
            }

        }

        public async Task<List<Option>> RetornarTodasASOptionPorLOgId(int log)
        {
            try
            {
                var lista = await RetonarOptionComMenu();
                var ListaFiltrada = lista.Where(x => x.LogId == log).ToList();
                return ListaFiltrada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Option> CriarOptions(Option option)
        {

            var options = await RetonarOptionComMenu();


            var result = options.Where(x => x.Men.MenId == option.MenId).ToList();
          if (result.Count < 10)
            {
                try
                {
                    await Adicionar(option);
                    return option;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {

                return null;
            }
           
        }
    }
}