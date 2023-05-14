namespace CSharpBoosts
{
    public static class ObjectUtils
    {
        public static string GetHash(ObjectData data)
        {
            return data.Hash;
        }

        public static (string, ObjectData) ResultSelect(ObjectData data)
        {
            return (data.Hash, data);
        }
    }
}