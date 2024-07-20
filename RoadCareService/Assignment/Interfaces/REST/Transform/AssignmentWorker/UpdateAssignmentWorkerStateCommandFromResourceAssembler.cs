using RoadCareService.Assignment.Domain.Model.Commands.AssignmentWorker;
using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;
using RoadCareService.Assignment.Interfaces.REST.Resources.AssignmentWorker;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.AssignmentWorker
{
    public class UpdateAssignmentWorkerStateCommandFromResourceAssembler
    {
        public static UpdateAssignmentWorkerStateCommand ToCommandFromResource
            (UpdateAssignmentWorkerStateResource resource) =>
            new(resource.Id, Enum.Parse<EAssignmentWorkerState>
                (resource.AssignmentWorkerState));
    }
}