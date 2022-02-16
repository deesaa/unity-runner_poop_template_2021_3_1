using DataBase.Game;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Game.Systems
{
    public class LoadNextLevelStageSystem : GameStageSystem
    {
        [Inject] private GameContext G;
        protected override EcsWorld World { get; set; }
        protected override EGameStage Stage { get; set; } = EGameStage.LoadNextLevel;

        protected override void OnPreEnter()
        {
            
        }
        
        protected override void OnEnter()
        { 
            G.GameData.Get1(0).ValueGameData.CurrentLevelIndex += 1;

            if (G.GameData.Get1(0).ValueGameData.CurrentLevelIndex >= 1)
            {
                G.GameData.Get1(0).ValueGameData.CurrentLevelIndex = 0;
            }
            
            G.LoadingManager.LoadScene($"Level_{G.GameData.Get1(0).ValueGameData.CurrentLevelIndex}");
        }

        protected override void OnPreExit() { }
        protected override void OnExit() { }
    }
}