using AutoMapper;
using Controle_Financeiro.Data;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;
using Controle_Financeiro.Services.UsuarioService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Financeiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController:ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            this._usuarioService = cadastroService;
        }

        [HttpPost("cadastro")]

        public async Task<IActionResult> CadastraUsurio(CreateUsuarioDto dto)
        {
            await _usuarioService.Cadastra(dto);
            return Ok("Usuário Cadastrado Com Sucesso!");
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
           var token =  await _usuarioService.Login(dto);
            return Ok(token);
        }
    }
}
