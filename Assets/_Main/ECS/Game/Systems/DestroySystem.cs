using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using Leopotam.Ecs;
using UnityEngine;

public class DestroySystem : IEcsUpdateSystem
{
    private EcsFilter<LinkComponent, DelayedDestroyComponent> _links;
        
    public void Run()
    {
        foreach (var i in _links)
        {
            if (_links.Get2(i).Delay <= _links.Get2(i).TimePassed)
            {
                _links.Get1(i).View.Destroy();
                _links.GetEntity(i).Destroy();
                continue;
            }

            if (_links.Get2(i).IsUnscaledTime)
            {
                _links.Get2(i).TimePassed += Time.unscaledDeltaTime;
            }
            else
            {
                _links.Get2(i).TimePassed += Time.deltaTime;
            }
        }
    }
}