using RoadCareService.Publishing.Domain.Model.Commands.Evidence;

namespace RoadCareService.Publishing.Domain.Services.Evidence
{
    public interface IEvidenceCommandService
    {
        Task<bool> Handle(CreateEvidenceCommand command);
    }
}