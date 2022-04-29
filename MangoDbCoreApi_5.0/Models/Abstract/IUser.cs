namespace MangoDbCoreApi_5.Models.Abstract
{
    public interface IUser
    {
         public string Id { get; set; }
        public string Name { get; set; }    
        public  string Email { get; set; }  
        public  string Password { get; set; }    
    }
}
