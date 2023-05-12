using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpBoosts;
using Factories;

namespace Abilities.Factories
{
    public static class AbilityFactoryUtility
    {
        public static IEnumerable<string> All => TypeUtils.All
            .SelectNotNull(it => it.GetCustomAttribute<AbilityFactoryAttribute>()).Select(it => it.Hash);

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