// using System.Collections.Generic;
// using Factories;
//
// namespace Abilities.Factories
// {
//     public class AbilityFactory<TObject>
//     {
//         public IDictionary<string, IFactory<AbilityMaterial<TObject>, IAbilityExtension<TObject>>> Factories
//         {
//             private get;
//             set;
//         }
//
//         public IAbilityExtension<TObject> Create(AbilityMaterial<TObject> material)
//         {
//             return Factories[material.Values.Hash].Create(material);
//         }
//     }
// }