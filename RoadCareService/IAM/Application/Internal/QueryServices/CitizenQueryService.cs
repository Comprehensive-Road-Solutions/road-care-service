using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.Queries.Citizen;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Citizen;

namespace RoadCareService.IAM.Application.Internal.QueryServices
{
    internal class CitizenQueryService
        (ICitizenRepository citizenRepository) :
        ICitizenQueryService
    {
        public async Task<Citizen?> Handle
            (GetCitizenByIdQuery query) =>
            await citizenRepository
            .FindByIdAsync(query.Id);
    }
}