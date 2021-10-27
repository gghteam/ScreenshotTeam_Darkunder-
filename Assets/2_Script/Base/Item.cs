[System.Serializable]
public class Item 
{
    public int itemID;
    public string itemName;
    public int imageNumber;
    public ItemType itemType;
    public enum ItemType
    {
        Use,
        Equip,
        ETC
    }
    public Item(int _itemID,string _itemName,int _imageNumber,ItemType _itemType)
    {
        itemID = _itemID;
        itemName = _itemName;
        imageNumber = _imageNumber;
        itemType = _itemType;
    }
}
