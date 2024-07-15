namespace RoadCareService.Publishing.Domain.Model.Entities
{
    public class Department
    {
        public int Id { get; }
        public string Name { get; private set; } = null!;

        public virtual ICollection<District> Districts { get; } = [];
    }
}