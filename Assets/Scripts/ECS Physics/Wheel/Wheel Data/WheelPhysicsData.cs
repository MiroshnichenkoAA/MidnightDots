using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct WheelPhysicsData : IComponentData
{
    public float3 linearVelocity;
    public float wheelRadius;
    public float angularVelocity;
    public float driveTorque;
    public float brakeTorque;
    public float angularAcceleration;
  
}
