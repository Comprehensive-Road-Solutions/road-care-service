namespace RoadCareService.Publishing.Domain.Model.Commands.Evidence
{
    public record AddEvidenceToPublicationCommand
        (int PublicationId, string FileUrl);
}