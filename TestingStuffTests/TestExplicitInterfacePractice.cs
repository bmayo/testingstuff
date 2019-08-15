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
    public class TestExplicitInterfacePractice
    {
        [TestMethod]
        public void GetReponse(){
            var explicitInterface = new ExplicitInterfacePractice();

            var result = explicitInterface.GetReponse();

            Assert.IsTrue(result == "omega");
        }

        [TestMethod]
        public void GetAlphaReponse()
        {
            var explicitInterface = new ExplicitInterfacePractice();

            var result = explicitInterface.GetAlphaReponse();

            Assert.IsTrue(result == "alpha");
        }

        [TestMethod]
        public void GetBravoReponse()
        {
            var explicitInterface = new ExplicitInterfacePractice();

            var result = explicitInterface.GetBetaReponse();

            Assert.IsTrue(result == "beta");
        }

        [TestMethod]
        public void GetGenericReponse()
        {
            var explicitInterface = new ExplicitInterfacePractice();

            var result = explicitInterface.GetReponse<IAlphaReponse>();

            Assert.IsTrue(result == "alpha");
        }


        [TestMethod]
        public void GetUnknownGenericReponse()
        {
            var explicitInterface = new ExplicitInterfacePractice();

            var result = explicitInterface.GetReponse<IDunnoResponse>();

            Assert.IsTrue(result == "omega");
        }

        public interface IDunnoResponse: IBaseReponse
        {

        }


    }
}
