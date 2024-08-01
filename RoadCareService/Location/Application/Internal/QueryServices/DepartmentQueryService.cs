using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Location.Domain.Model.Queries.Department;
using RoadCareService.Location.Domain.Repositories;
using RoadCareService.Location.Domain.Services.Department;

namespace RoadCareService.Location.Application.Internal.QueryServices
{
    internal class DepartmentQueryService
        (IDepartmentRepository departmentRepository) :
        IDepartmentQueryService
    {
        public async Task<IEnumerable<Department>> Handle
            (GetAllDepartmentsQuery query) =>
            await departmentRepository.ListAsync();

        public async Task<Department?> Handle
            (GetDepartmentByIdQuery query) =>
            await departmentRepository
            .FindByIdAsync(query.Id);
    }
}