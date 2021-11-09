using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    private Image itemImage = null;
    [SerializeField]
    private Text itemNameText = null;
    [SerializeField]
    private Sprite[] itemSprites = null;
    private Item inventory;
    public void SetValue(Item inventory)
    {
        this.inventory = inventory;
        UpdateUI();
    }
    private void UpdateUI()
    {
        itemImage.sprite = itemSprites[inventory.imageNumber];
        itemNameText.text = inventory.itemName;
    }
    
}
