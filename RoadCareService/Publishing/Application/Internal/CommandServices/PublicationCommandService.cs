using RoadCareService.Publishing.Domain.Model.Commands.Publication;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Publishing.Application.Internal.CommandServices
{
    public class PublicationCommandService(IPublicationRepository publicationRepository,
        IUnitOfWork unitOfWork) : IPublicationCommandService
    {
        public async Task<bool> Handle(CreatePublicationCommand command)
        {
            try
            {
                await publicationRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}