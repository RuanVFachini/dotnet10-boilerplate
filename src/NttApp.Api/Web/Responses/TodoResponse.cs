namespace NttApp.Api.Web.Responses;

public record TodoResponse(
    long Id,
    string Title,
    string Description,
    bool IsComplete);