using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip click_Carfet;

    public AudioClip click_Door;

    public AudioClip click_Key;

    public AudioClip click_Light;

    public AudioClip click_Drawer;

    public AudioClip click_Mirror;

    public AudioClip click_DoorLock;

    public AudioClip click_Paper;

    public AudioClip click_Tape;

    public AudioClip click_Book;

    public AudioClip click_RemoteControl;

    public AudioClip click_TVSound;

    public static SfxManager sfxInstance;
    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
