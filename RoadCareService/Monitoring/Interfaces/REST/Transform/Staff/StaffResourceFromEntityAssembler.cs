using RoadCareService.Monitoring.Interfaces.REST.Resources.Staff;

namespace RoadCareService.Monitoring.Interfaces.REST.Transform.Staff
{
    public class StaffResourceFromEntityAssembler
    {
        public static StaffResource ToResourceFromEntity
            (Domain.Model.Aggregates.Staff entity) =>
            new(entity.Id, entity.DamagedInfrastructuresId,
                entity.WorkersId, entity.State);
    }
}