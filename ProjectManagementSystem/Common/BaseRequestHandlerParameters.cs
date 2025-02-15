﻿using FluentValidation;
using MediatR;
using ProjectManagementSystem.Data.Repositories;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Common;
public class BaseRequestHandlerParameters
{
    readonly IMediator _mediator;
    readonly IRepository<BaseModel> _repository;
    readonly IUserRepository _userRepository;

    public IMediator Mediator => _mediator;
    public IRepository<BaseModel> Repository => _repository;
    public IUserRepository UserRepository => _userRepository;
    
    public BaseRequestHandlerParameters(IMediator mediator, IRepository<BaseModel> repository, IUserRepository userRepository)
    {
        _mediator = mediator;
        _repository = repository;
        _userRepository = userRepository;
    }
    
}

