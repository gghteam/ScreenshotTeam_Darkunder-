using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{
    [SerializeField]
    private Image[] keypad;
    private string password;
    private string[] split_Text;
    public void Input(int number)
    {
        password += string.Format("{0},",number);
        keypad[number-1].color = new Color(0.7f,0.09f,0.13f,0.5f);
    }
    public void Acept()
    {
        int a= 0;
        split_Text = password.Split(',');
        for(int i = 0;i < split_Text.Length-1;i++)
        {
            if(split_Text[i] == "2"||split_Text[i] == "4"||split_Text[i] == "5"||split_Text[i] == "9")
            {
                a++;
            }
            else
            {
                a--;
            }
        }
        if(a>=4)
        {
            OpenDoor();
            return;
        }
        password = "";
        SetColor();

    }
    private void SetColor()
    {
        for(int i=0;i<keypad.Length;i++)
        {
            keypad[i].color = new Color(0,0,0,0f);
        }
    }
    private void OpenDoor()
    {
        Debug.Log("Open Exit Door");
    }
}
