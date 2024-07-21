namespace RoadCareService.IAM.Domain.Model.Commands.CitizenCredential
{
    public record AddCitizenCredentialCommand
        (int CitizenId, string Code);
}