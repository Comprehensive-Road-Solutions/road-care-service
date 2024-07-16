using RoadCareService.Publishing.Domain.Model.Commands.Publication;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Shared.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace RoadCareService.Publishing.Application.Internal.CommandServices
{
    public class PublicationCommandService(RoadCareContext context,
        IUnitOfWork unitOfWork) : IPublicationCommandService
    {
        private IPublicationRepository PublicationRepository =
            new PublicationRepositoryEFC(context);

        public async Task<bool> Handle(CreatePublicationCommand command)
        {
            try
            {
                await PublicationRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}