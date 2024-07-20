using RoadCareService.Assignment.Domain.Model.Commands.WorkerArea;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.WorkerArea;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Application.Internal.CommandServices
{
    public class WorkerAreaCommandService
        (IWorkerAreaRepository workerAreaRepository,
        IUnitOfWork unitOfWork) :
        IWorkerAreaCommandService
    {
        public Task<bool> Handle
            (CreateWorkerAreaCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle
            (UpdateWorkerAreaStateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}