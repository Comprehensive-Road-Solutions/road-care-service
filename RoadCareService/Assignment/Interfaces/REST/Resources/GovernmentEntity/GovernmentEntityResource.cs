namespace RoadCareService.Assignment.Interfaces.REST.Resources.GovernmentEntity
{
    public record GovernmentEntityResource
        (int Id, int DistrictId, int Ruc, string Name,
        int Phone, string Email, string Address);
}