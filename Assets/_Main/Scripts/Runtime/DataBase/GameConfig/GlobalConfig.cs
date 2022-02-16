using System;
using UnityEngine;

namespace Runtime.DataBase.General.GameCFG
{
    [Serializable]
    public struct GlobalConfig
    {
        public float TurnSpeed;
        public float Sensitivity;
        public Vector3 SideMoveBounds;
        public float AddMultiplierPerBossAttack;
        public int AddCoinsPerEnemy;
        public float FreezeTimeSpeed;
        public float UnfreezeTimeSpeed;
        public float CameraFocusSpeed;
        public float PlayerInfoFollowSpeed;
        public Vector3 PlayerInfoOffset;
    }
}