using RoadCareService.Publishing.Application.Internal.OutboundServices.ACL;
using RoadCareService.Publishing.Domain.Model.Commands.Publication;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Publishing.Application.Internal.CommandServices
{
    public class PublicationCommandService
        (IPublicationRepository publicationRepository,
        IUnitOfWork unitOfWork,
        ExternalIamService externalIamService,
        ExternalPublishingService externalPublishingService) :
        IPublicationCommandService
    {
        public async Task<bool> Handle
            (CreatePublicationCommand command)
        {
            try
            {
                if (await externalIamService
                    .ExistsCitizenById
                    (command.CitizenId) is false ||
                    await externalPublishingService
                    .ExistsDistrictById
                    (command.DistrictId) is false)
                    return false;

                await publicationRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}