namespace CSharpBoosts
{
    public class Id : IId
    {
        private int _value;

        public int Value
        {
            get => _value++;
            set => _value = value;
        }
    }
}