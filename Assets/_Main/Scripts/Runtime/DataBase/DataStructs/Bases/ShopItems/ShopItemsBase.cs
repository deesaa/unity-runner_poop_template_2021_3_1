using System;using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

[CreateAssetMenu(menuName = "DB/Base/ShopItemBase", fileName = "ShopItemBase", order = 0)]
public class ShopItemsBase : ScriptableObject, IShopItemsBase, IInitializable
{
    [SerializeField] private List<ShopItemConfigWrap> _shopItemConfigs;
    
    private Dictionary<GameItemID, ShopItemConfig> _shopItemConfigsDic = new Dictionary<GameItemID, ShopItemConfig>();
    
    public void Initialize()
    {
        foreach (var shopItemConfig in _shopItemConfigs)
        {
            _shopItemConfigsDic.Add(shopItemConfig.Config.ItemID.ItemID, shopItemConfig.Config);
        }
    }

    public ShopItemConfig GetShopItemConfig(GameItemID itemID)
    {
        if (!_shopItemConfigsDic.ContainsKey(itemID))
            throw new ArgumentException($"{nameof(GetType)} Base does not contains key {itemID}");

        return _shopItemConfigsDic[itemID];
    }

    public List<ShopItemConfig> GetAllConfigs()
    {
        return new List<ShopItemConfigWrap>(_shopItemConfigs).Select(x => x.Config).ToList();
    }
}