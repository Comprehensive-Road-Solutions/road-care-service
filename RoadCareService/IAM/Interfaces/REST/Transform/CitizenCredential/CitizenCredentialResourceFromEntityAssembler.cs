using RoadCareService.IAM.Interfaces.REST.Resources.CitizenCredential;

namespace RoadCareService.IAM.Interfaces.REST.Transform.CitizenCredential
{
    public class CitizenCredentialResourceFromEntityAssembler
    {
        public static CitizenCredentialResource ToResourceFromEntity
            (Domain.Model.Entities.CitizenCredential entity) =>
            new(entity.CitizensId, entity.Code);
    }
}