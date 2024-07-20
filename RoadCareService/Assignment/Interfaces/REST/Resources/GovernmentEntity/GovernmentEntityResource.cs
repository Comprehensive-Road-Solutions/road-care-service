namespace RoadCareService.Assignment.Interfaces.REST.Resources.GovernmentEntity
{
    public record GovernmentEntityResource
        (int Id, int DistrictId, string Ruc, string Name,
        int Phone, string Email, string Address);
}