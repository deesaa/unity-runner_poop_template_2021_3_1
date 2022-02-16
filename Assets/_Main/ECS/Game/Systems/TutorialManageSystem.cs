using ECS.Core.Utils.SystemInterfaces;
using Leopotam.Ecs;
using UnityEngine;

public class TutorialManageSystem : IEcsUpdateSystem
{
    private EcsFilter<RuntimeDataComponent> _runtimeData;
    public void Run()
    {
        if (_runtimeData.Get1(0).PlayerMoveTime_Tutorial >= 3f)
        {
            PlayerPrefs.SetInt("StickTutorial", 0);
        }
    }
}