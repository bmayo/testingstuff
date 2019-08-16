using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingStuff
{
    public class LinqPractice
    {

        public List<LinkTypeNames> TestingListNames;

        public List<LinkTypeNames> TestingListNames2;
        
        public List<LinkTypeValues> TestingListValues;

        public void PopulateData()
        {
            TestingListNames = new List<LinkTypeNames>
            {
                new LinkTypeNames
                {
                    id = 1,
                    name = "bob"
                },
                new LinkTypeNames
                {
                    id = 2,
                    name = "larry"
                },
                  new LinkTypeNames
                {
                    id = 3,
                    name = "steve"
                },
            };

            TestingListNames2 = new List<LinkTypeNames>
            {
                new LinkTypeNames // shouldn't be in list
                {
                    id = 1,
                    name = "bob"
                },
                new LinkTypeNames
                {
                    id = 4,
                    name = "sally"
                },
                new LinkTypeNames
                {
                    id = 5,
                    name = "amanda"
                },
                  new LinkTypeNames
                {
                    id = 6,
                    name = "lauren"
                },
            };

            TestingListValues = new List<LinkTypeValues>
            {
                new LinkTypeValues
                {
                    id = 1,
                    linkAId = 1, //bob
                    value = 10
                },
                 new LinkTypeValues
                {
                     id = 2,
                    linkAId = 1, //bob
                    value = 10
                },
                new LinkTypeValues
                {
                    id = 3,
                    linkAId = 2, //larry
                    value = 20
                },
                 new LinkTypeValues
                {
                    id = 4,
                    linkAId = 2, //larry
                    value = 20
                },
                 new LinkTypeValues
                {
                     id =5,
                    linkAId = 2, //larry
                    value = 20
                },
                new LinkTypeValues
                {
                    id = 6,
                    linkAId = 2, //larry
                    value = 10
                },
                  new LinkTypeValues
                {
                    id = 7,
                    linkAId = 3, //steve
                    value = 30
                },
                 new LinkTypeValues
                {
                     id = 8,
                    linkAId = 3, //steve
                    value = 30
                },
                new LinkTypeValues
                {
                    id = 9,
                    linkAId = 3, //steve
                    value = 30
                }
            };
        }

        public IEnumerable<LinkTypeValues> SkipHalf()
        {
            int half = TestingListValues.Count() / 2;
            var result = TestingListValues.Skip(half).Take(half);

            return result.ToList();
        }


        public IEnumerable<int> JoinLists()
        {
            var join = TestingListNames.Join(TestingListValues, c => c.id, d => d.linkAId, (c, d) => c.id).ToList();

            return join;
        }

        public IEnumerable<LinkTypeNames> UnionLists()
        {
            var union = TestingListNames.Union(TestingListNames2, new LinkComparer());

            return union;

        }

        public IEnumerable<LinkTypeNames> IntersectLists()
        {
            var intersect = TestingListNames.Intersect(TestingListNames2, new LinkComparer());

            return intersect;

        }

        public LinkTypeNames FindInList(int id)
        {
            var find = TestingListNames.Find(c => c.id == id);

            return find;

        }

        public class LinkComparer : IEqualityComparer<LinkTypeNames>
        {
            public bool Equals(LinkTypeNames x, LinkTypeNames y)
            {
                return x.id == y.id;
            }

    
            public int GetHashCode(LinkTypeNames obj)
            {
                return obj.id.GetHashCode();
            }
        }


        public class LinkTypeNames
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class LinkTypeValues
        {
            public int id { get; set; }
            public int linkAId { get; set; }
            public float value { get; set; }
        }
    }


}
