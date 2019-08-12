using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingStuff;

namespace TestingStuffTests
{
    [TestClass]
    public class TestGenericRefPassing
    {
        [TestMethod]
        public void TestAClassWithAReponseRefToCallAMethod()
        {
            var refTesting = new GenericRefPassing();
            var result = refTesting.AClassWithAReponseRefToCallAMethod();
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void TestAClassWithBReponseRefToCallAMethod()
        {
            var refTesting = new GenericRefPassing();
            var result = refTesting.AClassWithBReponseRefToCallAMethod();
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void TestBClassWithBReponseRefToCallAMethod()
        {
            var refTesting = new GenericRefPassing();
            var result = refTesting.BClassWithBReponseRefToCallAMethod();
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void TestBClassWithAReponseRefToCallAMethod()
        {
            var refTesting = new GenericRefPassing();
            var result = refTesting.BClassWithAReponseRefToCallAMethod();
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void TestAnyClassReponseRefToCallAMethod()
        {
            var refTesting = new GenericRefPassing();
            var result = refTesting.AnyClassReponseRefToCallAMethod<AClass<GenericClassA>, GenericClassA>();
            Assert.IsTrue(result == 1);
        }

    }
}
