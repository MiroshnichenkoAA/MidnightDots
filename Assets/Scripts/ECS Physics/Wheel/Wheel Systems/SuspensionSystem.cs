using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public class SuspensionSystem : SystemBase
{
   
    protected override void OnUpdate()
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
    
        Entities.ForEach((ref WheelPhysicsData wheelData, ref SuspensionData suspensionData, ref PhysicsVelocity physicsVelocity, ref TransformAuthoring transformAuthoring) =>
        {
           
            // ����� Raycast()
            RaycastInput raycastInput = new RaycastInput
            {
                Start = transformAuthoring.LocalPosition,
                End = transformAuthoring.LocalPosition - new float3(0, suspensionData.restLength + wheelData.wheelRadius, 0),
                Filter = new CollisionFilter
                {
                    // ������� ���� ��������� ���������� �����
                }
            };
            //PhysicsWorld.CollisionWorld.CastRay(raycastInput, out hit);
            RaycastHit hit = new RaycastHit();
            bool wheelHit = World.DefaultGameObjectInjectionWorld.GetExistingSystem<BuildPhysicsWorld>().

            if (wheelHit)
            {
                suspensionData.currentLength = math.distance(transformAuthoring.LocalPosition, hit.Position);

                // ����� GetSuspensionForce()
                suspensionData.springForce = (suspensionData.restLength - suspensionData.currentLength) * suspensionData.suspensionStiffness;
                suspensionData.damperForce = ((suspensionData.lastLength - suspensionData.currentLength) / deltaTime) * suspensionData.damperStiffness;
                float fZ = math.max(0, suspensionData.springForce + suspensionData.damperForce);
                suspensionData.lastLength = suspensionData.currentLength;

                // ����� ApplySuspensionForce()
                float3 forceDirection = math.normalize(new float3 (transformAuthoring.LocalRotation.value.x, transformAuthoring.LocalRotation.value.y, transformAuthoring.LocalRotation.value.z)) * fZ;
                physicsVelocity.Linear += forceDirection / physicsVelocity.Mass;
            }
        }).ScheduleParallel();
    }
}

