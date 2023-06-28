using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct SteeringData : IComponentData
{
    public float steerTime;
    public float steerAngle;
}