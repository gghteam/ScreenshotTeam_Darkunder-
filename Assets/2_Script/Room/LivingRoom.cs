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
    GameObject drawers; //������ ��ü

    [SerializeField]
    private GameObject carfet; //ī�� ������Ʈ 

    [SerializeField]
    private GameObject mirror;

    [SerializeField]
    private Button mirrorButton;

    [SerializeField]
    private Button mirrorExitButton;

    [SerializeField]
    private GameObject drawer1; //ù��° ����

    [SerializeField]
    private Button carfetButton;//ī�� ��ư

    [SerializeField]
    private Button drawersButton1;//ù��° ���� ��ư

    [SerializeField]
    private Button drawerButton1Image2;//Ȯ�� �Ǿ����� ù��° ���� ������ �� ��ư

    [SerializeField]
    private Button drawersExitButton1;//������ ������ ��ư

    [SerializeField]
    private Button drawersExitButton2;//������ ������ ��ư2

    [SerializeField]
    private Button kitchenButton;//�ξ� ���� ��ư

    [SerializeField]
    private Button drawer1button;//Ȯ�� �Ǿ�����ù��° ���� ��ư

    [SerializeField]
    private Sprite[] carfetSprites;//ī�� ��������Ʈ��

    [SerializeField]
    private Sprite[] drawersSprites;//���� ��������Ʈ��

    [SerializeField]
    private Button frameButton;

    [SerializeField]
    private Button frameExitButton;

    [SerializeField]
    private GameObject frame;

    private Image carfetImage;

    private Image drawer1Image;

    public bool objectOnOff = false;

    private bool frameOnOff = false;

    private bool drawerOnOff = false;

    private bool mirrorOnOff = false;
    private void Start()
    {
        drawer1Image = drawer1.GetComponent<Image>();
        carfetImage = carfet.GetComponent<Image>();
        drawersExitButton1.gameObject.SetActive(false);
        drawersExitButton2.gameObject.SetActive(false);
        frameExitButton.gameObject.SetActive(false);
        mirrorExitButton.gameObject.SetActive(false);
        drawerButton1Image2.gameObject.SetActive(false);
        drawers.SetActive(false);
    }
    public void DrawersClick()
    {
        if (drawerOnOff == false)
        {
            drawers.SetActive(true);
            drawerOnOff = true;
            kitchenButton.gameObject.SetActive(false);
            carfetButton.gameObject.SetActive(false);
            mirrorButton.gameObject.SetActive(false);
            mirrorExitButton.gameObject.SetActive(false);
            drawersExitButton1.gameObject.SetActive(true);
            drawersExitButton2.gameObject.SetActive(true);
            drawersButton1.gameObject.SetActive(false);
        }
        else if (drawerOnOff == true)
        {
            kitchenButton.gameObject.SetActive(true);
            drawers.SetActive(false);
            drawerOnOff = false;
            mirrorButton.gameObject.SetActive(true);
            mirrorExitButton.gameObject.SetActive(false);
            carfetButton.gameObject.SetActive(true);
            drawersExitButton1.gameObject.SetActive(false);
            drawersExitButton2.gameObject.SetActive(false);
            drawersButton1.gameObject.SetActive(true);
        }
    }
    public void FrameClick()
    {
        if (frameOnOff == false)
        {
            frameOnOff = true;
            frame.SetActive(true);
            frameExitButton.gameObject.SetActive(true);
            mirrorButton.gameObject.SetActive(false);
            mirrorExitButton.gameObject.SetActive(false);
            frameButton.gameObject.SetActive(false);
            kitchenButton.gameObject.SetActive(false);
            carfetButton.gameObject.SetActive(false);
            drawersButton1.gameObject.SetActive(false);
        }
        else if (frameOnOff == true)
        {
            frameOnOff = false;
            frame.SetActive(false);
            frameExitButton.gameObject.SetActive(false);
            mirrorButton.gameObject.SetActive(true);
            mirrorExitButton.gameObject.SetActive(false);
            frameButton.gameObject.SetActive(true);
            kitchenButton.gameObject.SetActive(true);
            carfetButton.gameObject.SetActive(true);
            drawersButton1.gameObject.SetActive(true);
        }
    }
    public void MirrorClick()
    {
        if (mirrorOnOff == false)
        {
            mirrorOnOff = true;
            mirror.SetActive(true);
            frameExitButton.gameObject.SetActive(true);
            mirrorButton.gameObject.SetActive(false);
            mirrorExitButton.gameObject.SetActive(true);
            frameButton.gameObject.SetActive(false);
            kitchenButton.gameObject.SetActive(false);
            carfetButton.gameObject.SetActive(false);
            drawersButton1.gameObject.SetActive(false);
        }
        else if (mirrorOnOff == true)
        {
            mirrorOnOff = false;
            mirror.SetActive(false);
            frameExitButton.gameObject.SetActive(false);
            mirrorButton.gameObject.SetActive(true);
            mirrorExitButton.gameObject.SetActive(false);
            frameButton.gameObject.SetActive(true);
            kitchenButton.gameObject.SetActive(true);
            carfetButton.gameObject.SetActive(true);
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
