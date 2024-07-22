namespace RoadCareService.IAM.Domain.Model.Queries.CitizenCredential
{
    public record GetCitizenCredentialByCitizenIdAndCodeQuery
        (int Id, string Code);
}