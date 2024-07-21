using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Aggregates;

namespace RoadCareService.IAM.Domain.Model.Aggregates
{
    public class Citizen
    {
        public int Id { get; private set; }
        public string? ProfileUrl { get; private set; }
        public string Firstname { get; private set; } = null!;
        public string Lastname { get; private set; } = null!;
        public int Age { get; private set; }
        public string Genre { get; private set; } = null!;
        public int Phone { get; private set; }
        public string Email { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual CitizenCredential? CitizenCredential { get; }

        public virtual ICollection<Comment> Comments { get; } = [];
        public virtual ICollection<Publication> Publications { get; } = [];
    }
}