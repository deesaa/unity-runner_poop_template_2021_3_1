using System;
using System.Collections.Generic;

[Serializable]
public struct ReferenceGameData
{
    public List<ShopItemPlayerData> PlayerItems;
    public ReferenceGameData(List<ShopItemPlayerData> playerItems = null)
    {
        PlayerItems = playerItems ?? new List<ShopItemPlayerData>();
    }
}