using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ShopItems> shopItems;
    [SerializeField] private ShopSlot[] shopSlots;

}

[System.Serializable]
public class ShopItems
{
    public ItemSO item;
    public int price;
}