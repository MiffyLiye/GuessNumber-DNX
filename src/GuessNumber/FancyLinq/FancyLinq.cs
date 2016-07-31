using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessNumber.FancyLinq
{
    public static class FancyCount
    {
        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            return source.Where(predicate).Count();
        }
    }
}