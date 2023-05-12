namespace Abilities.Extensions
{
    // public struct DensitySummonAbilityExtensionData
    // {
    //     public struct AnimationData
    //     {
    //         public string Hash;
    //         public string Message;
    //     }
    //     
    //     public struct SpawnData
    //     {
    //         public float Density;
    //         public string Hash;
    //     }
    //
    //     public AnimationData Animation;
    //     public SpawnData Spawn;
    // }
    public class DensitySummonAbilityExtensionProperties
    {
        public string AnimationHash;
        public string AnimationMessage;
        public int SpawnDensity;
        public string SpawnHash;
    }
}