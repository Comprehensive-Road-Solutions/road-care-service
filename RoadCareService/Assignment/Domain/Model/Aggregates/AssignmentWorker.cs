using RoadCareService.Assignment.Domain.Model.Commands.AssignmentWorker;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;
using RoadCareService.IAM.Domain.Model.Aggregates;

namespace RoadCareService.Assignment.Domain.Model.Aggregates
{
    public class AssignmentWorker
    {
        public int Id { get; }
        public int WorkersRolesId { get; private set; }
        public int WorkersId { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly FinalDate { get; private set; }
        public string State { get; private set; } = null!;

        public virtual WorkerRole WorkerRole { get; } = null!;
        public virtual Worker Worker { get; } = null!;

        public AssignmentWorker()
        {
            this.WorkersRolesId = 0;
            this.WorkersId = 0;
            this.State = string.Empty;
        }
        public AssignmentWorker
            (int workerRoleId, int workerId, DateOnly startDate,
            DateOnly finalDate, EAssignmentWorkerState assignmentWorkerState)
        {
            this.WorkersRolesId = workerRoleId;
            this.WorkersId = workerId;
            this.StartDate = startDate;
            this.FinalDate = finalDate;
            this.State = assignmentWorkerState.ToString();
        }
        public AssignmentWorker
            (AddAssignmentWorkerCommand command)
        {
            this.WorkersRolesId = command.WorkerRoleId;
            this.WorkersId = command.WorkerId;
            this.StartDate = command.StartDate;
            this.FinalDate = command.FinalDate;
            this.State = command.AssignmentWorkerState.ToString();
        }
        public AssignmentWorker
            (UpdateAssignmentWorkerStateCommand command)
        {
            this.Id = command.Id;
            this.State = command.AssignmentWorkerState.ToString();
        }
    }
}