using ECS.Core.Utils.ReactiveSystem;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Game.Systems
{
    public class UIUpdateDataSystem : ReactiveSystem<SignalUpdateData>
    {
        protected override EcsFilter<SignalUpdateData> ReactiveFilter { get; }
        [Inject] private SignalBus _signalBus;
        private EcsFilter<GameDataComponent> _gameData;
        protected override void Execute(EcsEntity entity)
        {
            _signalBus.Fire(new SignalUpdateData()
            {
                TargetUI = entity.Get<SignalUpdateData>().TargetUI,
                GameData = _gameData.Get1(0)
            });
        }
    }
}