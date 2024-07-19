using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;

namespace RoadCareService.Assignment.Domain.Model.Queries.WorkerArea
{
    public record GetWorkersAreasByGovernmentsEntitiesIdAndStateQuery
        (int GovernmentsEntitiesId, EWorkerAreaState WorkerAreaState);
}