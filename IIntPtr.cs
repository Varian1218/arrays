namespace CSharpBoosts
{
    public interface IIntPtr
    {
        int Value { get; set; }

        public static IIntPtr operator ++(IIntPtr intPtr)
        {
            intPtr.Value++;
            return intPtr;
        }
    }
}