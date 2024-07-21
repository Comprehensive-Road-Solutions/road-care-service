namespace RoadCareService.IAM.Domain.Model.Queries.Citizen
{
    public record GetCitizenCredentialByIdAndCodeQuery
        (int Id, string Code);
}