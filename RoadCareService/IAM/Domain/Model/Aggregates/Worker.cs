using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Entities;

namespace RoadCareService.IAM.Domain.Model.Aggregates
{
    public class Worker
    {
        public int Id { get; private set; }
        public int DistrictsId { get; private set; }
        public int GovernmentsEntitiesId { get; private set; }
        public string Firstname { get; private set; } = null!;
        public string Lastname { get; private set; } = null!;
        public int Age { get; private set; }
        public string Genre { get; private set; } = null!;
        public int Phone { get; private set; }
        public string Email { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual District Districts { get; } = null!;
        public virtual GovernmentEntity GovernmentsEntities { get; } = null!;
        public virtual WorkerCredential? WorkersCredential { get; }

        public virtual ICollection<AssignmentWorker> AssignmentsWorkers { get; } = [];
        public virtual ICollection<Staff> Staff { get; } = [];
    }
}