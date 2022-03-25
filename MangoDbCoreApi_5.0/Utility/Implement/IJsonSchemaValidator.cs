using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5._0.Utility.Implement
{
    public interface IJsonSchemaValidator
    {
          Task<string> GetJsonSchema(string filePath);
        Task<bool> ValidateJsonSchemaAsync(string text);
    }
}
