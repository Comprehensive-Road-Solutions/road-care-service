using RoadCareService.Assignment.Domain.Model.Commands.WorkerRole;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.WorkerRole;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Application.Internal.CommandServices
{
    public class WorkerRoleCommandService
        (IWorkerRoleRepository workerRoleRepository,
        IUnitOfWork unitOfWork) : IWorkerRoleCommandService
    {
        public Task<bool> Handle
            (AddWorkerRoleToWorkerAreaCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle
            (UpdateWorkerRoleStateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}