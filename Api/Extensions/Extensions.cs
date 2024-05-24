using Api.Abstractions;
using Api.Middlewares;
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

        public static void RegisterEndpointdefinitions(this WebApplication app)
        {
            var endpointdefs = typeof(Program).Assembly
                .GetTypes()
                .Where(t => typeof(IEndpointDefinition).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach(var endpoints in endpointdefs)
            {
                endpoints.RegisterEndpoints(app);
            }
        }

        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
