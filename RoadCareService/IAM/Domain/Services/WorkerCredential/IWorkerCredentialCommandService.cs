using RoadCareService.IAM.Domain.Model.Commands.WorkerCredential;

namespace RoadCareService.IAM.Domain.Services.WorkerCredential
{
    public interface IWorkerCredentialCommandService
    {
        Task<bool> Handle
            (AddWorkerCredentialCommand command);
    }
}