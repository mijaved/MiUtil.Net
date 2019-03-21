using Microsoft.VisualStudio.TestTools.UnitTesting;
//Add package For DescriptionAttribute you need to use the System.ComponentModel.Primitives package
namespace MiUtil.Net.MSTest
{
    [TestClass]
    public class EnumUtilUnitTest
    {
        private const string desc1 = "This is One";
        private const string desc2 = "This is Two";
        private const string desc3 = "This is Three";

        enum MyEnum
        {
            [System.ComponentModel.Description(desc1)]
            One = 1,
            [System.ComponentModel.Description(desc2)]
            Two = 2,
            [System.ComponentModel.Description(desc3)]
            Three  =3
        }

        [TestMethod]
        public void TestEnumUtilKey()
        {
            Assert.AreEqual(1, MiUtil.Net.EnumUtil.GetKey(MyEnum.One));
            Assert.AreEqual(2, MiUtil.Net.EnumUtil.GetKey(MyEnum.Two));
            Assert.AreEqual(3, MiUtil.Net.EnumUtil.GetKey(MyEnum.Three));
        }

        [TestMethod]
        public void TestEnumUtilValue()
        {
            Assert.AreEqual("One", MiUtil.Net.EnumUtil.GetValue(MyEnum.One));
            Assert.AreEqual("Two", MiUtil.Net.EnumUtil.GetValue(MyEnum.Two));
            Assert.AreEqual("Three", MiUtil.Net.EnumUtil.GetValue(MyEnum.Three));
        }

        [TestMethod]
        public void TestEnumUtilDescription()
        {
            Assert.AreEqual(desc1, MiUtil.Net.EnumUtil.GetDescription(MyEnum.One));
            Assert.AreEqual(desc2, MiUtil.Net.EnumUtil.GetDescription(MyEnum.Two));
            Assert.AreEqual(desc3, MiUtil.Net.EnumUtil.GetDescription(MyEnum.Three));
        }
    }
}
