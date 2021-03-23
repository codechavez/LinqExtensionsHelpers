using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChavez.LinqExtensions
{
    public static class Helpers
    {
        public static IEnumerable<TSource> Except<TSource, TKey>(this IEnumerable<TSource> incoming, IEnumerable<TSource> original, Func<TSource, TKey> comparingKeys)
        {
            if (incoming == null) throw new ArgumentNullException($"incoming list cannot be null - {nameof(incoming)}");
            if (original == null) throw new ArgumentNullException($"original list cannot be null - {nameof(original)}");
            if (comparingKeys == null) throw new ArgumentNullException($"Lambda cannot be null = {nameof(comparingKeys)}");

            var keys = new HashSet<TKey>(original.Select(comparingKeys), null);

            foreach (var item in incoming)
                if (keys.Add(comparingKeys(item)))
                    yield return item;
        }
    }
}
