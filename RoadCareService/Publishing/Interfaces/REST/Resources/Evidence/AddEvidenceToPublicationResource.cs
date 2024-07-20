namespace RoadCareService.Publishing.Interfaces.REST.Resources.Evidence
{
    public record AddEvidenceToPublicationResource
        (int PublicationId, string FileUrl);
}