using MangoDbCoreApi_5.Models.Abstract;
using System;

namespace MangoDbCoreApi_5.Models
{
    public class MangoDbSettings  
    { 
        public string BookCollectionName { get; set; }
        public string ConnectionString { get; set; }

        public string DataBaseName { get; set; }
    }
     
}