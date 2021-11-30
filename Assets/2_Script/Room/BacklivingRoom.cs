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
    private Sprite[] panelImage;
    private int openDoorLock;
    private string doorLockNumber;
    private void Start() {
        if(PlayerPrefs.GetInt("isOpen")==1)
        {
            panel.GetComponent<Image>().sprite = panelImage[1];
            doorlock.SetActive(false);
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
    public void DoorLockNumber(int number)
    {
        doorLockNumber+=string.Format("{0}",number);
        SetPassword(doorLockNumber);
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
            PlayerPrefs.SetInt("isOpen",1);
            return;
        }
    }
}
