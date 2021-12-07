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
    private bool isReset = false;
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
        if(Input.GetKey(KeyCode.A))
        {
            PlayerPrefs.SetInt("isOpen",0);
        }
    }
    private void SaveToJson()
    {   
        if(isReset) return;
        SAVE_PATH = Application.persistentDataPath + "/Save";
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
    public void ResetToJson()
    {
        isReset = true;
        PlayerPrefs.SetInt("isOpen",0);
        PlayerPrefs.SetInt("STARTGAME",0);
        File.Delete(SAVE_PATH+SAVE_FILENAME);
        Application.Quit();
    }
    private void OnApplicationQuit() {
        if(isReset) return;
        SaveToJson();    
    }
}
