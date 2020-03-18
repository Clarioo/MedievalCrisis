using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarStateUI : MonoBehaviour
{
    public Text enemyPopulationTxt;
    public Text kingdomPopulationTxt;
    public Text winChanceTxt;

    [SerializeField] Image warAllertPanel;

    [SerializeField] Image winWarPanel;
    [SerializeField] Text winSatisfactionTxt;

    [SerializeField] Image loseWarPanel;
    [SerializeField] Text loseSatisfactionTxt;

    public void ShowWarAllertPanel()
    {
        warAllertPanel.gameObject.SetActive(true);
    }
    public void CloseWarAllertPanel()
    {
        warAllertPanel.gameObject.SetActive(false);
    }
    public void ShowWinWarPanel(float satisfaction)
    {
        winWarPanel.gameObject.SetActive(true);
        winSatisfactionTxt.text = "Satisfaction: +" + satisfaction;

    }
    public void ShowLoseWarPanel(float satisfaction)
    {
        loseWarPanel.gameObject.SetActive(true);
        loseSatisfactionTxt.text = "Satisfaction: -" + satisfaction;
    }
}
