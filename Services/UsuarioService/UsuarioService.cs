using AutoMapper;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;
using Controle_Financeiro.Services.TokenService;
using Microsoft.AspNetCore.Identity;

namespace Controle_Financeiro.Services.UsuarioService
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenServices _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenServices tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
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

        internal async Task<string> Login(LoginUsuarioDto dto)
        {
           var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password,false,false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuario não autenticado!");
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user=>user.NormalizedUserName==dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}
