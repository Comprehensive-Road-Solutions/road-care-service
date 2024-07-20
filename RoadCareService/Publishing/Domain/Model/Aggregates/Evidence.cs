using RoadCareService.Publishing.Domain.Model.Commands.Evidence;

namespace RoadCareService.Publishing.Domain.Model.Aggregates
{
    public class Evidence
    {
        public int Id { get; }
        public int PublicationsId { get; private set; }
        public string FileUrl { get; private set; } = null!;

        public virtual Publication Publication { get; } = null!;

        public Evidence()
        {
            this.PublicationsId = 0;
            this.FileUrl = string.Empty;
        }
        public Evidence(int publicationId, string fileUrl)
        {
            this.PublicationsId = publicationId;
            this.FileUrl = fileUrl;
        }
        public Evidence(AddEvidenceToPublicationCommand command)
        {
            this.PublicationsId = command.PublicationId;
            this.FileUrl = command.FileUrl;
        }
    }
}