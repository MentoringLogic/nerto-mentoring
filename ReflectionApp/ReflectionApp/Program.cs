using System.Reflection;

public class MyReflection
{
    public static void Main()
    {
        var classesAsm = Assembly.LoadFrom("Education_dotNet_Reflection_classes.dll");
        var classesTypes = classesAsm.GetTypes();

        var interfaceAsm = Assembly.LoadFrom("Education_dotNet_Reflection_interface.dll");
        var interfaceType = interfaceAsm.GetTypes().First();

        var implemented = classesTypes.Where(t => t.GetInterfaces().Contains(interfaceType)).First();

        var instance = Activator.CreateInstance(implemented);

        var currentIndexProp = implemented.GetProperty("CurrentIndex");
        currentIndexProp?.SetValue(instance, 5);

        var getNextIndexMethod = implemented.GetMethod("GetNextIndex");
        var result = getNextIndexMethod?.Invoke(instance, null);

        Console.WriteLine(result);
    }
}