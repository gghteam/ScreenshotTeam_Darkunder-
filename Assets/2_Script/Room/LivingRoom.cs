using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject[] nextRoom;
    public void OnClickNextRoom(int a)
    {
        gameObject.SetActive(false);
        nextRoom[a].SetActive(true);
    }
    
}
