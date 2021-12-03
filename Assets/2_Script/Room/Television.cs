using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Television : MonoBehaviour
{
    [SerializeField]
    private Text telecisionNumberText;
    [SerializeField]
    private Image televisionScreen;
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
            televisionScreen.sprite = televisionSprite[1];
        }
        else
        {
            offTv = true;
            televisionScreen.sprite = televisionSprite[0];
        }
        
    }
    public void InputNumber(int number)
    {
        if(offTv)return;
        telecisionNumber += string.Format("{0}",number);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click_RemoteControl);
        channelSet =0;
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
        Debug.Log("Input Chanel Number "+telecisionNumber);
        if(telecisionNumber=="1836")
        {
            StartCoroutine(ScreenTrue());
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click_RemoteControl);
        }
        else
        {
            StartCoroutine(ScreenError());
        }
        telecisionNumber = "";
        telecisionNumberText.text = telecisionNumber;
    }
    private IEnumerator ScreenTrue()
    {
        televisionScreen.sprite = televisionSprite[4];
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.tvSound);
        yield return new WaitForSeconds(1f);
        televisionScreen.sprite = televisionSprite[7];
         SfxManager.sfxInstance.Audio.Stop();
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.scream);
        yield return new WaitForSeconds(0.5f);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.tvSound);
        televisionScreen.sprite = televisionSprite[5];
        yield return new WaitForSeconds(1f);
        televisionScreen.sprite = televisionSprite[6];
        yield return new WaitForSeconds(0.5f);
        SfxManager.sfxInstance.Audio.Stop();
        televisionScreen.sprite = televisionSprite[1];
    }
    private IEnumerator ScreenError()
    {
        int a = Random.Range(1,3);
        if(a!=3)
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.tvSound);
            televisionScreen.sprite = televisionSprite[2];
            
        }
        else{
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.scream);
            televisionScreen.sprite = televisionSprite[3];
        }
        yield return new WaitForSeconds(0.5f);
        SfxManager.sfxInstance.Audio.Stop();
        televisionScreen.sprite = televisionSprite[1];
        yield return new WaitForSeconds(0.5f);
    }
}
