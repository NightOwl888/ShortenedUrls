﻿using Microsoft.Extensions.DependencyInjection;
using ShortenedUrls.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortenedUrls.Routing
{
    public class LinkCachedRouteDataProvider : ICachedRouteDataProvider<int>
    {
        private readonly IServiceProvider serviceProvider;

        public LinkCachedRouteDataProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider
                ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IDictionary<string, int> GetPageToIdMap()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

                return (from link in dbContext.Links
                        select new KeyValuePair<string, int>(
                            link.ShortenedLink.Trim('/'),
                            link.Id)
                        ).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
    }
}
