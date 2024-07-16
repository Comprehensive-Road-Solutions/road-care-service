using RoadCareService.Publishing.Interfaces.REST.Resources.Department;

namespace RoadCareService.Publishing.Interfaces.REST.Transform.Department
{
    public class DepartmentResourceFromEntityAssembler
    {
        public static DepartmentResource ToResourceFromEntity
            (Domain.Model.Entities.Department entity) =>
            new(entity.Id, entity.Name);
    }
}