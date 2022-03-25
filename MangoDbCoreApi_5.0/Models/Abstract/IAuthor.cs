namespace MangoDbCoreApi_5._0.Models.Abstract
{
    public interface IAuthor
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        int Age { get; set; }

        string Location { get; set; }
    }
}
