namespace L2Art.Api.Controllers.Authorization
{
    public record RegistrationRequest(string userName, string email, string password);
}
