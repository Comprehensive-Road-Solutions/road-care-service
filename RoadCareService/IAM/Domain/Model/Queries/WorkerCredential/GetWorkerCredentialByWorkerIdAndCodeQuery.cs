namespace RoadCareService.IAM.Domain.Model.Queries.WorkerCredential
{
    public record GetWorkerCredentialByWorkerIdAndCodeQuery
        (int Id, string Code);
}