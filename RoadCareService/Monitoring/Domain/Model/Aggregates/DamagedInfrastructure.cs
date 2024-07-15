namespace RoadCareService.Monitoring.Domain.Model.Aggregates
{
    public class DamagedInfrastructure
    {
        public int Id { get; }
        public DateTime RegistrationDate { get; private set; }
        public string Description { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public DateTime? WorkDate { get; private set; }
        public string State { get; private set; } = null!;

        public virtual ICollection<Staff> Staff { get; } = [];
    }
}