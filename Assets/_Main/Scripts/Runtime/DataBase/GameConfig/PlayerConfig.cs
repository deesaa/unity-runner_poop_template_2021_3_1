using System;
using _Main.Scripts.Runtime.DataBase.DataStructs.Basic;
using UnityEngine;

namespace Runtime.DataBase.General.GameCFG
{
    [Serializable]
    public struct PlayerConfig
    {
        public UpgradeableValueConfig MoveSpeed;
        public UpgradeableValueConfig LookRotationSpeed;
        public UpgradeableValueConfig MinAngleAbleMove;
        public UpgradeableValueConfig IncomeCoins;
        public UpgradeableValueConfig StartPlayerUnits;
        public float PlayerTargetMaxDistance;
        public float AttackCooldown;

        public GameItemIDWrap DefalutWeapon;
        public LayerMask EnemyRaycastMask;
    }
}