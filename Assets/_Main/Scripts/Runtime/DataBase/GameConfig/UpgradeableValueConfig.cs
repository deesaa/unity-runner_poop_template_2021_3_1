using System;

namespace Runtime.DataBase.General.GameCFG
{
    [Serializable]
    public class UpgradeableValueConfig
    {
        public float StartValue;
        public float AddValuePerUpgrade;

        public float GetSumValue(int upgradeLevel) => 
            (StartValue + AddValuePerUpgrade * upgradeLevel);
    }
}