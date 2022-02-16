using System;

namespace Game.Ui.InGameMenu
{
    [Serializable]
    public struct SafeRewardData
    {
        public GameItemID RewardItem;
        public ECurrencyType CurrencyType;
        public int Price;
    }
}