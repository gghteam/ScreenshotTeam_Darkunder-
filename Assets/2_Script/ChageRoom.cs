using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject onPanel,offPanel;
    public void OnClickChangePanel()
    {
        onPanel.SetActive(true);
        offPanel.SetActive(false);
    }
}
