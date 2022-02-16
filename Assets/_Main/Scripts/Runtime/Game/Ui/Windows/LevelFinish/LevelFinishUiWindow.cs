using Game.Ui.BlackScreen;
using Game.Ui.InGameMenu;
using Runtime.Game.Ui.Windows.TouchPad;
using SimpleUi;

namespace Runtime.Game.Ui
{
    public class LevelFinishUiWindow : WindowBase
    {
        public override string Name => nameof(GetType);
        protected override void AddControllers()
        {
            AddController<LevelFinishUiController>();
        }
    }
}