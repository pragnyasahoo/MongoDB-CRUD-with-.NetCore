using MangoDbCoreApi_5._0.Models.Abstract;

namespace MangoDbCoreApi_5._0.Models
{
    public class DbConfiguration: IDbConfiguration
    {
        public string BookCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }

    }
}