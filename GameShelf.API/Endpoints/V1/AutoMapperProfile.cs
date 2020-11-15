using AutoMapper;
using GameShelf.Domain.Dtos;
using GameShelf.Domain.Models;

namespace GameShelf.API.Endpoints.V1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Games
            CreateMap<CreateGame, Game>();
            CreateMap<UpdateGame, Game>();
            
            // Users
            CreateMap<CreateUser, Domain.Models.User>();
            CreateMap<UpdateUser, Domain.Models.User>();
        }
    }
}