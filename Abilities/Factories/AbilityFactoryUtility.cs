using System;
using System.Linq;
using CSharpBoosts;
using Factories;

namespace Abilities.Factories
{
    public static class AbilityFactoryUtility
    {
        public static IFactory<AbilityMaterial<THandler>, IAbilityExtension<THandler>> Create<THandler>()
        {
            return TypeUtils.All.GetHashTypes<AbilityFactoryAttribute>()
                .Select(it => (it.Hash,
                    (IFactory<AbilityMaterial<THandler>, IAbilityExtension<THandler>>)Activator
                        .CreateInstance(it.Type)))
                .SelectDictionaryFactory(it => it.Values.Hash);
        }
    }
}