namespace MangoDbCoreApi_5._0.Models.Abstract
{
    public interface IBook
    {
        public string Id { get; set; }
        public string bookName { get; set; }
        public decimal BookPrice { get; set; }
        public string category { get; set; }
        public Author author { get; set; }
    }
}
