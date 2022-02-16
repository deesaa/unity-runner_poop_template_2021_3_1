using ECS.Core.Utils.SystemInterfaces;
using Leopotam.Ecs;

namespace ECS.Game.Systems
{
    public class GameStageUpdateSystem : IEcsUpdateSystem
    {
        private EcsFilter<StageHandlerComponent, ActiveComponent> _activeStages;

        public void Run()
        {
            foreach (var i in _activeStages)
            {
                _activeStages.Get1(i).Update();
            }
        }
    }
}