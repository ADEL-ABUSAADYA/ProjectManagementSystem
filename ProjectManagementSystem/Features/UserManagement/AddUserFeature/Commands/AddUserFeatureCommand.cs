using MediatR;
using ProjectManagementSystem.Common;
using ProjectManagementSystem.Common.Data.Enums; 
using ProjectManagementSystem.Common.Views;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Features.userManagement.AddUserFeature.Commands;

public record AddUserFeatureCommand(int userID, Feature feature) : IRequest<RequestResult<bool>>;

public class AddUserFeatureCommandHandler : BaseRequestHandler<AddUserFeatureCommand, RequestResult<bool>>
{
    public AddUserFeatureCommandHandler(BaseRequestHandlerParameters parameters ): base(parameters) { }

    public async override Task<RequestResult<bool>> Handle(AddUserFeatureCommand request, CancellationToken cancellationToken)
    {
        var userFeatureID = await _repository.AddAsync(new UserFeature
        {
            Feature = request.feature
        });
         await _repository.SaveChangesAsync();

         if (userFeatureID >= 0)
         {
             return RequestResult<bool>.Success(true);
         }

         return RequestResult<bool>.Failure(ErrorCode.UserNotFound);
    }
}