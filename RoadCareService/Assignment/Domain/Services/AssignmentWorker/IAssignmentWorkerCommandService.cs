using RoadCareService.Assignment.Domain.Model.Commands.AssignmentWorker;

namespace RoadCareService.Assignment.Domain.Services.AssignmentWorker
{
    public interface IAssignmentWorkerCommandService
    {
        Task<bool> Handle(AddAssignmentWorkerCommand command);
        Task<bool> Handle(UpdateAssignmentWorkerStateCommand command);
    }
}