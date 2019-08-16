using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingStuff
{
    public class BoxPractice
    {
        public object BoxIt(int num)
        {
            return num as object;
        }

        public int UnBoxIt(object num)
        {
            return (int)num;
        }

        public List<object> BoxItList(List<int> nums)
        {
            var boxes = new List<object>();
            nums.ForEach(c => { boxes.Add(c); });

            return boxes;
        }

        public List<int> UnBoxItList(List<object> obs)
        {
            var unboxes = new List<int>();
            obs.ForEach(c => { unboxes.Add((int)c); });

            return unboxes;
        }

        public List<object> RandomBoxItList(List<int> ints, List<string> strings)
        {
            var obs = new List<object>();
            ints.ForEach(c => { obs.Add((object)c); });
            strings.ForEach(c => { obs.Add((object)c); });
            return obs;
        }

        public List<string> RandomUnBoxItList(List<object> obs)
        {
            var ints = new List<int>();
            var strings = new List<string>();

            foreach(var o in obs)
            {
                if (o.GetType() == typeof(int))
                {
                    ints.Add((int)o);
                }
                if (o.GetType() == typeof(string))
                {
                    strings.Add((string)o);
                }
            }

            return strings;
        }



    }
}
