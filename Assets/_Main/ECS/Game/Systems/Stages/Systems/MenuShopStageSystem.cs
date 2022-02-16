using _Main.Scripts.Runtime.Services;
using DataBase.Game;
using ECS.Utils.Extensions;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using Runtime.Game.Ui.Windows.Shop;
using SimpleUi.Signals;
using Zenject;

namespace ECS.Game.Systems
{
    public class MenuShopStageSystem : GameStageSystem
    {
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private SceneData _sceneData;
        [Inject] private VibrationService _vibrationService;
        private EcsFilter<GameDataComponent> _gameData;
        private EcsFilter<MonoLinkComponent<MainCameraGroup>> _camera;
        protected override EcsWorld World { get; set; }
        protected override EGameStage Stage { get; set; } = EGameStage.MenuShop;
        
        protected override void OnEnter()
        {
            _vibrationService.Vibrate(_gameData.Get1(0).ValueGameData, 25);
            _signalBus.OpenWindow<ShopWindow>();
        }

        protected override void OnPreExit()
        {
            _gameData.Get1(0).ValueGameData.IsNewItemAvaibleNotification = false;
            _signalBus.Fire(new SignalHide()
            {
                TargetUI = ETargetUI.Shop
            });
        }

        protected override void OnExit()
        {
            _signalBus.BackWindow();
        }
    }
}