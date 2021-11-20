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
}
