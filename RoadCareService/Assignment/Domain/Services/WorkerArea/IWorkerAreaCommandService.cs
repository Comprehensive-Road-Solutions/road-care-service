using RoadCareService.Assignment.Domain.Model.Commands.WorkerArea;

namespace RoadCareService.Assignment.Domain.Services.WorkerArea
{
    public interface IWorkerAreaCommandService
    {
        Task<bool> Handle
            (CreateWorkerAreaCommand command);

        Task<bool> Handle
            (UpdateWorkerAreaStateCommand command);
    }
}