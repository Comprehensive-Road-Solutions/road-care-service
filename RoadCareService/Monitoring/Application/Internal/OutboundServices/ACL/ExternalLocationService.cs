﻿using RoadCareService.Location.Interfaces.ACL;

namespace RoadCareService.Monitoring.Application.Internal.OutboundServices.ACL
{
    public class ExternalLocationService
        (ILocationContextFacade locationContextFacade)
    {
        public async Task<bool> ExistsDistrictById
            (int id) => await locationContextFacade
            .ExistsDistrictById(id);
    }
}