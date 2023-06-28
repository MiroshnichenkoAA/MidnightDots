using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct SuspensionData : IComponentData
{
    public float restLength;
    public float currentLength;
    public float lastLength;
    public float suspensionStiffness;
    public float damperStiffness;
    public float springForce;
    public float damperForce;
}
