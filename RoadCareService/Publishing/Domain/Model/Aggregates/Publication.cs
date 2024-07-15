using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Aggregates;
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
    }
}