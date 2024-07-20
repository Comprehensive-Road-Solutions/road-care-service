using RoadCareService.Assignment.Domain.Model.Commands.WorkerRole;

namespace RoadCareService.Assignment.Domain.Services.WorkerRole
{
    public interface IWorkerRoleCommandService
    {
        Task<bool> Handle
            (AddWorkerRoleToWorkerAreaCommand command);
        Task<bool> Handle
            (UpdateWorkerRoleStateCommand command);
    }
}