using Ecs.Views.Linkable.Impl;
using UnityEngine;

public class FinishView : LinkableView
{
    public Animator FinalGates;
    private static readonly int IsBeam = Animator.StringToHash("IsBeam");

    public void BeamEffect(bool enable)
    {
        FinalGates.SetBool(IsBeam, enable);
    }
}