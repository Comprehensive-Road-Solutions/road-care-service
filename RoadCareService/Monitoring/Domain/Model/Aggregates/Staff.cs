using RoadCareService.IAM.Domain.Model.Aggregates;

namespace RoadCareService.Monitoring.Domain.Model.Aggregates
{
    public class Staff
    {
        public int Id { get; }
        public int DamagedInfrastructuresId { get; private set; }
        public int WorkersId { get; private set; }
        public string State { get; private set; } = null!;

        public virtual DamagedInfrastructure DamagedInfrastructures { get; } = null!;
        public virtual Worker Workers { get; } = null!;
    }
}