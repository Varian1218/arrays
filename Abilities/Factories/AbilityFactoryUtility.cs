using System;
using System.Collections.Generic;
using System.Linq;
using CSharpBoosts;
using Factories;

namespace Abilities.Factories
{
    public static class AbilityFactoryUtility
    {
        public static IEnumerable<string> Names => Types.Select(it => it.GetHash());

        public static IEnumerable<Type> Types => TypeUtils.All.Where(it => it.IsClass && !it.IsAbstract)
            .InterfaceTypeWhere(typeof(IFactory<,>), new[]
            {
                typeof(ObjectData),
                typeof(IAbilityExtension<>)
            });

        public static IFactory<ObjectData, IAbilityExtension<THandler>> Create<THandler>()
        {
            return Types.Select(it => (
                it.GetHash(),
                (IFactory<ObjectData, IAbilityExtension<THandler>>)Activator.CreateInstance(it)
            )).ToDictionaryFactory(it => it.Hash);
        }
    }
}