namespace RoadCareService.Publishing.Domain.Model.Commands.Evidence
{
    public record AddEvidenceToPublicationCommand(int PublicationsId, string FileUrl);
}