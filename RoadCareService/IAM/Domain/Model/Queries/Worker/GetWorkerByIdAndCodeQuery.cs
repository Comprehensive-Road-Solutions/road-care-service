namespace RoadCareService.IAM.Domain.Model.Queries.Worker
{
    public record GetWorkerByIdAndCodeQuery
        (int Id, string Code);
}