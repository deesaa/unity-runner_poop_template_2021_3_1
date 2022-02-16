using UnityEngine;

namespace Runtime.Game.Ui.Windows.TouchPad
{
    public struct SwipeData
    {
        public Vector2 StartPosition;
        public Vector2 EndPosition;
        public ESwipeDirection Direction;
    }
}