using System;

[Serializable]
public class Item 
{
    public int itemID;
    private string itemName;
    private int imageNumber;
    private ItemType itemType;
    public enum ItemType
    {
        None = 0,
        Use = 1,
        Equip = 2,
        ETC = 3
    }
    // public int ID{
    //     set{itemID = value;}
    //     get{return itemID;}
    // }
    public string NAME{
        set{itemName = value;}
        get{return itemName;}
    }
    public int ICON{
        set{imageNumber = value;}
        get{return imageNumber;}
    }
    public ItemType TYPE{
        set{itemType = value;}
        get{return itemType;}
    }
}
