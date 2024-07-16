using RoadCareService.Publishing.Interfaces.REST.Resources.District;

namespace RoadCareService.Publishing.Interfaces.REST.Transform.District
{
    public class DistrictResourceFromEntityAssembler
    {
        public static DistrictResource ToResourceFromEntity
            (Domain.Model.Entities.District entity) =>
            new(entity.Id, entity.DepartmentsId, entity.Name);
    }
}