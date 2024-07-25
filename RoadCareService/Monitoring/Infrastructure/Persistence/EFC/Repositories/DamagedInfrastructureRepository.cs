using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Monitoring.Infrastructure.Persistence.EFC.Repositories
{
    public class DamagedInfrastructureRepository
        (RoadCareContext context,
        HttpContext httpContext) :
        BaseRepository<DamagedInfrastructure>(context),
        IDamagedInfrastructureRepository
    {
        public async Task<bool> AssignWorkDateToDamagedInfrastructureAsync
            (int id, DateTime workDate)
        {
            try
            {
                var credentials = httpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return false;

                int districtId = credentials.DistrictId;

                await Context.Set<DamagedInfrastructure>()
                    .Where(d => d.Id == id &&
                    d.DistrictsId == districtId)
                    .ExecuteUpdateAsync(d => d
                    .SetProperty(u => u.WorkDate, workDate));

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> UpdateDamagedInfrastructureStateAsync
            (int id, EDamagedInfrastructureState damagedInfrastructureState)
        {
            try
            {
                var credentials = httpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return false;

                int districtId = credentials.DistrictId;

                await Context.Set<DamagedInfrastructure>()
                    .Where(d => d.Id == id &&
                    d.DistrictsId == districtId)
                    .ExecuteUpdateAsync(d => d
                    .SetProperty(u => u.State, Regex.Replace
                    (damagedInfrastructureState.ToString(),
                    "([A-Z])", " $1").Trim()));

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<IEnumerable<DamagedInfrastructure>> FindByDepartmentIdAndDistrictIdAsync
            (int departmentId, int districtId)
        {
            Task<IEnumerable<DamagedInfrastructure>> queryAsync = new(() =>
            {
                return
                from da in Context.Set<DamagedInfrastructure>().ToList()
                join di in Context.Set<District>().ToList()
                on da.DistrictsId equals di.Id
                join de in Context.Set<Department>().ToList()
                on di.DepartmentsId equals de.Id
                where de.Id == departmentId &&
                di.Id == districtId
                select da;
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<DamagedInfrastructure>> FindByStateAsync
            (EDamagedInfrastructureState damagedInfrastructureState) =>
            await Context.Set<DamagedInfrastructure>()
            .Where(d => d.State == Regex.Replace(damagedInfrastructureState
                .ToString(), "([A-Z])", " $1").Trim()).ToListAsync();
    }
}