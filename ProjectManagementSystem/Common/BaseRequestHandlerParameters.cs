using MediatR;
using ProjectManagementSystem.Data.Repositories;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Common;
public class BaseRequestHandlerParameters
{
    readonly IMediator _mediator;
    readonly IRepository<BaseModel> _repository;
    public IMediator Mediator => _mediator;
    public IRepository<BaseModel> Repository => _repository;
    
    public BaseRequestHandlerParameters(IMediator mediator, IRepository<BaseModel> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }
    
}

