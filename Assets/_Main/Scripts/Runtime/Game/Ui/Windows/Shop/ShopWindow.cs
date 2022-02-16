using SimpleUi;
using SimpleUi.Interfaces;

namespace Runtime.Game.Ui.Windows.Shop
{
    public class ShopWindow : WindowBase
    {
        public override string Name => nameof(GetType);
        
        protected override void AddControllers()
        {
            AddController<ShopController>();
        }
    }
}