using RoadCareService.IAM.Interfaces.REST.Resources.Worker;

namespace RoadCareService.IAM.Interfaces.REST.Transform.Worker
{
    public class WorkerResourceFromEntityAssembler
    {
        public static WorkerResource ToResourceFromEntity
            (Domain.Model.Aggregates.Worker entity) =>
                new(entity.Id, entity.DistrictsId,
                entity.GovernmentsEntitiesId,
                entity.Firstname, entity.Lastname,
                entity.Age, entity.Genre,
                entity.Phone, entity.Email,
                entity.Address);
    }
}