﻿using RoadCareService.Publishing.Domain.Model.Queries.Publication;

namespace RoadCareService.Publishing.Domain.Services.Publication
{
    public interface IPublicationQueryService
    {
        Task<IEnumerable<Model.Aggregates.Publication>?> Handle
            (GetAllPublicationsQuery query);
        Task<IEnumerable<Model.Aggregates.Publication>?> Handle
            (GetPublicationsByDepartmentsIdAndDistrictsIdQuery query);
    }
}