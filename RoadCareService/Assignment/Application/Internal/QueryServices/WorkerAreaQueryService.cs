using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.Queries.WorkerArea;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.WorkerArea;

namespace RoadCareService.Assignment.Application.Internal.QueryServices
{
    public class WorkerAreaQueryService
        (IWorkerAreaRepository workerAreaRepository) :
        IWorkerAreaQueryService
    {
        public Task<IEnumerable<WorkerArea>?> Handle
            (GetAllWorkersAreasQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<WorkerArea?> Handle
            (GetWorkerAreaByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkerArea>?> Handle
            (GetWorkersAreasByGovernmentEntityIdAndStateQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkerArea>?> Handle
            (GetWorkersAreasByGovernmentEntityIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}