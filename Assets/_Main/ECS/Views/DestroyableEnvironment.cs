using System.Collections.Generic;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using UnityEngine;


public class DestroyableEnvironment : LinkableView, IReinitializable
{
    public Transform UnbrokenView;
    public Collider ImpactCollider;
    public Transform BrokenView;
    public List<BrokePart> _brokeParts = new List<BrokePart>();

    public override void Link(EcsEntity entity)
    {
        base.Link(entity);

        _brokeParts.Clear();
        foreach (Transform t in BrokenView)
        {
            if (t.TryGetComponent(out Rigidbody rb))
            {
                _brokeParts.Add(new BrokePart()
                {
                    Rb = rb,
                    InitialPosition = t.position,
                    InitialRotation = t.rotation
                }); 
            }
        }
        
        Break(false);
    }

    public void Break(bool isBroke, Vector3 position = default, Vector3 direction = default, float power = 1f)
    {
        if (isBroke)
        {
            UnbrokenView.gameObject.SetActive(false);
            BrokenView.gameObject.SetActive(true);
        }
        else
        {
            UnbrokenView.gameObject.SetActive(true);
            BrokenView.gameObject.SetActive(false);

            foreach (var brokePart in _brokeParts)
            {
                brokePart.Rb.velocity = Vector3.zero;
                brokePart.Rb.transform.SetPositionAndRotation(brokePart.InitialPosition, brokePart.InitialRotation);
            }
        }
    } 
    public void Reinitialize()
    {
        Break(false);
    }
}

