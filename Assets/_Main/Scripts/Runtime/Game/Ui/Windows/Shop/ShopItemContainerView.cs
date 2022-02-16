using System;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.Ui.Windows.Shop
{
    public class ShopItemContainerView : MonoBehaviour
    {
        public Image ItemIcon;
        public TMP_Text LabelItemName;
        public ShopBuyButtonView ButtonBuy;
        public Button ButtonEquip;
        public TMP_Text ButtonEquipText;
        public Image EquippedFlag;

        private ShopItemConfig _itemConfig;

        public void SetItemContainerView(ShopItemConfig config, ShopItemPlayerData? playerItemData, ValueGameData playerData)
        {
            _itemConfig = config;
            LabelItemName.text = config.NameInShop;
            ItemIcon.sprite = config.InShopIcon;
            ButtonBuy.SetButtonView(config.PriceConfig.Price, config.PriceConfig.CurrencyType, playerData);

            if (playerItemData != null)
            {
                if (playerItemData.Value.ObtainedCount >= 1)
                {
                    ButtonBuy.gameObject.SetActive(false);
                    ButtonEquip.gameObject.SetActive(true);

                    var isAlreadyEquipped = config.ItemID.ItemID == playerData.EquippedWeapon;
                    
                    if (isAlreadyEquipped)
                    {
                        ButtonEquipText.text = "EQUIPPED";
                        EquippedFlag.gameObject.SetActive(true);
                        ButtonEquip.interactable = false;
                    }
                    else
                    {
                        ButtonEquipText.text = "EQUIP";
                        EquippedFlag.gameObject.SetActive(false);
                        ButtonEquip.interactable = true;
                    }
                }
                else
                {
                    ButtonBuy.gameObject.SetActive(true);
                    EquippedFlag.gameObject.SetActive(false);
                    ButtonEquip.gameObject.SetActive(false);
                }
            }
            else
            {
                ButtonBuy.gameObject.SetActive(true);
                EquippedFlag.gameObject.SetActive(false);
                ButtonEquip.gameObject.SetActive(false);
            }
        }
    }
}