namespace RoadCareService.Publishing.Domain.Model.Aggregates
{
    public class Evidence
    {
        public int Id { get; }
        public int PublicationsId { get; private set; }
        public string FileUrl { get; private set; } = null!;

        public virtual Publication Publications { get; } = null!;
    }
}