using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeManager : MonoBehaviour
{
    public Resources currentResourcesToSell;
    public Resources currentResourcesToBuy;

    private int sellID;
    private int buyID;

    public Sprite standardButton;
    public Sprite pressedButton;

    public List<Image> sellButtonList;
    public List<Image> buyButtonList;

    List<Resources> resourcesList;

    private void Start()
    {
        
    }

    public void SetResourcesListToTrader(List<Resources> resourcesList)
    {
        this.resourcesList = resourcesList;
    }
    
    public void SetResourcesToSell(int resID)
    {
        ResetButtons(sellButtonList);
        sellButtonList[resID].sprite = pressedButton;

        currentResourcesToSell = resourcesList[resID];
        sellID = resID;
    }
    public void SetResourcesToBuy(int resID)
    {
        ResetButtons(buyButtonList);
        buyButtonList[resID].sprite = pressedButton;

        currentResourcesToBuy = resourcesList[resID];
        buyID = resID;
    }
    private void ResetButtons(List<Image> buttonList)
    {
        foreach(Image butt in buttonList)
        {
            butt.sprite = standardButton;
        }
    }
    public void TradeResources(int resCount)
    {
        if (currentResourcesToSell != null && currentResourcesToBuy != null)
        {
            if (currentResourcesToSell.Count >= resCount)
            {
                currentResourcesToSell.Count -= resCount;
                currentResourcesToBuy.Count += resCount;
            }
        }
    }
    
}
