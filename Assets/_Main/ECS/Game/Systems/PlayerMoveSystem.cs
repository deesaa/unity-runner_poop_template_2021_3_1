using System;
using DataBase.Game;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using Leopotam.Ecs;
using PathCreation;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerMoveSystem : IEcsUpdateSystem
{
    private EcsFilter<MonoComponent<PathCreator>> _path;
    [Inject] private GameContext G;
    
    public void Run()
    {
        if (G.GameStage.CurrentStage != EGameStage.Play)
            return;
        
        float distance = G.Player.Get2(0).MoveDistance;

        if (G.Player.Get2(0).InjuredTimer > 0f)
            distance += G.GameConfig.PlayerConfig.MoveSpeed.StartValue * 0.3f * Time.deltaTime;
        else
            distance += G.GameConfig.PlayerConfig.MoveSpeed.StartValue * Time.deltaTime;
        G.Player.Get2(0).InjuredTimer -= Time.deltaTime;

        G.Player.Get2(0).MoveDistance = distance;
        G.Player.Get1(0).View.transform.position = _path.Get1(0).Value.path.GetPointAtDistance(distance);
        G.Player.Get1(0).View.transform.rotation = _path.Get1(0).Value.path.GetRotationAtDistance(distance);
        
        G.SignalBus.Fire(new SignalUpdateLevelProgress()
        {
            Value = distance / (_path.Get1(0).Value.path.length * 0.9f)
        });

        G.Player.Get1(0).View.OnRun();
    }
}