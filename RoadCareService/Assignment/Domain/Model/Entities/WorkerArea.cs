using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Commands.WorkerArea;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;

namespace RoadCareService.Assignment.Domain.Model.Entities
{
    public class WorkerArea
    {
        public int Id { get; }
        public int GovernmentsEntitiesId { get; private set; }
        public string Name { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual GovernmentEntity GovernmentEntity { get; } = null!;

        public virtual ICollection<WorkerRole> WorkersRoles { get; } = [];

        public WorkerArea()
        {
            this.GovernmentsEntitiesId = 0;
            this.Name = string.Empty;
            this.State = string.Empty;
        }
        public WorkerArea
            (int governmentEntityId, string name,
            EWorkerAreaState workerAreaState)
        {
            this.GovernmentsEntitiesId = governmentEntityId;
            this.Name = name.ToUpper();
            this.State = workerAreaState.ToString();
        }
        public WorkerArea
            (CreateWorkerAreaCommand command)
        {
            this.GovernmentsEntitiesId = command.GovernmentEntityId;
            this.Name = command.Name.ToUpper();
            this.State = command.WorkerAreaState.ToString();
        }
        public WorkerArea
            (UpdateWorkerAreaStateCommand command)
        {
            this.Id = command.Id;
            this.State = command.WorkerAreaState.ToString();
        }
    }
}