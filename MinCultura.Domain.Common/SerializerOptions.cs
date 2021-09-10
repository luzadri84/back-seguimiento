using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinCultura.Domain.Common
{
    public class SerializerOptions
    {
        public static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve,
        };
    }
}
