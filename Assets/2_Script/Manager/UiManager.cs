using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform itemPanel;
    [SerializeField]
    private float upDownY = 0.5f;
    private bool isUp = true;
    private bool isUptime = false;
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
        yield return new WaitForSeconds(1.5f);
        isUptime = false;
    }
}
