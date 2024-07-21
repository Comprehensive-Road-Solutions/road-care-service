namespace RoadCareService.IAM.Interfaces.REST.Resources.Citizen
{
    public record CitizenResource
        (int Id, string? ProfileUrl,
        string Firstname, string Lastname,
        int Age, string Genre, int Phone,
        string Email);
}