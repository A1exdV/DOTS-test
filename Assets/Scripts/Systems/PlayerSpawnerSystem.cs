using Components;
using Unity.Entities;

namespace Systems
{
    public partial class PlayerSpawnerSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var playerEntryQuery = EntityManager.CreateEntityQuery(typeof(PlayerTagComponent));
            var playerSpawnerComponent = SystemAPI.GetSingleton<PlayerSpawnerComponent>();
            var randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

            var entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(World.Unmanaged);
            if (playerEntryQuery.CalculateEntityCount()< 20)
            {
                var spawnEntity = entityCommandBuffer.Instantiate(playerSpawnerComponent.PlayerPrefab);
                entityCommandBuffer.SetComponent(spawnEntity,new Speed
                {
                    Value = randomComponent.ValueRW.Random.NextFloat(1f,5f)
                });
            }
        }
    }
}



