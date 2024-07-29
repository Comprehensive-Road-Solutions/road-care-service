using RoadCareService.Location.Interfaces.REST.Resources.Department;

namespace RoadCareService.Location.Interfaces.REST.Transform.Department
{
    public class DepartmentResourceFromEntityAssembler
    {
        public static DepartmentResource ToResourceFromEntity
            (Domain.Model.Aggregates.Department entity) =>
            new(entity.Id, entity.Name);
    }
}