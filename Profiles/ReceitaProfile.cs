using AutoMapper;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;

namespace Controle_Financeiro.Profiles
{
    public class ReceitaProfile:Profile
    {
        public ReceitaProfile()
        {
            CreateMap<CreateReceitaDto,Receita>();
            CreateMap<Receita,ReadReceitaDto>();
            CreateMap<Receita,UpdateReceitaDto>();
            CreateMap<UpdateReceitaDto, Receita>();
        }
    }
}
