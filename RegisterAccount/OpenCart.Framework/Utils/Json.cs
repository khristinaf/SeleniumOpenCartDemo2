using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace OpenCart.Framework.Utils
{
    public static class Json
    {
        public static T DeserializeFromFile<T>(string filePath)
        {
            filePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, filePath);
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}