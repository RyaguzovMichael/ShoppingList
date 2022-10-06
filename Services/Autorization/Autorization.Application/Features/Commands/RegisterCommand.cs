using Ardalis.Result;
using MediatR;
using System.Security.Claims;

namespace Authorization.Application.Features.Commands;

public class RegisterCommand : IRequest<(List<Claim> ,Result<RegisterCommandVm>)>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}
