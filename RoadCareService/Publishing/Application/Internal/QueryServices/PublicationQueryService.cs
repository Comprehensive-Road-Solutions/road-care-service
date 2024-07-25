using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Queries.Publication;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Publication;

namespace RoadCareService.Publishing.Application.Internal.QueryServices
{
    public class PublicationQueryService
        (IPublicationRepository publicationRepository) :
        IPublicationQueryService
    {
        public async Task<IEnumerable<Publication>> Handle
            (GetAllPublicationsQuery query) =>
            await publicationRepository.ListAsync();

        public async Task<Publication?> Handle
            (GetPublicationByIdQuery query) =>
            await publicationRepository
            .FindByIdAsync(query.Id);

        public async Task<IEnumerable<Publication>> Handle
            (GetPublicationsByDepartmentIdAndDistrictIdQuery query) =>
            await publicationRepository
            .FindByDepartmentIdAndDistrictIdAsync
            (query.DepartmentId, query.DistrictId);
    }
}