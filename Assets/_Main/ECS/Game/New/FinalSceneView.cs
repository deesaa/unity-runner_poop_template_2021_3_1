using DG.Tweening;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using UnityEngine;

public class FinalSceneView : LinkableView, IReinitializable
{
    public Camera Camera;
    public Transform CameraGroup;
    public Light Light;
    public Transform Particles;

    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        CameraGroup.gameObject.SetActive(false);
        Particles.gameObject.SetActive(false);
    }

    public void OnFinalScene(bool enable)
    {
        CameraGroup.gameObject.SetActive(enable);
        Light.DOColor(Color.white, 0.5f);
        Particles.gameObject.SetActive(true);
    }

    public void Reinitialize()
    {
        Particles.gameObject.SetActive(false);
    }
}