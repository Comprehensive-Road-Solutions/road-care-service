using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.Aggregates;

namespace RoadCareService.Assignment.Domain.Model.Aggregates
{
    public class AssignmentWorker
    {
        public int Id { get; }
        public int RolesId { get; private set; }
        public int WorkersId { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly FinalDate { get; private set; }
        public string State { get; private set; } = null!;

        public virtual Role Roles { get; } = null!;
        public virtual Worker Workers { get; } = null!;
    }
}