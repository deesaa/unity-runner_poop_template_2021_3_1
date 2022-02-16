using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class PlayerView : HumanoidView, IReinitializable, IMonoLinkCreator
{
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    public Animator BeamAnimator;

    public Transform DamageEffectPrefab;

    public float StartDistance;

    public Transform SideMoveRoot;


    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        Entity.Get<PlayerComponent>().MoveDistance = StartDistance;
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
    }


    public void DoBeam()
    {
        BeamAnimator.SetTrigger("Beam");
    }
    public void OnDeath()
    {
        
    }
    
    public void Reinitialize()
    {
        Entity.Del<DeathComponent>();
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
        Entity.Get<PlayerComponent>().MoveDistance = StartDistance;
    }


    public void CreateLinks(EcsWorld world)
    {
        
    }

    public void OnDamage()
    {
        var p = Instantiate(DamageEffectPrefab, SideMoveRoot, true);
        p.transform.position = SideMoveRoot.position;
        Observable.Timer(TimeSpan.FromSeconds(5)).Subscribe(x =>
        {
            Destroy(p.gameObject);
        }).AddTo(p.gameObject);
    }

    public void OnTake()
    {
        
    }
}