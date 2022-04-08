using MangoDbCoreApi_5.Utility.Implement;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks; 

namespace MangoDbCoreApi_5.Utility
{
    public class JsonSchemaValidator : IJsonSchemaValidator
    {
        public async Task<string> GetJsonSchema(string filePath)
        {
            //await JSchema.FromFileAsync(content);
            return "";

        }

        Task<bool> IJsonSchemaValidator.ValidateJsonSchemaAsync(string text)
        {
            throw new NotImplementedException();
        }
    }
}
