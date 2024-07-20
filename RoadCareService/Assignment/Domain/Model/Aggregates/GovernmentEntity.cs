using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Entities;

namespace RoadCareService.Assignment.Domain.Model.Aggregates
{
    public class GovernmentEntity
    {
        public int Id { get; }
        public int DistrictsId { get; private set; }
        public string Ruc { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public int Phone { get; private set; }
        public string Email { get; private set; } = null!;
        public string Address { get; private set; } = null!;

        public virtual District District { get; } = null!;

        public virtual ICollection<Worker> Workers { get; } = [];
        public virtual ICollection<WorkerArea> WorkersAreas { get; } = [];
    }
}