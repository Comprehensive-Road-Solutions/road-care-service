using RoadCareService.Location.Interfaces.REST.Resources.District;

namespace RoadCareService.Location.Interfaces.REST.Transform.District
{
    public class DistrictResourceFromEntityAssembler
    {
        public static DistrictResource ToResourceFromEntity
            (Domain.Model.Aggregates.District entity) =>
            new(entity.Id, entity.DepartmentsId, entity.Name);
    }
}