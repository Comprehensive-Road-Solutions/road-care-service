using RoadCareService.Location.Domain.Model.Queries.Department;

namespace RoadCareService.Location.Domain.Services.Department
{
    public interface IDepartmentQueryService
    {
        Task<IEnumerable<Model.Aggregates.Department>> Handle
            (GetAllDepartmentsQuery query);

        Task<Model.Aggregates.Department?> Handle
            (GetDepartmentByIdQuery query);
    }
}