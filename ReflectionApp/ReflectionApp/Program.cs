using System.Reflection;
using System.Linq;
using System.Security.Claims;
using Education_dotNet_Reflection_interface;
using Education_dotNet_Reflection_classes;

namespace ReflectionApp 
{ 
    public class MyReflection
    {    
        public static void Main()
        {
            var classes = LoadASM("Education_dotNet_Reflection_classes.dll");
            var interfaces = LoadASM("Education_dotNet_Reflection_interface.dll");
            var allClasses = classes.GetTypes().ToList();
            var allInterfaces = interfaces.GetTypes().ToList();
            var index = GetNextIndexMethod(allInterfaces, allClasses, 2);
            Console.WriteLine(index);
        }
        public static Assembly LoadASM(string assemblyName)
        {
            try
            {
                Assembly result = Assembly.LoadFrom(assemblyName);
                return result;
            }
            catch
            {
                throw new Exception($"Assembly {assemblyName} could not be loaded");
            }
        }
        public static int GetNextIndexMethod(List<Type> myInterfaces, List<Type> myClasses, int FirstIndex)
        {

            var result2 = from i in myInterfaces.Where(i => i.Name == "IInterface")
                          from c in myClasses.Where(c => c.GetInterfaces().Contains(i)).ToList()
                          select c;
            foreach (var classWithInterface in result2)
            {            
                var instance = Activator.CreateInstance(classWithInterface);

                PropertyInfo prop = classWithInterface.GetProperty("CurrentIndex");
                prop.SetValue(instance, FirstIndex, null);

                MethodInfo mi = classWithInterface.GetMethod("GetNextIndex");
                var result = mi.Invoke(instance, null);
                return (int)result;
            }
            return 0;
        }
    }
}