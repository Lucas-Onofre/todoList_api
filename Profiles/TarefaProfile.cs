using AutoMapper;
using todoListAPI.Data.Dtos.Tarefa;
using todoListAPI.Models;

namespace todoListAPI.Profiles
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<CreateTarefaDto, Tarefa>();
            CreateMap<Tarefa, ReadTarefaDto>();
            CreateMap<UpdateTarefaDto, Tarefa>();
        }
    }
}