using RoadCareService.Assignment.Interfaces.REST.Resources.AssignmentWorker;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.AssignmentWorker
{
    public class AssignmentWorkerResourceFromEntityAssembler
    {
        public static AssignmentWorkerResource ToResourceFromEntity
            (Domain.Model.Aggregates.AssignmentWorker entity) =>
            new(entity.Id, entity.WorkersRolesId, entity.WorkersId,
                entity.StartDate, entity.FinalDate, entity.State);
    }
}