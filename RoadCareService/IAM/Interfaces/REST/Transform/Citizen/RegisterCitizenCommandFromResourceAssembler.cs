using RoadCareService.IAM.Domain.Model.Commands.Citizen;
using RoadCareService.IAM.Domain.Model.ValueObjects.Citizen;
using RoadCareService.IAM.Interfaces.REST.Resources.Citizen;

namespace RoadCareService.IAM.Interfaces.REST.Transform.Citizen
{
    public class RegisterCitizenCommandFromResourceAssembler
    {
        public static RegisterCitizenCommand ToCommandFromResource
            (RegisterCitizenResource resource) =>
            new(resource.Id, resource.ProfileUrl,
                resource.Firstname, resource.Lastname,
                resource.Age, resource.Genre,
                resource.Phone, resource.Email,
                ECitizenState.ACTIVO);
    }
}