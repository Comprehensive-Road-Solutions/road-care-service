using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Commands;
using RoadCareService.Interaction.Domain.Model.ValueObjects;
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

        public virtual Citizen Citizen { get; } = null!;
        public virtual Publication Publication { get; } = null!;

        public Comment()
        {
            this.PublicationsId = 0;
            this.CitizensId = 0;
            this.ShippingDate = DateTime.Now;
            this.Opinion = string.Empty;
        }
        public Comment(int publicationId, int citizenId,
            string opinion, ECommentState commentState)
        {
            this.PublicationsId = publicationId;
            this.CitizensId = citizenId;
            this.ShippingDate = DateTime.Now;
            this.Opinion = opinion;
            this.State = commentState.ToString();
        }
        public Comment(AddCommentToPublicationCommand command)
        {
            this.PublicationsId = command.PublicationId;
            this.CitizensId = command.CitizenId;
            this.ShippingDate = DateTime.Now;
            this.Opinion = command.Opinion;
            this.State = command.CommentState.ToString();
        }
    }
}