using System;

namespace CSharpBoosts
{
    public static class FuncParam<T>
    {
        public static Func<T, TResult> Result<TResult>(Func<T, TResult> func)
        {
            return func;
        }
    }
}

namespace CSharpBoosts
{
    public static class FuncParam<T1, T2>
    {
        public static Func<T1, T2, TResult> Result<TResult>(Func<T1, T2, TResult> func)
        {
            return func;
        }
    }
}