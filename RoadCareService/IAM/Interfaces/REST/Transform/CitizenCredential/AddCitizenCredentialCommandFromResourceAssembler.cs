using RoadCareService.IAM.Domain.Model.Commands.CitizenCredential;
using RoadCareService.IAM.Interfaces.REST.Resources.CitizenCredential;

namespace RoadCareService.IAM.Interfaces.REST.Transform.CitizenCredential
{
    public class AddCitizenCredentialCommandFromResourceAssembler
    {
        public static AddCitizenCredentialCommand ToCommandFromResource
            (AddCitizenCredentialResource resource) =>
            new(resource.CitizenId, resource.Code);
    }
}