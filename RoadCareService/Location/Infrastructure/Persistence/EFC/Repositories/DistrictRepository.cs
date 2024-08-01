using Microsoft.EntityFrameworkCore;
using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Location.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Location.Infrastructure.Persistence.EFC.Repositories
{
    internal class DistrictRepository
        (RoadCareContext context) :
        BaseRepository<District>(context),
        IDistrictRepository
    {
        public async Task<IEnumerable<District>> FindByDepartmentIdAsync
            (int departmentId) => await Context.Set<District>()
            .Where(d => d.DepartmentsId == departmentId).ToListAsync();
    }
}