using System;
using System.Collections;
using System.Collections.Generic;
using Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerVisual : MonoBehaviour
{
    private Entity _targetEntitiy;


    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("in");
            _targetEntitiy = GetRandomEntity();
            print(_targetEntitiy);
        }
        if (_targetEntitiy != Entity.Null)
        {
            var followPosition = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(_targetEntitiy)
                ._Position;
            transform.position = followPosition;
        }
    }

    private Entity GetRandomEntity()
    {
        var playerTagEntityQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(PlayerTagComponent));
        var entityNativeArray = playerTagEntityQuery.ToEntityArray(Unity.Collections.Allocator.Temp);
        if (entityNativeArray.Length > 0)
        {
            return entityNativeArray[Random.Range(0, entityNativeArray.Length)];
        }
        else
        {
            return Entity.Null;
        }
    }
}
