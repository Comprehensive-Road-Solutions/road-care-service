﻿namespace RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute { }
}