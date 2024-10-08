﻿using RoadCareService.Monitoring.Domain.Model.Queries.Staff;

namespace RoadCareService.Monitoring.Domain.Services.Staff
{
    public interface IStaffQueryService
    {
        Task<IEnumerable<Model.Aggregates.Staff>> Handle
            (GetAllStaffQuery query);

        Task<Model.Aggregates.Staff?> Handle
            (GetStaffByIdQuery query);

        Task<IEnumerable<Model.Aggregates.Staff>> Handle
            (GetStaffByWorkerIdQuery query);

        Task<IEnumerable<Model.Aggregates.Staff>> Handle
            (GetStaffByStateQuery query);
    }
}