using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Commands.Publication;
using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Publishing.Domain.Model.ValueObjects;

namespace RoadCareService.Publishing.Domain.Model.Aggregates
{
    public class Publication
    {
        public int Id { get; }
        public int CitizensId { get; private set; }
        public DateTime PublicationDate { get; private set; }
        public int DistrictsId { get; private set; }
        public string Ubication { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string State => PublicationState.ToString();

        public EPublicationState PublicationState { get; set; }

        public virtual Citizen Citizens { get; } = null!;
        public virtual District Districts { get; } = null!;

        public virtual ICollection<Comment> Comments { get; } = [];
        public virtual ICollection<Evidence> Evidences { get; } = [];

        public Publication()
        {
            this.CitizensId = 0;
            this.PublicationDate = DateTime.Now;
            this.DistrictsId = 0;
            this.Ubication = string.Empty;
            this.Description = string.Empty;
        }
        public Publication(int citizensId, DateTime publicationDate,
            int districtsId, string ubication, string description,
            EPublicationState publicationState)
        {
            this.CitizensId = citizensId;
            this.PublicationDate = publicationDate;
            this.DistrictsId = districtsId;
            this.Ubication = ubication;
            this.Description = description;
            this.PublicationState = publicationState;
        }
        public Publication(CreatePublicationCommand command)
        {
            this.CitizensId = command.CitizensId;
            this.PublicationDate = DateTime.Now;
            this.DistrictsId = command.DistrictsId;
            this.Ubication = command.Ubication;
            this.Description = command.Description;
            this.PublicationState = command.PublicationState;
        }
    }
}