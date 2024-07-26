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
        public string State { get; private set; } = null!;

        public virtual Citizen Citizen { get; } = null!;
        public virtual District District { get; } = null!;

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
        public Publication
            (int citizenId,int districtId,
            string ubication, string description,
            EPublicationState publicationState)
        {
            this.CitizensId = citizenId;
            this.PublicationDate = DateTime.Now;
            this.DistrictsId = districtId;
            this.Ubication = ubication;
            this.Description = description;
            this.State = publicationState.ToString();
        }
        public Publication
            (CreatePublicationCommand command)
        {
            this.CitizensId = command.CitizenId;
            this.PublicationDate = DateTime.Now;
            this.DistrictsId = command.DistrictId;
            this.Ubication = command.Ubication;
            this.Description = command.Description;
            this.State = command.PublicationState.ToString();
        }
    }
}