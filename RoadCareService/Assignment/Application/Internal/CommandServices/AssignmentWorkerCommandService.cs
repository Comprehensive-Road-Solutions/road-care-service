using RoadCareService.Assignment.Application.Internal.OutboundServices.ACL;
using RoadCareService.Assignment.Domain.Model.Commands.AssignmentWorker;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.AssignmentWorker;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Application.Internal.CommandServices
{
    public class AssignmentWorkerCommandService
        (IAssignmentWorkerRepository assignmentWorkerRepository,
        IUnitOfWork unitOfWork,
        ExternalIamService externalIamService) :
        IAssignmentWorkerCommandService
    {
        public async Task<bool> Handle
            (AddAssignmentWorkerCommand command)
        {
            try
            {
                if (await externalIamService
                    .ExistsWorkerById
                    (command.WorkerId)
                    is false)
                    return false;

                await assignmentWorkerRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> Handle
            (UpdateAssignmentWorkerStateCommand command) =>
            await assignmentWorkerRepository
            .UpdateAssignmentWorkerStateAsync
            (command.Id, command.AssignmentWorkerState);
    }
}