﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpGif
{
    internal static class IEnumerableExtension
    {
        public static IEnumerable<TSource> PadEnd<TSource>(this IEnumerable<TSource> source, ulong length, Func<TSource> generator)
        {
            var i = 0u;
            foreach (var item in source)
            {
                ++i;
                yield return item;
            }

            if (i >= length)
                yield break;

            for (; i < length; ++i)
                yield return generator();
        }

        public static IEnumerable<TSource> PadEnd<TSource>(this IEnumerable<TSource> source, ulong length)
        {
            return source.PadEnd(length, () => default(TSource));
        }

        public static IEnumerable<TSource> PadEnd<TSource>(this IEnumerable<TSource> source, ulong length, Func<ulong, TSource> generator)
        {
            var i = 0u;
            foreach (var item in source)
            {
                ++i;
                yield return item;
            }

            if (i >= length)
                yield break;

            for (; i < length; ++i)
                yield return generator(i);
        }
    }
}