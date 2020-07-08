using BasketApp.Data.Documents;
using System.Collections.Generic;

namespace BasketApp.Data.Configs
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
