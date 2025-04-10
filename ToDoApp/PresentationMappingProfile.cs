using Persistence.Models;
using ToDoApp.Viewmodels;
using AutoMapper;

namespace ToDoApp
{
    public class PresentationMappingProfile : Profile
    {
        public PresentationMappingProfile() {
            CreateMap<ToDoTaskModel, ToDoTask>();
        }
    }
}
