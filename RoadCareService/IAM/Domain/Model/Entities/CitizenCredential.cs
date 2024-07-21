using RoadCareService.IAM.Domain.Model.Aggregates;

namespace RoadCareService.IAM.Domain.Model.Entities
{
    public class CitizenCredential
    {
        public int CitizensId { get; private set; }
        public string Code { get; private set; } = null!;

        public virtual Citizen Citizen { get; } = null!;
    }
}