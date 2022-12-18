using System.Reflection;
using System.Linq;
using Education_dotNet_Reflection_interface;

public class MyReflection
{
    public static void Main()
    {
        Assembly assembly1 = Assembly.LoadFrom("Education_dotNet_Reflection_classes.dll");
        Assembly assembly2 = Assembly.LoadFrom("Education_dotNet_Reflection_interface.dll");

        var classTypes = assembly1.GetTypes().ToList();
        var allInterfaces = assembly2.GetTypes().ToList();

        var result2 = from i in allInterfaces.Where(i => i.Name == "IInterface")
                      from c in classTypes.Where(c => c.GetInterfaces().Contains(i)).ToList()
                      select c;

        foreach (var classWithInterface in result2)
        {
            var instance = Activator.CreateInstance(classWithInterface);

            PropertyInfo prop = classWithInterface.GetProperty("CurrentIndex");
            prop.SetValue(instance, 3, null);

            MethodInfo mi = classWithInterface.GetMethod("GetNextIndex");
            var result = mi.Invoke(instance, null);

            Console.WriteLine($"{result} is a new index");
        }
    }
}