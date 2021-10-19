using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
   private GameObject[] roomPanel = null;
    private void Awake()
    {
        
    }
}
