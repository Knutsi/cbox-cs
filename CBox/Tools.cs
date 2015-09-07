using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox
{
    public static class Tools
    {
        public static Random Random = new Random();

        /// <summary>
        /// Shamelessly ripped from http://rosettacode.org/wiki/Power_set#C.23
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                       from i in Enumerable.Range(0, list.Count)
                       where (m & (1 << i)) != 0
                       select list[i];
        }


        public static T PickRandom<T>(List<T> list)
        {
            return list[Tools.Random.Next(list.Count)];
        }

    }
}
