using System;
using _Main.Scripts.Runtime.DataBase.DataStructs.Basic;
using UnityEngine;

[Serializable]
public struct ShopItemConfig
{
    public GameItemIDWrap ItemID;

    public string NameInShop;
    public ShopPriceConfig PriceConfig;
    public int MaxObtained;
    public ItemInShopView ItemInShopView;
    public Sprite InShopIcon;
}