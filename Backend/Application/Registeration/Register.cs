


using Microsoft.Extensions.DependencyInjection;

namespace Application.Registeration
{
    public static class Register
    {
        public static void RegisterAppLicationServices(this IServiceCollection _srv)
        {
            _srv.AddScoped<IUnitOfWork, UnitOfWork>();
            _srv.AddScoped<IPlayerMapper, PlayerMapper>();
            _srv.AddScoped<ITeamMapper,TeamMapper>();
            _srv.AddScoped<IPlayerAppService, PlayerAppService>();
            _srv.AddScoped<ITeamAppService, TeamAppService>();
            
        }
    }
}
