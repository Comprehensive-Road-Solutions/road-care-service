namespace RoadCareService.Publishing.Domain.Model.Commands.Evidence
{
    public record CreateEvidenceCommand(int PublicationsId, string FileUrl);
}