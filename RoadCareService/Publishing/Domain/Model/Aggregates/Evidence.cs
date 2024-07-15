using RoadCareService.Publishing.Domain.Model.Commands.Evidence;

namespace RoadCareService.Publishing.Domain.Model.Aggregates
{
    public class Evidence
    {
        public int Id { get; }
        public int PublicationsId { get; private set; }
        public string FileUrl { get; private set; } = null!;

        public virtual Publication Publications { get; } = null!;

        public Evidence()
        {
            this.PublicationsId = 0;
            this.FileUrl = string.Empty;
        }
        public Evidence(int publicationsId, string fileUrl)
        {
            this.PublicationsId = publicationsId;
            this.FileUrl = fileUrl;
        }
        public Evidence(CreateEvidenceCommand command)
        {
            this.PublicationsId = command.PublicationsId;
            this.FileUrl = command.FileUrl;
        }
    }
}