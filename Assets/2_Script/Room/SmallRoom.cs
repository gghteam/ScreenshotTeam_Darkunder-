using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject[] chagePanel;
    [SerializeField]
    private GameObject nextRoom;
    private bool isopenDoor = false;
    private bool iskey = false;
    private void OnClickNextRoom()
    {
        gameObject.SetActive(false);
        nextRoom.SetActive(true);
    }
    public void OnClickChageOn(int a)
    {
        Debug.Log("on");
        chagePanel[a].SetActive(true);
    }
    public void OnClickChageOff(int a)
    {
        Debug.Log("off");
        chagePanel[a].SetActive(false);
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
        Debug.Log(id);
        Door door = null;
        door =  GameManager.Instance.CurrentUser.doorListData.DoorList[id];
        if(door.doorOpen)
        {
            ChangeRoom();
            return;
        }
        foreach (Item inventory in GameManager.Instance.CurrentUser.inventoryList)
        {
            if(inventory.itemID == door.doorKeyID)
            {
                GameManager.Instance.CurrentUser.doorListData.DoorList[id].doorOpen = true;
                ChangeRoom();
                return;
            }
        }
        FindObjectOfType<DialogueData>().StartDialogue(id);
    }
    private void ChangeRoom()
    {
        gameObject.SetActive(false);
        nextRoom.SetActive(true);
    }
}
