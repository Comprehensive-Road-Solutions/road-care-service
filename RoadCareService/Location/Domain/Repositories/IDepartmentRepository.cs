using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Location.Domain.Repositories
{
    public interface IDepartmentRepository :
        IBaseRepository<Department>
    { }
}