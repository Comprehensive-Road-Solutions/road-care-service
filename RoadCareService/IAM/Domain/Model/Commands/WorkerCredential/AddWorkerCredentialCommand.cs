namespace RoadCareService.IAM.Domain.Model.Commands.WorkerCredential
{
    public record AddWorkerCredentialCommand
        (int WorkerId, string Code);
}