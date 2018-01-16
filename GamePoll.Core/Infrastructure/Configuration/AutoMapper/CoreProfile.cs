using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GamePoll.Core.Models;
using GamePoll.Core.Repositories.Entities;

namespace GamePoll.Core.Infrastructure.Configuration.AutoMapper
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<GameEntity, GameModel>();
            CreateMap<GameModel, GameEntity>();
        }
    }
}
