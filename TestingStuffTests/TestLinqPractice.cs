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
    public class TestLinqPractice
    {
        LinqPractice Practice;

        [TestInitialize]
        public void Setup()
        {
           Practice = new LinqPractice();
           Practice.PopulateData();
        }

        [TestMethod]
        public void SkipHalf()
        {
           
            var result = Practice.SkipHalf();

            Assert.IsTrue(result.Count() == 4);
        }

        [TestMethod]
        public void Union()
        {
            var result = Practice.UnionLists();

            Assert.IsTrue(result.Count() == 6);
        }

        [TestMethod]
        public void Intersect()
        {
            var result = Practice.IntersectLists();

            Assert.IsTrue(result.Count() == 1);
        }

        [TestMethod]
        public void FindInList()
        {
            var result = Practice.FindInList(3);

            Assert.IsTrue(result.id == 3);
        }


    }
}
