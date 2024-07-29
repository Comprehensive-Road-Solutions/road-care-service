namespace RoadCareService.Location.Domain.Model.Aggregates
{
    public class Department
    {
        public int Id { get; }
        public string Name { get; private set; } = null!;

        public virtual ICollection<District> Districts { get; } = [];
    }
}