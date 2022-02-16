using System;

namespace Game.Ui.InGameMenu
{
    [Flags]
    public enum ETargetUI : short
    {
        MainMenu = 1,
        Shop = 2,
        GameHood = 4,
        LevelFinish = 8
    }
}