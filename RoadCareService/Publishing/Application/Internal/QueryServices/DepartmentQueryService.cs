using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Publishing.Domain.Model.Queries.Department;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Department;

namespace RoadCareService.Publishing.Application.Internal.QueryServices
{
    public class DepartmentQueryService
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