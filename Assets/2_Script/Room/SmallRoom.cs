using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject[] chagePanel;
    [SerializeField]
    private GameObject smallRoomKey;
    private void Start() {
        foreach (Item item in GameManager.Instance.CurrentUser.inventoryList)
        {
            if(item.itemID==0)
            {
                smallRoomKey.SetActive(false);
                return;
            }
        }
    }
    public void OnClickChageOn(int a)
    {
        Debug.Log("on");
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click_Light);
        chagePanel[a].SetActive(true);
    }
    public void OnClickChageOff(int a)
    {
        Debug.Log("off");
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click_Light);
        chagePanel[a].SetActive(false);
    }
    public void Key(GameObject Ob)
    {   
        Ob.SetActive(false);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click_Key);
    }
    public void DoorSound()
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click_Door);
    }
}
