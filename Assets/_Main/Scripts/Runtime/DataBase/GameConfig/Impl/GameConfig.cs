using System.Collections.Generic;
using UnityEngine;
using PlayerSettingsConfig = Runtime.Services.PlayerSettings.PlayerSettings;

namespace Runtime.DataBase.General.GameCFG.Impl
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Settings/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private GlobalConfig _globalConfig;
        [SerializeField] private ShopConfig _shopConfig;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private EffectsConfig _effectsConfig;
        [SerializeField] private List<LevelConfig> _levelConfigs;
        [SerializeField] private PlayerSettingsConfig _playerSettings;
        public PlayerConfig PlayerConfig => _playerConfig;
        public GlobalConfig GlobalConfig => _globalConfig;
        public ShopConfig ShopConfig => _shopConfig;
        public EnemyConfig EnemyConfig => _enemyConfig;
        public EffectsConfig EffectsConfig => _effectsConfig;
        public List<LevelConfig> LevelConfigs => _levelConfigs;
        public PlayerSettingsConfig PlayerSettings => _playerSettings;
    }
}