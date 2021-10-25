using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public UiManager uiManager {get;private set;}
    [SerializeField]
    private GameObject[] roomPanel = null;
    private void Awake()
    {
        
    }
}
