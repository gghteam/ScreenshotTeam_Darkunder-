using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rooms = null;
    private GameObject inRoom = null;
    private void Awake() {
        inRoom = rooms[0];
    }
    public void AcquisitionItem(int itmeId)
    {
        foreach (Item item in GameManager.Instance.CurrentUser.itemList)
        {
            if(itmeId==item.itemID)
            {
                foreach (Item inventory in GameManager.Instance.CurrentUser.inventoryList)
                {
                    if(itmeId==inventory.itemID)
                    {
                        return;
                    }
                }
                GameManager.Instance.CurrentUser.inventoryList.Add(item);
                GameManager.Instance.uiManager.AddPanel(item);
                Debug.Log("item Acquisition");
                return;
            }
        }
    }
    public void OpenDoor(int id)
    {
        Debug.Log("openDoorList "+id);
        Door door = null;
        door =  GameManager.Instance.CurrentUser.doorListData.DoorList[id];
        if(door.doorOpen)
        {
            ChangeRoom(door.nextRoomID);
            return;
        }
        foreach (Item inventory in GameManager.Instance.CurrentUser.inventoryList)
        {
            if(inventory.itemID == door.doorKeyID)
            {
                GameManager.Instance.CurrentUser.doorListData.DoorList[id].doorOpen = true;
                ChangeRoom(door.nextRoomID);
                return;
            }
        }
        FindObjectOfType<DialogueData>().StartDialogue(id);
    }
    private void ChangeRoom(int i)
    {
        Debug.Log("ChangeRoom ID : "+i);
        rooms[i].SetActive(true);
        inRoom.SetActive(false);
        inRoom = rooms[i];
    }
}
