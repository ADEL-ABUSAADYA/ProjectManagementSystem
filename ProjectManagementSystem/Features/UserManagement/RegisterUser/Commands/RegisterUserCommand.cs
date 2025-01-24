using MediatR;
using ProjectManagementSystem.Common;
using ProjectManagementSystem.Common.Views;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Features.userManagement.RegisterUser.Commands;

public record RegisterUserCommand(string email, string password, string name, string phoneNo, string country) : IRequest<RequestResult<int>>;

public class RegisterUserCommandHandler : BaseRequestHandler<RegisterUserCommand, RequestResult<int>>
{
    public RegisterUserCommandHandler(BaseRequestHandlerParameters parameters) : base(parameters)
    {
    }

    public async override Task<RequestResult<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userID = await _repository.AddAsync(new User
        { PhoneNo= request.phoneNo,
          Name = request.name,
          Country= request.country,
          Email=request.email,
          Password=request.password,
          IsActive = true
        });
        await _repository.SaveChangesAsync();

        return RequestResult<int>.Success(userID);
    }
}