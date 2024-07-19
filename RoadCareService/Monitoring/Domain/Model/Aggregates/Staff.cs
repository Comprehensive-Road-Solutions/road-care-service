using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.Commands.Staff;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;

namespace RoadCareService.Monitoring.Domain.Model.Aggregates
{
    public class Staff
    {
        public int Id { get; }
        public int DamagedInfrastructuresId { get; private set; }
        public int WorkersId { get; private set; }
        public string State { get; private set; } = null!;

        public virtual DamagedInfrastructure DamagedInfrastructures { get; } = null!;
        public virtual Worker Workers { get; } = null!;

        public Staff()
        {
            this.DamagedInfrastructuresId = 0;
            this.WorkersId = 0;
            this.State = string.Empty;
        }
        public Staff(int damagedInfrastructuresId,
            int workersId, EStaffState staffState)
        {
            this.DamagedInfrastructuresId = damagedInfrastructuresId;
            this.WorkersId = workersId;
            this.State = staffState.ToString();
        }
        public Staff(AddStaffInChargeCommand command)
        {
            this.DamagedInfrastructuresId = command.DamagedInfrastructuresId;
            this.WorkersId = command.WorkersId;
            this.State = command.StaffState.ToString();
        }
        public Staff(UpdateStaffStateCommand command)
        {
            this.State = command.StaffState.ToString();
        }
    }
}