using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivingRoom : MonoBehaviour
{
    private int carfetNum = 0;
    [SerializeField]
    GameObject drawer;
    [SerializeField]
    private GameObject carfet;
    [SerializeField]
    private Button carfetButton;
    [SerializeField]
    private Button drawerButton1;
    [SerializeField]
    private Button drawerExitButton1;
    [SerializeField]
    private Button drawerExitButton2;
    [SerializeField]
    private Sprite[] carfetSprites;
    private Image carfetImage;
    public bool onoff = false;
    private void Start()
    {
        carfetImage = carfet.GetComponent<Image>();
        drawerExitButton1.gameObject.SetActive(false);
        drawer.SetActive(false);
    }
    public void DrawerClick()
    {
        if (onoff == false)
        {
            drawer.SetActive(true);
            onoff = true;
            carfetButton.gameObject.SetActive(false);
            drawerExitButton1.gameObject.SetActive(true);
            drawerExitButton2.gameObject.SetActive(true);
            drawerButton1.gameObject.SetActive(false);
        }
        else if (onoff == true)
        {
            drawer.SetActive(false);
            onoff = false;
            carfetButton.gameObject.SetActive(true);
            drawerExitButton1.gameObject.SetActive(false);
            drawerExitButton2.gameObject.SetActive(false);
            drawerButton1.gameObject.SetActive(true);
        }
    }
    public void CarfetClick()
    {
        if (carfetNum == 0)
        {
            ++carfetNum;
            carfetImage.sprite = carfetSprites[carfetNum];
        }
        else if (carfetNum == 1)
        {
            --carfetNum;
            carfetImage.sprite = carfetSprites[carfetNum];
        }
    }
}
