using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CommonUtility
{
    public static class EntityFrameworkUtil
    {
        public static IEnumerable<T> EnumerateInChunksOf<T>(this IEnumerable<T> enumerable, int chunkSize)
        {
            foreach (var chunk in enumerable.GetChunksOfSize(chunkSize))
            {
                foreach (T item in chunk)
                    yield return item;
            }
        }
        public static IEnumerable<T[]> GetChunksOfSize<T>(this IEnumerable<T> enumerable, int chunkSize)
        {
            int count = enumerable.Count();
            for (int chunkIndex = 0; chunkIndex * chunkSize < count; chunkIndex++)
                yield return enumerable.Skip(chunkIndex * chunkSize).Take(chunkSize).ToArray();
        }


        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }  

        }

    }
}
