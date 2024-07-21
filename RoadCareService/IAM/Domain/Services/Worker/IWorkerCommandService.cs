using RoadCareService.IAM.Domain.Model.Commands.Worker;

namespace RoadCareService.IAM.Domain.Services.Worker
{
    public interface IWorkerCommandService
    {
        Task<bool> Handle
            (RegisterWorkerCommand command);
    }
}