namespace CSharpBoosts
{
    [KeySelector]
    public static class KeySelectorUtility
    {
        public static string Object(ObjectData data)
        {
            return data.Hash;
        }
    }
}