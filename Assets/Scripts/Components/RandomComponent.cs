using Unity.Entities;

namespace Components
{
    public struct RandomComponent : IComponentData
    {
        public Unity.Mathematics.Random Random;
        
    }
}
