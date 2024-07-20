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
        public Task<IEnumerable<WorkerRole>?> Handle(GetAllWorkersRolesQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<WorkerRole?> Handle(GetWorkerRoleByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkerRole>?> Handle(GetWorkersRolesByGovernmentEntityIdAndWorkerAreaIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}