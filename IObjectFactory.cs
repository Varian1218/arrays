namespace CSharpBoosts
{
    public interface IObjectFactory
    {
        string ObjectHash { get; }
        IObject Create(HashValues hashValues);
    }
}