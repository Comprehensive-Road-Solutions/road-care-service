namespace RoadCareService.IAM.Domain.Model.Queries.WorkerCredential
{
    public record GetWorkerCredentialByIdAndCodeQuery
        (int Id, string Code);
}