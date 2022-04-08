namespace MangoDbCoreApi_5.Models.Abstract
{
    public interface IDbConfiguration
    {
        public string BookCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
