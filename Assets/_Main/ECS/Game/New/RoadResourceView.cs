using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;

public class RoadResourceView : LinkableView
{
    public EGameChoice Choice;

    public void OnTake()
    {
        Entity.Get<DelayedDestroyComponent>();
    }
}