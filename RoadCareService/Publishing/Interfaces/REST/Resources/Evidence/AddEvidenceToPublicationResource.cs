namespace RoadCareService.Publishing.Interfaces.REST.Resources.Evidence
{
    public record AddEvidenceToPublicationResource(int PublicationsId, string FileUrl);
}