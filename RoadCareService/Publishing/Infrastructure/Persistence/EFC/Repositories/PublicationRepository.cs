﻿using Microsoft.EntityFrameworkCore;
using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.ValueObjects.Publication;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories
{
    internal class PublicationRepository
        (RoadCareContext context) :
        BaseRepository<Publication>(context),
        IPublicationRepository
    {
        public new async Task<IEnumerable<Publication>> ListAsync() =>
            await Context.Set<Publication>()
            .Where(p => p.State == EPublicationState.PUBLICADO.ToString())
            .ToListAsync();

        public new async Task<Publication?> FindByIdAsync
            (int id) => await Context.Set<Publication>()
            .Where(p => p.Id == id && p.State == EPublicationState.PUBLICADO.ToString())
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Publication>> FindByDepartmentIdAndDistrictIdAsync
            (int departmentId, int districtId)
        {
            Task<IEnumerable<Publication>> queryAsync = new(() =>
            {
                return
                [.. (from pu in Context.Set<Publication>()
                join di in Context.Set<District>()
                on pu.DistrictsId equals di.Id
                join de in Context.Set<Department>()
                on di.DepartmentsId equals de.Id
                where di.Id == districtId &&
                de.Id == departmentId &&
                pu.State == EPublicationState.PUBLICADO.ToString()
                select pu)];
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}