using Newtonsoft.Json;

namespace Sorschia.Utilities
{
    public static class ObjectCopy
    {
        public static T Copy<T>(T copyFrom) => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(copyFrom));
    }
}
