using Game.Ui.BlackScreen;
using Game.Ui.InGameMenu;
using Runtime.Game.Ui.Windows.ConsentPopUp;
using Runtime.Game.Ui.Windows.FocusSpace;
using Runtime.Game.Ui.Windows.MainMenu;
using Runtime.Game.Ui.Windows.Shop;
using Runtime.Game.Ui.Windows.TouchPad;
using Runtime.Installers;
using Runtime.UI.QuitConcentPopUp;
using SimpleUi;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/GameUiPrefabInstaller", fileName = "GameUiPrefabInstaller")]
    public class GameUiPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas GameUICanvas;
        [SerializeField] private Camera GameUICamera;

        //[SerializeField] private InGameMenuView inGameMenu;
        [SerializeField] private FocusView focusView;
        [SerializeField] private GameHoodView gameHood;
        [SerializeField] private StickInputView stickInput;
        [SerializeField] private ShopView shopView;
        [SerializeField] private LevelFinishUiView levelFinishUiView;
        [SerializeField] private MainMenuView mainMenuView;
        [SerializeField] private RunnerMainMenuView runnerMainMenuView;
        [SerializeField] private ConsentPopUpTarget consentPopUpTarget;
        [SerializeField] private TouchpadView touchpadView;

        public override void InstallBindings()
        {
            var gameUICanvas = Instantiate(GameUICanvas);
            var canvasTransform = gameUICanvas.transform;
            //var gameUICamera = Container.InstantiatePrefab(GameUICamera).GetComponent<Camera>();
            //gameUICamera.clearFlags = CameraClearFlags.Depth;
            //gameUICanvas.worldCamera = gameUICamera;
            //gameUICanvas.planeDistance = 10f;
            //Canvas.ForceUpdateCanvases();
            //gameUICamera.Render();
            //gameUICamera.clearFlags = CameraClearFlags.Depth;
           // gameUICamera.orthographic = false;
            //gameUICamera.transform.SetParent(null);
            //gameUICanvas.renderMode = RenderMode.ScreenSpaceCamera;
            //gameUICanvas.worldCamera = gameUICamera;
            //gameUICanvas.planeDistance = 100f;
            Container.Bind<Canvas>().FromInstance(gameUICanvas).AsSingle().NonLazy();
            
            //Container.BindUiView<InGameMenuViewController, InGameMenuView>(inGameMenu, canvasTransform);
            Container.BindUiView<GameHoodController, GameHoodView>(gameHood, canvasTransform);
            Container.BindUiView<MainMenuViewController, MainMenuView>(mainMenuView, canvasTransform);
            Container.BindUiView<RunnerMainMenuViewController, RunnerMainMenuView>(runnerMainMenuView, canvasTransform);
            Container.BindUiView<ShopController, ShopView>(shopView, canvasTransform);
            Container.BindUiView<FocusViewController, FocusView>(focusView, null);
            Container.BindUiView<ConsentPopUpViewController, ConsentPopUpTarget>(consentPopUpTarget, canvasTransform);
            Container.BindUiView<TouchpadViewController, TouchpadView>(touchpadView, canvasTransform);
            Container.BindUiView<LevelFinishUiController, LevelFinishUiView>(levelFinishUiView, canvasTransform);
            Container.BindUiView<StickInputViewController, StickInputView>(stickInput, null);
        }
    }
}