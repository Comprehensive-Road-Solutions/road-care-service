using RoadCareService.Assignment.Domain.Model.Commands.WorkerArea;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.WorkerArea;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Application.Internal.CommandServices
{
    internal class WorkerAreaCommandService
        (IWorkerAreaRepository workerAreaRepository,
        IUnitOfWork unitOfWork) :
        IWorkerAreaCommandService
    {
        public async Task<bool> Handle
            (CreateWorkerAreaCommand command)
        {
            try
            {
                await workerAreaRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception){ return true; }
        }

        public async Task<bool> Handle
            (UpdateWorkerAreaStateCommand command) =>
            await workerAreaRepository
            .UpdateWorkerAreaStateAsync
            (command.Id, command.WorkerAreaState);
    }
}