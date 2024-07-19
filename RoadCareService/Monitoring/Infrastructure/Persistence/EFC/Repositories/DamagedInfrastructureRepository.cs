using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Monitoring.Infrastructure.Persistence.EFC.Repositories
{
    public class DamagedInfrastructureRepository(RoadCareContext context) :
        BaseRepository<DamagedInfrastructure>(context), IDamagedInfrastructureRepository
    {
        public async Task<bool> UpdateDamagedInfrastructureStateAsync
            (int id, EDamagedInfrastructureState damagedInfrastructureState)
        {
            try
            {
                await Context.Set<DamagedInfrastructure>().Where(d => d.Id == id)
                .ExecuteUpdateAsync(d => d
                .SetProperty(u => u.State, Regex.Replace(damagedInfrastructureState
                .ToString(), "([A-Z])", " $1").Trim()));

                return true;
            }
            catch (Exception) { return false; }
        }
        public async Task<IEnumerable<DamagedInfrastructure>?> FindByDepartmentsIdAndDistrictsIdAsync
            (int departmentsId, int districtsId)
        {
            Task<IEnumerable<DamagedInfrastructure>?> queryAsync = new(() =>
            {
                return
                from da in Context.Set<DamagedInfrastructure>()
                join di in Context.Set<District>() on da.DistrictsId equals di.Id
                join de in Context.Set<Department>() on di.DepartmentsId equals de.Id
                where de.Id == departmentsId && di.Id == districtsId
                select da;
            });

            queryAsync.Start();

            return await queryAsync;
        }
        public async Task<IEnumerable<DamagedInfrastructure>?> FindByStateAsync
            (EDamagedInfrastructureState damagedInfrastructureState) =>
            await Context.Set<DamagedInfrastructure>()
            .Where(d => d.State == Regex.Replace(damagedInfrastructureState
                .ToString(), "([A-Z])", " $1").Trim()).ToListAsync();
    }
}