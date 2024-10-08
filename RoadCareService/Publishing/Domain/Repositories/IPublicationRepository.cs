﻿using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Publishing.Domain.Repositories
{
    public interface IPublicationRepository :
        IBaseRepository<Publication>
    {
        Task<IEnumerable<Publication>> FindByDepartmentIdAndDistrictIdAsync
            (int departmentId, int districtId);
    }
}