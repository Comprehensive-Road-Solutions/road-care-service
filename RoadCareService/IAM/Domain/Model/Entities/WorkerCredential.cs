using RoadCareService.IAM.Domain.Model.Aggregates;

namespace RoadCareService.IAM.Domain.Model.Entities
{
    public class WorkerCredential
    {
        public int WorkersId { get; private set; }
        public string Code { get; private set; } = null!;

        public virtual Worker Worker { get; } = null!;
    }
}