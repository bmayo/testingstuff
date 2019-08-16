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
    public class TestBoxPractice
    {
        [TestMethod]
        public void BoxIt()
        {
            var boxing = new BoxPractice();
            var result = boxing.BoxIt(1);

            Assert.IsTrue(result.GetType() == typeof(int));

        }

        [TestMethod]
        public void UnBoxIt()
        {
            var boxing = new BoxPractice();
            var result = boxing.UnBoxIt((object)1);

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void BoxItList()
        {
            var boxing = new BoxPractice();
            var result = boxing.BoxItList(new List<int> { 1,2,3,4,5 });

            Assert.IsTrue(result.Count() == 5);

        }

        [TestMethod]
        public void UnBoxItList()
        {
            var boxing = new BoxPractice();
            var result = boxing.UnBoxItList(new List<object> { 1, 2, 3, 4, 5 });

            Assert.IsTrue(result.Count() == 5 && result.Last() == 5);

        }

        [TestMethod]
        public void RandomBoxItList()
        {
            var boxing = new BoxPractice();
            var result = boxing.RandomBoxItList(new List<int> { 1, 2, 3, 4, 5 }, new List<string> { "aa", "bb", "cc" });

            Assert.IsTrue(result.Count() == 8);

        }

        [TestMethod]
        public void RandomUnBoxItList()
        {
            var boxing = new BoxPractice();
            var result = boxing.RandomUnBoxItList(new List<object> { 1, 2, 3, 4, 5, "aa", "bb", "cc" });

            Assert.IsTrue(result.Count() == 3 && result.Last() == "cc");

        }
    }
}
