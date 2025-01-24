using MediatR;
using ProjectManagementSystem.Common;
using ProjectManagementSystem.Common.Data.Enums;
using ProjectManagementSystem.Common.Views;
using ProjectManagementSystem.Features.userManagement.RegisterUser.Queries;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Features.userManagement.RegisterUser.Commands;

public record RegisterUserCommand(string email, string password, string name, string phoneNo, string country) : IRequest<RequestResult<bool>>;

public class RegisterUserCommandHandler : BaseRequestHandler<RegisterUserCommand, RequestResult<bool>>
{
    public RegisterUserCommandHandler(BaseRequestHandlerParameters parameters) : base(parameters)
    {
    }

    public async override Task<RequestResult<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var reponse = await _mediator.Send(new IsUserExistQuery(request.email));
        if (reponse.isSuccess)
            return RequestResult<bool>.Failure(ErrorCode.UserAlreadyExist);
        
        var userID = await _repository.AddAsync(new User
        { 
          Email=request.email,
          Password=request.password,
          Name = request.name,
          PhoneNo= request.phoneNo,
          Country= request.country,
          IsActive = true
        });
        await _repository.SaveChangesAsync();

        return RequestResult<bool>.Success(true);
    }
}