using RoadCareService.Assignment.Interfaces.REST.Resources.WorkerRole;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.WorkerRole
{
    public class WorkerRoleResourceFromEntityAssembler
    {
        public static WorkerRoleResource ToResourceFromEntity
            (Domain.Model.Entities.WorkerRole entity) =>
            new(entity.Id, entity.WorkersAreasId,
                entity.Name, entity.State);
    }
}