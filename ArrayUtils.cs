using System;

namespace CSharpExtensions
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

        public static Array CloneIgnore(Array array, int index)
        {
            var newArray = Activator.CreateInstance(array.GetType(), array.Length - 1) as Array ??
                           throw new NullReferenceException();
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
    }
}