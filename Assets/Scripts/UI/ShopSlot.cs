using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public ItemSO item;
    public TMP_Text itemNameText;
    public TMP_Text itemPriceText;
    public Image itemImage;

    private int itemPrice;

    public void Initalize(ItemSO _newItem, int _price)
    {
        item = _newItem;
        itemPrice = _price;

        itemNameText.text = item.itemName;
        itemPriceText.text = itemPrice.ToString();
        itemImage.sprite = item.itemImage;
        this.itemPrice = _price;

    }



}
