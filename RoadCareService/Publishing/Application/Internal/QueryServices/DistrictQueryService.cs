﻿using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Publishing.Domain.Model.Queries.District;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.District;

namespace RoadCareService.Publishing.Application.Internal.QueryServices
{
    public class DistrictQueryService
        (IDistrictRepository districtRepository) :
        IDistrictQueryService
    {
        public async Task<bool> Handle
            (GetDistrictByIdQuery query) =>
            await districtRepository
            .FindByIdAsync(query.Id)
            is not null;

        public async Task<IEnumerable<District>> Handle
            (GetDistrictsByDepartmentIdQuery query) =>
            await districtRepository.FindByDepartmentIdAsync
            (query.DepartmentId);
    }
}