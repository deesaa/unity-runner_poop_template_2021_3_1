using DG.Tweening;
using ECS.Game.Systems.Initialize;
using ECS.Utils.Extensions;
using Ecs.Views.Linkable.Impl;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class CoinView : LinkableView, IReinitializable
{
    [SerializeField] public Transform View;
    [SerializeField] public Transform ViewContainer;
    [SerializeField] private int amount = 1;
    [SerializeField] private ParticleSystem claimParticle;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Collider TriggerCollider;

    private Vector3 initialPosition;
    private Vector3 initialScale;
    
    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        entity.Get<CoinComponent>().Value = amount;
        initialPosition = View.position;
        initialScale = View.localScale;
        View.DORotate(new Vector3(0f, 360f, 0f), rotationSpeed, RotateMode.WorldAxisAdd)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart)
            .SetTarget(View);
    }
    
    public void OnTake(SignalBus _signalBus, int globalCoinsCount, Transform coinCollectPosition)
    {
        TriggerCollider.enabled = false;
        claimParticle.Play(true);
    }

    public void OnTaken()
    {
        gameObject.SetActive(false);
    }

    public void Reinitialize()
    {
        View.position = initialPosition;
        gameObject.SetActive(true);
        TriggerCollider.enabled = true;
        View.SetParent(ViewContainer);
        View.localScale = initialScale;
        
        View.DORotate(new Vector3(0f, 360f, 0f), rotationSpeed, RotateMode.WorldAxisAdd)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart)
            .SetTarget(View);
    }
}
