namespace NttApp.Api.Web.Routes;

internal interface IAppRouter
{
    internal void RegisterHandlers(IEndpointRouteBuilder endpoints);
}