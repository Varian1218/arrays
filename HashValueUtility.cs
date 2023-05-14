using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpBoosts
{
    public static class HashValueUtility
    {
        public static IEnumerable<HashValue<T>> Sum<T>(
            this IEnumerable<IEnumerable<HashValue<T>>> source,
            Func<IEnumerable<T>, T> sum
        )
        {
            return source.SelectMany(it => it).GroupBy(
                it => it.Hash,
                (hash, values) => new HashValue<T>
                {
                    Hash = hash,
                    Value = sum(values.Select(it => it.Value))
                });
        }

        public static IEnumerable<HashValue<int>> HashSelect(
            this IEnumerable<string> source,
            string hash,
            int max,
            int point
        )
        {
            var values = source.HashSelect(new Random(hash.ToHashCode()), max).ToArray();
            float sum = values.Sum(it => it.Value);
            return values.Select(it => new HashValue<int>
            {
                Hash = it.Hash,
                Value = (int)(it.Value / sum * point)
            });
        }

        public static IEnumerable<HashValue<int>> HashSelect(
            this IEnumerable<string> source,
            Random random,
            int max
        )
        {
            return source.Select(it => new HashValue<int>
            {
                Hash = it,
                Value = random.Next(max) + 1
            });
        }

        public static IEnumerable<(string Hash, double Value)> DoubleWeightSelect(
            this IEnumerable<string> source,
            string hash
        )
        {
            return source.DoubleWeightSelect(new Random(hash.ToHashCode()));
        }

        public static IEnumerable<(string Hash, double Value)> DoubleWeightSelect(
            this IEnumerable<string> source,
            Random random
        )
        {
            return source.Select(it => (it, random.NextDouble()));
        }

        public static IEnumerable<HashValue<int>> Next(this IEnumerable<string> source, string hash, int point)
        {
            var random = new Random(hash.ToHashCode());
            var weights = source.Select(it => (Hash: it, Weight: random.NextDouble())).ToArray();
            return weights.Select(it => new HashValue<int>
            {
                Hash = it.Hash,
                Value = (int)(it.Weight * point)
            });
        }

        public static T To<T>(this HashValues values) where T : new()
        {
            return values.To<T>(key => key);
        }

        public static T To<T>(this HashValues values, Func<string, string> keySelector) where T : new()
        {
            var obj = new T();
            var type = typeof(T);
            foreach (var value in values.Ints)
            {
                type.GetField(keySelector(value.Hash)).SetValue(obj, value.Value);
            }

            foreach (var value in values.Strings)
            {
                type.GetField(keySelector(value.Hash)).SetValue(obj, value.Value);
            }

            return obj;
        }
    }
}