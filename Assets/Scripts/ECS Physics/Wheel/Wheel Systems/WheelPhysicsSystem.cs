using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class WheelPhysicsSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        Entities.ForEach((ref WheelPhysicsData wheel) =>
        {
            // Здесь вы можете добавить логику для обновления физики колеса

        }).ScheduleParallel();
    }


}
