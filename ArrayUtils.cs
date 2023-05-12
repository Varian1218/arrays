using System;
using System.Linq;

namespace CSharpBoosts
{
    public static class ArrayUtils
    {
        public static Array Clone(Array array, int length)
        {
            var result = Activator.CreateInstance(array.GetType(), length) as Array ??
                         throw new NullReferenceException();
            Array.Copy(array, result, Math.Min(array.Length, length));
            return result;
        }
        
        public static T[] Clone<T>(T[] array, int length)
        {
            var result = new T[length];
            Array.Copy(array, result, Math.Min(array.Length, length));
            return result;
        }

        public static Array CloneIgnore(Array array, int index)
        {
            var newArray = Activator.CreateInstance(array.GetType(), array.Length - 1) as Array ??
                           throw new NullReferenceException();
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, array.Length - index - 1);
            return newArray;
        }

        public static T[] CloneIgnore<T>(T[] array, int index)
        {
            var newArray = new T[array.Length - 1];
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, array.Length - index - 1);
            return newArray;
        }

        public static void Copy<T>(ref T[] array, int length, Func<int, T> selector)
        {
            for (var i = 0; i < length; i++)
            {
                array[i] = selector(i);
            }
        }

        public static void Copy<T>(T[] array, int length, Func<int, T> selector)
        {
            for (var i = 0; i < length; i++)
            {
                array[i] = selector(i);
            }
        }

        public static void CopyIgnore<T>(T[] des, int index, T[] src)
        {
            Array.Copy(src, 0, des, 0, index);
            Array.Copy(src, index + 1, des, index, src.Length - index - 1);
        }

        public static bool SequenceEqual<T1, T2>(T1[] a, T2[] b)
        {
            if (a.Length != b.Length) return false;
            return !a.Where((t, i) => !Equals(t, b[i])).Any();
        }
    }
}