using NttApp.Api.Web.Routes.Todos;

namespace NttApp.Api.Web.Routes.Extensions;

internal static class EndpointRouteBuilderExtensions
{
    extension(IEndpointRouteBuilder endpoints)
    {
        internal IEndpointRouteBuilder RegisterApiRoutes()
        {
            return endpoints
                .RegisterAppRouter<TodoAppRouter>();
        }

        private IEndpointRouteBuilder RegisterAppRouter<T>()
            where T : IAppRouter, new()
        {
            var router = new T();
        
            router.RegisterHandlers(endpoints);
        
            return endpoints;
        }
    }
}