using Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Entities
{
    public class TargetPositionAuthoring : MonoBehaviour
    {
        public float3 value;
    }
    
    public class TargetPosotionBaker : Baker<TargetPositionAuthoring>
    {
        public override void Bake(TargetPositionAuthoring authoring)
        {
            AddComponent(new TargetPosition
            {
                Value = authoring.value
            });
        }
    }
}
