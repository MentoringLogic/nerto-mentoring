using System.Reflection;
using System.Linq;
using System.Security.Claims;
using Education_dotNet_Reflection_interface;
using Education_dotNet_Reflection_classes;

namespace ReflectionApp 
{ 
    public class myApp
    {    
        public static void Main()
        {
            var myFileData = new FileSystemData();
            var myClass = new ReflectionClass(myFileData);
            var index = myClass.GetNextIndexMethod(2);
            Console.WriteLine(index);
        }
       
    }
}