




using Services.Authentication;

namespace Application.Registeration
{
    public static class RegisterServices
    {
        public static void RegisterAppLicationServices(this IServiceCollection _srv)
        {
            _srv.AddScoped<IUnitOfWork, UnitOfWork>();
            _srv.AddScoped<IPlayerMapper, PlayerMapper>();
            _srv.AddScoped<ITeamMapper,TeamMapper>();
            _srv.AddScoped<IPlayerAppService, PlayerAppService>();
            _srv.AddScoped<ITeamAppService, TeamAppService>();
            _srv.AddScoped<ICountryAppService, CountryAppService>();
            _srv.AddScoped<IGenerateToken, GenerateToken>();
            _srv.AddScoped<IRegisterAuthenticate, Register>();
            _srv.AddScoped<ILoginAuthenticate, Login>();
            
        }
    }
}
