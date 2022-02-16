using System;
using DataBase.Game;

namespace ECS.Game.Systems
{
    public struct StageHandlerComponent
    {
        public EGameStage Stage;
        public Action OnEnter;
        public Action OnPreEnter;
        public Action OnExit;
        public Action OnPreExit;
        public Action Update;
    }
}