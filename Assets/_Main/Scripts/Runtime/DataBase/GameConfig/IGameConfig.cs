using System.Collections.Generic;
using System.Linq;
using Runtime.Services.PlayerSettings;
using UnityEngine;

namespace Runtime.DataBase.General.GameCFG
{
    public interface IGameConfig
    {
        PlayerConfig PlayerConfig { get; }
        GlobalConfig GlobalConfig { get; }
        ShopConfig ShopConfig { get; }
        EnemyConfig EnemyConfig { get; }
        EffectsConfig EffectsConfig{ get; }
        List<LevelConfig> LevelConfigs { get; }
        PlayerSettings PlayerSettings { get; }
    }
}