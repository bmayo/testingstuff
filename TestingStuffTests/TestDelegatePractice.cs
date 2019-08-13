using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingStuff;

namespace TestingStuffTests
{
    [TestClass]
    public class TestDelegatePractice
    {
        [TestMethod]
        public void TestMessagePayloadString()
        {
            var delegatePractice = new DelegatePractice();
            delegatePractice.SetPolicy(MessagePayloadReponsePolicies.StringMessageResponsePayloadPolicy);

            var result = delegatePractice.ReponsePayload(new int[] { 1, 2, 3, 4 });

            Assert.IsTrue(result.Payload == "{1:2:3:4}");
        }

        [TestMethod]
        public void TestMessagePayloadJson()
        {
            var delegatePractice = new DelegatePractice();
            delegatePractice.SetPolicy(MessagePayloadReponsePolicies.JsonMessageResponsePayloadPolicy);

            var result = delegatePractice.ReponsePayload(new int[] { 1, 2, 3, 4 });

            Assert.IsTrue(result.Payload == "[1,2,3,4]");

        }
    }
}
