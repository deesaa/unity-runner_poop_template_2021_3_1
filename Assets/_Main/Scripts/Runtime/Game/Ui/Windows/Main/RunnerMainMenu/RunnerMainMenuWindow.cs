using Runtime.Game.Ui.Windows.Shop;
using SimpleUi;
using SimpleUi.Interfaces;
using SimpleUi.Managers;
using Zenject;

namespace Runtime.Game.Ui.Windows.MainMenu
{
    public class RunnerMainMenuWindow : WindowBase
    {
        [Inject] private ISelectableMapper _selectableMapper;
        
        public override string Name => "RunnerMainMenu";
        protected override void AddControllers()
        {
            AddController<RunnerMainMenuViewController>();
        }
    }
}