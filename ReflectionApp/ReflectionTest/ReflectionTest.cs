using FluentAssertions;
using System.Reflection;
using NSubstitute;
using Education_dotNet_Reflection_interface;
using Education_dotNet_Reflection_classes;
using System.Collections.Generic;
using ReflectionApp;
namespace ReflectionApp
{
    [TestClass]
    public class ReflectionTest
    {
        [TestMethod]
        public void LoadASM_stringNotDll_ThrowException()
        {
            //arrange
            var newFileData = new FileSystemData();
            //act
            Action Act = () => newFileData.LoadASM("Gigachad");
            //assert
            Act.Should().Throw<Exception>("Its not dll");
        }

        [TestMethod]
        public void GetNextIndexMethod_2_returns3()
        {
            //arrange
            var myFileData = Substitute.For<IFileSystemData>();

            myFileData.LoadASM("Education_dotNet_Reflection_interface.dll").Returns(new System.Type[] { typeof(IInterface) });
            myFileData.LoadASM("Education_dotNet_Reflection_classes.dll").Returns(new System.Type[] { typeof(ClassB) });

            var classInstance = new ReflectionClass(myFileData);

            //act
            var result = (int) classInstance.GetNextIndexMethod(4);

            //assert
            result.Should().Be(5);
        }
    }
}