using MongoDB.Driver;

namespace AspNet.Identity3.MongoDB.MvcSample.Models
{
    public class ApplicationDbContext : MongoIdentityContext<ApplicationUser, IdentityRole>
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(ApplicationSettings settings)
        {
            var client = new MongoClient(settings.MongoConnectionString);

            _database = client.GetDatabase(settings.MongoDatabaseName);

            this.Users = _database.GetCollection<ApplicationUser>("users");
            this.Roles = _database.GetCollection<IdentityRole>("roles");
        }
    }
}
