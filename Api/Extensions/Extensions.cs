using Application.Abstractions;
using DataAccess.DbConnection;
using DataAccess.Repositories;

namespace Api.Extensions
{
    public static class Extensions
    {

        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IDbConnectionProvider, DbConnection>();
            builder.Services.AddTransient<ICandidateRepository, CandidateRepository>();
        }
    }
}
