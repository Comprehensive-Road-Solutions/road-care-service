using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Domain.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<IEnumerable<Role>> FindByGovernmentsEntitiesIdAndWorkersIdAsync
            (int governmentsEntitiesId, int workersId);
    }
}