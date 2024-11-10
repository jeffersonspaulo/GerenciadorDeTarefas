using AutoMapper;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;

namespace GerenciadorDeTarefas.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjetoDto, Projeto>()
              .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
              .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));

            CreateMap<TarefaDto, Tarefa>()
              .ForMember(dest => dest.ProjetoId, opt => opt.MapFrom(src => src.ProjetoId))
              .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
              .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
              .ForMember(dest => dest.DataVencimento, opt => opt.MapFrom(src => src.DataVencimento))
              .ForMember(dest => dest.TarefaStatusId, opt => opt.MapFrom(src => src.TarefaStatusId));

        }
    }
}
