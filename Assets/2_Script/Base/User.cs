using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class User
{
    
    public List<Item> itemList = new List<Item>();
    public void AddList(int itemID,string itemName,int imageNumber,int itemType)
    {
        switch(itemType)
        {
            case 1:
            itemList.Add(new Item(itemID,itemName,imageNumber,Item.ItemType.Use));
            break;
            case 2:
            itemList.Add(new Item(itemID,itemName,imageNumber,Item.ItemType.Equip));
            break;
            case 3:
            itemList.Add(new Item(itemID,itemName,imageNumber,Item.ItemType.ETC));
            break;
            default:
            Debug.Log("Wrong type.");
            break;
        }
        
    }
}
