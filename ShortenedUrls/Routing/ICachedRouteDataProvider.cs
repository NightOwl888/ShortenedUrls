using System.Collections.Generic;

namespace ShortenedUrls.Routing
{
    public interface ICachedRouteDataProvider<TPrimaryKey>
    {
        IDictionary<string, TPrimaryKey> GetPageToIdMap();
    }
}
