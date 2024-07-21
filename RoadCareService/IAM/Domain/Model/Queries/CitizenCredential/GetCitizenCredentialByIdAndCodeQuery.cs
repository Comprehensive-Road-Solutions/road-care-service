namespace RoadCareService.IAM.Domain.Model.Queries.CitizenCredential
{
    public record GetCitizenCredentialByIdAndCodeQuery
        (int Id, string Code);
}