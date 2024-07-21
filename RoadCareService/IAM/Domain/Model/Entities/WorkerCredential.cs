using RoadCareService.IAM.Domain.Model.Aggregates;

namespace RoadCareService.IAM.Domain.Model.Entities
{
    public class WorkerCredential
    {
        public int WorkersId { get; private set; }
        public string Code { get; private set; } = null!;

        public virtual Worker Worker { get; } = null!;

        public WorkerCredential()
        {
            this.WorkersId = 0;
            this.Code = string.Empty;
        }
        public WorkerCredential(int workerId, string code)
        {
            this.WorkersId = workerId;
            this.Code = code;
        }
    }
}