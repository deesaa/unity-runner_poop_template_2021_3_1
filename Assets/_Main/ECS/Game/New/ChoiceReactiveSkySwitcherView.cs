using System;
using System.Collections.Generic;
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

public class ChoiceReactiveSkySwitcherView : ChoiceReactiveAnimatorSwitchView
{
    public Light Light;
    public float ChangeLightSpeed; 
    public List<GlobalLightReactConfig> Configs;

    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        
        if (Configs.Exists(x => x.Choice == EGameChoice.Null))
        {
            var c = Configs.Find(x => x.Choice == EGameChoice.Null);
            DOTween.Kill(Light);
            Light.DOColor(c.LightColor, ChangeLightSpeed).SetTarget(Light);
        }
    }

    public override void OnChoice(EGameChoice choice)
    {
        base.OnChoice(choice);

        if (Configs.Exists(x => x.Choice == choice))
        {
            var c = Configs.Find(x => x.Choice == choice);
            DOTween.Kill(Light);
            Light.DOColor(c.LightColor, ChangeLightSpeed).SetTarget(Light);
        }
    }

    public override void Reinitialize()
    {
        base.Reinitialize();
        
        if (Configs.Exists(x => x.Choice == EGameChoice.Null))
        {
            var c = Configs.Find(x => x.Choice == EGameChoice.Null);
            DOTween.Kill(Light);
            Light.DOColor(c.LightColor, ChangeLightSpeed).SetTarget(Light);
        }
    }
}

[Serializable]
public struct GlobalLightReactConfig
{
    public EGameChoice Choice;
    public Color LightColor;
    public float LightIntensity;
}