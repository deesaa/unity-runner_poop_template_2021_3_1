using UnityEngine;

namespace _Main.Scripts.Runtime.DataBase.DataStructs.Basic
{
    [CreateAssetMenu(menuName = "DB/Item/GameItemIDWrap", fileName = "GameItemIDWrap", order = 0)]
    public class GameItemIDWrap : ScriptableObject
    {
        public GameItemID ItemID;
    }
}