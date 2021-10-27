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
        switch(itmeId)
        {
            case 1:
            if(iskey)return;
            iskey = true;
            GameManager.Instance.currentUser.AddList(1,"열쇠",1,1);
            break;
        }
    }
    public void OpenDoor(int id)
    {
        if(isopenDoor)
        {
            OnClickNextRoom();
            return;
        }
        foreach (Item item in GameManager.Instance.currentUser.itemList)
        {
            if(item.itemID == id)
            {
                isopenDoor = true;
                OnClickNextRoom();
                return;
            }
        }
        FindObjectOfType<DialogueData>().StartDialogue(0);
    }
}
