using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Commands.WorkerRole;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerRole;

namespace RoadCareService.Assignment.Domain.Model.Entities
{
    public class WorkerRole
    {
        public int Id { get; }
        public int WorkersAreasId { get; private set; }
        public string Name { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual WorkerArea WorkersAreas { get; set; } = null!;

        public virtual ICollection<AssignmentWorker> AssignmentsWorkers { get; set; } = [];

        public WorkerRole()
        {
            this.WorkersAreasId = 0;
            this.Name = string.Empty;
            this.State = string.Empty;
        }
        public WorkerRole(int workersAreasId, string name,
            EWorkerRoleState roleState)
        {
            this.WorkersAreasId = workersAreasId;
            this.Name = name;
            this.State = roleState.ToString();
        }
        public WorkerRole(AddWorkerRoleToWorkerAreaCommand command)
        {
            this.WorkersAreasId = command.WorkersAreasId;
            this.Name = command.Name;
            this.State = command.RoleState.ToString();
        }
        public WorkerRole(UpdateWorkerRoleStateCommand command)
        {
            this.Id = command.Id;
            this.State = command.RoleState.ToString();
        }
    }
}