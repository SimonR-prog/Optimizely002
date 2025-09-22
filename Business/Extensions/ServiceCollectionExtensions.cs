﻿using Microsoft.AspNetCore.Mvc;

namespace Optimizely002.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNackademin(this IServiceCollection services)
    {
        services.Configure<MvcOptions>(options => options.Filters.Add<PageContextActionFilter>());

        return services;
    }
}
