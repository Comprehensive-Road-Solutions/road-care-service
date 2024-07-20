using RoadCareService.Assignment.Interfaces.REST.Resources.WorkerArea;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.WorkerArea
{
    public class WorkerAreaResourceFromEntityAssembler
    {
        public static WorkerAreaResource ToResourceFromEntity
            (Domain.Model.Entities.WorkerArea entity) =>
            new(entity.Id, entity.GovernmentsEntitiesId,
                entity.Name, entity.State);
    }
}