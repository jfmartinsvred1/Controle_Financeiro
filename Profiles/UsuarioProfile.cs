using AutoMapper;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;

namespace Controle_Financeiro.Profiles
{
    public class UsuarioProfile:Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
