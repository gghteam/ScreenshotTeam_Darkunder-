using System.Collections.Generic;
[System.Serializable]
public class User
{
    public List<Item> itemList = new List<Item>();
    public List<Item> inventoryList = new List<Item>();
    public DoorData doorListData;
}
