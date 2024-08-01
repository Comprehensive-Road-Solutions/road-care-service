using RoadCareService.Interaction.Application.Internal.OutboundServices.ACL;
using RoadCareService.Interaction.Domain.Model.Commands;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Interaction.Domain.Services;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Interaction.Application.Internal.CommandServices
{
    internal class CommentCommandService
        (ICommentRepository commentRepository,
        IUnitOfWork unitOfWork,
        ExternalPublishingService externalPublishingService,
        ExternalIamService externalIamService) :
        ICommentCommandService
    {
        public async Task<bool> Handle
            (AddCommentToPublicationCommand command)
        {
            try
            {
                if (await externalPublishingService
                    .ExistsPublicationById
                    (command.PublicationId) is false ||
                    await externalIamService
                    .ExistsCitizenById
                    (command.CitizenId) is false)
                    return false;

                await commentRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}