using System;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using UnityEngine;

public class ChoiceReactiveAnimatorSwitchView : ChoiceReactiveView, IReinitializable
{
    public Animator Animator;
    public Animator PlayerAnimator;
    

    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
    }

    public void EnableSitting(int enable)
    {
        PlayerAnimator.SetBool("Sitting", enable == 1);
    }

    public override void OnChoice(EGameChoice choice)
    {
        Animator.CrossFadeInFixedTime("DisableAll", 0f);

        if(Animator.HasState(0, Animator.StringToHash(choice.ToString())))
        {
            Animator.CrossFadeInFixedTime(choice.ToString(), 0f);
        }
    }

    public virtual void Reinitialize()
    {
        Animator.CrossFadeInFixedTime("Restart", 0f);
    }
}