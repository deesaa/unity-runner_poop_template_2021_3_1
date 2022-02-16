using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using UnityEngine;

public class BulletView : LinkableView
{
    public GameObject ImpactPrefab;
    public GameObject ExplosionPrefab;
    
    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        Entity.Get<DelayedDestroyComponent>().Delay = 8f;
        Entity.Get<DelayedDestroyComponent>().IsUnscaledTime = true;
    }

    public void OnHit(ContactPoint contactPoint)
    {
        //transform.position = hitPosition;
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, contactPoint.normal);
        Vector3 pos = contactPoint.point;
        Instantiate(ImpactPrefab, pos, rot);
        Entity.Get<DelayedDestroyComponent>().Delay = 0f;
    }
}