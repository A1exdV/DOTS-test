using Components;
using Unity.Entities;
using UnityEngine;

namespace Entities
{
    public class PlayerTagAutoring : MonoBehaviour
    {

    }

    public class PlayerTagBaker : Baker<PlayerTagAutoring>
    {
        public override void Bake(PlayerTagAutoring authoring)
        {
            AddComponent(new PlayerTagComponent());
        }
    }
}
