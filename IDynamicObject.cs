namespace CSharpBoosts
{
    public interface IDynamicObject
    {
        T GetValue<T>(string fieldName);
    }
}