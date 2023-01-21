
using Unity.Entities;


namespace Systems
{
    public partial class MovingSystemBase : SystemBase // SystemBase выполняется ТОЛЬКО на главном потоке
    {
        protected override void OnUpdate()
        {
            // var randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
            // foreach (var moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>()) //Выполняется только в однопотоке на главном
            // {
            //     moveToPositionAspect.Move(SystemAPI.Time.DeltaTime);
            // }
        }
    }
}
