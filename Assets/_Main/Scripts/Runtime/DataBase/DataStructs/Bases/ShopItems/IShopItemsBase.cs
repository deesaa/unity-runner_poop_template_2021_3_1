using System.Collections.Generic;

public interface IShopItemsBase
{
    ShopItemConfig GetShopItemConfig(GameItemID itemID);
    List<ShopItemConfig> GetAllConfigs();
}