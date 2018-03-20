using System.Linq;

namespace ShortenedUrls.Data
{
    public static class DbInitializer 
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Links.Any())
                return; // DB has been seeded

            var links = new Link[]
            {
                new Link { ShortenedLink = "M81J1w0A", FullLink = "https://maps.google.com/" },
                new Link { ShortenedLink = "r33NW8K", FullLink = "https://stackoverflow.com/" },
            };
            foreach (var l in links)
            {
                context.Links.Add(l);
            }
            context.SaveChanges();
        }
    }
}
