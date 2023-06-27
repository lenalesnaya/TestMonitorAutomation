using System.Reflection;

namespace Core.Utilites.Helpers;

public class TestDataHelper
{
    public static EntityType GetTestEntity<EntityType>(string fileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData" 
                                    + Path.DirectorySeparatorChar + fileName + ".json");
        return JsonHelper.FromJson(json).ToObject<EntityType>()!;
    }
}