using UnityEngine;

namespace ECS.Views.LevelObjects
{
    public struct LevelPathPointComponent
    {
        public Vector3 TargetPosition;
        public Vector3 TargetPlayerRotationOnPoint;
        public BoxCollider Collider;
    }
}