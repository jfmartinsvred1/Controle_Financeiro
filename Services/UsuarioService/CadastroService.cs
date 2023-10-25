using AutoMapper;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Identity;

namespace Controle_Financeiro.Services.UsuarioService
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public CadastroService(UserManager<Usuario> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded) {
                throw new ApplicationException
                ("Falha ao cadastrar usuário!");
            }

            
        }

    }
}
