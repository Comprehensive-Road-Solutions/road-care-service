using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.Queries.WorkerArea;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.WorkerArea;

namespace RoadCareService.Assignment.Application.Internal.QueryServices
{
    internal class WorkerAreaQueryService
        (IWorkerAreaRepository workerAreaRepository) :
        IWorkerAreaQueryService
    {
        public async Task<IEnumerable<WorkerArea>> Handle
            (GetAllWorkersAreasQuery query) =>
            await workerAreaRepository.ListAsync();

        public async Task<WorkerArea?> Handle
            (GetWorkerAreaByIdQuery query) =>
            await workerAreaRepository
            .FindByIdAsync(query.Id);

        public async Task<IEnumerable<WorkerArea>> Handle
            (GetWorkersAreasByGovernmentEntityIdAndStateQuery query)
            => await workerAreaRepository
            .FindByGovernmentEntityIdAndStateAsync
            (query.GovernmentEntityId, query.WorkerAreaState);

        public async Task<IEnumerable<WorkerArea>> Handle
            (GetWorkersAreasByGovernmentEntityIdQuery query) =>
            await workerAreaRepository
            .FindByGovernmentEntityIdAsync
            (query.GovernmentEntityId);
    }
}