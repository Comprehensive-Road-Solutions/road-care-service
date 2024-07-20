using RoadCareService.Publishing.Domain.Model.Commands.Evidence;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Evidence;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Publishing.Application.Internal.CommandServices
{
    public class EvidenceCommandService
        (IEvidenceRepository evidenceRepository,
        IUnitOfWork unitOfWork) :
        IEvidenceCommandService
    {
        public async Task<bool> Handle
            (AddEvidenceToPublicationCommand command)
        {
            try
            {
                await evidenceRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}