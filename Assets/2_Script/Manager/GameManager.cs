using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    
    public UiManager uiManager {get;private set;}
    [SerializeField]
    private User user;
    public User currentUser {get{return user;}}

}
