namespace RoadCareService.Publishing.Domain.Model.Commands
{
    public record CreateEvidenceCommand(int PublicationsId, string FileUrl);
}