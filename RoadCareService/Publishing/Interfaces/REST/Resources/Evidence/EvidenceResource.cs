namespace RoadCareService.Publishing.Interfaces.REST.Resources.Evidence
{
    public record EvidenceResource(int Id,
        int PublicationId, string FileUrl);
}