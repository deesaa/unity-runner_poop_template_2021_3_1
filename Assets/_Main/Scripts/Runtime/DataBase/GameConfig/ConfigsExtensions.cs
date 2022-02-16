using System.Collections.Generic;
using Runtime.DataBase.General.GameCFG;

public static class ConfigsExtensions
{
    public static LevelConfig GetConfig(this List<LevelConfig> list, int levelIndex)
    {
        return list.Find(config => config.LevelIndex == levelIndex);
    }
}