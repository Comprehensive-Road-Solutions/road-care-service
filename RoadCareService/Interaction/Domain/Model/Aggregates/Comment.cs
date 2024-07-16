using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Commands;
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

        public Comment()
        {
            this.PublicationsId = 0;
            this.CitizensId = 0;
            this.ShippingDate = DateTime.Now;
            this.Opinion = string.Empty;
        }
        public Comment(int publicationsId, int citizensId, string opinion)
        {
            this.PublicationsId = publicationsId;
            this.CitizensId = citizensId;
            this.ShippingDate = DateTime.Now;
            this.Opinion = opinion;
        }
        public Comment(AddCommentToPublicationCommand command)
        {
            this.PublicationsId = command.PublicationsId;
            this.CitizensId = command.CitizensId;
            this.ShippingDate = DateTime.Now;
            this.Opinion = command.Opinion;
        }
    }
}