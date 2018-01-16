﻿using GamePoll.Core.Infrastructure.Configuration.AutoMapper;
using GamePoll.Core.Infrastructure.Data;
using GamePoll.Core.Repositories;
using GamePoll.Core.Repositories.Entities;
using GamePoll.Core.Services.GameData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GamePoll.Core.Infrastructure.Configuration
{
    public static class CoreConfigurationExtensions
    {
        public static IServiceCollection AddCoreConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped<IGameService, GameService>()
                .AddScoped<IRepository<GameEntity>, GameRepository>()
                .AddSingleton<IDbConnectionFactory>(factory => new SqlConnectionFactory(configuration.GetConnectionString("CoreData")))
                .AddSingleton(AutoMapperConfiguration.CreateConfiguration().CreateMapper());
        }
    }
}
