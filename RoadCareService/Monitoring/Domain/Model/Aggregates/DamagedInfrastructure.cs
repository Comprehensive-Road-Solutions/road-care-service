using System.Text.RegularExpressions;
using RoadCareService.Monitoring.Domain.Model.Commands.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Location.Domain.Model.Aggregates;

namespace RoadCareService.Monitoring.Domain.Model.Aggregates
{
    public class DamagedInfrastructure
    {
        public int Id { get; private set; }
        public int DistrictsId { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string Description { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public DateTime? WorkDate { get; private set; }
        public string State { get; private set; } = null!;

        public virtual District District { get; } = null!;

        public virtual ICollection<Staff> Staff { get; } = [];

        public DamagedInfrastructure()
        {
            this.DistrictsId = 0;
            this.RegistrationDate = DateTime.Now;
            this.Description = string.Empty;
            this.Address = string.Empty;
            this.WorkDate = null;
            this.State = string.Empty;
        }
        public DamagedInfrastructure
            (int districtId, string description, string address,
            EDamagedInfrastructureState damagedInfrastructureState)
        {
            this.DistrictsId = districtId;
            this.RegistrationDate = DateTime.Now;
            this.Description = description.ToUpper();
            this.Address = address.ToUpper();
            this.WorkDate = null;
            this.State = Regex.Replace
                (damagedInfrastructureState
                .ToString(), "([A-Z])", " $1")
                .Trim();
        }
        public DamagedInfrastructure
            (RegisterDamagedInfrastructureCommand command)
        {
            this.DistrictsId = command.DistrictId;
            this.RegistrationDate = DateTime.Now;
            this.Description = command.Description.ToUpper();
            this.Address = command.Address.ToUpper();
            this.WorkDate = null;
            this.State = Regex.Replace(command
                .DamagedInfrastructureState
                .ToString(), "([A-Z])", " $1")
                .Trim();
        }
        public DamagedInfrastructure
            (AssignWorkDateToDamagedInfrastructureCommand command)
        {
            this.Id = command.Id;
            this.WorkDate = command.WorkDate;
        }
        public DamagedInfrastructure
            (UpdateDamagedInfrastructureStateCommand command)
        {
            this.Id = command.Id;
            this.State = Regex.Replace(command
                .DamagedInfrastructureState
                .ToString(), "([A-Z])", " $1")
                .Trim();
        }
    }
}