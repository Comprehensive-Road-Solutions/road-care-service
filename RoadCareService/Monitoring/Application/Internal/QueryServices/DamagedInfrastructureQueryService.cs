﻿using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.Queries.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Monitoring.Domain.Services.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Application.Internal.QueryServices
{
    public class DamagedInfrastructureQueryService
        (IDamagedInfrastructureRepository damagedInfrastructureRepository) :
        IDamagedInfrastructureQueryService
    {
        public async Task<IEnumerable<DamagedInfrastructure>?> Handle
            (GetAllDamagedInfrastructuresQuery query) =>
            await damagedInfrastructureRepository.ListAsync();
        public async Task<DamagedInfrastructure?> Handle
            (GetDamagedInfrastructureByIdQuery query) =>
            await damagedInfrastructureRepository
            .FindByIdAsync(query.Id);
        public async Task<IEnumerable<DamagedInfrastructure>?> Handle
            (GetDamagedInfrastructuresByDepartmentsIdAndDistrictsIdQuery query) =>
            await damagedInfrastructureRepository
            .FindByDepartmentsIdAndDistrictsIdAsync
            (query.DepartmentsId, query.DistrictsId);
        public async Task<IEnumerable<DamagedInfrastructure>?> Handle
            (GetDamagedInfrastructuresByStateQuery query) =>
            await damagedInfrastructureRepository.FindByStateAsync
            (query.DamagedInfrastructureState);
    }
}