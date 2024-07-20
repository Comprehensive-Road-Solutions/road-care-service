using RoadCareService.Assignment.Domain.Model.Queries.WorkerRole;

namespace RoadCareService.Assignment.Domain.Services.WorkerRole
{
    public interface IWorkerRoleQueryService
    {
        Task<IEnumerable<Model.Entities.WorkerRole>?> Handle
            (GetAllWorkersRolesQuery query);

        Task<Model.Entities.WorkerRole?> Handle
            (GetWorkerRoleByIdQuery query);

        Task<IEnumerable<Model.Entities.WorkerRole>?> Handle
            (GetWorkersRolesByGovernmentEntityIdAndWorkerAreaIdQuery query);
    }
}