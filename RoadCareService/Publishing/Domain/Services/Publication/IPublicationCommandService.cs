using RoadCareService.Publishing.Domain.Model.Commands.Publication;

namespace RoadCareService.Publishing.Domain.Services.Publication
{
    public interface IPublicationCommandService
    {
        Task<bool> Handle(CreatePublicationCommand command);
    }
}