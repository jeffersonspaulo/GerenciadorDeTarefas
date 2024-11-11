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

            CreateMap<TarefaCreateDto, Tarefa>()
              .ForMember(dest => dest.ProjetoId, opt => opt.MapFrom(src => src.ProjetoId))
              .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
              .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
              .ForMember(dest => dest.DataVencimento, opt => opt.MapFrom(src => src.DataVencimento))
              .ForMember(dest => dest.TarefaStatus, opt => opt.MapFrom(src => src.TarefaStatus))
              .ForMember(dest => dest.Prioridade, opt => opt.MapFrom(src => src.Prioridade));

            CreateMap<TarefaUpdateDto, Tarefa>()
              .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
              .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
              .ForMember(dest => dest.DataVencimento, opt => opt.MapFrom(src => src.DataVencimento))
              .ForMember(dest => dest.TarefaStatus, opt => opt.MapFrom(src => src.TarefaStatus));

        }
    }
}
