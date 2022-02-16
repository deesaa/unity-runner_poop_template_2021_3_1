using Game.Ui.BlackScreen;
using SimpleUi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/ProjectUiPrefabInstaller", fileName = "ProjectUiPrefabInstaller")]
    public class ProjectUiPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas Canvas;
        [SerializeField] private BlackScreenView blackScreen;
        
        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(Canvas);
            var canvasTransform = canvasView.transform;
            Container.BindUiView<BlackScreenViewController, BlackScreenView>(blackScreen, canvasTransform);
        }
    }
}