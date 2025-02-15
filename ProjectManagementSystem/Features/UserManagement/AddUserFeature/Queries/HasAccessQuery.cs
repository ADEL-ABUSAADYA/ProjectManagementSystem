using MediatR;
using ProjectManagementSystem.Common.Data.Enums;
using ProjectManagementSystem.Data.Repositories;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Features.userManagement.AddUserFeature.Queries;

public record HasAccessQuery(int ID, Feature Featuer) : IRequest<bool>;

public class HasAccessQueryHandler : IRequestHandler<HasAccessQuery, bool>
{
    IRepository<UserFeature> _repository;
    IMediator _mediator;
    public HasAccessQueryHandler(IMediator mediator, IRepository<UserFeature> repository)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<bool> Handle(HasAccessQuery request, CancellationToken cancellationToken)
    {
        var hasFeature = await _repository.AnyAsync(
             uf => uf.UserID == request.ID && uf.Feature == request.Featuer);

        return hasFeature;
    }
}