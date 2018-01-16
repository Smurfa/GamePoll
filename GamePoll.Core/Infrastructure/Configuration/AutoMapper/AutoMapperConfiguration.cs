using AutoMapper;

namespace GamePoll.Core.Infrastructure.Configuration.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CoreProfile>();
            });
        }
    }
}
