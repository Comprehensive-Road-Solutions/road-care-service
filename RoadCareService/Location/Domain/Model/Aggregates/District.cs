using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Aggregates;

namespace RoadCareService.Location.Domain.Model.Aggregates
{
    public class District
    {
        public int Id { get; }
        public int DepartmentsId { get; private set; }
        public string Name { get; private set; } = null!;

        public virtual Department Department { get; } = null!;

        public virtual ICollection<DamagedInfrastructure> DamagedInfrastructures { get; } = [];
        public virtual ICollection<GovernmentEntity> GovernmentsEntities { get; } = [];
        public virtual ICollection<Publication> Publications { get; } = [];
        public virtual ICollection<Worker> Workers { get; } = [];
    }
}