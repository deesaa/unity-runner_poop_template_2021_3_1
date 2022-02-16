using _Main.Scripts.Runtime.DataBase.DataStructs.Basic;
using DG.Tweening;
using ECS.Game.Components;
using ECS.Utils.Extensions;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using PdUtils;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : NewHumanoidView, IReinitializable, IMonoLinkCreator
{
    public Transform AimAtPoint;

    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        Entity.Get<TargetableComponent>().AimAtPoint = AimAtPoint;
        Entity.Get<EnemyComponent>();
    }

    public void Reinitialize()
    {
        GetComponent<Collider>().enabled = true;
        DOTween.Complete(gameObject);
        Entity.Del<DeathComponent>();

        SetIsDead(false);
        Restart();
    }

    public void OnDeath()
    {
        GetComponent<Collider>().enabled = false;
        SetIsDead(true);
    }
    

    public void CreateLinks(EcsWorld world)
    {

    }
}