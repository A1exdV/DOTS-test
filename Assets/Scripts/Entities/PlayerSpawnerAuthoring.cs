using Components;
using Unity.Entities;
using UnityEngine;

namespace Entities
{
    public class PlayerSpawnerAuthoring : MonoBehaviour
    {
        public GameObject playerPrefab;
    }

    public class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
    {
        public override void Bake(PlayerSpawnerAuthoring authoring)
        {
            AddComponent(new PlayerSpawnerComponent
            {
                PlayerPrefab = GetEntity(authoring.playerPrefab)
            });

        }
    }
}