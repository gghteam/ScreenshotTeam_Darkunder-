using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivingRoom : MonoBehaviour
{
    private int carfetNum = 0;
    private int drawers1Num = 0;
    private int drawers2Num = 0;
    [SerializeField]
    GameObject drawers; //서랍장 전체

    [SerializeField]
    private GameObject carfet; //카펫 오브젝트 

    [SerializeField]
    private GameObject drawer1; //첫번째 서랍

    [SerializeField]
    private Button carfetButton;//카펫 버튼

    [SerializeField]
    private Button drawersButton1;//첫번째 서랍 버튼

    [SerializeField]
    private Button drawerButton1Image2;//확대 되었을때 첫번째 서랍 눌렀을 때 버튼

    [SerializeField]
    private Button drawersExitButton1;//서랍장 나가기 버튼

    [SerializeField]
    private Button drawersExitButton2;//서랍장 나가기 버튼2

    [SerializeField]
    private Button kitchenButton;//부엌 가기 버튼

    [SerializeField]
    private Button drawer1button;//확대 되었을때첫번째 서랍 버튼

    [SerializeField]
    private Sprite[] carfetSprites;//카펫 스프라이트들

    [SerializeField]
    private Sprite[] drawersSprites;//서랍 스프라이트들

    private Image carfetImage;

    private Image drawer1Image;

    public bool onOff = false;
    public bool objectOnOff = false;

    private void Start()
    {
        drawer1Image = drawer1.GetComponent<Image>();
        carfetImage = carfet.GetComponent<Image>();
        drawersExitButton1.gameObject.SetActive(false);
        drawersExitButton2.gameObject.SetActive(false);
        drawerButton1Image2.gameObject.SetActive(false);
        drawers.SetActive(false);
    }
    public void DrawersClick()
    {
        if (onOff == false)
        {
            drawers.SetActive(true);
            onOff = true;
            kitchenButton.gameObject.SetActive(false);
            carfetButton.gameObject.SetActive(false);
            drawersExitButton1.gameObject.SetActive(true);
            drawersExitButton2.gameObject.SetActive(true);
            drawersButton1.gameObject.SetActive(false);
        }
        else if (onOff == true)
        {
            kitchenButton.gameObject.SetActive(true);
            drawers.SetActive(false);
            onOff = false;
            carfetButton.gameObject.SetActive(true);
            drawersExitButton1.gameObject.SetActive(false);
            drawersExitButton2.gameObject.SetActive(false);
            drawersButton1.gameObject.SetActive(true);
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
    public void Drawer1Click()
    {
        if (drawers1Num == 0)
        {
            ++drawers1Num;
            drawer1Image.sprite = drawersSprites[drawers1Num];
            drawer1button.gameObject.SetActive(false);
            drawerButton1Image2.gameObject.SetActive(true);
        }
        else if (drawers1Num == 1)
        {
            --drawers1Num;
            drawer1Image.sprite = drawersSprites[drawers1Num];
            drawer1button.gameObject.SetActive(true);
            drawerButton1Image2.gameObject.SetActive(false);
        }
    }
    public void Drawer2Click()
    {
        if (drawers2Num == 0)
        {
            ++drawers2Num;
            carfetImage.sprite = carfetSprites[carfetNum];
        }
        else if (drawers2Num == 1)
        {
            --drawers2Num;
            carfetImage.sprite = carfetSprites[carfetNum];
        }
    }
}
