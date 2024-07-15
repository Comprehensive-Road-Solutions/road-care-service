using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Aggregates;

namespace RoadCareService.Interaction.Domain.Model.Aggregates
{
    public class Comment
    {
        public int Id { get; }
        public int PublicationsId { get; private set; }
        public int CitizensId { get; private set; }
        public DateTime ShippingDate { get; private set; }
        public string Opinion { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual Citizen Citizens { get; } = null!;
        public virtual Publication Publications { get; } = null!;
    }
}