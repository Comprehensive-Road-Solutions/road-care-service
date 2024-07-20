using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.Queries.WorkerRole;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.WorkerRole;

namespace RoadCareService.Assignment.Application.Internal.QueryServices
{
    public class WorkerRoleQueryService
        (IWorkerRoleRepository workerRoleRepository) :
        IWorkerRoleQueryService
    {
        public async Task<IEnumerable<WorkerRole>?> Handle
            (GetAllWorkersRolesQuery query) =>
            await workerRoleRepository.ListAsync();

        public async Task<WorkerRole?> Handle
            (GetWorkerRoleByIdQuery query) =>
            await workerRoleRepository
            .FindByIdAsync(query.Id);

        public async Task<IEnumerable<WorkerRole>?> Handle(
            GetWorkersRolesByGovernmentEntityIdAndWorkerAreaIdQuery query)
            => await workerRoleRepository
            .FindByGovernmentEntityIdAndWorkerAreaIdAsync
            (query.GovernmentEntityId, query.WorkerAreaId);
    }
}