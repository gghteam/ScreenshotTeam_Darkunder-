using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacklivingRoom : MonoBehaviour
{
    [SerializeField]
    private Text password;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject doorlock;
    [SerializeField]
    private GameObject tv;
    [SerializeField]
    private GameObject remoconBox;
    [SerializeField]
    private GameObject remocon;
    [SerializeField]
    private GameObject booksPanel;
    [SerializeField]
    private GameObject book;
    [SerializeField]
    private Sprite[] books;
    [SerializeField]
    private Sprite[] panelImage;
    private int openDoorLock;
    private string doorLockNumber;
    private void Start() {
        if(PlayerPrefs.GetInt("isOpen")==1)
        {
            panel.GetComponent<Image>().sprite = panelImage[1];
            doorlock.SetActive(false);
            booksPanel.SetActive(true);
            foreach(Item item in GameManager.Instance.CurrentUser.inventoryList)
            {
                if(item.itemID==4)
                return;
            }
            remoconBox.SetActive(true);
            
        }
    }
    public void OnGameOb(GameObject ob)
    {
        ob.SetActive(true);
    }
    public void OffGameOb(GameObject ob)
    {
        ob.SetActive(false);
    }
    public void ChangeBooks(int id){
        book.GetComponent<Image>().sprite = books[id];
    }
    public void DoorLockNumber(int number)
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click_DoorLock);
        doorLockNumber +=string.Format("{0}",number);
        SetPassword(doorLockNumber);
    }
    public void OnTv(int id){
        foreach(Item item in GameManager.Instance.CurrentUser.inventoryList)
        {
            if(item.itemID==4)
            {
                tv.SetActive(true);
                return;
            }
            
        }
        FindObjectOfType<DialogueData>().StartDialogue(id);
    }
    public void RemoconBoxOpen(int id)
    {
        foreach(Item item in GameManager.Instance.CurrentUser.inventoryList)
        {
            if(item.itemID==3)
            {
                //사운드 찾으면 바꾸기
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click_DoorLock);
                remoconBox.SetActive(false);
                remocon.SetActive(true);
                return;
            }
            
        }
        FindObjectOfType<DialogueData>().StartDialogue(id);
    }
    public void RemoconAcquisition()
    {
        remocon.SetActive(false);
        Item _item = GameManager.Instance.CurrentUser.itemList[4];
        GameManager.Instance.CurrentUser.inventoryList.Add(_item);
        GameManager.Instance.uiManager.AddPanel(_item);
    }
    private void SetPassword(string _password)
    {
        if(_password.Length>=5)
        {
            doorLockNumber = null;
            password.text = string.Format("{0}",0000);
            return;
        }
        password.text = string.Format("{0}",_password);
        if(_password==string.Format("2678"))
        {
            Debug.Log("Open DoorLock Password : 2678");
            panel.GetComponent<Image>().sprite = panelImage[1];
            doorlock.SetActive(false);
            remoconBox.SetActive(true);
            booksPanel.SetActive(true);
            PlayerPrefs.SetInt("isOpen",1);
            return;
        }
    }
}
