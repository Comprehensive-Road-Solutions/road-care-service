using RoadCareService.Publishing.Domain.Model.Commands.Evidence;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Evidence;
using RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Shared.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace RoadCareService.Publishing.Application.Internal.CommandServices
{
    public class EvidenceCommandService(RoadCareContext context,
        IUnitOfWork unitOfWork) : IEvidenceCommandService
    {
        private IEvidenceRepository EvidenceRepository =
            new EvidenceRepositoryEFC(context);

        public async Task<bool> Handle
            (AddEvidenceToPublicationCommand command)
        {
            try
            {
                await EvidenceRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}