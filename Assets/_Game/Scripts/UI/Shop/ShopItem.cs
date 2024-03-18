using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public enum State { Buy, Bought, Equipped, Selecting }

    [SerializeField] GameObject[] stateObjects;

    private UISkinShop shop;

    [SerializeField] Color[] colorBg;
    [SerializeField] Image icon;
    [SerializeField] Image bgIcon;

    public int id;
    public State state;

    public Enum Type;
    internal ShopItemData data;

    public void SetShop(UISkinShop shop)
    {
        this.shop = shop;
    }

    public void SetData<T>(int id, ShopItemData<T> itemData, UISkinShop shop) where T : Enum
    {
        this.id = id;
        Type = itemData.type;
        this.data = itemData;
        this.shop = shop;
        icon.sprite = itemData.icon;
        bgIcon.color = colorBg[(int)shop.skinType];
    }
    
    public void SelectButton()
    {
        shop.SelectItem(this);
    }

    public void SetState(State state)
    {
        for (int i = 0; i < stateObjects.Length; i++)
        {
            stateObjects[i].SetActive(false);
        }

        stateObjects[(int)state].SetActive(true);

        this.state = state;
    }
}
