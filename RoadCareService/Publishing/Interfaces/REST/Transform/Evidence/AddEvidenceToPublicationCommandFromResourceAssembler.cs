﻿using RoadCareService.Publishing.Domain.Model.Commands.Evidence;
using RoadCareService.Publishing.Interfaces.REST.Resources.Evidence;

namespace RoadCareService.Publishing.Interfaces.REST.Transform.Evidence
{
    public class AddEvidenceToPublicationCommandFromResourceAssembler
    {
        public static AddEvidenceToPublicationCommand ToCommandFromResource
            (AddEvidenceToPublicationResource resource) =>
            new(resource.PublicationId, resource.FileUrl);
    }
}