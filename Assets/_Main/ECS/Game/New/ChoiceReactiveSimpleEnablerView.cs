using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public class ChoiceReactiveSimpleEnablerView : ChoiceReactiveView, IReinitializable
{
    public Transform Target;

    public List<EGameChoice> EnableIf;

    public bool IsDefultEnabled;

    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        Target.gameObject.SetActive(IsDefultEnabled);
    }

    public override void OnChoice(EGameChoice choice)
    {
        Target.gameObject.SetActive(EnableIf.Contains(choice));
    }

    public void Reinitialize()
    {
        Target.gameObject.SetActive(IsDefultEnabled);
    }
}