using System;
[Serializable]
public class Item
{
    public int itemID;
    public string itemName;
    public int imageNumber;
    public ItemType itemType;
    public enum ItemType 
    {
        None = 0,
        Use = 1,
        Equip = 2,
        ETC = 3
    }
}
