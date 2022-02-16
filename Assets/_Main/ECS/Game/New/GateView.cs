using System.Collections.Generic;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;

public class GateView : LinkableView
{
    [SerializeField] private EGameChoice LeftGate;
    [SerializeField] private EGameChoice RightGate;
    public Collider LeftGateCollider;
    public Collider RightGateCollider;

    [SerializeField] private SpriteRenderer LeftSprite;
    [SerializeField] private SpriteRenderer LeftSpritTop;
    [SerializeField] private SpriteRenderer RightSprite;
    [SerializeField] private SpriteRenderer RightSpriteTop;

    public List<MeshRenderer> LeftBaseMeshes;
    public MeshRenderer LeftGateDoorMesh;
    
    public List<MeshRenderer> RightBaseMeshes;
    public MeshRenderer RightGateDoorMesh;

    public TMP_Text LeftTitle;
    public TMP_Text RigthTitle;

    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        Entity.Get<GateComponent>().LeftGate = LeftGate;
        Entity.Get<GateComponent>().RightGate = RightGate;
    }

    public void SetChoices(EGameChoice left, EGameChoice right)
    {
        LeftGate = left;
        RightGate = right;
        LeftTitle.text = left.ToString().Replace("_", " ");
        RigthTitle.text = right.ToString().Replace("_", " ");
    }

    public void SetMaterials(GateMaterialElement leftMats, GateMaterialElement rightMats)
    {
        foreach (var baseMesh in LeftBaseMeshes)
            baseMesh.material = leftMats.BaseMaterial;
        LeftGateDoorMesh.material = leftMats.DoorMaterial;
        
        foreach (var baseMesh in RightBaseMeshes)
            baseMesh.material = rightMats.BaseMaterial;
        RightGateDoorMesh.material = rightMats.DoorMaterial;
    }

    public void SetIcons(Sprite left, Sprite leftTop, Sprite right, Sprite rightTop)
    {
        LeftSprite.sprite = left;
        RightSprite.sprite = right;
        LeftSpritTop.sprite = leftTop;
        RightSpriteTop.sprite = rightTop;
    }

    public void OnGateEnter(ESide left)
    {
        LeftGateCollider.enabled = false;
        RightGateCollider.enabled = false;
    }
}