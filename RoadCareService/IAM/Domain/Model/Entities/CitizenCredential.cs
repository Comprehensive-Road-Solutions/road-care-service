using RoadCareService.IAM.Domain.Model.Aggregates;

namespace RoadCareService.IAM.Domain.Model.Entities
{
    public class CitizenCredential
    {
        public int CitizensId { get; private set; }
        public string Code { get; private set; } = null!;

        public virtual Citizen Citizen { get; } = null!;

        public CitizenCredential()
        {
            this.CitizensId = 0;
            this.Code = string.Empty;
        }
        public CitizenCredential(int citizenId, string code)
        {
            this.CitizensId = citizenId;
            this.Code = code;
        }
    }
}