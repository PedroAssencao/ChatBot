﻿using Chatbot.API.Models;
using Chatbot.API.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        protected readonly menuRepository _menuRepository;

        public MenusController(menuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [HttpGet("/Menus")]
        //[EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> PegarTodosMenu() => Ok(await _menuRepository.GetAll());

        [HttpGet("/Menus/{id}")]
        public async Task<IActionResult> PegarTodosMenusPorLogId(int id) => Ok(await _menuRepository.PegarTodosOsMenusPorLogID(id));   
        [HttpGet("/Menus/MenuInicial/{id}")]
        public async Task<IActionResult> PegarMenuInicialPorLodId(int id) => Ok(await _menuRepository.PegarMenuPorLogIDEMenuInicial(id));
        [HttpPost("/Menus/Create")]
        //[EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> CriarNovoMenu(Menu Model) => Ok(await _menuRepository.Adicionar(Model));
        [HttpPut("/Menus/Atualizar")]
        public async Task<IActionResult> AtualizarMenu(Menu Model) => Ok(await _menuRepository.Update(Model));
        [HttpDelete("/Menus/Delete")]
        public async Task<IActionResult> DeleteMenu(int model) => Ok(await _menuRepository.Delete(model));

    }
}