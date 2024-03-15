using AutoMapper;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;

namespace Controle_Financeiro.Profiles
{
    public class DespesaProfile:Profile
    {
        public DespesaProfile()
        {
            CreateMap<CreateDespesaDto, Despesa>();
            CreateMap<Despesa,ReadDespesaDto>();
            CreateMap<UpdateDespesaDto, Despesa>();
            CreateMap<Despesa,UpdateDespesaDto>();
        }
    }
}
