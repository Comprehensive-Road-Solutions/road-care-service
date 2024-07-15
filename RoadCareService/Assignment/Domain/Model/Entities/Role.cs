using RoadCareService.Assignment.Domain.Model.Aggregates;

namespace RoadCareService.Assignment.Domain.Model.Entities
{
    public class Role
    {
        public int Id { get; }
        public int WorkersAreasId { get; private set; }
        public string Name { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual WorkerArea WorkersAreas { get; set; } = null!;

        public virtual ICollection<AssignmentWorker> AssignmentsWorkers { get; set; } = [];
    }
}