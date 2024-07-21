using Microsoft.EntityFrameworkCore;
using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories
{
    public class DistrictRepository
        (RoadCareContext context) :
        BaseRepository<District>(context),
        IDistrictRepository
    {
        public async Task<IEnumerable<District>?> FindByDepartmentIdAsync
            (int departmentId) => await Context.Set<District>()
            .Where(d => d.DepartmentsId == departmentId).ToListAsync();
    }
}