using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    
    public UiManager uiManager {get;private set;}
    [SerializeField]
    private User user;
    public User CurrentUser {get{return user;}}
    private string SAVE_PATH = "";
    private readonly string SAVE_FILENAME = "/SaveFile.txt";
 private void Awake() 
    {
        uiManager = FindObjectOfType<UiManager>();
        SAVE_PATH = Application.persistentDataPath + "/Save";
        if(!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        LoadFromJson();
        
        InvokeRepeating("SaveToJson",1f,60f);
    }
    private void Update() {
        //이코드 없에야 됨 ㅇㅇ
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("isOpen : 0");
            PlayerPrefs.SetInt("isOpen",0);
        }
    }
    private void SaveToJson()
    {   
        SAVE_PATH = Application.persistentDataPath  + "/Save";
        if(user == null) return;
        string json = JsonUtility.ToJson(user,true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME,json,System.Text.Encoding.UTF8);
    }
    private void LoadFromJson()
    {
        string json = "";
        if(File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
        else
        {
            SaveToJson();
            LoadFromJson();
        }
    }
    private void OnApplicationQuit() {
        SaveToJson();    
    }
}
