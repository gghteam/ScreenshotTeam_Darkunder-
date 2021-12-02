using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Television : MonoBehaviour
{
    [SerializeField]
    private Text telecisionNumberText;
    [SerializeField]
    private GameObject televisionScreen;
    [SerializeField]
    private Sprite[] televisionSprite;
    private string telecisionNumber;
    private int channelSet;
    private bool offTv=true;
    private bool isInput=false;
    public void OnffTelevision()
    {
        if(offTv)
        {
            offTv = false;
            televisionScreen.GetComponent<Image>().sprite = televisionSprite[1];
        }
        else
        {
            offTv = true;
            televisionScreen.GetComponent<Image>().sprite = televisionSprite[0];
        }
        
    }
    public void InputNumber(int number)
    {
        if(offTv)return;
        telecisionNumber += string.Format("{0}",number);
        channelSet=0;
        telecisionNumberText.text = telecisionNumber;
        if(isInput==false)
        StartCoroutine(ChangeChanal());
    }
    private IEnumerator ChangeChanal()
    {
        while(true)
        {
            isInput = true;
            if(channelSet>=2)
            {
                
                isInput = false;
                Channel();
                yield break;
            }
            channelSet++;
            yield return new WaitForSeconds(1f);
        }
    }
    private void Channel()
    {
        Debug.Log("Input Chanel Number"+telecisionNumber);
        if(telecisionNumber=="1234")
        {
            
        }
        telecisionNumber = "";
        telecisionNumberText.text = telecisionNumber;
    }
}
