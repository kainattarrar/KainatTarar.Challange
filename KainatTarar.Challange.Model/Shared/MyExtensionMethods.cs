using KainatTarar.Challange.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KainatTarar.Challange.Model.Shared
{
    public static class MyExtensionMethods
    {
        public static IQueryable<TSource> OrderByDirection<TSource, TKey>(
            this IQueryable<TSource> source,
            Func<TSource, TKey> selector,
            SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Ascending)
                return source.OrderBy(selector).AsQueryable();
            else
                return source.OrderByDescending(selector).AsQueryable();
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem,
            Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

       
    }
}
