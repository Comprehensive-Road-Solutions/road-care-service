using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories
{
    public class PublicationRepository
        (RoadCareContext context) :
        BaseRepository<Publication>(context),
        IPublicationRepository
    {
        public async Task<IEnumerable<Publication>> FindByDepartmentIdAndDistrictIdAsync
            (int departmentId, int districtId)
        {
            Task<IEnumerable<Publication>?> queryAsync = new(() =>
            {
                return
                from pu in Context.Set<Publication>().ToList()
                join di in Context.Set<District>().ToList()
                on pu.DistrictsId equals di.Id
                join de in Context.Set<Department>().ToList()
                on di.DepartmentsId equals de.Id
                where de.Id == departmentId &&
                di.Id == districtId &&
                pu.State == "PUBLICADO"
                select pu;
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}