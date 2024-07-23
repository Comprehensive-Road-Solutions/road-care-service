using RoadCareService.IAM.Interfaces.ACL;

namespace RoadCareService.Interaction.Application.Internal.OutboundServices.ACL
{
    public class ExternalIamService
        (IIamContextFacade iamContextFacade)
    {
        public async Task<bool> ExistsCitizenById
            (int id) => await iamContextFacade
            .ExistsCitizenById(id);
    }
}