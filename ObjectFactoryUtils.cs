namespace CSharpBoosts
{
    public static class ObjectFactoryUtils
    {
        public static ObjectFactory CreateFactory()
        {
            return new ObjectFactory
            {
                Factories = TypeUtils.All.CreateAssignableWhere<IObjectFactory>()
            };
        }
    }
}