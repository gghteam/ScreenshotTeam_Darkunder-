using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startGamePanel;
    [SerializeField]
    private GameObject inGmaePanel;
    [SerializeField]
    private GameObject settingPanel;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private RectTransform itemPanel;
    [SerializeField]
    private float upDownY = 0.5f;
    [SerializeField]
    private InventoryPanel inventoryPanelTemp = null;
    private List<InventoryPanel> InventoryPanelList = new List<InventoryPanel>();
    private bool isUp = true;
    private bool isUptime = false;
    private void Start() {
        CreateInventoryPanel();
    }
    private void Update() {
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Click ESC On");
            OnMenuPanelBtn();
        }
    }
    public void StartGameBtn()
    {
        Debug.Log("Start Game");
        inGmaePanel.SetActive(true);
        startGamePanel.SetActive(false);
    }
    public void SettingPanelBtn()
    {
        settingPanel.SetActive(true);
    }
    public void OffSettingPanelBtn()
    {
        settingPanel.SetActive(false);
    }
    public void OnMenuPanelBtn()
    {
        menuPanel.SetActive(true);
    }
    public void OffMenuPanelBtn()
    {
        menuPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    private void CreateInventoryPanel()
    {
        GameObject panel = null;
        InventoryPanel panelComponent = null;
        foreach(var inventory in GameManager.Instance.CurrentUser.inventoryList)
        {
            panel = Instantiate(inventoryPanelTemp.gameObject,inventoryPanelTemp.transform.parent);
            panelComponent = panel.GetComponent<InventoryPanel>();
            panelComponent.SetValue(inventory);
            panel.SetActive(true);
            InventoryPanelList.Add(panelComponent);
        }
    }

    public void AddPanel(Item addItem)
    {
        Debug.Log("Null?");
        GameObject panel = null;
        InventoryPanel panelComponent = null;
        panel = Instantiate(inventoryPanelTemp.gameObject,inventoryPanelTemp.transform.parent);
        panelComponent = panel.GetComponent<InventoryPanel>();
        panelComponent.SetValue(addItem);
        panel.SetActive(true);
        InventoryPanelList.Add(panelComponent);
    }
    public void UpDownPanel()
    {
        if(isUptime)return;
        if(isUp)
        {
            isUp = false;
            itemPanel.DOAnchorPosY(itemPanel.anchoredPosition.y-upDownY,0.5f);
        }
        else
        {
            isUp = true;
            itemPanel.DOAnchorPosY(itemPanel.anchoredPosition.y+upDownY,0.5f);
        }
        isUptime = true;
        StartCoroutine(WaitTime());
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.5f);
        isUptime = false;
    }
}
