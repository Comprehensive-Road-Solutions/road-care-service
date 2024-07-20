using RoadCareService.Assignment.Domain.Model.Commands.AssignmentWorker;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.AssignmentWorker;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Application.Internal.CommandServices
{
    public class AssignmentWorkerCommandService
        (IAssignmentWorkerRepository assignmentWorkerRepository,
        IUnitOfWork unitOfWork) : IAssignmentWorkerCommandService
    {
        public Task<bool> Handle
            (AddAssignmentWorkerCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle
            (UpdateAssignmentWorkerStateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}