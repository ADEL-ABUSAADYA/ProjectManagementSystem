using HotelReservationSystem.AutoMapper;
using MediatR;
using ProjectManagementSystem.Common;
using ProjectManagementSystem.Common.Data.Enums;
using ProjectManagementSystem.Common.Views;
using ProjectManagementSystem.Data.Repositories;
using ProjectManagementSystem.Features.Common.Users.DTOs;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Features.userManagement.RegisterUser.Queries;

public record IsUserExistQuery (string email) : IRequest<RequestResult<bool>>;


public class GetUserByIDQueryHandler : UserBaseRequestHandler<IsUserExistQuery, RequestResult<bool>>
{
    public GetUserByIDQueryHandler(UserBaseRequestHandlerParameters parameters) : base(parameters) { }

    public async override Task<RequestResult<bool>> Handle(IsUserExistQuery request, CancellationToken cancellationToken)
    {
        var result= (await _userRepository.AnyAsync(u => u.Email == request.email));
        if (!result)
        {
            return RequestResult<bool>.Failure(ErrorCode.UserNotFound);
        }

        return RequestResult<bool>.Success(result);
    }
}