using MediatR;
using ProjectManagementSystem.Data.Repositories;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Common;

public abstract class BaseRequestHandler<TRequest, TRespone> : IRequestHandler<TRequest, TRespone> where TRequest : IRequest<TRespone>
{
    protected readonly IMediator _mediator;
    protected readonly IRepository<BaseModel> _repository;

    public BaseRequestHandler(BaseRequestHandlerParameters parameters)
    {
        _mediator = parameters.Mediator;
        _repository = parameters.Repository;
    }
    public abstract Task<TRespone> Handle(TRequest request, CancellationToken cancellationToken);
}

