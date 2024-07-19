using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Commands.Role;
using RoadCareService.Assignment.Domain.Model.ValueObjects.Role;

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

        public Role()
        {
            this.WorkersAreasId = 0;
            this.Name = string.Empty;
            this.State = string.Empty;
        }
        public Role(int workersAreasId, string name, ERoleState roleState)
        {
            this.WorkersAreasId = workersAreasId;
            this.Name = name;
            this.State = roleState.ToString();
        }
        public Role(AddRoleToWorkerAreaCommand command)
        {
            this.WorkersAreasId = command.WorkersAreasId;
            this.Name = command.Name;
            this.State = command.RoleState.ToString();
        }
        public Role(UpdateRoleStateCommand command)
        {
            this.Id = command.Id;
            this.State = command.RoleState.ToString();
        }
    }
}