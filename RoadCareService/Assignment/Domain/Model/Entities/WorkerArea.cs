using RoadCareService.Assignment.Domain.Model.Aggregates;

namespace RoadCareService.Assignment.Domain.Model.Entities
{
    public class WorkerArea
    {
        public int Id { get; }
        public int GovernmentsEntitiesId { get; private set; }
        public string Name { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual GovernmentEntity GovernmentsEntities { get; } = null!;

        public virtual ICollection<Role> Roles { get; } = [];
    }
}