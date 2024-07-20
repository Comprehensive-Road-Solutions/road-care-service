using RoadCareService.Assignment.Interfaces.REST.Resources.GovernmentEntity;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.GovernmentEntity
{
    public class GovernmentEntityResourceFromEntityAssembler
    {
        public static GovernmentEntityResource ToResourceFromEntity
            (Domain.Model.Aggregates.GovernmentEntity entity) =>
            new(entity.Id, entity.DistrictsId, entity.Ruc,
                entity.Name, entity.Phone, entity.Email,
                entity.Address);
    }
}