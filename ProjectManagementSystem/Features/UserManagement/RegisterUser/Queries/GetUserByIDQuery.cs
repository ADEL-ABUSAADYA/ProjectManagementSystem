using HotelReservationSystem.AutoMapper;
using MediatR;
using ProjectManagementSystem.Common.Views;
using ProjectManagementSystem.Data.Repositories;
using ProjectManagementSystem.Features.Common.Users.DTOs;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Features.userManagement.RegisterUser.Queries;

public record GetUserByIDQuery (int ID) : IRequest<RequestResult<UserDTO>>;


public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, RequestResult<UserDTO>>
{
    IRepository<User> _repository;
    IMediator _mediator;
    public GetUserByIDQueryHandler(IMediator mediator, IRepository<User> repository)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<RequestResult<UserDTO>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
    {
        // var exams = _mediator.Send(new GetExamsByInstructorIDQuery(request.ID));

        var result= (await _repository.GetByIDAsync(request.ID))
            .Map<RequestResult<UserDTO>>();
        return result;
    }
}