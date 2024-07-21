using RoadCareService.IAM.Domain.Model.ValueObjects.Citizen;

namespace RoadCareService.IAM.Domain.Model.Commands.Citizen
{
    public record RegisterCitizenCommand
        (int Id, string? ProfileUrl,
        string Firstname, string Lastname,
        int Age, string Genre,
        int Phone, string Email,
        ECitizenState CitizenState);
}