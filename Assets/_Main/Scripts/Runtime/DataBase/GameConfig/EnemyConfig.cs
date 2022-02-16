using System;

namespace Runtime.DataBase.General.GameCFG
{
    [Serializable]
    public struct EnemyConfig
    {
        public float Health;
        public float AttackCooldown;
        public double UnitsDamageDelay;
        public int KillUnitsPerBossHit;
        public int KillUnitsPerEnemy;
        public float PredictionPower;
    }
}