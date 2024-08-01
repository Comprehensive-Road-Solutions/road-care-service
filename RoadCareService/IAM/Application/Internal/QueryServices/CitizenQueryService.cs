using RoadCareService.IAM.Domain.Model.Queries.Citizen;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Citizen;

namespace RoadCareService.IAM.Application.Internal.QueryServices
{
    internal class CitizenQueryService
        (ICitizenRepository citizenRepository) :
        ICitizenQueryService
    {
        public async Task<bool> Handle
            (GetCitizenByIdQuery query)
        {
            var result = await citizenRepository
                .FindByIdAsync(query.Id);

            if (result is null)
                return false;

            return true;
        }
    }
}