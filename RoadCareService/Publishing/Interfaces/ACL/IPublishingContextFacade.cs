﻿using RoadCareService.Publishing.Domain.Model.Entities;

namespace RoadCareService.Publishing.Interfaces.ACL
{
    public interface IPublishingContextFacade
    {
        Task<IEnumerable<District>?> ExistsDistrictByDepartmentId(int departmentId);
        Task<bool> ExistsPublicationById(int id);
    }
}