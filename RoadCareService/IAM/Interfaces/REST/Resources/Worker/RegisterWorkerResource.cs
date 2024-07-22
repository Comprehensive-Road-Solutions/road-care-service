namespace RoadCareService.IAM.Interfaces.REST.Resources.Worker
{
    public record RegisterWorkerResource
        (int Id, int DistrictId, int GovernmentEntityId,
        string Firstname, string Lastname, int Age,
        string Genre, int Phone, string Email,
        string Address, string Code);
}