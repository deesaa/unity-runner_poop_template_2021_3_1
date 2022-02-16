using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Game.SceneLoading;
using Leopotam.Ecs;
using Runtime.DataBase.General.GameCFG;
using Zenject;

public class GameContext : IEcsInitSystem
{
    [Inject] public IGameConfig GameConfig;
    [Inject] public SceneData SceneData;
    [Inject] public IGameStageService GameStage;
    [Inject] public ISceneLoadingManager LoadingManager;
    public EcsFilter<MonoLinkComponent<PlayerView>, PlayerComponent> Player;
    public EcsFilter<MonoLinkComponent<MainCameraGroup>> Camera;
    public EcsFilter<GameDataComponent> GameData;
    public EcsWorld World;
    public EcsFilter<RuntimeDataComponent> RuntimeData;
    [Inject] public SignalBus SignalBus;
    public void Init()
    {
        
    }
}