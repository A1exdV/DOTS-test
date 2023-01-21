
using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity _entity;
    
    private readonly TransformAspect _transformAspect;
    private readonly RefRO<Speed> _speed;
    private readonly RefRW<TargetPosition> _targetPosition;

    public void Move(float deltaTime)
    {
        float3 direction = math.normalize(_targetPosition.ValueRW.Value - _transformAspect.LocalPosition);
                
        _transformAspect.LocalPosition += direction * deltaTime * _speed.ValueRO.Value;
    }

    public void IsTargetPositionReached(RefRW<RandomComponent> randomComponent)
    {
        if (math.distance(_transformAspect.LocalPosition, _targetPosition.ValueRW.Value) < .5f)
        {
            _targetPosition.ValueRW.Value = GetRandomPosition(randomComponent);
        }
    }

    private float3 GetRandomPosition(RefRW<RandomComponent> randomComponent)
    {
        return new float3(randomComponent.ValueRW.Random.NextFloat(-10f,10f),0,randomComponent.ValueRW.Random.NextFloat(-10f,10f));
    }
}
