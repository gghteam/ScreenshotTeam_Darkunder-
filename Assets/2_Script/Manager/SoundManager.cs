using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;
    public static SoundManager BgInstance;
    private void Awake()
    {
        if(BgInstance!=null&&BgInstance!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        BgInstance = this;
    }
    public void BGMSoundVolume(float val)
    {
        mixer.SetFloat("BgmSound",Mathf.Log10(val)*20);
    }
}
