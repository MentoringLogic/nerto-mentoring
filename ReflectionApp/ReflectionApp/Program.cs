//using Education_dotNet_Reflection_interface;
//using Education_dotNet_Reflection_classes;
using System.Reflection;
using System.Linq;

public class MyReflection
{
    public static void Main()
    {
        Assembly assembly1 = Assembly.LoadFrom("Education_dotNet_Reflection_classes.dll");
        Assembly assembly2 = Assembly.LoadFrom("Education_dotNet_Reflection_interface.dll");

        Type[] classTypes = assembly1.GetTypes();
        foreach (Type ti in assembly2.GetTypes().Where(x => x.IsInterface))
        {
            foreach (Type classType in classTypes)
            {
                Type[] interfaceTypes = classType.GetInterfaces();
                if (interfaceTypes.Contains(ti))
                {
                    var instance = Activator.CreateInstance(classType);

                    PropertyInfo prop = classType.GetProperty("CurrentIndex");
                    prop.SetValue(instance, 0, null);

                    MethodInfo mi = classType.GetMethod("GetNextIndex");
                    var result = mi.Invoke(instance, null);

                    Console.WriteLine($"{result} is a new index");
                }
            }
        }
    }
}