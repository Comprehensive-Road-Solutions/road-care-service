using Microsoft.EntityFrameworkCore;
using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Monitoring.Infrastructure.Persistence.EFC.Repositories
{
    internal class DamagedInfrastructureRepository
        (RoadCareContext context,
        IHttpContextAccessor httpContextAccessor) :
        BaseRepository<DamagedInfrastructure>(context),
        IDamagedInfrastructureRepository
    {
        public async Task<bool> AssignWorkDateToDamagedInfrastructureAsync
            (int id, DateTime workDate)
        {
            try
            {
                if (httpContextAccessor.HttpContext is null)
                    return false;

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return false;

                int districtId = credentials.DistrictId;

                return await Context.Set<DamagedInfrastructure>()
                    .Where(d => d.Id == id &&
                    d.DistrictsId == districtId)
                    .ExecuteUpdateAsync(d => d
                    .SetProperty(u => u.WorkDate, workDate)) > 0;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> UpdateDamagedInfrastructureStateAsync
            (int id, EDamagedInfrastructureState damagedInfrastructureState)
        {
            try
            {
                if (httpContextAccessor.HttpContext is null)
                    return false;

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return false;

                int districtId = credentials.DistrictId;

                string newState = damagedInfrastructureState.ToString() ==
                    "ENPROCESO" ? "EN PROCESO" :
                    damagedInfrastructureState
                    .ToString();

                return await Context.Set<DamagedInfrastructure>()
                    .Where(d => d.Id == id &&
                    d.DistrictsId == districtId)
                    .ExecuteUpdateAsync(d => d
                    .SetProperty(u => u.State, newState)) > 0;
            }
            catch (Exception) { return false; }
        }

        public async Task<IEnumerable<DamagedInfrastructure>> FindByStateAsync
            (EDamagedInfrastructureState damagedInfrastructureState)
        {
            string newState = damagedInfrastructureState.ToString() ==
                "ENPROCESO" ? "EN PROCESO" :
                damagedInfrastructureState
                .ToString();

            return await Context.Set<DamagedInfrastructure>()
                .Where(d => d.State == newState).ToListAsync();
        }

        public async Task<IEnumerable<DamagedInfrastructure>> FindByDepartmentIdAndDistrictIdAsync
            (int departmentId, int districtId)
        {
            Task<IEnumerable<DamagedInfrastructure>> queryAsync = new(() =>
            {
                return
                [.. (from di in Context.Set<DamagedInfrastructure>()
                join dt in Context.Set<District>()
                on di.DistrictsId equals dt.Id
                join de in Context.Set<Department>()
                on dt.DepartmentsId equals de.Id
                where de.Id == departmentId &&
                dt.Id == districtId
                select di)];
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}