namespace CSharpExtensions
{
    public class ValueHolder<TValue>
    {
        public TValue Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}