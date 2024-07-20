using RoadCareService.Assignment.Domain.Model.Commands.AssignmentWorker;
using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;
using RoadCareService.Assignment.Interfaces.REST.Resources.AssignmentWorker;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.AssignmentWorker
{
    public class AddAssignmentWorkerCommandFromResourceAssembler
    {
        public static AddAssignmentWorkerCommand ToCommandFromResource
            (AddAssignmentWorkerResource resource) =>
            new(resource.WorkerRoleId, resource.WorkerId, resource.StartDate,
                resource.FinalDate, EAssignmentWorkerState.VIGENTE);
    }
}