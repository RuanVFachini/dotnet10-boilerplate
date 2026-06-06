namespace NttApp.Api.Web.Requests;

public record TodoRequest(
    string Title,
    string Description);