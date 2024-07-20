using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    public class WorkerAreaRepository(RoadCareContext context) :
        BaseRepository<WorkerArea>(context), IWorkerAreaRepository
    {
        public Task<bool> UpdateWorkerAreaStateAsync(int id, EWorkerAreaState workerAreaState)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<WorkerArea>?> FindByWorkersAreasByGovernmentsEntitiesIdAndStateAsync
            (int governmentsEntitiesId, EWorkerAreaState workerAreaState)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<WorkerArea>?> FindByWorkersAreasByGovernmentsEntitiesIdAsync
            (int governmentsEntitiesId)
        {
            throw new NotImplementedException();
        }
    }
}