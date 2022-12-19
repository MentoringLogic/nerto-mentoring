using FluentAssertions;
using System.Reflection;
using NSubstitute;
using Education_dotNet_Reflection_interface;
using Education_dotNet_Reflection_classes;
using System.Collections.Generic;

namespace ReflectionApp
{
    [TestClass]
    public class ReflectionTest
    {
        [TestMethod]
        public void LoadASM_stringNotDll_ThrowException()
        {
            //arrange and act
            Action Act = () => MyReflection.LoadASM("Gigachad");
            //assert
            Act.Should().Throw<Exception>("Its not dll");
        }
        //[TestMethod]
        //public void GetNextIndexMethod_2_returns3()
        //{
        //    //arrange
        //    var MockInterface = Substitute.For<IInterface>();
        //    var MockClass = Substitute.For<ClassB>();
            
        //    List<Type> interfaces = new List<Type>();
        //    List<Type> classes = new List<Type>();
            
        //    int CurrentIndex = 2;
        //    //act
        //    interfaces.Add((Type) MockInterface);
        //    //classes.Add((Type) MockClass);
        //    //Action Act = () => MyReflection.GetNextIndexMethod( interfaces, MockClass, CurrentIndex);
        //    //assert
        //    //Act.Should().;
        //}
    }
}