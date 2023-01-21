using Components;
using Unity.Entities;
using UnityEngine;

namespace Entities
{
   public class SpeedAuthoring : MonoBehaviour
   {
      public float value;
   
   }

   public class SpeedBacker : Baker<SpeedAuthoring>
   {
      public override void Bake(SpeedAuthoring authoring)
      {
         AddComponent(new Speed
         {
            Value = authoring.value
         });
      }
   }
}